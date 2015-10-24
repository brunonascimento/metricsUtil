using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrics.MetricPrinter
{
    class ExcelPrinter : IMetricPrinter
    {
        public void Print(String metricName,List<Metric> metrics)
        {
            // this code is for reference and consider changing the code for your need
            OleDbConnection excelConnection = null;
            try
            {
                excelConnection = new OleDbConnection();
                excelConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ExcelCon"].ConnectionString;

                excelConnection.Open();
                OleDbCommand comCreateTable = new OleDbCommand("Create Table ["+metricName+"] ([ObjectName] Varchar,[Type] Varchar,[Value] Double);", excelConnection);
                comCreateTable.ExecuteNonQuery();

                OleDbCommand comCreateMetric;
                foreach (Metric metric in metrics)
                {
                    comCreateMetric = new OleDbCommand(@"Insert into ["+ metricName + "]([ObjectName], [Type], [Value]) VALUES('" + metric.ObjectName + "','" + metric.Type.ToString() + "','" + metric.Value + "');"
                    , excelConnection);
                    comCreateMetric.ExecuteNonQuery();
                }
            }
            finally
            {
                excelConnection.Close();
                excelConnection.Dispose();
            }
        }
    }
}
