using System;
using System.Collections.Generic;
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

            worksheet.Cells[1, 1] = "Input data";
            worksheet.Cells[2, 1] = "N";
            worksheet.Cells[2, 2] = "x";
            worksheet.Cells[2, 3] = "p";
            worksheet.Cells[2, 4] = "a";
            worksheet.Cells[3, 4] = a;

            for (int i = 0; i < maxSize + 2; i++)
            {
                for (int j = 0; j < matrixInputData.Count; j++)
                {
                    worksheet.Cells[i + 1 + 2, ++j] = i + 1;
                    worksheet.Cells[i + 1 + 2, ++j] = x[i];
                    worksheet.Cells[i + 1 + 2, ++j] = p[i];
                }
            }


            var step = matrixInputData.Count + 3;
            worksheet.Cells[1, step] = "Matrix (N-2 х N-2)";
            worksheet.Cells[2, step] = "MatrixSize " + maxSize;
            for (int i = 0; i < maxSize; i++)
            {
                for (int j = 0; j < maxSize; j++)
                {
                    worksheet.Cells[i + 1 + 2, j + step] = matrix[i, j];
                }
            }
            m_Workbook.Save();
            MessageBox.Show("Успешно сохранено!");
        }

        public double[,] PullOutMatrix(double[,] matrix)
        {
            try
            {
                Excel.Worksheet worksheet = (Excel.Worksheet)m_Excel.ActiveSheet;
                int matrixSize;
                string matrixSizeExcel = worksheet.Cells[2, 6].Text.ToString();
                if (!int.TryParse(string.Join("", matrixSizeExcel.Where(c => char.IsDigit(c))), out matrixSize))
                {
                    return matrix;
                };

                matrix = new double[matrixSize, matrixSize];

                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {
                        string x = worksheet.Cells[i + 3, j + 6].Text.ToString();
                        matrix[i, j] = Convert.ToDouble(x);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не получается правильно обнаружить данные");
            }
            MessageBox.Show("Матрица взята!");
            return matrix;
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
