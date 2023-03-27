using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnySportScoresFilesProcessor.Models
{
    public interface IAnySportScoreFile
    {
        string FileName { get; set; }
        string SportName { get; set; }
        ILogger Logger { get; set; }
    }
}