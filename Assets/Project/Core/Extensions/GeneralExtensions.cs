using System.Collections;

namespace JCI.Core.Extensions
{
    public static class GeneralExtensions
    {
        public static bool IsNullOrEmpty(this ICollection _this)
        {
            if (_this == null)
                return true;

            return _this.Count == 0;
        }

        public static bool IsNullOrEmpty(this string _this)
        {
            return string.IsNullOrEmpty(_this);
        }
    }
}