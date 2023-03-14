using deepdiver.Application.Factories.PredictorFactory.Ports;
using deepdiver.Application.Services.DescriptionService.Dtos;
using deepdiver.Application.Services.DescriptionService.Ports;
using deepdiver.Application.Services.Models.GenericServiceResponsePayloadModel;
using deepdiver.Domain.Entities;
using deepdiver.Domain.Factories;
using deepdiver.Infrastructure.Adapters.FileReaderAdapter.Ports;

namespace deepdiver.Application.Services.DescriptionService {
    public class DescriptionServiceImpl : Descriptor {
        private readonly FileReader FileReader;
        private readonly PredictorCreator PredictorCreator;

        public DescriptionServiceImpl(FileReader fileReader, PredictorCreator predictorCreator) {
            this.FileReader = fileReader;
            this.PredictorCreator = predictorCreator;
        }

        public DescriptionResponseDto Describe(String predictorName) {
            var predictor = PredictorCreator.Create("", predictorName, "");
            var description = FileReader.Read(predictor.DescriptorPath);

            var response = new DescriptionResponseDto { Success = description.Success };
            
            if (description.Success) {
                response.Data = new GenericServiceResponsePayloadModel<String> {
                    Value = description.Data!.Content
                };
            }

            response.Reason = description.Reason;
            return response;
        }
    }
}