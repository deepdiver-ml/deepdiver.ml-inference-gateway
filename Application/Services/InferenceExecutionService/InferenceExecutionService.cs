using deepdiver.Application.Services.InferenceExecutionService.Dtos.InferenceExecutionDto;

namespace deepdiver.Application.Services.InferenceExecutionService {
    public interface InferenceExecutionService {
        public InferenceExecutionResponseDto Infer(InferenceExecutionRequestDto inferenceData);
    }
}