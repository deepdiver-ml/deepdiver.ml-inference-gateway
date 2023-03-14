using deepdiver.Application.Services.Dtos.GenericServiceResponseDto;
using deepdiver.Application.Services.Models.GenericServiceResponsePayloadModel;

namespace deepdiver.Application.Services.InferenceExecutionService.Dtos {
    public class InferenceExecutionResponseDto : GenericServiceResponseDto<GenericServiceResponsePayloadModel<String>> {}
}