using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDepend.CodeModel;

namespace Metrics.Calculator
{
    class LackOfCohesionInMethods : ICalculate
    {
        public List<Metric> Calculate(ICodeBase codeBase, string className)
        {
            var result = from t in codeBase.Application.Types
                         where t.IsClass
                         let lcom = t.LCOM
                         select new Metric() { Type = ElementType.Class, Value = lcom.Value, ObjectName = t.Name };

            return result.ToList();
        }
    }
}
