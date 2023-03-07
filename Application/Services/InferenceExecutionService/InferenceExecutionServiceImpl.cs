using System;
using deepdiver.Application.Services.InferenceExecutionService.Ports.StringBasedInferenceExecutor;
using deepdiver.Domain.Entities.Predictor;
using deepdiver.Application.Factories.PredictorFactory.Ports.SimplePredictorFactory;
using deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Ports.StringBasedCommandExecutor;

namespace deepdiver.Application.Services.InferenceExecutionService {
    public class InferenceExecutionServiceImpl : InferenceExecutionService, StringBasedInferenceExecutor {
        private StringBasedCommandExecutor CommandExecutor;
        private readonly SimplePredictorFactory predictorFactory;


        public InferenceExecutionServiceImpl(StringBasedCommandExecutor commandExecutor, SimplePredictorFactory predictorFactory) {
            this.CommandExecutor = commandExecutor;
            this.predictorFactory = predictorFactory;
        }

        public String Infer(String predictorName, String predictorInput) {
            Predictor predictor = predictorFactory.Create(predictorName, predictorInput);
    
            String inferenceInput = $"'{predictor.InferenceInput}'";
            return CommandExecutor.Execute(predictor.Executable, $"{predictor.ExecutionPath} {inferenceInput}").Data!.Value!;
        }
    }
}