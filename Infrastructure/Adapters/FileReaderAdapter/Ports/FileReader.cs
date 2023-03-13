using deepdiver.Infrastructure.Adapters.FileReaderAdapter.Dtos;

namespace deepdiver.Infrastructure.Adapters.FileReaderAdapter.Ports {
    public interface FileReader {
        public FileReaderResponseDto Read(String filePath);
    }
}