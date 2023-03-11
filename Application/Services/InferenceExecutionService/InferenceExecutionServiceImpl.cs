using System;
using deepdiver.Application.Services.InferenceExecutionService.Ports;
using deepdiver.Domain.Entities.Predictor;
using deepdiver.Application.Factories.PredictorFactory.Ports;
using deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Ports.CommandExecutor;
using deepdiver.Application.Services.InferenceExecutionService.Dtos.InferenceExecutionResponseDto;
using deepdiver.Application.Services.Models.GenericServiceResponsePayloadModel;
using deepdiver.Infrastructure.Adapters.FileWriterAdapter.Ports;

namespace deepdiver.Application.Services.InferenceExecutionService {
    public class InferenceExecutionServiceImpl : InferenceExecutionService, InferenceExecutor {
        private CommandExecutor CommandExecutor;
        private readonly SimplePredictorFactory predictorFactory;
        private readonly FileWriter fileWriter;


        public InferenceExecutionServiceImpl(CommandExecutor commandExecutor, FileWriter fileWriter, SimplePredictorFactory predictorFactory) {
            this.CommandExecutor = commandExecutor;
            this.fileWriter = fileWriter;
            this.predictorFactory = predictorFactory;
        }

        public InferenceExecutionResponseDto Infer(String predictorName, String predictorInput) {
            Predictor predictor = predictorFactory.Create(predictorName, predictorInput);

            // TODO - integrate this to application flow instead of inferenceInput.    
            var inferenceInputFile = fileWriter.Create((predictor.RootPath, $"{predictor.Name}Input", ""), predictorInput);

            String inferenceInput = $"'{predictor.InferenceInput}'";
            var commandExecutionResult = CommandExecutor.Execute(predictor.Executable, $"{predictor.ExecutionPath} {inferenceInput}");

            var response = new InferenceExecutionResponseDto {
                Data = new GenericServiceResponsePayloadModel<String> {}
            };

            response.Success = commandExecutionResult.Success;
            response.Reason = commandExecutionResult.Reason;
            response.Data.Value = commandExecutionResult.Data is not null ? commandExecutionResult.Data.Value : null;

            return response;
        }
    }
}