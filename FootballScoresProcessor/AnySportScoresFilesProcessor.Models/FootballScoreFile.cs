using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnySportScoresFilesProcessor.Models
{
    public class FootballScoreFile : IFootballScoreFile
    {
        Dictionary<string, FileColumn> allColumns;
        public Dictionary<string, FileColumn> AllColumns
        {
            get
            {
                if (allColumns == null)
                    allColumns = new Dictionary<string, FileColumn>();

                return allColumns;
            }
            set
            {
                allColumns = value;
            }
        }

        Dictionary<string, AnySportRule> allRules;
        public Dictionary<string, AnySportRule> AllRules
        {
            get
            {
                if (allRules == null)
                    allRules = new Dictionary<string, AnySportRule>();

                return allRules;
            }
            set
            {
                allRules = value;
            }
        }

        Dictionary<string, string[]> allRecords;
        public Dictionary<string, string[]> AllRecords
        {
            get
            {
                if (allRecords == null)
                    allRecords = new Dictionary<string, string[]>();

                return allRecords;
            }
            set
            {
                allRecords = value;
            }
        }

        List<SportRuleResult> allRulesResults;
        List<SportRuleResult> IAnySportScoreFile.AllRulesResults
        {
            get
            {
                if (allRulesResults == null)
                    allRulesResults = new List<SportRuleResult>();
                return allRulesResults;
            }
            set
            {
                allRulesResults = value;
            }
        }

        public string FileName
        {
            get;
            set;
        }

        public SportType SportType
        {
            get { return Models.SportType.Football; }
        }


        public ILogger Logger
        {
            get ;
            set ;
        }
    }
}