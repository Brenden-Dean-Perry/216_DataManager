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
        Workbook workbook;
        Worksheet worksheet;

        internal void ExportDataToSheet<T>(IList<T> Data, bool Open = true, string SavePath = null, string FileName = null)
        {

            if (Data.Count == 0)
            {
                MessageBox.Show(null, "No data to be exported.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Worksheet ws = excel.Sheets[0];
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
            i = 0;
            int j = 0;
            object[,] Cells = new object[Data.Count, HeaderCount];
            foreach(T item in Data)
            {
                foreach (var prop in item.GetType().GetProperties())
                {
                    Cells[i, j] = prop.GetValue(null).ToString();
                    j++;
                }
                i++;
            }

            ws.get_Range((_excel.Range)(ws.Cells[2, 1]), (_excel.Range)(ws.Cells[Data.Count + 1, HeaderCount + 1])).Value = Cells;
            ws.Columns.AutoFit();
        
        }
    }
}
