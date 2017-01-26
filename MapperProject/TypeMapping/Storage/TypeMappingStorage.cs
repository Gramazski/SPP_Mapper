using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperProject.TypeConverter
{
    class TypeMappingStorage
    {
        private static readonly Dictionary<Type, List<Type>> typesMappingTable = new Dictionary<Type, List<Type>>()
        {
            {
                typeof(char),
                new List<Type> {
                    typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong),
                    typeof(float), typeof(double), typeof(decimal)
                }
            },
            {
                typeof(byte),
                new List<Type> {
                    typeof(short), typeof(ushort), typeof(int), typeof(uint), typeof(long),
                    typeof(ulong), typeof(float), typeof(double), typeof(decimal) }
            },
            {
                typeof(sbyte),
                new List<Type> {
                    typeof(short), typeof(int), typeof(long), typeof(float), typeof(double), typeof(decimal)
                }
            },
            {
                typeof(short),
                new List<Type> {
                    typeof(int), typeof(long), typeof(float), typeof(double), typeof(decimal)
                }
            },
            {
                typeof(ushort),
                new List<Type> {
                    typeof(int), typeof(uint), typeof(long), typeof(ulong),
                    typeof(float), typeof(double), typeof(decimal)
                }
            },
            {
                typeof(int),
                new List<Type> {
                    typeof(long), typeof(float), typeof(double), typeof(decimal) }

            },
            {
                typeof(uint),
                new List<Type> {
                    typeof(long), typeof(ulong), typeof(float), typeof(double), typeof(decimal)
                }
            },
            {
                typeof(long),
                new List<Type> {
                    typeof(float), typeof(double), typeof(decimal)
                }
            },
            {
                typeof(ulong),
                new List<Type> {
                    typeof(float), typeof(double), typeof(decimal)
                }
            },
            {
                typeof(float),
                new List<Type> {
                    typeof(double)
                }
            }
        };

        public List<Type> GetMappingTypes(Type key)
        {
            List<Type> mappingTypes;

            if (typesMappingTable.TryGetValue(key, out mappingTypes))
            {
                return mappingTypes;
            }
            else
            {
                return null;//Exception?
            }
        }

    }
}
