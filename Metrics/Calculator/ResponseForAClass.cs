using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDepend.CodeModel;

namespace Metrics.Calculator
{
    class ResponseForAClass : ICalculate
    {
        public List<Metric> Calculate(ICodeBase codeBase, string className)
        {
            var result = from m in codeBase.Application.Methods
                         where !m.IsThirdParty
                         let rfc = m.MethodsCalled.ExceptThirdParty().Count()
                         select new Metric() { Type = ElementType.Method, Value = rfc, ObjectName = m.Name };

            return result.ToList();
        }
    }
}
