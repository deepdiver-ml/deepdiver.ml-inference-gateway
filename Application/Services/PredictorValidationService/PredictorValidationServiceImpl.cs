using System.Reflection;
using deepdiver.Application.Services.PredictorValidationService.Ports;

namespace deepdiver.Application.Services.PredictorValidationService {
    public class PredictorValidationServiceImpl : PredictorValidationService, PredictorExistenceValidator, PredictorNameValidator {
        public Boolean ValidateName(List<String> predictorNames, String predictorName) {
            return predictorNames.Contains(predictorName);
        }
        public Boolean ValidateExistence(string predictorName) {
            return false;
        }
    }
}