using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using MathematicalPackage_Smoothing.Design;
using System.Numerics;
using MathematicalPackage_Smoothing.Caclulations;
using MathematicalPackage_Smoothing.FileHelper;

namespace MathematicalPackage_Smoothing
{
    public partial class MainForm : MaterialForm
    {
        InitMatrix formMatrix = new InitMatrix(14, 0.01f);
        public MainForm()
        {
            InitializeComponent();
            var formDesigner = new FormDesigner();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            formMatrix.CreateMatrix();
        }

        private void ChooseExcelButton_Click(object sender, EventArgs e)
        {
            WindowOpener windowOpener = new WindowOpener();
            using (ExcelConnector excelConnector = new ExcelConnector())
            {
                if (excelConnector.OpenExcelFile(windowOpener.filePath))
                {
                    excelConnector.Set(formMatrix.matrix);
                }
                MessageBox.Show("end0");
            }
        }
    }
}
