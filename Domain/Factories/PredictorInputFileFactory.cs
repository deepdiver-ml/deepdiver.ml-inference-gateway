using deepdiver.Domain.Entities;
using deepdiver.Domain.ValueObjects;

namespace deepdiver.Domain.Factories
{
    public interface PredictorInputFileFactory {
        public PredictorInputFile? Create(Predictor predictor);
        public Boolean Destroy(PredictorInputFile file);
    }
}