using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace TDMakerLib.Templates
{
    public class MIFieldValue
    {
        private string OrginalName { get; set; }
        public string Value { get; set; }
        private string OrginalPrefix { get; set; }
        private string Name { get; set; }
        private string OriginalField { get; set; }
        private string NameWithPrefix { get; set; }
        public string Field { get; set; }

        private char replaceChar = '%';

        public MIFieldValue(string name, string value, string prefix)
        {
            OrginalName = name.Trim();
            Value = value;
            OrginalPrefix = prefix;
            TextInfo ti = new CultureInfo("en-US", false).TextInfo;
            string tempName = string.Empty;

            foreach (char c in name)
            {
                if (Char.IsLetterOrDigit(c))
                {
                    tempName += c;
                }
                else if (c == '(' || c == ')')
                {
                    continue;
                }
                else
                {
                    tempName += " ";
                }
            }
            Name = ti.ToTitleCase(tempName.Trim()).Replace(" ", "");
            OriginalField = tempName;
            NameWithPrefix = string.Format("{0}_{1}", prefix, Name);
            Field = string.Format("{0}{1}{2}", replaceChar, NameWithPrefix, replaceChar);
        }

        public override string ToString()
        {
            return string.Format("{0} = {1}", Field, OriginalField);
        }
    }
}