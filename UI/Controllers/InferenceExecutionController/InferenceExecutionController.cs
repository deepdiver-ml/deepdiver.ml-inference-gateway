using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using deepdiver.UI.Dtos.InferenceExectuionDto.Request.InferenceExecutionRequestDto;
using deepdiver.Application.Services.PredictorValidationService.Ports.PredictorNameValidator;
using deepdiver.Application.Factories.PredictorFactory.Ports.SimplePredictorFactory;
using deepdiver.Application.Factories.PredictorFactory;
using deepdiver.UI.Dtos.InferenceExectuionDto.Response.InferenceExecutionResponseDto;
using deepdiver.Application.Services.InferenceExecutionService.Ports.StringBasedInferenceExecutor;

namespace deepdiver.UI.Controllers.InferenceExecutionController
{
    [Route("deepdiver/api/infer/{predictorName}")]
    public class InferenceExecutionController : Controller {
        private readonly PredictorNameValidator PredictorNameValidator;
        private readonly SimplePredictorFactory predictorFactory;
        private readonly StringBasedInferenceExecutor InferenceExecutor;

        public InferenceExecutionController(PredictorNameValidator predictorNameValidator, StringBasedInferenceExecutor inferenceExecutor, SimplePredictorFactory predictorFactory) {
            this.PredictorNameValidator = predictorNameValidator;
            this.InferenceExecutor = inferenceExecutor;
            this.predictorFactory = predictorFactory;
        }

        [HttpPost]
        public async Task<ActionResult<InferenceExecutionResponseDto>> getInferenceResponse([FromBody] InferenceExectutionRequestDto inferenceExecutionData, [FromRoute] String predictorName) {
            Boolean isPredictorNameValid = PredictorNameValidator.ValidateName(predictorName);

            if (isPredictorNameValid) {
                return Ok(new InferenceExecutionResponseDto {
                    InferenceResponseData = InferenceExecutor.Infer(predictorFactory.Create(predictorName, inferenceExecutionData.InferenceInputData)),
                });
            }
            
            return BadRequest(new {
                message = "This resource does not exist."
            });
        }
    }
}