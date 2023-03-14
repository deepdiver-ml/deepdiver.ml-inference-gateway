using deepdiver.Application.Factories.PredictorInputFileFactory.Dtos;
using deepdiver.Domain.Entities;
using deepdiver.Domain.ValueObjects;

namespace deepdiver.Application.Factories.PredictorInputFileFactory.Ports {
    public interface PredictorInputFileCreator {
        public PredictorInputFileFactoryResponseDto Create(Predictor predictor);
        public Boolean Destroy(PredictorInputFile file);                
    }
}