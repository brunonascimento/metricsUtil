using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrics.MetricPrinter
{
    class ConsolePrinter : IMetricPrinter
    {
        public void Print(String metricName,List<Metric> metrics)
        {
            Console.WriteLine("The values for the metric "+metricName+" are");
            foreach (var m in metrics)
            {
                Console.WriteLine(m.ObjectName + " has a value of " + m.Value);
            }
            Console.ReadKey();
        }
    }
}
