using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace AnySportScoresFilesProcessor.BusinessLogic
{
    /// <summary>
    /// This is a singleton class
    /// </summary>
    public class Logger : ILogger 
    {
        private static Logger logger = null;
        private static readonly object lockObject = new object();
        
        private Logger (){}

        public static Logger GetLogger()
        {
            lock (lockObject)
            {
                if (logger == null)
                    logger = new Logger();
                
                return logger;
            }
        }

        public void Log(string logMessage)
        {            
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", logMessage);
                w.WriteLine("-------------------------------");
            }
        }
    }
}