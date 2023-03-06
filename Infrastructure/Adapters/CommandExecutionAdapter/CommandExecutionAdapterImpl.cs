using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Ports.StringBasedCommandExecutor;

namespace deepdiver.Infrastructure.Adapters.CommandExecutionAdapter
{
    public class CommandExecutionAdapterImpl : CommandExecutionAdapter, StringBasedCommandExecutor
    {
        public String Execute(String executable, String arguments) {
            return $"{executable} {arguments}";
        }
    }
}