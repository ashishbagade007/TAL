using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace AnySportScoresFilesProcessor
{
    /// <summary>
    /// This is a singleton class
    /// </summary>
    public class Logger : ILogger 
    {
        static Logger logger;
        
        private Logger (){}

        public static Logger GetLogger()
        {
            if (logger != null)
            {
                return logger;
            }
            else
            {
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