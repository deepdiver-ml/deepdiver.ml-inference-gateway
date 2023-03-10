using deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Dtos.CommandExecutionResponseDto;

namespace deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Ports.CommandExecutor {
    public interface CommandExecutor {
        public CommandExecutionResponseDto Execute(String executable, String arguments);
    }
}