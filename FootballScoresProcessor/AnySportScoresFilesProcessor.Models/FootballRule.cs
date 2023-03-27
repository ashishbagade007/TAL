using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnySportScoresFilesProcessor.Models
{
    public class FootballRule : AnySportRule
    {
        IFootballScoreFile footballScoreFile = null;
        public FootballRule(IFootballScoreFile scoreFile)
        {
            this.footballScoreFile = scoreFile;
        }

        public override void ExecuteRule()
        {
            int result = 0;
            string teamName = "";

            foreach (var record in this.footballScoreFile.AllRecords)
            {
                string[] fields = record.Value;
                SportRuleResult ruleResult = new SportRuleResult();

                var nameIndex = this.footballScoreFile.AllColumns.
                                       Where(c => c.Key == "Team").First().
                                       Value.Index;

                var col1Index = this.footballScoreFile.AllColumns.
                                       Where(c => c.Key == this.Column1).First().
                                       Value.Index;

                var col2Index = this.footballScoreFile.AllColumns.
                                       Where(c => c.Key == this.Column2).First().
                                       Value.Index;

                try
                {
                    var col1Value = Convert.ToInt32(fields[col1Index]);
                    var col2Value = Convert.ToInt32(fields[col2Index]);
                    teamName = Convert.ToString(fields[nameIndex]);

                    result = DoOperation(col1Value, col2Value);

                    ruleResult.OperationType = this.Operation;
                    ruleResult.result = result;
                    ruleResult.TeamName = teamName;

                    this.footballScoreFile.AllRulesResults.Add(ruleResult);
                }
                catch
                {
                    string tabSpace = "\t";
                    string errorText = string.Concat("Error Record", tabSpace,
                                                                                    "FileName :", footballScoreFile.FileName, tabSpace,
                                                                                    "ErrorString:", fields.First().ToString());
                    footballScoreFile.Logger.Log(errorText);
                }
            }            
        }

        private int DoOperation(int col1Value, int col2Value)
        {
            int result = 0;
            switch (this.Operation)
            {
                case Models.Operation.Difference:
                    result = Math.Abs(col1Value - col2Value);
                    break;
                case Models.Operation.Plus:
                    result = col1Value + col2Value;
                    break;
            }

            return result;
        }
    }
}
