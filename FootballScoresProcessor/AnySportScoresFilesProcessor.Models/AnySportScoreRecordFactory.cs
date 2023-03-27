using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnySportScoresFilesProcessor.Models
{
    public class AnySportScoreRecordFactory
    {
        public static IAnySportScoreRecord GetSportRecord(SportType sport)
        {
            IAnySportScoreRecord sportFile = null;

            switch (sport)
            {
                case SportType.Football:
                    sportFile = new FootballScoreRecord();
                    break;
                case SportType.Cricket:
                    //Implement any future sport
                    break;
                default:
                    //implement any default
                    break;
            }

            return sportFile;
        }
    }
}
