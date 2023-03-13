using deepdiver.Domain.Entities;
using deepdiver.Domain.ValueObjects;

namespace deepdiver.Application.Factories.PredictorInputFileFactory.Ports {
    public interface SimplePredictorInputFileFactory {
        public PredictorInputFile? Create(Predictor predictor);
        public Boolean Destroy(PredictorInputFile file);                
    }
}