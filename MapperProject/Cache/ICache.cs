using System;

namespace MapperProject.Cache
{
    public interface ICache
    {
        void Add(TypesInfoPair key, Delegate value);
        Delegate GetValue(TypesInfoPair key);
        bool ContainsKey(TypesInfoPair key);
    }
}