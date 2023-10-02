using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FileImportExperiments.Strategies;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FileImportExperiments.Extensions;
internal static class RegexExtensions
{
    public static bool CanAddLineItem(this Match match)
    {
        return string.IsNullOrWhiteSpace(match.Groups[nameof(LineItem.DateOfFile)].Value.Trim()) is false &&
               string.IsNullOrWhiteSpace(match.Groups[nameof(LineItem.ClerkNumber)].Value.Trim()) is false &&
               string.IsNullOrWhiteSpace(match.Groups["TOI"].Value.Trim()) is false &&
               string.IsNullOrWhiteSpace(match.Groups[nameof(LineItem.Legal)].Value.Trim()) is false;
    }
}
