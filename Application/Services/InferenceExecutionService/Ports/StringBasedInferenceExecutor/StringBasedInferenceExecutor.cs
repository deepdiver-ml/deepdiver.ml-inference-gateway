namespace deepdiver.Application.Services.InferenceExecutionService.Ports.StringBasedInferenceExecutor {
    public interface StringBasedInferenceExecutor {
        public String Infer(String predictorName, String predictorInput);
    }
}