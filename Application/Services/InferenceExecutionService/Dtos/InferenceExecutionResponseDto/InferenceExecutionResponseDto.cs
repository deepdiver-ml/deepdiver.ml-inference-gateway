using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deepdiver.Application.Services.Dtos.GenericServiceResponseDto;
using deepdiver.Application.Services.Models.GenericServiceResponsePayloadModel;

namespace deepdiver.Application.Services.InferenceExecutionService.Dtos.InferenceExecutionResponseDto
{
    public class InferenceExecutionResponseDto : GenericServiceResponseDto<GenericServiceResponsePayloadModel<String>> {}
}