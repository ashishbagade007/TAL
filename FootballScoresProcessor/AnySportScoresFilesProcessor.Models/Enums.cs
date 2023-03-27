using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace AnySportScoresFilesProcessor.Models
{
    public enum SportType
    {
        Football = 0,
        Cricket ,
        INVALID,
    }

    public enum Operation
    {
        Plus = 0,
        Difference,
        Minus,
        Multiply,
        Divide,
        OpenBracket,
        CloseBracket,
    }

    public enum FileColumnNameAttributes
    {
        Name = 0,
        Header,
        Type,
        Index,
    }

    public enum RuleAttributes
    {
        Name = 0,
        Column1,
        Column2,
        Operator,
    }
}