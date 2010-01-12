using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Globalization;
using TDMakerLib.Templates;

namespace TDMakerLib
{
    public class TemplateReader2
    {
        List<TemplateItem> Items { get; set; }

        public TemplateReader2(string summary)
        {
            if (!string.IsNullOrEmpty(summary))
            {
                Items = new List<TemplateItem>();
                string prefix = string.Empty;
                string[] lines = summary.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    string[] temp = line.Split(new[] { " : " }, StringSplitOptions.None);

                    if (temp.Length == 2 && !string.IsNullOrEmpty(prefix))
                    {
                        Items.Add(new TemplateItem(temp[0], temp[1], prefix));
                    }
                    else if (temp.Length == 1)
                    {
                        prefix = temp[0].Trim();
                    }
                    else
                    {
                        Console.WriteLine(string.Format("Error TemplateReader2.cs: {0}, {1}", line, prefix));
                    }
                }
            }
        }
    }
}