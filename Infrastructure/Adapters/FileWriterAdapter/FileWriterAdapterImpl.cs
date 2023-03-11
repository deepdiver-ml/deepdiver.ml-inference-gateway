using deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Dtos.CommandExecutionResponseDto;
using deepdiver.Infrastructure.Adapters.FileWriterAdapter.Dtos;
using deepdiver.Infrastructure.Adapters.FileWriterAdapter.Ports;
using deepdiver.Infrastructure.Adapters.Models;

namespace deepdiver.Infrastructure.Adapters.FileWriterAdapter {
    public class FileWriterAdapterImpl : FileWriterAdapter, FileWriter {
        public FileWriterResponseDto Create((String, String, String) fileData, String content) {
            var (path, name, extension) = fileData;
            var creationPath = Path.Combine(path, name, extension);
            var creationResult = CreateFileFromPath(creationPath, content);

            var response = new FileWriterResponseDto {
                Success = creationResult,
                Data = new GenericAdapterResponsePayloadModel<String> { Value = creationPath }
            };

            return response;
        }

        private Boolean CreateFileFromPath(String path, String content) {
            FileStream fileStream = new FileStream(path, FileMode.Create);
            StreamWriter writer = new StreamWriter(fileStream);

            writer.Write(content);
            writer.Close();
            fileStream.Close();

            return File.Exists(path);
        }
    }
}