using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deepdiver.Application.Services.InferenceExecutionService.Ports.StringBasedInferenceExecutor;
using deepdiver.Domain.Entities.Predictor;
using deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Ports.StringBasedCommandExecutor;

namespace deepdiver.Application.Services.InferenceExecutionService
{
    public class InferenceExecutionServiceImpl : InferenceExecutionService, StringBasedInferenceExecutor
    {
        private StringBasedCommandExecutor CommandExecutor;

        public InferenceExecutionServiceImpl(StringBasedCommandExecutor commandExecutor) {
            this.CommandExecutor = commandExecutor;
        }

        public String Infer(Predictor predictor) {
            String inferenceInput = "\"" + predictor.InferenceInput + "\"";
            return CommandExecutor.Execute(String.Join(" ", new String[] { predictor.Invoker, predictor.ExecutionPath, inferenceInput }));
        }
    }
}