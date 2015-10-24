using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metrics.Calculator;
using NDepend.CodeModel;

namespace Metrics
{
    enum ElementType
    {
        Class,
        Method
    }
    class Metric
    {
        public ElementType Type { get; set; }
        public String ObjectName { get; set; }
        public double Value { get; set; }
        public ICalculate Calculator { get; set; }

    }
}
