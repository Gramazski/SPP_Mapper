using System.Collections.Generic;
using System.Linq;
using MapperProject.PropertyMapping.Info;
using MapperProject.TypeMapping.Validator;

namespace MapperProject.PropertyMapping.Manager
{
    class PropertyMappingManager
    {
        private readonly TypeMappingValidator typeMappingValidator = new TypeMappingValidator();

        public List<PropertiesInfoPair> GetMappingPropertiesPairs<TSource, TDestination>()
        {
            return (
                from sourceProperty in typeof(TSource).GetProperties()
                join destinationProperty in typeof(TDestination).GetProperties()
                    on sourceProperty.Name equals destinationProperty.Name
                where
                    sourceProperty.CanRead && destinationProperty.CanWrite &&
                    typeMappingValidator.IsValidForMapping(sourceProperty.PropertyType, destinationProperty.PropertyType)
                select new PropertiesInfoPair(sourceProperty, destinationProperty)
                ).ToList();
        }
    }
}
