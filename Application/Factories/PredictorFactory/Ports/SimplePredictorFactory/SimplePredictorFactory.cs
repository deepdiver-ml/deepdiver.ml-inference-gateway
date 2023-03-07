using deepdiver.Domain.Entities.Predictor;

namespace deepdiver.Application.Factories.PredictorFactory.Ports.SimplePredictorFactory {
    public interface SimplePredictorFactory {
        public Predictor Create(String predictorName, String predictorInput);
    }
}