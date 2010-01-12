using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace TDMakerLib.Templates
{
    public class TemplateItem
    {
        public string OrginalName { get; set; }
        public string OrginalValue { get; set; }
        public string OrginalPrefix { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string NameWithPrefix { get; set; }
        public string NameForReplace { get; set; }

        private char replaceChar = '%';

        public TemplateItem(string name, string value, string prefix)
        {
            OrginalName = name;
            OrginalValue = value;
            OrginalPrefix = prefix;

            TextInfo ti = new CultureInfo("en-US", false).TextInfo;
            Name = ti.ToTitleCase(name.Trim());
            string tempName = string.Empty;
            foreach (char c in Name)
            {
                if (Char.IsLetterOrDigit(c))
                {
                    tempName += c;
                }
            }
            Name = tempName;
            Value = value.Trim();
            NameWithPrefix = string.Format("{0}_{1}", prefix, Name);
            NameForReplace = string.Format("{0}{1}{2}", replaceChar, NameWithPrefix, replaceChar);
        }

        public string ToString()
        {
            return string.Format("{0} = {1}", NameWithPrefix, Value);
        }
    }
}