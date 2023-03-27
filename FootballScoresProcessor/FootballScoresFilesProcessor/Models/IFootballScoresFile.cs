using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AnySportScoresFilesProcessor.Models
{     
    public interface IFootballScoresFile : IAnySportScoreFile
    {
        List<FootballScoreRecord> GetAllRecords();
        FootballScoreRecord LeastDifferenceRecord();
    }
}