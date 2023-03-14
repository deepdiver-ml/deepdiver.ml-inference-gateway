using deepdiver.Application.Services.InferenceExecutionService.Ports;
using deepdiver.Domain.Entities;
using deepdiver.Application.Factories.PredictorFactory.Ports;
using deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Ports.CommandExecutor;
using deepdiver.Application.Services.InferenceExecutionService.Dtos;
using deepdiver.Application.Services.Models.GenericServiceResponsePayloadModel;
using deepdiver.Infrastructure.Adapters.FileWriterAdapter.Ports;
using deepdiver.Infrastructure.Adapters.FileReaderAdapter.Ports;
using deepdiver.Application.Factories.PredictorInputFileFactory.Ports;

namespace deepdiver.Application.Services.InferenceExecutionService {
    public class InferenceExecutionServiceImpl : InferenceExecutor {
        private CommandExecutor CommandExecutor;
        private readonly PredictorCreator PredictorCreator;
        PredictorInputFileCreator PredictorInputFileCreator;
        private readonly FileWriter FileWriter;
        private readonly FileReader FileReader;


        public InferenceExecutionServiceImpl(
            CommandExecutor commandExecutor,
            FileWriter fileWriter,
            PredictorCreator predictorCreator,
            PredictorInputFileCreator predictorInputFileCreator,
            FileReader fileReader
        ) {
            this.CommandExecutor = commandExecutor;
            this.FileWriter = fileWriter;
            this.PredictorCreator = predictorCreator;
            this.PredictorInputFileCreator = predictorInputFileCreator;
            this.FileReader = fileReader;
        }

        public InferenceExecutionResponseDto Infer(InferenceExecutionRequestDto predictorData) {
            Predictor predictor = PredictorCreator.Create(predictorData.PredictorId, predictorData.PredictorName, predictorData.PredictorInput);
            var predictionInput = predictorData.PredictorInput;
            var reason = "";

            if (predictorData.Physical) {
                var fileCreationResult = PredictorInputFileCreator.Create(predictor);
                reason = fileCreationResult.Reason;

                if (fileCreationResult.Success) {
                    predictor.InputFile = fileCreationResult.Data!.Value;

                    var readerResponse = FileReader.Read(predictor.InputFile!.Path);
                    reason = readerResponse.Reason;

                    predictionInput = readerResponse.Data!.Content;
                    PredictorInputFileCreator.Destroy(predictor.InputFile!);
                }
            }

            var response = new InferenceExecutionResponseDto {
                Data = new GenericServiceResponsePayloadModel<String> {}
            };

            if (predictionInput is not null) {
                var commandExecutionResult = CommandExecutor.Execute((predictor.Executable, predictor.ExecutionPath, predictionInput));

                response.Success = commandExecutionResult.Success;
                response.Reason = commandExecutionResult.Reason;
                response.Data.Value = commandExecutionResult.Data is not null ? commandExecutionResult.Data.Value : null;
            } else {
                response.Success = false;
                response.Reason = reason;
            }

            return response;
        }
    }
}