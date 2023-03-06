using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deepdiver.Application.Factories.PredictorFactory.Ports.SimplePredictorFactory;
using deepdiver.Domain.Entities.Predictor;

namespace deepdiver.Application.Factories.PredictorFactory
{
    public class PredictorFactoryImpl : Domain.Factories.PredictorFactory.PredictorFactory, SimplePredictorFactory
    {
        private String InferenceRootPath;
        private String DescriptorFileName;
        private String InferenceExecutable;
        private String InferenceScriptExtension;

        public PredictorFactoryImpl(
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
            String predictorName,
            String predictorInput
        ) {
            return new Predictor() {
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