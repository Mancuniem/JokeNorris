using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace JokeNorris.BusinessLogic
{
    /// <summary>
    /// A tool to escape a select list of characters from a given input string.
    /// This would make a nice extension method to String.
    /// </summary>
    public static class TextSanitizer
    {
        //Characters to check for, and their replacements
        public static IDictionary<string, string> EscapePairs { get; } = new Dictionary<string, string>()
        {
            {"&", "&amp;"},
            {"<", "&lt;"},
            {">", "&gt;"},
            {"\"", "&quot;"},
            {"\'", "&#x27;"}
        };

        public static string Sanitize(string Text)
        {
            // Cycle through the special characters, testing each for their presence in the text with each iteration
            // Replace any found with their appropriate escape character.
            // Ampersand must be first, else the whole thing would break!
            foreach (var pair in EscapePairs)
            {
                Text = Text.Replace(pair.Key, pair.Value);
            }

            return HttpUtility.HtmlEncode(Text);
        }
    }
}