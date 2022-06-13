using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;
using MaterialSkin.Controls;

namespace MathematicalPackage_Smoothing.FileHelper
{
    public class CsvConnector : IDisposable
    {
        public DataGridView PullData(string filePath, DataGridView dataGridView)
        {
            try
            {
                StreamReader streamReader = new StreamReader(new FileStream(filePath, FileMode.Open));
                var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";" };
                CsvReader csvReader = new CsvReader(streamReader, config);
                List<SplineInputData> splineData = csvReader.GetRecords<SplineInputData>().ToList();
                dataGridView.DataSource = splineData;
                
                return dataGridView;
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.ToString());
                dataGridView.Columns.Clear();
                MaterialMessageBox.Show("Incorrect input data format");
            }
            return dataGridView;
        }

        public void SaveCsvFile(string filePath, DataGridView dataGridView, float[] X, float[] F, float[] Fn)
        {
            try
            {
                using (var sw = new StreamWriter(filePath))
                {
                    var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";" };
                    var writer = new CsvWriter(sw, config);

                    writer.WriteHeader(typeof(SplineOutputData));
                    writer.NextRecord();
                    for (int i = 0; i < X.Length; i++)
                    {
                        writer.WriteRecord(X[i]);
                        writer.WriteRecord(F[i]);
                        writer.WriteRecord(Fn[i]);
                        writer.NextRecord();
                    }
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show("Failed to save data");
            }
        }

        public void Dispose()
        {
        }
    }
}
