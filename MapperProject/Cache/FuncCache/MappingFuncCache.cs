using System;
using System.Collections.Generic;

namespace MapperProject.Cache.FuncCache
{
    public class MappingFuncCache : ICache
    {
        private readonly Dictionary<TypesInfoPair, Delegate> mappingFuncCache;

        public MappingFuncCache()
        {
            mappingFuncCache = new Dictionary<TypesInfoPair, Delegate>(new TypesInfoComparer());
        }

        public void Add(TypesInfoPair key, Delegate value)
        {
            mappingFuncCache.Add(key, value);
        }

        public bool ContainsKey(TypesInfoPair key)
        {
            return mappingFuncCache.ContainsKey(key);
        }

        public Delegate GetValue(TypesInfoPair key)
        {
            return mappingFuncCache[key];
        }
    }
}