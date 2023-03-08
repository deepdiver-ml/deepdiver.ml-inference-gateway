namespace deepdiver.Application.Services.InferenceExecutionService.Dtos.InferenceExecutionDto {
    public class InferenceExecutionRequestDto {
        public String predictorName { get; set; } = String.Empty;
        public String predictorInput { get; set; } = String.Empty;
    }
}