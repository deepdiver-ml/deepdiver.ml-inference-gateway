using deepdiver.Domain.Entities.Predictor;

namespace deepdiver.Application.Factories.PredictorFactory.Ports {
    public interface SimplePredictorFactory {
        public Predictor Create(String predictorName, String predictorInput);
    }
}