using System.Diagnostics;
using deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Dtos.CommandExecutionResponseDto;
using deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Ports.CommandExecutor;
using deepdiver.Infrastructure.Adapters.Models;

namespace deepdiver.Infrastructure.Adapters.CommandExecutionAdapter {
    public class CommandExecutionAdapterImpl : CommandExecutor {
        public CommandExecutionResponseDto Execute((String, String, String) executionData) {
            var (executablePath, executionPath, inputData) = executionData;

            var (success, reason, data) = ExecuteCommandInServerTerminal(executablePath, executionPath, inputData);
            
            var response = new CommandExecutionResponseDto {
                Success = success,
                Reason = reason,
                Data = new GenericAdapterResponsePayloadModel<String> { Value = data }
            };

            return response;
        }
        private (Boolean, String?, String?) ExecuteCommandInServerTerminal(String executablePath, String executionPath, String inputData) {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = executablePath;
            startInfo.Arguments = $@"""{executionPath}""";
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardInput = true;

            String output = "";
            String? error = null;

            var response = new CommandExecutionResponseDto {
                Success = true,
            };

            try {
                using (Process process = new Process()) {
                    process.StartInfo = startInfo;
                    process.Start();
                    process.StandardInput.Write(inputData);
                    process.StandardInput.Close();
                    output = process.StandardOutput.ReadToEnd();
                    error = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                }

                var success = String.IsNullOrEmpty(error);

                return (
                    success,
                    success ? null : error,
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