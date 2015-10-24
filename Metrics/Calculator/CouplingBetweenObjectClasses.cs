using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDepend.CodeModel;

namespace Metrics.Calculator
{
    class CouplingBetweenObjectClasses : ICalculate
    {
        public List<Metric> Calculate(ICodeBase codeBase)
        {
            var result = from t in codeBase.Application.Types
                         let typesUsed = t.TypesUsed.ExceptThirdParty()
                         orderby typesUsed.Count() descending
                         select new Metric() { Type = ElementType.Class, Value = Double.Parse(typesUsed.Count().ToString()), ObjectName = t.Name };

            return result.ToList();
        }
    }
}
