using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineIntegrationWinApp.Models
{
    public class SampleResult
    {
        public string barcode_or_level { get; set; }
        public DateTime result_date { get; set; }
        public string test_parameters_name { get; set; }
        public string actual_result_value { get; set; }
        public string result_entry_by { get; set; }
        public DateTime result_entry_date { get; set; }
    }
}
