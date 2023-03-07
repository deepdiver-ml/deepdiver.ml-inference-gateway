namespace deepdiver.Application.Services.InferenceExecutionService {
    public interface InferenceExecutionService {
        public String Infer(String predictorName, String predictorInput);
    }
}