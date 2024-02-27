using MachineIntegrationWinApp.Models;
using MachineIntegrationWinApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineIntegrationWinApp.UI
{
    public partial class ManualUI : Form
    {
        public ManualUI()
        {
            InitializeComponent();
        }

        private void BtnMicrosES60Analyzer_Click(object sender, EventArgs e)
        {
            string data = @"00772
                            ? RESULT  
                            p 00
                            q 24/02/10 08h02mn27s
                            u 001             
                            s     
                            v SHUMI                         
                            t M
                            ? D
                            ! 005.7  
                            2 04.66  
                            3 011.0 l
                            4 035.3 l
                            5 00076 l
                            6 023.6 l
                            7 031.2 l
                            8 017.3 h
                            9 00047  
                            @ 00506 h
                            A 006.5 l
                            B 0.331  
                            C 015.0  
                            # 032.2  
                            % 005.3  
                            ' 062.5  
                            "" 001.8  
                            $ 000.3  
                            & 003.6  
                            W       !%+,3H}??????lXKF@====::75679799==@?==?GKNNRXY\^_`_cgjmigcijpmic_`_\XQONQONJHC=9950.//.,++''$$""""!!!!! !!                 !
                            X            !""!""""$#&-2?Rc????????????????????uznk]ZUMDD:8855/-+)%)(&&&#%%$$""""""!!""!!!!!!!   ! !                                  #
                            Y   ""'+07>FNV^cglprsttttsokfd`\XSNJGDB?<975530/.-,++)((('''&&&%%%$$$###""""""!""!!!!!!                          ! !!""""""""""""###""""######$
                            S       
                            _ 105
                            P         G2  
                            ] 000 000 000 024 034
                            ? MICROS60
                            ? V2.8 
                            ? A0FE
                            ";

            string[] lines = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            List<SampleResult> sampleResults = new List<SampleResult>();
            string barcode = string.Empty;
            DateTime dateTime = DateTime.Now;

            foreach (string line in lines)
            {
                SampleResult sampleResult = new SampleResult();

                if (line.Trim().StartsWith("u"))
                {
                    string[] result = line.Split(new string[] { "u" }, StringSplitOptions.None);
                    string sampleid = result[1].Trim();
                    barcode = sampleid;
                }
                if (line.Trim().StartsWith("!"))
                {
                    string[] result = line.Split(new string[] { "!", "l", "h" }, StringSplitOptions.None);
                    string resultValueWithLeadingZeroes = result[1].Trim();
                    string resultValue = decimal.Parse(resultValueWithLeadingZeroes).ToString(); // Convert to decimal and remove leading zeros

                    sampleResult.barcode_or_level = barcode;
                    sampleResult.result_date = dateTime;
                    sampleResult.test_parameters_name = "WBC";
                    sampleResult.actual_result_value = resultValue;

                    sampleResults.Add(sampleResult);
                }
                if (line.Trim().StartsWith("2"))
                {
                    string[] result = line.Split(new string[] { "2", "l", "h" }, StringSplitOptions.None);
                    string resultValueWithLeadingZeroes = result[1].Trim();
                    string resultValue = decimal.Parse(resultValueWithLeadingZeroes).ToString(); // Convert to decimal and remove leading zeros

                    sampleResult.barcode_or_level = barcode;
                    sampleResult.result_date = dateTime;
                    sampleResult.test_parameters_name = "RBC";
                    sampleResult.actual_result_value = resultValue;

                    sampleResults.Add(sampleResult);
                }
                if (line.Trim().StartsWith("3"))
                {
                    string[] result = line.Split(new string[] { "3", "l", "h" }, StringSplitOptions.None);
                    string resultValueWithLeadingZeroes = result[1].Trim();
                    string resultValue = decimal.Parse(resultValueWithLeadingZeroes).ToString(); // Convert to decimal and remove leading zeros

                    sampleResult.barcode_or_level = barcode;
                    sampleResult.result_date = dateTime;
                    sampleResult.test_parameters_name = "HGB";
                    sampleResult.actual_result_value = resultValue;

                    sampleResults.Add(sampleResult);
                }
                if (line.Trim().StartsWith("4"))
                {
                    string[] result = line.Split(new string[] { "4", "l", "h" }, StringSplitOptions.None);
                    string resultValueWithLeadingZeroes = result[1].Trim();
                    string resultValue = decimal.Parse(resultValueWithLeadingZeroes).ToString(); // Convert to decimal and remove leading zeros

                    sampleResult.barcode_or_level = barcode;
                    sampleResult.result_date = dateTime;
                    sampleResult.test_parameters_name = "HCT";
                    sampleResult.actual_result_value = resultValue;

                    sampleResults.Add(sampleResult);
                }
                if (line.Trim().StartsWith("5"))
                {
                    string[] result = line.Split(new string[] { "5", "l", "h" }, StringSplitOptions.None);
                    string resultValueWithLeadingZeroes = result[1].Trim();
                    string resultValue = decimal.Parse(resultValueWithLeadingZeroes).ToString(); // Convert to decimal and remove leading zeros

                    sampleResult.barcode_or_level = barcode;
                    sampleResult.result_date = dateTime;
                    sampleResult.test_parameters_name = "MCV";
                    sampleResult.actual_result_value = resultValue;

                    sampleResults.Add(sampleResult);
                }
                if (line.Trim().StartsWith("6"))
                {
                    string[] result = line.Split(new string[] { "6", "l", "h" }, StringSplitOptions.None);
                    string resultValueWithLeadingZeroes = result[1].Trim();
                    string resultValue = decimal.Parse(resultValueWithLeadingZeroes).ToString(); // Convert to decimal and remove leading zeros

                    sampleResult.barcode_or_level = barcode;
                    sampleResult.result_date = dateTime;
                    sampleResult.test_parameters_name = "MCH";
                    sampleResult.actual_result_value = resultValue;

                    sampleResults.Add(sampleResult);
                }
                if (line.Trim().StartsWith("7"))
                {
                    string[] result = line.Split(new string[] { "7", "l", "h" }, StringSplitOptions.None);
                    string resultValueWithLeadingZeroes = result[1].Trim();
                    string resultValue = decimal.Parse(resultValueWithLeadingZeroes).ToString(); // Convert to decimal and remove leading zeros

                    sampleResult.barcode_or_level = barcode;
                    sampleResult.result_date = dateTime;
                    sampleResult.test_parameters_name = "MCHC";
                    sampleResult.actual_result_value = resultValue;

                    sampleResults.Add(sampleResult);
                }
                if (line.Trim().StartsWith("8"))
                {
                    string[] result = line.Split(new string[] { "8", "l", "h" }, StringSplitOptions.None);
                    string resultValueWithLeadingZeroes = result[1].Trim();
                    string resultValue = decimal.Parse(resultValueWithLeadingZeroes).ToString(); // Convert to decimal and remove leading zeros

                    sampleResult.barcode_or_level = barcode;
                    sampleResult.result_date = dateTime;
                    sampleResult.test_parameters_name = "RDW-CV";
                    sampleResult.actual_result_value = resultValue;

                    sampleResults.Add(sampleResult);
                }
                if (line.Trim().StartsWith("9"))
                {
                    string[] result = line.Split(new string[] { "9", "l", "h" }, StringSplitOptions.None);
                    string resultValueWithLeadingZeroes = result[1].Trim();
                    string resultValue = decimal.Parse(resultValueWithLeadingZeroes).ToString(); // Convert to decimal and remove leading zeros

                    sampleResult.barcode_or_level = barcode;
                    sampleResult.result_date = dateTime;
                    sampleResult.test_parameters_name = "RDW-SD";
                    sampleResult.actual_result_value = resultValue;

                    sampleResults.Add(sampleResult);
                }
                if (line.Trim().StartsWith("@"))
                {
                    string[] result = line.Split(new string[] { "@", "l", "h" }, StringSplitOptions.None);
                    string resultValueWithLeadingZeroes = result[1].Trim();
                    string resultValue = decimal.Parse(resultValueWithLeadingZeroes).ToString(); // Convert to decimal and remove leading zeros

                    sampleResult.barcode_or_level = barcode;
                    sampleResult.result_date = dateTime;
                    sampleResult.test_parameters_name = "PLT";
                    sampleResult.actual_result_value = resultValue;

                    sampleResults.Add(sampleResult);
                }
                if (line.Trim().StartsWith("A"))
                {
                    string[] result = line.Split(new string[] { "A", "l", "h" }, StringSplitOptions.None);
                    string resultValueWithLeadingZeroes = result[1].Trim();
                    string resultValue = decimal.Parse(resultValueWithLeadingZeroes).ToString(); // Convert to decimal and remove leading zeros

                    sampleResult.barcode_or_level = barcode;
                    sampleResult.result_date = dateTime;
                    sampleResult.test_parameters_name = "MPV";
                    sampleResult.actual_result_value = resultValue;

                    sampleResults.Add(sampleResult);
                }
                if (line.Trim().StartsWith("B"))
                {
                    string[] result = line.Split(new string[] { "B", "l", "h" }, StringSplitOptions.None);
                    string resultValueWithLeadingZeroes = result[1].Trim();
                    string resultValue = decimal.Parse(resultValueWithLeadingZeroes).ToString(); // Convert to decimal and remove leading zeros

                    sampleResult.barcode_or_level = barcode;
                    sampleResult.result_date = dateTime;
                    sampleResult.test_parameters_name = "THT";
                    sampleResult.actual_result_value = resultValue;

                    sampleResults.Add(sampleResult);
                }
                if (line.Trim().StartsWith("C"))
                {
                    string[] result = line.Split(new string[] { "C", "l", "h" }, StringSplitOptions.None);
                    string resultValueWithLeadingZeroes = result[1].Trim();
                    string resultValue = decimal.Parse(resultValueWithLeadingZeroes).ToString(); // Convert to decimal and remove leading zeros

                    sampleResult.barcode_or_level = barcode;
                    sampleResult.result_date = dateTime;
                    sampleResult.test_parameters_name = "PDW";
                    sampleResult.actual_result_value = resultValue;

                    sampleResults.Add(sampleResult);
                }
                if (line.Trim().StartsWith("\""))
                {
                    string[] result = line.Split(new string[] { "\"", "l", "h" }, StringSplitOptions.None);
                    string resultValueWithLeadingZeroes = result[1].Trim();
                    string resultValue = decimal.Parse(resultValueWithLeadingZeroes).ToString(); // Convert to decimal and remove leading zeros

                    sampleResult.barcode_or_level = barcode;
                    sampleResult.result_date = dateTime;
                    sampleResult.test_parameters_name = "Lymphocytes (#)";
                    sampleResult.actual_result_value = resultValue;

                    sampleResults.Add(sampleResult);
                }
                if (line.Trim().StartsWith("#"))
                {
                    string[] result = line.Split(new string[] { "#", "l", "h" }, StringSplitOptions.None);
                    string resultValueWithLeadingZeroes = result[1].Trim();
                    string resultValue = decimal.Parse(resultValueWithLeadingZeroes).ToString(); // Convert to decimal and remove leading zeros

                    sampleResult.barcode_or_level = barcode;
                    sampleResult.result_date = dateTime;
                    sampleResult.test_parameters_name = "Lymphocytes (%)";
                    sampleResult.actual_result_value = resultValue;

                    sampleResults.Add(sampleResult);
                }
                if (line.Trim().StartsWith("$"))
                {
                    string[] result = line.Split(new string[] { "$", "l", "h" }, StringSplitOptions.None);
                    string resultValueWithLeadingZeroes = result[1].Trim();
                    string resultValue = decimal.Parse(resultValueWithLeadingZeroes).ToString(); // Convert to decimal and remove leading zeros

                    sampleResult.barcode_or_level = barcode;
                    sampleResult.result_date = dateTime;
                    sampleResult.test_parameters_name = "Monocytes (#)";
                    sampleResult.actual_result_value = resultValue;

                    sampleResults.Add(sampleResult);
                }
                if (line.Trim().StartsWith("%"))
                {
                    string[] result = line.Split(new string[] { "%", "l", "h" }, StringSplitOptions.None);
                    string resultValueWithLeadingZeroes = result[1].Trim();
                    string resultValue = decimal.Parse(resultValueWithLeadingZeroes).ToString(); // Convert to decimal and remove leading zeros

                    sampleResult.barcode_or_level = barcode;
                    sampleResult.result_date = dateTime;
                    sampleResult.test_parameters_name = "Monocytes (%)";
                    sampleResult.actual_result_value = resultValue;

                    sampleResults.Add(sampleResult);
                }
                if (line.Trim().StartsWith("&"))
                {
                    string[] result = line.Split(new string[] { "&", "l", "h" }, StringSplitOptions.None);
                    string resultValueWithLeadingZeroes = result[1].Trim();
                    string resultValue = decimal.Parse(resultValueWithLeadingZeroes).ToString(); // Convert to decimal and remove leading zeros

                    sampleResult.barcode_or_level = barcode;
                    sampleResult.result_date = dateTime;
                    sampleResult.test_parameters_name = "Granulocytes (#)";
                    sampleResult.actual_result_value = resultValue;

                    sampleResults.Add(sampleResult);
                }
                if (line.Trim().StartsWith("'"))
                {
                    string[] result = line.Split(new string[] { "'", "l", "h" }, StringSplitOptions.None);
                    string resultValueWithLeadingZeroes = result[1].Trim();
                    string resultValue = decimal.Parse(resultValueWithLeadingZeroes).ToString(); // Convert to decimal and remove leading zeros

                    sampleResult.barcode_or_level = barcode;
                    sampleResult.result_date = dateTime;
                    sampleResult.test_parameters_name = "Granulocytes (%)";
                    sampleResult.actual_result_value = resultValue;

                    sampleResults.Add(sampleResult);
                }

            }   

            dataGridView.DataSource = sampleResults;
        }

        private void ManualUI_Load(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        private void btnHospitalSync_Click(object sender, EventArgs e)
        {
            MachineHospitalService machineHospitalService = new MachineHospitalService();
            machineHospitalService.PostSampleResults();
        }
    }
}
