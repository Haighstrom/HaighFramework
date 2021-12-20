using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaighFramework
{
    public class HException : Exception
    {
        /// <summary>
        /// Disable to stop exceptions being written to the Console and potentially the log file
        /// </summary>
        public static bool LogExceptions { get; set; } = true;

        public HException(string exceptionMessage, params object[] args)
            : base(string.Format(exceptionMessage, args))
        {
            HConsole.Log("A HException was thrown.");
            HConsole.Log(exceptionMessage, args);
        }
    }
}