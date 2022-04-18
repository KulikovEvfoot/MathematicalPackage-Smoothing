using System;
using System.IO;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;

namespace MathematicalPackage_Smoothing.FileHelper
{
    public class ExcelConnector : IDisposable
    {
        public ExcelConnector()
        {
            m_Excel = new Excel.Application();
        }

        public bool OpenExcelFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    m_Workbook = m_Excel.Workbooks.Open(filePath);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public void Set(float[,] matrix)
        {
            Excel.Worksheet worksheet = (Excel.Worksheet)m_Excel.ActiveSheet;
            for (int i = 1; i < Math.Sqrt(matrix.Length) - 5; i++)
            {
                for (int j = 1; j < Math.Sqrt(matrix.Length) - 5; j++)
                {
                    worksheet.Cells[i, j] = matrix[i, j];
                }
            }
            m_Workbook.Save();
        }

        public void Dispose()
        {
            try
            {
                m_Workbook.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Excel.Application m_Excel;
        private Excel.Workbook m_Workbook;
    }
}
