using System;
using System.IO;
using System.Windows.Forms;

namespace MathematicalPackage_Smoothing.FileHelper
{
    public class WindowOpener
    {
        public string filePath;

        public WindowOpener()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                openFileDialog.Filter = "Csv Files|*.csv;*.xls;*.xlsx;*.xlsm";
                openFileDialog.Title = "Выберите документ для загрузки данных";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        filePath = openFileDialog.FileName;
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
