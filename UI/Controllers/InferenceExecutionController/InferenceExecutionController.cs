using Microsoft.AspNetCore.Mvc;
using deepdiver.UI.Controllers.InferenceExecutionController.Dtos.InferenceExecutionDto;
using deepdiver.Application.Services.InferenceExecutionService.Ports;
using deepdiver.Domain.Enums;
using deepdiver.Application.Services.PredictorValidationService.Ports;
using deepdiver.Lib;

namespace deepdiver.UI.Controllers.InferenceExecutionController {
    [Route("deepdiver/api/infer/{predictorName}")]
    public class InferenceExecutionController : Controller {
        private readonly InferenceExecutor InferenceExecutor;
        private readonly PredictorNameValidator PredictorNameValidator;

        public InferenceExecutionController(InferenceExecutor inferenceExecutor, PredictorNameValidator predictorNameValidator) {
            this.PredictorNameValidator = predictorNameValidator;
            this.InferenceExecutor = inferenceExecutor;
        }

        [HttpPost]
        public async Task<ActionResult<InferenceExecutionResponseDto>> getInferenceResponse([FromBody] InferenceExectutionRequestDto inferenceExecutionData, [FromRoute] String predictorName) {
            var isPredictorNameValid = PredictorNameValidator.ValidateName(EnumLib.GetKeys<Predictors>(), predictorName);

            if (isPredictorNameValid) {
                var inferenceResult = InferenceExecutor.Infer(predictorName, inferenceExecutionData.Input);

                var response = new InferenceExecutionResponseDto {
                    Success = inferenceResult.Success,
                    Result = inferenceResult.Success ? inferenceResult.Data!.Value : inferenceResult.Reason,
                };

                return response.Success ? Ok(response) : StatusCode(500, response);
            }
            
            return BadRequest(new InferenceExecutionResponseDto {
                Success = false,
                Result = "This resource does not exist."
            });
        }
    }
}