using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MvvmToolkitSample.Core.Helpers
{
    public static class MarkdownHelper
    {
        public static IReadOnlyDictionary<string, string> GetParagraphs(string text)
        {
            return
                Regex.Matches(text, @"(?<=\W)#+ ([^\n]+).+?(?=\W#|$)", RegexOptions.Singleline)
                .OfType<Match>()
                .ToDictionary(
                    m => Regex.Replace(m.Groups[1].Value.Trim().Replace("&lt;", "<"), @"\[([^]]+)\]\([^)]+\)", m => m.Groups[1].Value),
                    m => m.Groups[0].Value.Trim().Replace("&lt;", "<").Replace("[!WARNING]", "**WARNING:**").Replace("[!NOTE]", "**NOTE:**"));
        }
    }
}
