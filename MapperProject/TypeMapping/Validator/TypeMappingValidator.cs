using MapperProject.TypeConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperProject.TypeMapping.Validator
{
    class TypeMappingValidator
    {
        private static readonly TypeMappingStorage typeMappingStorage = new TypeMappingStorage();

        public bool IsValidForMapping(Type source, Type dest)
        {
            return IsSameRefType(source, dest) 
                || IsBelongToStorage(source, dest);
        }

        private bool IsSameRefType(Type source, Type dest)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (dest == null)
                throw new ArgumentNullException(nameof(dest));

            if (source.IsClass && dest.IsClass)
            {
                return source == dest;
            }

            return false;
        }

        private bool IsBelongToStorage(Type source, Type dest)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (dest == null)
                throw new ArgumentNullException(nameof(dest));

            List<Type> mappingTypes = typeMappingStorage.GetMappingTypes(source);

            if (mappingTypes != null)
            {
                return mappingTypes.Contains(dest);
            }

            return false;
        }
    }
}
