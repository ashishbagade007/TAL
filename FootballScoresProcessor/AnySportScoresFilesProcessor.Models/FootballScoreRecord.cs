using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace AnySportScoresFilesProcessor.Models
{
    public class FootballScoreRecord : IAnySportScoreRecord 
    {

        public string Team { get; set; }

        public int Played { get; set; }

        public int Win { get; set; }

        public int Loss { get; set; }

        public int Draw { get; set; }

        public int For { get; set; }

        public int Against { get; set; }

        public int Points { get; set; }
    }
}