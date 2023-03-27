using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnySportScoresFilesProcessor.Models
{
    public abstract class AnySportRule
    {
        public string Name { get; set; }
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public Operation Operation { get; set; }
        public IAnySportScoreFile SportScoreFile { get; set; }

        public virtual void ExecuteRule() { }
    }
}
