using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VectorLibrary
{
    interface IVector
    {
        [DataMember]
        public double X { get; set; }
        [DataMember]
        public double Y { get; set; }
        [DataMember]
        public double Z { get; set; }
        public double Length();
        public bool IsPositive { get; }
        public bool IsInteger { get; }
    }
}
