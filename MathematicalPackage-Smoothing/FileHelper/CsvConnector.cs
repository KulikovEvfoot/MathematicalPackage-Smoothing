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
                CreateReader(filePath);
                List<SplineData> splineData = csvReader.GetRecords<SplineData>().ToList();
                dataGridView.DataSource = splineData;
                return dataGridView;
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
            return dataGridView;
        }

        public void SaveCsvFile(string filePath, DataGridView dataGridView)
        {
            try
            {
                using (var sw = new StreamWriter(filePath))
                {
                    var writer = new CsvWriter(sw, CultureInfo.InvariantCulture);
                    foreach (SplineData item in dataGridView.DataSource as List<SplineData>)
                    {
                        writer.WriteRecord(item);
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
            streamReader.Close();
        }

        private StreamReader streamReader;
        private CsvReader csvReader;
        private void CreateReader(string filePath)
        {
            streamReader = new StreamReader(new FileStream(filePath, FileMode.Open));
            var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";" };
            csvReader = new CsvReader(streamReader, config);
        }
    }
}
