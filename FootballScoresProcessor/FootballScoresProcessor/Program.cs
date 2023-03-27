using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AnySportScoresFilesProcessor.BusinessLogic;
using AnySportScoresFilesProcessor.Models;

namespace FootballScoresProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DirectoryInfo sportScoreFilesDirectory;
            try
            {
                sportScoreFilesDirectory = new DirectoryInfo(System.IO.Path.Combine(System.IO.Path.GetFullPath(@"..\..\"), 
                    "SampleFootballScoresFile"));

                StringBuilder sb = new StringBuilder();
                const string tabSpace = "\t";



                foreach (FileInfo file in sportScoreFilesDirectory.GetFiles())
                {
                    AnySportScoresFileProcessor processor = new AnySportScoresFileProcessor(file.FullName);
                    processor.ProcessFile();
                    processor.ExecuteAllRules();

                    var allRulesResults = processor.CorrespondingSportScoreFile.AllRulesResults;
                    sb.Append(Environment.NewLine);
                    sb.Append("Least difference between goals scored for and against is for the following team(s) :");
                    sb.Append(Environment.NewLine);

                    var minVal = allRulesResults.Min(rr => rr.result);
                    var minValRecords = allRulesResults.Where(rr => rr.result == minVal);

                    foreach (var minValRecord in minValRecords)
                    {
                        sb.Append(String.Concat("TeamName : ", minValRecord.TeamName, tabSpace, "Goal Difference : ", minValRecord.result));
                    }
                }
                Console.WriteLine(sb.ToString());
            }
            catch (DirectoryNotFoundException exp)
            {
                string errorText = "Invalid Input : " + exp.Message;
                Console.WriteLine(errorText);
                LogMessage(errorText);
            }
            catch (Exception exp)
            {
                string errorText = "Some Error : " + exp.Message;
                Console.WriteLine(errorText);
                LogMessage(errorText);
            }
            finally
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Press Enter/Return key to abort.....");
                Console.ReadLine();
            }
        }

        private static void LogMessage(string messageText)
        {
            var logger = Logger.GetLogger();
            logger.Log(messageText);
        }

    }
}

