using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDepend.CodeModel;

namespace Metrics.Calculator
{
    interface ICalculate
    {
        List<Metric> Calculate(ICodeBase codeBase, String className);
    }
}
