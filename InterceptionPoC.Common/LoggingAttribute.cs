using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceptionPoC.Common
{
    [AttributeUsage(AttributeTargets.Method)]
    public class LoggingAttribute : Attribute
    {
        public bool LogParameters { get; set; }
        public bool LogReturnValue { get; set; }
        public bool LogParametersAfterExecution { get; set; }

        public LoggingAttribute(bool logParameters = true, bool logReturnValue = true, bool logParametersAfterExecution = false)
        {
            LogParameters = logParameters;
            LogReturnValue = logReturnValue;
            LogParametersAfterExecution = logParametersAfterExecution;
        }
    }
}
