using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnySportScoresFilesProcessor.Models
{
    public class AnySportScoresFileFactory
    {
        public static IAnySportScoreFile GetSportFile(SportType sport)
        {
            IAnySportScoreFile sportFile = null;

            switch (sport)
            {
                case SportType.Football:
                    sportFile = new FootballScoresFile();
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