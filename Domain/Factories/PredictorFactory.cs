using deepdiver.Domain.Entities;

namespace deepdiver.Domain.Factories {
    public interface PredictorFactory {
        public Predictor Create(String predictorId, String predictorName, String predictorInput);
    }
}