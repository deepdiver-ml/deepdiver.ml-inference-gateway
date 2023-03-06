using System.Reflection;
using deepdiver.Application.Services.PredictorValidationService.Ports.PredictorNameValidator;
using deepdiver.Domain.Constants.PredictorNames;

namespace deepdiver.Application.Services.PredictorValidationService {
    public class PredictorValidationServiceImpl : PredictorValidationService, PredictorNameValidator {
        public Boolean ValidateName(string predictorName) {
            Type predictorNameTypes = typeof(PredictorNames);
            FieldInfo[] fields = predictorNameTypes.GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (FieldInfo field in fields) {
                if (field.GetValue(null)!.Equals(predictorName)) {
                    return true;
                }
            }

            return false;            
        }
    }
}