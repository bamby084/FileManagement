using System;

namespace FileManagement.ExtensionMethods
{
    public static class StringExtensions
    {
        public static bool EqualsIgnoreCase(this string source, string target)
        {
            return source.Equals(target, StringComparison.CurrentCultureIgnoreCase);
        }

        public static bool IsNull(this string source)
        {
            return string.IsNullOrEmpty(source);
        }
    }
}
