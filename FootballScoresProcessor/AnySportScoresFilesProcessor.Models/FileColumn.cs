using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnySportScoresFilesProcessor.Models
{
    public class FileColumn
    {
        public string Name { get; set; }
        public string Header { get; set; }
        public string Type { get; set; }
        public int Index { get; set; }
    }
}
