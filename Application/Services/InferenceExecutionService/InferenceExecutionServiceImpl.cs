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
        private readonly SimplePredictorFactory predictorFactory;
        SimplePredictorInputFileFactory PredictorInputFileFactory;
        private readonly FileWriter FileWriter;
        private readonly FileReader FileReader;


        public InferenceExecutionServiceImpl(
            CommandExecutor commandExecutor,
            FileWriter fileWriter,
            SimplePredictorFactory predictorFactory,
            SimplePredictorInputFileFactory predictorInputFileFactory,
            FileReader fileReader
        ) {
            this.CommandExecutor = commandExecutor;
            this.FileWriter = fileWriter;
            this.predictorFactory = predictorFactory;
            this.PredictorInputFileFactory = predictorInputFileFactory;
            this.FileReader = fileReader;
        }

        public InferenceExecutionResponseDto Infer(InferenceExecutionRequestDto predictorData) {
            Predictor predictor = predictorFactory.Create(predictorData.PredictorId, predictorData.PredictorName, predictorData.PredictorInput);
            var predictionInput = predictorData.PredictorInput;
            var reason = "";

            if (predictorData.Physical) {
                var fileCreationResult = PredictorInputFileFactory.Create(predictor);
                reason = fileCreationResult.Reason;

                if (fileCreationResult.Success) {
                    predictor.InputFile = fileCreationResult.Data!.Value;

                    var readerResponse = FileReader.Read(predictor.InputFile!.Path);
                    reason = readerResponse.Reason;

                    predictionInput = readerResponse.Data!.Content;
                    PredictorInputFileFactory.Destroy(predictor.InputFile!);
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