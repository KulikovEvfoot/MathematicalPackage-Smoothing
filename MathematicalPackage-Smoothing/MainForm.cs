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
using LiveCharts.Wpf;
using LiveCharts;
using LiveCharts.Defaults;

namespace MathematicalPackage_Smoothing
{
    public partial class MainForm : MaterialForm
    {
        public MainForm()
        {
            InitializeComponent();
            var formDesigner = new FormDesigner();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }


        private void OpenExcelButton_Click(object sender, EventArgs e)
        {

        }

        private void FormMatrixButton_Click(object sender, EventArgs e)
        {
            double[] f = new double[14] { 0, 0.027, 0.072, 0.108, 0.129, 0.135, 0.131, 0.119, 0.104, 0.089, 0.073, 0.059, 0.047, 0.037 };
            //double[] f = new double[14] { 0, 0.027, 0.072, 0.120, 0.150, 0.135, 0.1, 0.119, 0.104, 0.2, 0.073, 0.059, 0.047, 0.037 };

            InitMatrix initMatrix = new InitMatrix(14, 0.01f);
            initMatrix.CreateMatrix();
            WindowOpener windowOpener = new WindowOpener();
            if (windowOpener.filePath != null)
            {
                using (ExcelConnector excelConnector = new ExcelConnector())
                {
                    if (excelConnector.OpenExcelFile(windowOpener.filePath))
                    {
                        excelConnector.SaveMatrix(initMatrix.matrixInputData, initMatrix.matrix);
                        dataGridView1 = excelConnector.OpenTable(dataGridView1);
                    }
                }
            }

            FormVector formVector = new FormVector(14, f, initMatrix.m_X, initMatrix.m_H);

            CalculateSpline calculateSpline = new CalculateSpline();
            var spline = calculateSpline.InitSplineX(14, 
                initMatrix.m_X,
                initMatrix.m_H,
                initMatrix.m_P,
                f,
                0.01,
                initMatrix.matrix,
                formVector.vector);

            float j = -0.2f;
            var sp = new ChartValues<ObservablePoint>();
            for (int i = 0; i < spline.Length; i++)
            {
                j += 0.2f;
                sp.Add(new ObservablePoint(j, spline[i])); 
            }

            float jj = -0.2f;
            var ff = new ChartValues<ObservablePoint>();
            for (int i = 0; i < f.Length; i++)
            {
                jj += 0.2f;
                ff.Add(new ObservablePoint(jj, f[i]));
            }

            MainCartesianChart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = sp,
                    Fill = System.Windows.Media.Brushes.Transparent
                },
                new LineSeries
                {
                    Values = ff,
                    Fill = System.Windows.Media.Brushes.Transparent
                }
            };

            string s = "";
            for (int i = 0; i < spline.Length; i++)
            {
                s += i+1 + " "  + spline[i] + "\n";
            }
            MessageBox.Show(s);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            WindowOpener windowOpener = new WindowOpener();
            if (windowOpener.filePath != null)
            {
                using (ExcelConnector excelConnector = new ExcelConnector())
                {
                    if (excelConnector.OpenExcelFile(windowOpener.filePath))
                    {
                        dataGridView1 = excelConnector.OpenTable(dataGridView1);
                    }
                }
            }
        }
    }
}
