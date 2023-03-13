using deepdiver.Infrastructure.Adapters.FileReaderAdapter.Dtos;
using deepdiver.Infrastructure.Adapters.FileReaderAdapter.Models;
using deepdiver.Infrastructure.Adapters.FileReaderAdapter.Ports;

namespace deepdiver.Infrastructure.Adapters.FileReaderAdapter {
    public class FileReaderAdapterImpl : FileReader {
        public FileReaderResponseDto Read(String filePath) {
            var response = new FileReaderResponseDto {
                Data = new FileReaderResponsePayloadModel {}
            };

            try {
                var fileContent = File.ReadAllText(filePath);

                response.Success = true;
                response.Data.Content = fileContent;
                response.Data.Path = filePath;

                return response;
            } catch (Exception readingException) {
                response.Success = false;
                response.Reason = readingException.Message;

                return response;
            }
        }
    }
}