using Microsoft.Win32;
using OfficeOpenXml;
using Script.Info;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetbixCVD.Saver
{
    public class ExcelFileCreator : IFileCreator
    {
        public bool SaveInfoToFile(DataOfComputer dataOfComputer, out string exMessgae)
        {
            exMessgae = string.Empty;
            try
            {
                var saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "xlsx|*.xlsx";
                saveFileDialog1.Title = "Save Excel file";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != string.Empty)
                {
                    var pathToFile = Path.GetFullPath(saveFileDialog1.FileName);
                    var fileInfo = new FileInfo(pathToFile);
                    using (var pck = new ExcelPackage(fileInfo))
                    {
                        var informationWorksheet = pck.Workbook.Worksheets.Add("Information");
                        var dictionary = dataOfComputer.GetInfoByDictionary();
                        var chars = Enumerable.Range(0, char.MaxValue + 1).Select(i => (char)i).Where(c => !char.IsControl(c)).ToArray();
                        foreach (var item in dictionary)
                        {
                            var c = chars.FirstOrDefault();
                            if (c != default(char))
                            {
                                var headerKey = c.ToString().ToUpper();
                                informationWorksheet.Cells[$"{headerKey}1"].Value = item.Key;
                                informationWorksheet.Cells[$"{headerKey}2"].Value = item.Value;
                            }
                        }
                        pck.Save();
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
                exMessgae = $"SaveInfoToFile (Excel): {ex.Message}";
                return false;
            }
        }
    }
}
