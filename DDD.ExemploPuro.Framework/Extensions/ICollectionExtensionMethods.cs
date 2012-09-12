using System;
using System.Collections.Generic;
using System.Linq;
namespace DDD.ExemploPuro.Framework
{
    public static class ICollectionExtensionMethods
    {
        public static IEnumerable<T> ToCloneEnumerable<T>(this ICollection<T> self_) where T : ICloneable
        {
            return self_.Select(e => e.Clone()).Cast<T>().AsEnumerable();
        }

        public static void RemoveAll<T>(this ICollection<T> self, Func<T, bool> clause)
        {
            self.Where(clause).ToList().ForEach(i => self.Remove(i));
        }
    }
}