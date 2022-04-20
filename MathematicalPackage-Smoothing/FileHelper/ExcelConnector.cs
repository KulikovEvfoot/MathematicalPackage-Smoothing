using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
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

        public void SaveMatrix(List<object> matrixInputData, double[,] matrix)
        {
            Excel.Worksheet worksheet = (Excel.Worksheet)m_Excel.ActiveSheet;
            double maxSize = Math.Sqrt(matrix.Length);
            double[] x = (double[])matrixInputData[0];
            double[] p = (double[])matrixInputData[1];
            double a = (double)matrixInputData[2];
            var step = matrixInputData.Count + 2;

            worksheet.Cells[1, 1] = "N";
            worksheet.Cells[1, 2] = "x";
            worksheet.Cells[1, 3] = "p";
            worksheet.Cells[1, 4] = "a";
            worksheet.Cells[2, 4] = a;

            worksheet.Cells[1, step] = "Matrix (N-2 х N-2)";
            worksheet.Cells[2, step] = "MatrixSize " + maxSize;

            worksheet.Cells[1, step + 1] = "0";

            for (int i = 0; i < maxSize + 2; i++)
            {
                for (int j = 0; j < matrixInputData.Count; j++)
                {
                    worksheet.Cells[i + 2, ++j] = i + 1;
                    worksheet.Cells[i + 2, ++j] = x[i];
                    worksheet.Cells[i + 2, ++j] = p[i];
                }
            }

            for (int i = 1; i < maxSize + 1; i++)
            {
                worksheet.Cells[1, step + i + 1] = i;
            }
            for (int i = 1; i < maxSize + 1; i++)
            {
                worksheet.Cells[i + 1, step + 1] = i;
            }

            for (int i = 0; i < maxSize; i++)
            {
                for (int j = 0; j < maxSize; j++)
                {
                    worksheet.Cells[i + 1 + 1, j + step + 2] = matrix[i, j];
                }
            }
            m_Workbook.Save();
            MessageBox.Show("Успешно сохранено!");
        }

        public System.Windows.Forms.DataGridView OpenTable(System.Windows.Forms.DataGridView dataGridView)
        {
            Excel.Worksheet worksheet = (Excel.Worksheet)m_Excel.Sheets.get_Item(1);
            Excel.Range ExcelRange;
            ExcelRange = worksheet.UsedRange;
            DataTable dt = new DataTable();
            for (int Cnum = 1; Cnum <= ExcelRange.Columns.Count; Cnum++)
            {
                try
                {
                    dt.Columns.Add(
                        new DataColumn((ExcelRange.Cells[1, Cnum] as Excel.Range).Value2.ToString()));
                }
                catch (Exception)
                {

                    dt.Columns.Add("");
                }
            }

            for (int Rnum = 2; Rnum <= ExcelRange.Rows.Count; Rnum++)
            {
                DataRow dr = dt.NewRow();
                for (int Cnum = 1; Cnum <= ExcelRange.Columns.Count; Cnum++)
                {
                    try
                    {
                        dr[Cnum - 1] =
                        (ExcelRange.Cells[Rnum, Cnum] as Excel.Range).Value2.ToString();
                    }
                    catch (Exception)
                    {
                        dr[Cnum - 1] = " ";
                    }
                    
                }
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            dataGridView.DataSource = dt;
            return dataGridView;
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
