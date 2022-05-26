using MaterialSkin.Controls;
using System;
using System.IO;
using System.Windows.Forms;

namespace MathematicalPackage_Smoothing.FileHelper
{
    public class WindowOpener
    {
        public string OpenFile()
        {
            string filePath = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                openFileDialog.Filter = "Csv Files|*.csv;";
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
                        MaterialMessageBox.Show(ex.Message);
                    }
                }
            }
            return filePath;
        }

        public string SaveFile()
        {
            string filePath = "";
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                saveFileDialog.Filter = "Csv Files|*.csv;";
                saveFileDialog.Title = "Выберите документ для сохранения данных";
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        filePath = saveFileDialog.FileName;
                    }
                    catch (Exception ex)
                    {
                        MaterialMessageBox.Show(ex.Message);
                    }
                }
            }
            return filePath;
        }

        public string SavePngFile()
        {
            string filePath = "";
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                saveFileDialog.Filter = "Png Files|*.png;";
                saveFileDialog.Title = "Выберите документ для сохранения данных";
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        filePath = saveFileDialog.FileName;
                    }
                    catch (Exception ex)
                    {
                        MaterialMessageBox.Show(ex.Message);
                    }
                }
            }
            return filePath;
        }
    }
}
