using deepdiver.Infrastructure.Adapters.FileWriterAdapter.Dtos;
using deepdiver.Infrastructure.Adapters.FileWriterAdapter.Ports;

namespace deepdiver.Infrastructure.Adapters.FileWriterAdapter {
    public class FileWriterAdapterImpl : FileWriter {
        public FileWriterResponseDto Create((String, String, String) fileData, String content) {
            var (path, name, extension) = fileData;
            var creationPath = Path.Combine(path, name, extension);
            var creationResult = CreateFileFromPath(creationPath, content);

            var response = new FileWriterResponseDto {
                Success = creationResult,
                Reason = creationResult ? null : "Inference input could not be forged.",
                Data = new Models.FileWriterResponsePayloadModel {
                    Path = creationPath,
                    Content = content
                }
            };

            return response;
        }

        private Boolean CreateFileFromPath(String path, String content) {
            try {
                FileStream fileStream = new FileStream(path, FileMode.Create);
                StreamWriter writer = new StreamWriter(fileStream);

                writer.Write(content);
                writer.Close();
                fileStream.Close();

                return File.Exists(path);
            } catch (Exception) {
                return false;
            }
        }
    }
}