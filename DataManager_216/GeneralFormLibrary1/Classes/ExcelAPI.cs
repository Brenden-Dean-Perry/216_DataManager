using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Office.Interop.Excel;
using _excel = Microsoft.Office.Interop.Excel;

namespace GeneralFormLibrary1
{
    public class ExcelAPI
    {
        _Application excel = new _excel.Application();
        Workbook wb;
        Worksheet ws;


        internal void ExportDataToSheet<T>(IList<T> Data, bool Open = true, string AppName = null, string FileName = null, string SavePath = null) where T : class
        {

            if (Data.Count == 0)
            {
                MessageBox.Show(null, "No data to be exported.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.wb = excel.Workbooks.Add();
            Worksheet ws = this.wb.Worksheets[1];

            int HeaderCount = typeof(T).GetProperties().Count();
            object[] Header = new object[HeaderCount];
            int i = 0;
            foreach (var prop in typeof(T).GetProperties())
            {
                Header[i] = prop.Name;
                i++;
            }

            //Paste Header & format
            _excel.Range HeaderRange = ws.get_Range((_excel.Range)(ws.Cells[1, 1]), (_excel.Range)(ws.Cells[1, HeaderCount]));
            HeaderRange.Value = Header;
            HeaderRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(192, 192, 192));
            HeaderRange.Font.Bold = true;
            HeaderRange.Borders.LineStyle = XlLineStyle.xlContinuous;
            HeaderRange.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);

            //Paste cell values
            i = 2;
            object[,] Cells = new object[Data.Count, HeaderCount];
            foreach(var item in Data)
            {
                T entry = item;
                int j = 1;
                foreach (var prop in item.GetType().GetProperties())
                {
                    if(prop.GetValue(entry, null) != null)
                    {
                        ws.Cells[i, j] = prop.GetValue(entry, null).ToString();
                    }
                    j++;
                }
                i++;
            }

            ws.Columns.AutoFit();
            excel.Visible = true;

            string SavePathLocation = string.Empty;
            if(SavePath != null)
            {
                SavePathLocation = SaveAs(SavePath, AppName, FileName, ".xlsx");

                if (!File.Exists(SavePathLocation))
                {
                    MessageBox.Show(null, "File failed to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        internal void ExportDataToSheet(DataGridView dataGridView, bool Open = true, string AppName = null, string FileName = null, string SavePath = null, bool ExportFilteredView = true)
        {
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show(null, "No data to be exported.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.wb = excel.Workbooks.Add();
            Worksheet ws = this.wb.Worksheets[1];
            int i = 0;
            for (i = 1; i < dataGridView.Columns.Count + 1; i++)
            {
                ws.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
            }

            
            //Paste Header & format
            _excel.Range HeaderRange = ws.get_Range((_excel.Range)(ws.Cells[1, 1]), (_excel.Range)(ws.Cells[1, dataGridView.Columns.Count]));
            HeaderRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(192, 192, 192));
            HeaderRange.Font.Bold = true;
            HeaderRange.Borders.LineStyle = XlLineStyle.xlContinuous;
            HeaderRange.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);

            //Paste cell values
            int validRows = 0;
            for (i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                if(ExportFilteredView == false || dataGridView.Rows[i].Visible == true)
                {
                    validRows++;
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        if (dataGridView.Rows[i].Cells[j].Value != null)
                        {
                            ws.Cells[validRows + 1, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                        }
                        else
                        {
                            ws.Cells[validRows + 1, j + 1] = "";
                        }
                    }
                }
            }

            ws.Columns.AutoFit();
            excel.Visible = true;

            string SavePathLocation = string.Empty;
            if (SavePath != null)
            {
                SavePathLocation = SaveAs(SavePath, AppName, FileName, ".xlsx");

                if (!File.Exists(SavePathLocation))
                {
                    MessageBox.Show(null, "File failed to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


            /// <summary>
            /// Saves excel file in a specified location with a unique file name
            /// </summary>
            /// <param name="directoryPath">Path where you would like to save the file</param>
            /// <param name="AppName">Name of your application</param>
            /// <param name="fileName">File Name</param>
            /// <param name="fileEnding">File ending. For example, ".txt", ".csv", or ".xlsx" </param>
            /// < name="fileEnding"></param>
            /// <returns></returns>
            public string SaveAs(string directoryPath, string AppName, string fileName, string fileEnding)
        {

            //Get date
            DateTime today = DateTime.Today;
            string dateStr = today.ToString("MM.dd.yyyy");

            //Find available file name to save as
            for(int i = 0; i < 1000; i++)
            {
                StringBuilder completeFilePath = new StringBuilder();
                completeFilePath.Append(directoryPath);

                //Add backslash if missing
                if (!directoryPath.EndsWith(@"\"))
                {
                    completeFilePath.Append(@"\");
                }

                completeFilePath.Append(AppName);
                completeFilePath.Append("_");
                completeFilePath.Append(fileName);
                completeFilePath.Append("_");
                completeFilePath.Append(dateStr);
                completeFilePath.Append("_(" + i.ToString() + ")");
                completeFilePath.Append(fileEnding);

                if (!File.Exists(completeFilePath.ToString()))
                {
                    wb.SaveAs(completeFilePath.ToString());
                    return completeFilePath.ToString();
                }
                completeFilePath.Clear();
            }

            return null;
        }

        public void Close()
        {
            wb.Close();
        }

        public void CreateExcelWorkbook(string SheetName, bool MakeVisable = false)
        {
            this.wb = excel.Workbooks.Add();

            if(MakeVisable == true)
            {
                excel.Visible = true;
            }

            this.ws = this.wb.Worksheets[1];
            this.ws.Name = SheetName;
        }
    }
}
