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
using MathematicalPackage_Smoothing.Caclulations;
using MathematicalPackage_Smoothing.FileHelper;
using MathematicalPackage_Smoothing.Charts;

namespace MathematicalPackage_Smoothing
{
    public partial class MainForm : MaterialForm
    {
        public MainForm()
        {
            InitializeComponent();
            var formDesigner = new FormDesigner();  
        }

        private void FormMatrixButton_Click(object sender, EventArgs e)
        {
            int n1 = 100; //100
            float x1 = 0.02f; //0.02f
            float a1 = 0.003162f;// 0.003162f;
            //float[] f = new float[14] { 0, 0.027f, 0.072f, 0.108f, 0.129f, 0.135f, 0.131f, 0.119f, 0.104f, 0.089f, 0.073f, 0.059f, 0.047f, 0.037f };
            float[] f = new float[n1];

            InitMatrix initMatrix = new InitMatrix(n1, x1, a1);
            initMatrix.CreateMatrix();

            WindowOpener windowOpener = new WindowOpener();
            if (!string.IsNullOrEmpty(windowOpener.filePath))
            {
                using (ExcelConnector excelConnector = new ExcelConnector())
                {
                    if (excelConnector.OpenExcelFile(windowOpener.filePath))
                    {
                        //excelConnector.SaveMatrix(initMatrix.matrixInputData, initMatrix.matrix);
                        //dataGridView1 = excelConnector.OpenTable(dataGridView1);
                        f = excelConnector.InitVectrorFFromExcel(f);
                    }
                }
            }

            FormVector formVector = new FormVector(n1, f, initMatrix.h);

            CalculateSpline calculateSpline = new CalculateSpline();
            var spline = calculateSpline.InitSplineX(
                n1,
                initMatrix.h,
                initMatrix.p,
                f,
                a1,
                initMatrix.matrix,
                formVector.vector);

            var d1Spline = calculateSpline.InitD1SplineX(
                n1,
                initMatrix.m_X,
                initMatrix.h,
                initMatrix.p,
                f,
                a1,
                initMatrix.matrix,
                formVector.vector);

            ChartsEditor splineChart = new ChartsEditor();
            splineChart.InputChart(spline, x1);
            splineChart.InputChart(f, x1);
            splineChart.InputChart(d1Spline, x1);
            splineChart.ShowSpline(MainCartesianChart);
        }
    }
}
