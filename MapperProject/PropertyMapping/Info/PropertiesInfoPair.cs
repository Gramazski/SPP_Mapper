using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MapperProject.PropertyMapping.Info
{
    class PropertiesInfoPair
    {
        internal PropertyInfo Source { get; }
        internal PropertyInfo Dest { get; }

        internal PropertiesInfoPair(PropertyInfo source, PropertyInfo dest)
        {
            Source = source;
            Dest = dest;
        }
    }
}
