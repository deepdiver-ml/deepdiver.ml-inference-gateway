using deepdiver.Infrastructure.Adapters.FileWriterAdapter.Dtos;

namespace deepdiver.Infrastructure.Adapters.FileWriterAdapter {
    public interface FileWriterAdapter {
        public FileWriterResponseDto Create((String, String, String) fileData, String content);
    }
}