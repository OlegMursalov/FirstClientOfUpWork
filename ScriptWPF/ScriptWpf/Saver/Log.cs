using Microsoft.Win32;
using Script.Info;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Script.Saver
{
    public class Log
    {
        public bool SaveInfoToFile(DataOfComputer dataOfComputer, out string exMessgae)
        {
            exMessgae = string.Empty;
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "txt|*.txt";
                saveFileDialog1.Title = "Save log file";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != string.Empty)
                {
                    var dataOfComputerText = dataOfComputer.ToString();
                    using (var fs = (FileStream)saveFileDialog1.OpenFile())
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(dataOfComputerText);
                        fs.Write(info, 0, info.Length);
                        byte[] data = new byte[] { 0x0 };
                        fs.Write(data, 0, data.Length);
                        fs.Close();
                        return true;
                    }
                }
                else
                {
                    exMessgae = "Not done";
                    return false;
                }
            }
            catch (Exception ex)
            {
                exMessgae = ex.Message;
                return false;
            }
        }
    }
}