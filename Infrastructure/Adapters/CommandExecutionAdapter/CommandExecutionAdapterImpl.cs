using System.Diagnostics;
using deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Dtos.CommandExecutionResponseDto;
using deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Ports.CommandExecutor;
using deepdiver.Infrastructure.Adapters.Models;

namespace deepdiver.Infrastructure.Adapters.CommandExecutionAdapter {
    public class CommandExecutionAdapterImpl : CommandExecutionAdapter, CommandExecutor {
        public CommandExecutionResponseDto Execute(String executable, String arguments) {
            var (success, reason, data) = ExecuteCommandInServerTerminal(executable, arguments);
            
            var response = new CommandExecutionResponseDto {
                Success = success,
                Reason = reason,
                Data = new GenericAdapterResponsePayloadModel<String> { Value = data }
            };

            return response;
        }
        private (Boolean, String?, String?) ExecuteCommandInServerTerminal(String fileName, String arguments) {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = fileName;
            startInfo.Arguments = arguments;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;

            String output = "";
            String? error = null;

            var response = new CommandExecutionResponseDto {
                Success = true,
            };

            try {
                using (Process process = new Process()) {
                    process.StartInfo = startInfo;
                    process.Start();
                    output = process.StandardOutput.ReadToEnd();
                    error = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                }

                return (
                    error is null,
                    error is not null ? error : null,
                    output
                );
            } catch (Exception exception) {
                return (
                    false,
                    exception.Message,
                    null
                );
            }
        }
    }
}