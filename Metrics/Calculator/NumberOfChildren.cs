using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDepend.CodeModel;

namespace Metrics.Calculator
{
    class NumberOfChildren : ICalculate
    {
        public List<Metric> Calculate(ICodeBase codeBase)
        {
            var result = from t in codeBase.Application.Types
                         where t.IsClass
                         let childClasses = t.DerivedTypes
                         where
                         !t.IsThirdParty
                         //t.Name == className 
                            //childClasses.Count() > 0
                         orderby childClasses.Count() descending
                         select new Metric() { Type = ElementType.Class, Value = Double.Parse(childClasses.Count().ToString()), ObjectName = t.Name };

            return result.ToList();

        }
    }
}
