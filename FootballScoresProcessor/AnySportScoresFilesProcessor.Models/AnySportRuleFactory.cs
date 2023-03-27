using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnySportScoresFilesProcessor.Models
{
    public class AnySportRuleFactory
    {
        public static AnySportRule GetSportRule(IAnySportScoreFile sportScoreFile)
        {
            switch (sportScoreFile.SportType)
            {
                case SportType.Football :
                    return new FootballRule((IFootballScoreFile) sportScoreFile);
                case SportType.Cricket :
                    //implement AnySportRule other sport rule
                    return null;
                default :
                    //just implementing default. production code would take care of this
                    return null;
            }
        }
    }
}
