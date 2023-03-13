using deepdiver.Application.Services.InferenceExecutionService.Dtos;

namespace deepdiver.Application.Services.InferenceExecutionService.Ports {
    public interface InferenceExecutor {
        public InferenceExecutionResponseDto Infer(InferenceExecutionRequestDto predictorData);
    }
}