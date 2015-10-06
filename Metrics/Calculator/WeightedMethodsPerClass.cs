using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDepend.CodeModel;

namespace Metrics.Calculator
{
    class WeightedMethodsPerClass : ICalculate
    {
        public List<Metric> Calculate(ICodeBase codeBase, String className)
        {
            var result = from t in codeBase.Application.Types
                         let methods = t.Methods.Where(m => !m.IsPropertyGetter && !m.IsPropertySetter && !m.IsConstructor)
                         orderby methods.Count() descending
                         select new Metric() { Type = ElementType.Class, Value = Double.Parse(methods.Count().ToString()), ObjectName = t.Name };

            return result.ToList();
        }
    }
}
