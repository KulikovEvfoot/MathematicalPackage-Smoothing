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
                MaterialMessageBox.Show(ex.Message);
            }
            return dataGridView;
        }

        public void SaveCsvFile(string filePath, DataGridView dataGridView, float[] f, float a)
        {
            try
            {
                using (var sw = new StreamWriter(filePath))
                {
                    var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";" };
                    var writer = new CsvWriter(sw, config);

                    writer.WriteHeader(typeof(SplineOutputData));
                    writer.NextRecord();

                    writer.WriteRecord(f[0]);
                    writer.WriteRecord(a);
                    writer.NextRecord();

                    for (int i = 1; i < f.Length; i++)
                    {
                        writer.WriteRecord(f[i]);
                        writer.NextRecord();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Dispose()
        {
        }
    }
}
