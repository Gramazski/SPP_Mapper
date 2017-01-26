using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Test.TestDataClasses
{
    class Destination
    {
        public string SameType { get; set; }
        public string NotSameType { get; set; }
        public long CanConvert { get; set; }
        public float CanNotConvert { get; set; }
        public List<string> SameRefType { get; set; }
        public int DestFieldWithoutSetter { get; }
        public int NoSuchPropertyInSource { get; set; }
    }
}
