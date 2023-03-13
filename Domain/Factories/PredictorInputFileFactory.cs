using deepdiver.Domain.Entities;
using deepdiver.Domain.ValueObjects;

namespace deepdiver.Domain.Factories
{
    public interface PredictorInputFileFactory<T> {
        public T Create(Predictor predictor);
        public Boolean Destroy(PredictorInputFile file);
    }
}