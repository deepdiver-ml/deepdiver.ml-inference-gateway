using System.Diagnostics;
using deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Ports.CommandExecutor;
using deepdiver.Infrastructure.Adapters.Dtos.GenericAdapterDto;
using deepdiver.Infrastructure.Adapters.Models;

namespace deepdiver.Infrastructure.Adapters.CommandExecutionAdapter {
    public class CommandExecutionAdapterImpl : CommandExecutionAdapter, CommandExecutor {
        public GenericAdapterResponseDto<GenericAdapterResponsePayloadModel<String>> Execute(String executable, String arguments) {

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
                return new GenericAdapterResponseDto<GenericAdapterResponsePayloadModel<String>>() {
                    Success = false,
                    Data = new GenericAdapterResponsePayloadModel<String> {
                        Value = exception.Message
                    }
                };
            }

            return new GenericAdapterResponseDto<GenericAdapterResponsePayloadModel<String>>() {
                Data = new GenericAdapterResponsePayloadModel<String> {
                    Value = output
                }
            };
        }
    }
}