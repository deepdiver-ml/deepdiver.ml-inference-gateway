using deepdiver.Application.Factories.PredictorFactory.Ports;
using deepdiver.Domain.Entities;

namespace deepdiver.Application.Factories.PredictorFactory {
    public class PredictorFactoryImpl : Domain.Factories.PredictorFactory, SimplePredictorFactory {
        private String InferenceRootPath;
        private String DescriptorFileName;
        private String InferenceExecutable;
        private String InferenceScriptExtension;

        public PredictorFactoryImpl (
            String inferenceRootPath,
            String descriptorFileName,
            String inferenceExecutable,
            String inferenceScriptExtension
        ) {
            this.InferenceRootPath = inferenceRootPath;
            this.DescriptorFileName = descriptorFileName;
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
                DescriptorPath =  Path.Combine(InferenceRootPath, predictorName, DescriptorFileName),
                Executable = InferenceExecutable,
                InferenceInput = predictorInput
            };
        }
    }
}