using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrics.MetricPrinter
{
    interface IMetricPrinter
    {
        void Print(String metricName,List<Metric> metrics);
    }
}
