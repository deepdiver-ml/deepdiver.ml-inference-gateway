using deepdiver.Application.Factories.PredictorFactory.Ports;
using deepdiver.Domain.Entities;

namespace deepdiver.Application.Factories.PredictorFactory {
    public class PredictorFactoryImpl : Domain.Factories.PredictorFactory, PredictorCreator {
        private String InferenceRootPath;
        private String DescriptorExtension;
        private String InferenceExecutable;
        private String InferenceScriptExtension;

        public PredictorFactoryImpl (
            String inferenceRootPath,
            String DescriptorExtension,
            String inferenceExecutable,
            String inferenceScriptExtension
        ) {
            this.InferenceRootPath = inferenceRootPath;
            this.DescriptorExtension = DescriptorExtension;
            this.InferenceExecutable = inferenceExecutable;
            this.InferenceScriptExtension = inferenceScriptExtension;
        }
        public Predictor Create(
            String predictorId,
            String predictorName,
            String predictorInput
        ) {
            return new Predictor() {
                Id = predictorId,
                Name = predictorName,
                RootPath = Path.Combine(InferenceRootPath, predictorName),
                ExecutionPath = Path.Combine(InferenceRootPath, predictorName, String.Concat(predictorName, InferenceScriptExtension)),
                DescriptorPath =  Path.Combine(InferenceRootPath, predictorName, $"{predictorName}{DescriptorExtension}"),
                Executable = InferenceExecutable,
                InferenceInput = predictorInput
            };
        }
    }
}