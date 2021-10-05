﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if DEBUG
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.RegularExpressions.Symbolic;
using System.Text.RegularExpressions.Symbolic.Unicode;

namespace System.Text.RegularExpressions
{
    public partial class Regex
    {
        /// <summary>Unwind the regex and save the resulting state graph in DGML</summary>
        /// <param name="bound">roughly the maximum number of states, 0 means no bound</param>
        /// <param name="hideStateInfo">if true then hide state info</param>
        /// <param name="addDotStar">if true then pretend that there is a .* at the beginning</param>
        /// <param name="inReverse">if true then unwind the regex backwards (addDotStar is then ignored)</param>
        /// <param name="onlyDFAinfo">if true then compute and save only general DFA info</param>
        /// <param name="writer">dgml output is written here</param>
        /// <param name="maxLabelLength">maximum length of labels in nodes anything over that length is indicated with .. </param>
        /// <param name="asNFA">if true creates NFA instead of DFA</param>
        [ExcludeFromCodeCoverage(Justification = "Debug only")]
        internal void SaveDGML(TextWriter writer, int bound, bool hideStateInfo, bool addDotStar, bool inReverse, bool onlyDFAinfo, int maxLabelLength, bool asNFA)
        {
            if (factory is not SymbolicRegexRunnerFactory srmFactory)
            {
                throw new NotSupportedException();
            }

            srmFactory._runner._matcher.SaveDGML(writer, bound, hideStateInfo, addDotStar, inReverse, onlyDFAinfo, maxLabelLength, asNFA);
        }

        /// <summary>
        /// Generates two files IgnoreCaseRelation.cs and UnicodeCategoryRanges.cs for the namespace System.Text.RegularExpressions.Symbolic.Unicode
        /// in the given directory path. Only avaliable in DEBUG mode.
        /// </summary>
        [ExcludeFromCodeCoverage(Justification = "Debug only")]
        internal static void GenerateUnicodeTables(string path)
        {
            IgnoreCaseRelationGenerator.Generate("System.Text.RegularExpressions.Symbolic.Unicode", "IgnoreCaseRelation", path);
            UnicodeCategoryRangesGenerator.Generate("System.Text.RegularExpressions.Symbolic.Unicode", "UnicodeCategoryRanges", path);
        }
    }
}
#endif