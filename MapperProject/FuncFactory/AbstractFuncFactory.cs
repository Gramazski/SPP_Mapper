using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperProject.FuncFactory
{
    public abstract class AbstractFuncFactory
    {
        public abstract Func<TSource, TDestination> GetFunc<TSource, TDestination>();
    }
}
