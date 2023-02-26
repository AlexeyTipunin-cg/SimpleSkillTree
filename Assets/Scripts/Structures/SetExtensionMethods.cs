using System.Collections.Generic;

namespace Assets.Scripts.Structures
{
    public static class SetExtensionMethods
    {
        public static ReadOnlySet<T> AsReadOnly<T>(this ISet<T> set)
        {
            return new ReadOnlySet<T>(set);
        }
    }
}
