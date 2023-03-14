using deepdiver.Domain.Entities;

namespace deepdiver.Application.Factories.PredictorFactory.Ports {
    public interface PredictorCreator {
        public Predictor Create(String predictorId, String predictorName, String predictorInput);
    }
}