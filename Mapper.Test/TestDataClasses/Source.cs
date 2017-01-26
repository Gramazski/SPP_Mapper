using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Test.TestDataClasses
{
    class Source
    {
        public string SameType { get; set; }
        public int NotSameType { get; set; }
        public int CanConvert { get; set; }
        public double CanNotConvert { get; set; }
        public List<string> SameRefType { get; set; }
        public int DestFieldWithoutSetter { get; set; }
        public int NoSuchPropertyInDestination { get; set; }
    }
}
