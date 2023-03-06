using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deepdiver.Infrastructure.Adapters.CommandExecutionAdapter.Ports.StringBasedCommandExecutor
{
    public interface StringBasedCommandExecutor
    {
         public String Execute(String executable, String arguments);   
    }
}