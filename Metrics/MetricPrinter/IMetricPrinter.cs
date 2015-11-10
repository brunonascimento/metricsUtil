using System;
using System.Collections.Generic;

namespace Metrics.MetricPrinter
{
    interface IMetricPrinter
    {
        void Print(String metricName,List<Metric> metrics);
    }
}
