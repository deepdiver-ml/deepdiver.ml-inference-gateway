using deepdiver.Domain.Entities;
using deepdiver.Infrastructure.Adapters.FileDestroyerAdapter.Ports;
using deepdiver.Application.Factories.PredictorInputFileFactory.Ports;
using deepdiver.Infrastructure.Adapters.FileWriterAdapter.Ports;
using deepdiver.Domain.ValueObjects;
using deepdiver.Application.Factories.PredictorInputFileFactory.Dtos;

namespace deepdiver.Application.Factories.PredictorInputFileFactory {
    public class PredictorInputFileFactoryImpl : Domain.Factories.PredictorInputFileFactory<PredictorInputFileFactoryResponseDto>, SimplePredictorInputFileFactory {
        private readonly FileDestroyer FileDestroyer;
        private readonly FileWriter FileWriter;

        public PredictorInputFileFactoryImpl(FileDestroyer fileDestroyer, FileWriter fileWriter) {
            this.FileDestroyer = fileDestroyer;
            this.FileWriter = fileWriter;
        }
        public PredictorInputFileFactoryResponseDto Create(Predictor predictor) {
            var fileCreationData = FileWriter.Create((predictor.RootPath, $"{predictor.Name}Input_{predictor.Id}", ""), predictor.InferenceInput);
            var response = new PredictorInputFileFactoryResponseDto { };

            if (fileCreationData.Success) {
                response.Data = new Models.GenericFactoryResponsePayloadModel<PredictorInputFile> {
                    Value = new PredictorInputFile {
                        Path = fileCreationData.Data!.Path!,
                    }
                };
            } 

            response.Success = fileCreationData.Success;
            response.Reason = fileCreationData.Reason;
            return response;
        }

        public Boolean Destroy(PredictorInputFile file) {
            return FileDestroyer.Destroy(file.Path).Success;
        }
    }
}