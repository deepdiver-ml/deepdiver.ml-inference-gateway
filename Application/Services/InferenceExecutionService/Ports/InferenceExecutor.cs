using deepdiver.Application.Services.InferenceExecutionService.Dtos.InferenceExecutionDto;

namespace deepdiver.Application.Services.InferenceExecutionService.Ports {
    public interface InferenceExecutor {
        public InferenceExecutionResponseDto Infer(InferenceExecutionRequestDto inferenceData);
    }
}