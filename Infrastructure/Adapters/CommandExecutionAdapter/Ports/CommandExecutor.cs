using deepdiver.Infrastructure.Adapters.Dtos.GenericAdapterDto;
using deepdiver.Infrastructure.Adapters.Models;

namespace deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Ports.CommandExecutor {
    public interface CommandExecutor {
        public GenericAdapterResponseDto<GenericAdapterResponsePayloadModel<String>> Execute(String executable, String arguments);
    }
}