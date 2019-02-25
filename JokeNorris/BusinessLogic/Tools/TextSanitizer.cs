using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace JokeNorris.BusinessLogic
{
    public class TextSanitizer
    {
        public IDictionary<string, string> EscapePairs { get; } = new Dictionary<string, string>()
        {
            {"&", "&amp;"},
            {"<", "&lt;"},
            {">", "&gt;"},
            {"\"", "&quot;"},
            {"\'", "&#x27;"}
        };

        public TextSanitizer(string InputText)
        {
            Sanitize(InputText);
        }

        public string Sanitize(string Text)
        {
            foreach (var pair in EscapePairs)
            {
                Text = Text.Replace(pair.Key, pair.Value);
            }

            return Text;
        }
    }
}