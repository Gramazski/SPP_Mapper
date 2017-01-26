using MapperProject.FuncFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperProject.Mapper
{
    public class DTOMapper : IMapper
    {
        private AbstractFuncFactory mappingFuncFactory;

        public DTOMapper(AbstractFuncFactory funcFactory)
        {
            mappingFuncFactory = funcFactory;
        }

        public TDestination Map<TSource, TDestination>(TSource source) where TDestination : new()
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var mappingFunc = mappingFuncFactory.GetFunc<TSource, TDestination>();

            return mappingFunc(source);
        }
    }
}
