using deepdiver.Infrastructure.Adapters.FileWriterAdapter.Dtos;

namespace deepdiver.Infrastructure.Adapters.FileWriterAdapter.Ports {
    public interface FileWriter {
        public FileWriterResponseDto Create((String, String, String) fileData, String content);
    }
}