namespace deepdiver.Application.Services.PredictorValidationService
{
    public interface PredictorValidationService {
        public Boolean ValidateExistence(String predictorName);
        public Boolean ValidateName(List<String> predictorNames, String predictorName);
    }
}