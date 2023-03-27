using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnySportScoresFilesProcessor
{
    public interface ILogger
    {
        void Log(string logMessage);
    }
}