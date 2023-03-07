using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using deepdiver.UI.Controllers.InferenceExecutionController.Dtos.InferenceExectuionDto.Request.InferenceExecutionRequestDto;
using deepdiver.Application.Services.PredictorValidationService.Ports.PredictorNameValidator;
using deepdiver.UI.Controllers.InferenceExecutionController.Dtos.InferenceExectuionDto.Response.InferenceExecutionResponseDto;
using deepdiver.Application.Services.InferenceExecutionService.Ports.StringBasedInferenceExecutor;

namespace deepdiver.UI.Controllers.InferenceExecutionController
{
    [Route("deepdiver/api/infer/{predictorName}")]
    public class InferenceExecutionController : Controller {
        private readonly PredictorNameValidator PredictorNameValidator;
        private readonly StringBasedInferenceExecutor InferenceExecutor;

        public InferenceExecutionController(PredictorNameValidator predictorNameValidator, StringBasedInferenceExecutor inferenceExecutor) {
            this.PredictorNameValidator = predictorNameValidator;
            this.InferenceExecutor = inferenceExecutor;
        }

        [HttpPost]
        public async Task<ActionResult<InferenceExecutionResponseDto>> getInferenceResponse([FromBody] InferenceExectutionRequestDto inferenceExecutionData, [FromRoute] String predictorName) {
            Boolean isPredictorNameValid = PredictorNameValidator.ValidateName(predictorName);

            if (isPredictorNameValid) {
                return Ok(new InferenceExecutionResponseDto {
                    InferenceResponseData = InferenceExecutor.Infer(predictorName, inferenceExecutionData.InferenceInputData),
                });
            }
            
            return BadRequest(new {
                message = "This resource does not exist."
            });
        }
    }
}