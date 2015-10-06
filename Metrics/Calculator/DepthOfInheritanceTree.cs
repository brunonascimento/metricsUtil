using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDepend.CodeModel;

namespace Metrics.Calculator
{
    class DepthOfInheritanceTree : ICalculate
    {
        public List<Metric> Calculate(ICodeBase codeBase, string className)
        {
            var result = from t in codeBase.Application.Types
                         where t.IsClass
                         let baseClasses = t.BaseClasses.ExceptThirdParty()
                         select new Metric() { Type = ElementType.Class, Value = Double.Parse(baseClasses.Count().ToString()), ObjectName = t.Name };

            return result.ToList();
        }
    }
}
