using deepdiver.Infrastructure.Adapters.FileDestroyerAdapter.Dtos;
using deepdiver.Infrastructure.Adapters.FileDestroyerAdapter.Ports;

namespace deepdiver.Infrastructure.Adapters.FileDestroyerAdapter
{
    public class FileDestroyerAdapterImpl : FileDestroyer {
        public FileDestroyerResponseDto Destroy(String path) {
            var response = new FileDestroyerResponseDto {
                Success = true,
            };
            
            try {
                File.Delete(path);
                return response;
            } catch (Exception deleteException) {
                response.Success = false;
                response.Reason = deleteException.Message;
                return response;
            }
        }   
    }
}