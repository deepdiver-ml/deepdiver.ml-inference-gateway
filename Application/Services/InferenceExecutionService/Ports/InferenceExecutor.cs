using deepdiver.Application.Services.InferenceExecutionService.Dtos.InferenceExecutionResponseDto;

namespace deepdiver.Application.Services.InferenceExecutionService.Ports {
    public interface InferenceExecutor {
        public InferenceExecutionResponseDto Infer(String predictorName, String predictorInput);
    }
}