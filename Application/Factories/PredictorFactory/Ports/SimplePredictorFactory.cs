using deepdiver.Domain.Entities;

namespace deepdiver.Application.Factories.PredictorFactory.Ports {
    public interface SimplePredictorFactory {
        public Predictor Create(String predictorId, String predictorName, String predictorInput);
    }
}