using System;
using deepdiver.Application.Services.InferenceExecutionService.Ports;
using deepdiver.Domain.Entities.Predictor;
using deepdiver.Application.Factories.PredictorFactory.Ports;
using deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Ports.CommandExecutor;
using deepdiver.Application.Services.InferenceExecutionService.Dtos.InferenceExecutionResponseDto;
using deepdiver.Application.Services.Models.GenericServiceResponsePayloadModel;

namespace deepdiver.Application.Services.InferenceExecutionService {
    public class InferenceExecutionServiceImpl : InferenceExecutionService, InferenceExecutor {
        private CommandExecutor CommandExecutor;
        private readonly SimplePredictorFactory predictorFactory;


        public InferenceExecutionServiceImpl(CommandExecutor commandExecutor, SimplePredictorFactory predictorFactory) {
            this.CommandExecutor = commandExecutor;
            this.predictorFactory = predictorFactory;
        }

        public InferenceExecutionResponseDto Infer(String predictorName, String predictorInput) {
            Predictor predictor = predictorFactory.Create(predictorName, predictorInput);
    
            String inferenceInput = $"'{predictor.InferenceInput}'";
            return new InferenceExecutionResponseDto {
                Data = new GenericServiceResponsePayloadModel<String> {
                    Value = CommandExecutor.Execute(predictor.Executable, $"{predictor.ExecutionPath} {inferenceInput}").Data!.Value!,
                }
            };
        }
    }
}