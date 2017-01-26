using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperProject.Cache
{
    public class TypesInfoPair
    {
        public Type Source { get; }
        public Type Dest { get; }

        public TypesInfoPair(Type source, Type dest)
        {
            Source = source;
            Dest = dest;
        }
    }
}
