namespace deepdiver.Application.Services.PredictorValidationService.Ports {
    public interface PredictorExistenceValidator {
        public Boolean ValidateExistence(String predictorName);
    }
}