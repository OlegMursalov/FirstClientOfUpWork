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
                        var informationWorksheet = pck.Workbook.Worksheets.Add("Information");
                        var dictionary = dataOfComputer.GetInfoByDictionary();
                        var chars = Enumerable.Range(0, char.MaxValue + 1).Select(i => (char)i).Where(c => char.IsLetter(c) && char.IsUpper(c)).Take(26).ToArray();
                        for (var i = 0; i < chars.Length; i++)
                        {
                            for (var j = 0; j < chars.Length; j++)
                            {
                                var item = dictionary.FirstOrDefault();
                                if (!string.IsNullOrEmpty(item.Key))
                                {
                                    var partOfKey = i == 0 ? $"{chars[j]}" : $"{chars[i - 1]}{chars[j]}";
                                    informationWorksheet.Cells[$"{partOfKey}1"].Value = item.Key;
                                    informationWorksheet.Cells[$"{partOfKey}2"].Value = item.Value;
                                    if (item.Key.Length > item.Value.Length)
                                    {
                                        informationWorksheet.Cells[$"{partOfKey}1"].AutoFitColumns();
                                    }
                                    else
                                    {
                                        informationWorksheet.Cells[$"{partOfKey}2"].AutoFitColumns();
                                    }
                                    dictionary.Remove(item.Key);
                                }
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
