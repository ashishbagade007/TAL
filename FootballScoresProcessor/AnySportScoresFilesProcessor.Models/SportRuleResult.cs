using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnySportScoresFilesProcessor.Models
{
    public class SportRuleResult
    {
        public string TeamName { get; set; }
        public Operation OperationType { get; set; }
        public int result { get; set; }
    }
}
