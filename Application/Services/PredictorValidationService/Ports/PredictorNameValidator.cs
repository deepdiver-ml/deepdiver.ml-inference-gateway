namespace deepdiver.Application.Services.PredictorValidationService.Ports {
    public interface PredictorNameValidator {
        public Boolean ValidateName(List<String> predictorNames, String predictorName);
    }
}