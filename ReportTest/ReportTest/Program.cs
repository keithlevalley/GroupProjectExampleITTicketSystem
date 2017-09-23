using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportTest.reportService;

namespace ReportTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Service1 reportTest = new Service1();
            reportTest.getBasicReport();
        }
    }
}
