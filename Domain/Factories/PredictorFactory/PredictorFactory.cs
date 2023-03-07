using deepdiver.Domain.Entities.Predictor;

namespace deepdiver.Domain.Factories.PredictorFactory {
    public interface PredictorFactory {
        public Predictor Create(String predictorName, String predictorInput);
    }
}