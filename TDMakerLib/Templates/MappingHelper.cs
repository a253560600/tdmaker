using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Globalization;
using TDMakerLib.Templates;
using System.Diagnostics;
using System.IO;

namespace TDMakerLib
{
    public class MappingHelper
    {
        Dictionary<string, string> Mappings { get; set; }

        public MappingHelper(string summary)
        {
            Mappings = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(summary))
            {
                string prefix = string.Empty;
                string[] lines = summary.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    string[] temp = line.Split(new[] { " : " }, StringSplitOptions.None);

                    if (temp.Length == 2 && !string.IsNullOrEmpty(prefix))
                    {
                        MIFieldValue mifv = new MIFieldValue(temp[0], temp[1], prefix);
                        this.Mappings.Add(mifv.Field, mifv.Value);
                    }
                    else if (temp.Length == 1)
                    {
                        prefix = temp[0].Trim();
                    }
                    else
                    {
                        Debug.WriteLine(string.Format("Error TemplateReader2.cs: {0}, {1}", line, prefix));
                    }
                }

                foreach (var pair in this.Mappings)
                {
                    Console.WriteLine("{0} - {1}",
                        pair.Key,
                        pair.Value);
                }
            }
        }
    }
}