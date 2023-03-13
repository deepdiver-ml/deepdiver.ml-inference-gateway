using deepdiver.Domain.Entities;
using deepdiver.Infrastructure.Adapters.FileDestroyerAdapter.Ports;
using deepdiver.Application.Factories.PredictorInputFileFactory.Ports;
using deepdiver.Infrastructure.Adapters.FileWriterAdapter.Ports;
using deepdiver.Domain.ValueObjects;

namespace deepdiver.Application.Factories.PredictorInputFileFactory {
    public class PredictorInputFileFactoryImpl : Domain.Factories.PredictorInputFileFactory, SimplePredictorInputFileFactory {
        private readonly FileDestroyer FileDestroyer;
        private readonly FileWriter FileWriter;

        public PredictorInputFileFactoryImpl(FileDestroyer fileDestroyer, FileWriter fileWriter) {
            this.FileDestroyer = fileDestroyer;
            this.FileWriter = fileWriter;
        }
        public PredictorInputFile? Create(Predictor predictor) {
            var fileCreationData = FileWriter.Create((predictor.RootPath, $"{predictor.Name}Input_{predictor.Id}", ""), predictor.InferenceInput);

            if (fileCreationData.Success) {
                return new PredictorInputFile {
                    Path = fileCreationData.Data!.Path!,
                };
            }

            return null;
        }

        public Boolean Destroy(PredictorInputFile file) {
            return FileDestroyer.Destroy(file.Path).Success;
        }
    }
}