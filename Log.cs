using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MachineIntegrationWinApp
{
    public static class Log
    {
        public static void Write(string ex)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string fileName = $"date-{DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss")}.txt";
            string path = System.IO.Path.GetDirectoryName(asm.Location) + @"\MachineIntegrationErrorLog " + fileName;
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(ex.ToString());
            }
        }
    }
}
