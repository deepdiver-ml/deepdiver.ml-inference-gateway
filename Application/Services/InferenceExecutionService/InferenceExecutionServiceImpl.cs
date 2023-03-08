using System;
using deepdiver.Application.Services.InferenceExecutionService.Ports;
using deepdiver.Domain.Entities.Predictor;
using deepdiver.Application.Factories.PredictorFactory.Ports;
using deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Ports.CommandExecutor;
using deepdiver.Application.Services.InferenceExecutionService.Dtos.InferenceExecutionDto;

namespace deepdiver.Application.Services.InferenceExecutionService {
    public class InferenceExecutionServiceImpl : InferenceExecutionService, InferenceExecutor {
        private CommandExecutor CommandExecutor;
        private readonly SimplePredictorFactory predictorFactory;


        public InferenceExecutionServiceImpl(CommandExecutor commandExecutor, SimplePredictorFactory predictorFactory) {
            this.CommandExecutor = commandExecutor;
            this.predictorFactory = predictorFactory;
        }

        public InferenceExecutionResponseDto Infer(InferenceExecutionRequestDto inferenceData) {
            Predictor predictor = predictorFactory.Create(inferenceData.predictorName, inferenceData.predictorName);
    
            String inferenceInput = $"'{predictor.InferenceInput}'";
            return new InferenceExecutionResponseDto {
                InferenceResult = CommandExecutor.Execute(predictor.Executable, $"{predictor.ExecutionPath} {inferenceInput}").Data!.Value!,
            };
        }
    }
}