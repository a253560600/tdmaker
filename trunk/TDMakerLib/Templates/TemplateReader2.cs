using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Globalization;

namespace TDMakerLib
{
    public class TemplateReader2
    {
        public TemplateReader2(string summary)
        {
            string[] lines = Regex.Split(summary, "\r\n");

            List<string> listSyntax = new List<string>();
            List<string> listValues = new List<string>();
            string prefix = string.Empty;
            foreach (string line in lines)
            {
                string[] temp = Regex.Split(line, " : ");
                if (temp.Length > 1)
                {
                    TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                    string syntax = myTI.ToTitleCase(temp[0].Trim()).Replace(" ", "").Replace(@"\", "").Replace("/", "").Replace("(", "").Replace(")", "").Replace("*", "");
                    string value = temp[1].Trim();
                    listSyntax.Add(string.Format("%{0}_{1}%", prefix, syntax));
                    listValues.Add(value);
                }
                else if (temp.Length == 1)
                {
                    prefix = temp[0].Trim();
                }
            }

            for (int i = 0; i < listSyntax.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(listSyntax[i] + " = " + listValues[i]);
            }

        }
    }
}
