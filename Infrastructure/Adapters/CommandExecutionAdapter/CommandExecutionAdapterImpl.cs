using System.Diagnostics;
using deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Dtos.CommandExecutionResponseDto;
using deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Ports.CommandExecutor;
using deepdiver.Infrastructure.Adapters.Models;

namespace deepdiver.Infrastructure.Adapters.CommandExecutionAdapter {
    public class CommandExecutionAdapterImpl : CommandExecutionAdapter, CommandExecutor {
        public CommandExecutionResponseDto Execute(String executable, String arguments) {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = executable;
            startInfo.Arguments = arguments;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;

            String output = "";

            try {
                using (Process process = new Process()) {
                    process.StartInfo = startInfo;
                    process.Start();
                    output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                }
            } catch (Exception exception) {
                return new CommandExecutionResponseDto {
                    Success = false,
                    Data = new GenericAdapterResponsePayloadModel<String> {
                        Value = exception.Message
                    }
                };
            }

            return new CommandExecutionResponseDto {
                Data = new GenericAdapterResponsePayloadModel<String> {
                    Value = output
                }
            };
        }
    }
}