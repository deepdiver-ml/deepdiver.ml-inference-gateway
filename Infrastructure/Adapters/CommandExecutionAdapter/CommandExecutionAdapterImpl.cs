using System.Diagnostics;
using deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Ports.StringBasedCommandExecutor;
using deepdiver.Infrastructure.Shared.Models.AdapterModel.AdapterResponsePayloadModel;
using deepdiver.Infrastructure.Shared.Dtos.AdapterDto.Response.AdapterResponseDto;

namespace deepdiver.Infrastructure.Adapters.CommandExecutionAdapter {
    public class CommandExecutionAdapterImpl : CommandExecutionAdapter, StringBasedCommandExecutor {
        public AdapterResponseDto<AdapterResponsePayloadModel<String>> Execute(String executable, String arguments) {

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
                return new AdapterResponseDto<AdapterResponsePayloadModel<String>>() {
                    Success = false,
                    Data = new AdapterResponsePayloadModel<String> {
                        Value = exception.Message
                    }
                };
            }

            return new AdapterResponseDto<AdapterResponsePayloadModel<String>>() {
                Data = new AdapterResponsePayloadModel<String> {
                    Value = output
                }
            };
        }
    }
}