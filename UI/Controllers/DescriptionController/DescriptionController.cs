using deepdiver.Application.Services.DescriptionService.Ports;
using deepdiver.Application.Services.PredictorValidationService.Ports;
using deepdiver.Domain.Enums;
using deepdiver.Lib;
using deepdiver.UI.Controllers.DescriptionController.Dtos;
using deepdiver.UI.Controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace deepdiver.UI.Controllers.DescriptionController {
    [Route("deepdiver/api/describe/{predictorName}")]
    public class DescriptionController : Controller {
        private readonly PredictorNameValidator PredictorNameValidator;
        private readonly Descriptor Descriptor;

        public DescriptionController(PredictorNameValidator predictorNameValidator, Descriptor descriptor) {
            this.PredictorNameValidator = predictorNameValidator;
            this.Descriptor = descriptor;
        }

        [HttpGet]
        public async Task<ActionResult<DescriptionResponseDto>> DescribePredictor([FromRoute] String predictorName) {
            var isPredictorNameValid = PredictorNameValidator.ValidateName(EnumLib.GetKeys<Predictors>(), predictorName);

            if (isPredictorNameValid) {
                var description = this.Descriptor.Describe(predictorName);

                var response = new DescriptionResponseDto {
                    Success = description.Success,
                    Data = new GenericControllerResponsePayloadModel<String> { Value = description.Success ? description.Data!.Value : description.Reason }
                };

                return response.Success ? Ok(response) : StatusCode(500, response);
            }

            return BadRequest(new DescriptionResponseDto {
                Success = false,
                Data = new GenericControllerResponsePayloadModel<String> { Value = "This resource does not exist." }
            });
        }
    }
}