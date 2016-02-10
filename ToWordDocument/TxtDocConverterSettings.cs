using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ToWordDocument
{
    public class TxtDocConverterSettings
    {
        public string AbiwordPath { get; set; }
        public string WorkDirectory { get; set; }
        public double FirstLineIndentation { get; set; }
        public double AfterParagraphIndentation { get; set; }
        public bool JustifyBothSides { get; set; }
        public bool IncludeSubfolders { get; set; }

    }


}
