using deepdiver.Application.Services.InferenceExecutionService.Dtos.InferenceExecutionResponseDto;

namespace deepdiver.Application.Services.InferenceExecutionService {
    public interface InferenceExecutionService {
        public InferenceExecutionResponseDto Infer(String predictorName, String predictorInput);
    }
}