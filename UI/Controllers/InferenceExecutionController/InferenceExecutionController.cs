using Microsoft.AspNetCore.Mvc;
using deepdiver.UI.Controllers.InferenceExecutionController.Dtos;
using deepdiver.Application.Services.InferenceExecutionService.Ports;
using deepdiver.Domain.Enums;
using deepdiver.Application.Services.PredictorValidationService.Ports;
using deepdiver.Lib;
using deepdiver.UI.Controllers.Lib;
using InferenceData = deepdiver.Application.Services.InferenceExecutionService.Dtos;
using deepdiver.UI.Controllers.Models;

namespace deepdiver.UI.Controllers.InferenceExecutionController {
    [Route("deepdiver/api/infer/{predictorName}")]
    public class InferenceExecutionController : Controller {
        private readonly InferenceExecutor InferenceExecutor;
        private readonly PredictorNameValidator PredictorNameValidator;
        public String? SessionId;

        public InferenceExecutionController(InferenceExecutor inferenceExecutor, PredictorNameValidator predictorNameValidator) {
            this.PredictorNameValidator = predictorNameValidator;
            this.InferenceExecutor = inferenceExecutor;
        }

        [UniqueSession]
        [HttpPost]
        public async Task<ActionResult<InferenceExecutionResponseDto>> GetInferenceResponse([FromBody] InferenceExectutionRequestDto inferenceExecutionData, [FromRoute] String predictorName) {
            var isPredictorNameValid = PredictorNameValidator.ValidateName(EnumLib.GetKeys<Predictors>(), predictorName);

            if (isPredictorNameValid) {
                var inferenceResult = InferenceExecutor.Infer(
                    new InferenceData.InferenceExecutionRequestDto {
                        PredictorId = SessionId!,
                        PredictorName = predictorName,
                        PredictorInput = inferenceExecutionData.Input,
                        Physical = true
                    }
                );

                var response = new InferenceExecutionResponseDto {
                    Success = inferenceResult.Success,
                    Data = new GenericControllerResponsePayloadModel<String> { Value = inferenceResult.Success ? inferenceResult.Data!.Value : inferenceResult.Reason, }
                };

                return response.Success ? Ok(response) : StatusCode(500, response);
            }
            
            return BadRequest(new InferenceExecutionResponseDto {
                Success = false,
                Data = new GenericControllerResponsePayloadModel<String> { Value = "This resource does not exist." }
            });
        }
    }
}