﻿using System;
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
                openFileDialog.Filter = "(*.xlsx) | *.xlsx";
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
