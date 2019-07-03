using Microsoft.Win32;
using OfficeOpenXml;
using Script.Info;
using System;
using System.IO;
using System.Linq;

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
                        var i = 1;
                        var informationWorksheet = pck.Workbook.Worksheets.Add("Information");
                        var dictionary = dataOfComputer.GetInfoByDictionary();
                        foreach (var item in dictionary)
                        {
                            informationWorksheet.Cells[$"A{i}"].Value = item.Key;
                            informationWorksheet.Cells[$"B{i}"].Value = item.Value;
                            i++;
                        }
                        informationWorksheet.Column(1).Width = 50;
                        informationWorksheet.Column(2).Width = 50;
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
