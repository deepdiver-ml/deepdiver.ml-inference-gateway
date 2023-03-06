using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deepdiver.Infrastructure.Adapters.CommandExecutionAdapter
{
    public interface CommandExecutionAdapter
    {
        public String Execute(String executable, String arguments);
    }
}