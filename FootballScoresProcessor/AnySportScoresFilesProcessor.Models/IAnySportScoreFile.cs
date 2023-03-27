using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnySportScoresFilesProcessor.Models
{
    public interface IAnySportScoreFile
    {
        string FileName { get; set; }
        SportType SportType { get; }
        Dictionary<string, string[]> AllRecords { get; set; }
        Dictionary<string, FileColumn> AllColumns { get; set; }
        Dictionary<string, AnySportRule> AllRules { get; set; }
        List<SportRuleResult> AllRulesResults { get; set; }
        ILogger Logger { get; set; }
    }
}