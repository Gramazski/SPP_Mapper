using MapperProject.Cache;
using MapperProject.PropertyMapping.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MapperProject.Cache.FuncCache;
using MapperProject.Logger;
using MapperProject.PropertyMapping.Manager;

namespace MapperProject.FuncFactory.Mapping
{
    public class MappingFuncFactory : AbstractFuncFactory
    {
        private readonly MappingFuncCache mappingFuncCache = new MappingFuncCache();
        private readonly ILogger logger = new TextFileLogger();

        public override Func<TSource, TDestination> GetFunc<TSource, TDestination>()
        {
            Func<TSource, TDestination> mappingFunc;
            var typesPair = new TypesInfoPair(typeof(TSource), typeof(TDestination));

            if (mappingFuncCache.ContainsKey(typesPair))
            {
                logger.WriteToLog("Func getting from cache for type pair: source - " 
                    + typesPair.Source + " dest - " + typesPair.Dest);
                mappingFunc = mappingFuncCache.GetValue(typesPair) as Func<TSource, TDestination>;
            }
            else
            {
                logger.WriteToLog("Creating new func for type pair: source - "
                    + typesPair.Source + " dest - " + typesPair.Dest);
                mappingFunc = CreateMappingFunc<TSource, TDestination>();
                mappingFuncCache.Add(typesPair, mappingFunc);
            }

            return mappingFunc;
        }

        private Func<TSource, TDestination> CreateMappingFunc<TSource, TDestination>()
        {
            var propertyMappingManager = new PropertyMappingManager();
            var mappingProperies = propertyMappingManager.GetMappingPropertiesPairs<TSource, TDestination>();

            var source = Expression.Parameter(typeof(TSource), "source");
            var memberBindings = GeneratePropertiesBindings(source, mappingProperies);
            var memberInit = Expression.MemberInit(Expression.New(typeof(TDestination)), memberBindings);

            var expression = Expression.Lambda<Func<TSource, TDestination>>(memberInit, source);

            return expression.Compile();
        }

        private List<MemberAssignment> GeneratePropertiesBindings(Expression source, List<PropertiesInfoPair> propertiesPair)
        {
            var propertiesBindings = new List<MemberAssignment>();

            foreach (var propertyPair in propertiesPair)
            {
                var sourceProperty = Expression.Property(source, propertyPair.Source.Name);
                var destValue = Expression.Convert(sourceProperty, propertyPair.Dest.PropertyType);
                var currentExpression = Expression.Bind(propertyPair.Dest, destValue);
                propertiesBindings.Add(currentExpression);
            }

            return propertiesBindings;
        }
    }
}
