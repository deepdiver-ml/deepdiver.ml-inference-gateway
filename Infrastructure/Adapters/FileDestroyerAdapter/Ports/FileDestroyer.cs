using deepdiver.Infrastructure.Adapters.FileDestroyerAdapter.Dtos;

namespace deepdiver.Infrastructure.Adapters.FileDestroyerAdapter.Ports {
    public interface FileDestroyer {
        public FileDestroyerResponseDto Destroy(String path);
    }
}