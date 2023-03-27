using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace AnySportScoresFilesProcessor.Models
{
    [DataContract]
    public class FootballScoreRecord
    {
        [DataMember]
        public string Team { get; set; }
        [DataMember]
        public int Played { get; set; }
        [DataMember]
        public int Win { get; set; }
        [DataMember]
        public int Loss { get; set; }
        [DataMember]
        public int Draw { get; set; }
        [DataMember]
        public int For { get; set; }
        [DataMember]
        public int Against { get; set; }
        [DataMember]
        public int Points { get; set; }
    }
}