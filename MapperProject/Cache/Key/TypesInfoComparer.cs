using System;
using System.Collections.Generic;

namespace MapperProject.Cache
{
    public class TypesInfoComparer : IEqualityComparer<TypesInfoPair>
    {
        public bool Equals(TypesInfoPair x, TypesInfoPair y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;

            return x.Source == y.Source && x.Dest == y.Dest;
        }

        public int GetHashCode(TypesInfoPair obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            var sourceHash = obj.Source?.GetHashCode() ?? 0;
            var destinationHash = obj.Dest?.GetHashCode() ?? 0;

            var result = 17;

            unchecked
            {
                result = 31 * result + sourceHash;
                result = 31 * result + destinationHash;
                return result;
            }
        }
    }
}