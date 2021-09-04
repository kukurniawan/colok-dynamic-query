using System;

namespace Colok.DynamicQuery
{
    public static class StringHelper
    {
        public static string Between(this string src, string findFrom, string findTo)
        {
            var start = src.IndexOf(findFrom, StringComparison.Ordinal);
            var to = src.IndexOf(findTo, start + findFrom.Length, StringComparison.Ordinal);
            if (start < 0 || to < 0) return "";
            var s = src.Substring(
                start + findFrom.Length,
                to - start - findFrom.Length);
            return s;
        }
    }
}