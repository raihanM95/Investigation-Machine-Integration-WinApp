using MachineIntegrationWinApp.DAL;
using MachineIntegrationWinApp.Models;
using MachineIntegrationWinApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
//using Timer = System.Timers.Timer;

namespace MachineIntegrationWinApp.UI
{
    public partial class TimerUI : Form
    {
        static SerialPort _spMicrosES60AnalyzerPort;

        public TimerUI()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            var isActiveMicrosES60Analyzer = System.Configuration.ConfigurationManager.AppSettings["MicrosES60Analyzer"];
            if(isActiveMicrosES60Analyzer == "True")
            {
                ActiveMicrosES60Analyzer();
            }

            timerMachineHospital.Interval = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MachineHospitalInterval"]);
            timerMachineHospital.Enabled = true;
        }

        #region MicrosES60Analyzer
        private void ActiveMicrosES60Analyzer()
        {
            try
            {
                // Create a new SerialPort object with default settings.
                _spMicrosES60AnalyzerPort = new SerialPort();

                // Allow the user to set the appropriate properties.
                _spMicrosES60AnalyzerPort.PortName = System.Configuration.ConfigurationManager.AppSettings["MicrosES60AnalyzerPort"];
                _spMicrosES60AnalyzerPort.BaudRate = 9600;
                _spMicrosES60AnalyzerPort.Parity = Parity.None;
                _spMicrosES60AnalyzerPort.DataBits = 8;
                _spMicrosES60AnalyzerPort.StopBits = StopBits.One;
                _spMicrosES60AnalyzerPort.Handshake = Handshake.None;

                // Set the read/write timeouts
                _spMicrosES60AnalyzerPort.ReadTimeout = 500;
                _spMicrosES60AnalyzerPort.WriteTimeout = 500;

                _spMicrosES60AnalyzerPort.Open();

                timerMicrosES60Analyzer.Interval = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MicrosES60AnalyzerInterval"]);
                timerMicrosES60Analyzer.Enabled = true;
            }
            catch (Exception ex)
            {
                _spMicrosES60AnalyzerPort.Close();
                Log.Write(ex.ToString());
                MessageBox.Show("Please Check Log", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timerMicrosES60Analyzer_Tick(object sender, EventArgs e)
        {
            string data = _spMicrosES60AnalyzerPort.ReadExisting();

            if (data.Length > 0)
            {
                GetES60AnalyzerData(data);
            }
        }

        private void GetES60AnalyzerData(string data)
        {
            try
            {
                //string[] lines = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                string[] lines = data.Split(new string[] { Environment.NewLine, "\r" }, StringSplitOptions.RemoveEmptyEntries);

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

                DataArchive dataArchive = new DataArchive();
                if(sampleResults.Count > 0)
                    dataArchive.Save(sampleResults);
            }
            catch (Exception ex)
            {
                Log.Write(ex.ToString());
            }
        }
        #endregion

        private void TimerUI_Load(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        private void timerMachineHospital_Tick(object sender, EventArgs e)
        {
            MachineHospitalService machineHospitalService = new MachineHospitalService();
            machineHospitalService.PostSampleResults();
        }
    }
}
