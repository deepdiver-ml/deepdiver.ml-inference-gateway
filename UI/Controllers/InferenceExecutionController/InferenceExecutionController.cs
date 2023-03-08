using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using deepdiver.UI.Controllers.InferenceExecutionController.Dtos.InferenceExecutionDto;
using deepdiver.Application.Services.PredictorValidationService.Ports;
using deepdiver.Application.Services.InferenceExecutionService.Ports;
using InferenceService = deepdiver.Application.Services.InferenceExecutionService.Dtos.InferenceExecutionDto;

namespace deepdiver.UI.Controllers.InferenceExecutionController
{
    [Route("deepdiver/api/infer/{predictorName}")]
    public class InferenceExecutionController : Controller {
        private readonly PredictorNameValidator PredictorNameValidator;
        private readonly InferenceExecutor InferenceExecutor;

        public InferenceExecutionController(PredictorNameValidator predictorNameValidator, InferenceExecutor inferenceExecutor) {
            this.PredictorNameValidator = predictorNameValidator;
            this.InferenceExecutor = inferenceExecutor;
        }

        [HttpPost]
        public async Task<ActionResult<InferenceExecutionResponseDto>> getInferenceResponse([FromBody] InferenceExectutionRequestDto inferenceExecutionData, [FromRoute] String predictorName) {
            Boolean isPredictorNameValid = PredictorNameValidator.ValidateName(predictorName);

            if (isPredictorNameValid) {
                return Ok(new InferenceExecutionResponseDto {
                    Result = InferenceExecutor.Infer(new InferenceService.InferenceExecutionRequestDto {
                        predictorName = predictorName,
                        predictorInput = inferenceExecutionData.Input
                    }).InferenceResult,
                });
            }
            
            return BadRequest(new {
                message = "This resource does not exist."
            });
        }
    }
}