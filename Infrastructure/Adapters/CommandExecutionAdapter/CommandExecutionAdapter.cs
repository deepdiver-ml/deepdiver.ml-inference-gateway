using deepdiver.Infrastructure.Adapters.Dtos.GenericAdapterDto;
using deepdiver.Infrastructure.Adapters.Models;

namespace deepdiver.Infrastructure.Adapters.CommandExecutionAdapter {
    public interface CommandExecutionAdapter {
        public GenericAdapterResponseDto<GenericAdapterResponsePayloadModel<String>> Execute(String executable, String arguments);
    }
}