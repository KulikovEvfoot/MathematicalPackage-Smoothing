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
using MathematicalPackage_Smoothing.FileHelper;
using MathematicalPackage_Smoothing.Charts;
using MathematicalPackage_Smoothing.Caclulations.Matrices;
using MathematicalPackage_Smoothing.Caclulations.Vectors;
using MathematicalPackage_Smoothing.Caclulations.SplineCoefficients;

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

        }

        private void CalcType2_0()
        {
            int n1 = 100; //100
            float x1 = 0.02f; //0.02f
            float a1 = 0.003162f;// 0.003162f;
            //float[] f = new float[14] { 0, 0.027f, 0.072f, 0.108f, 0.129f, 0.135f, 0.131f, 0.119f, 0.104f, 0.089f, 0.073f, 0.059f, 0.047f, 0.037f };
            float[] f = new float[n1];

            InitMatrixType2_0 initMatrix = new InitMatrixType2_0(n1, x1, a1);
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

            FormVectorType2_0 formVector = new FormVectorType2_0(n1, f, initMatrix.h);

            CalculateSpline calculateSpline = new CalculateSpline();
            var spline = calculateSpline.InitSplineXType2_0(
                n1,
                initMatrix.h,
                initMatrix.p,
                f,
                a1,
                initMatrix.matrix,
                formVector.vector);

            var d1Spline = calculateSpline.InitD1SplineXType2_0(
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

        private void CalcType1() 
        {
            int n1 = 100; //100
            float x1 = 0.02f; //0.02f
            float a1 = 0.0007499f;// 0.003162f; //0.0007499f;
            float[] f = new float[n1];
            float ds1 = 0.04f;
            float ds2 = 0.001f;

            InitMatrixType1 initMatrix = new InitMatrixType1(n1, x1, a1);
            initMatrix.CreateMatrix();

            WindowOpener windowOpener = new WindowOpener();
            if (!string.IsNullOrEmpty(windowOpener.filePath))
            {
                using (ExcelConnector excelConnector = new ExcelConnector())
                {
                    if (excelConnector.OpenExcelFile(windowOpener.filePath))
                    {
                        //excelConnector.SaveMatrix2(initMatrix.matrix);
                        //dataGridView1 = excelConnector.OpenTable(dataGridView1);
                        f = excelConnector.InitVectrorFFromExcel(f);
                    }
                }
            }

            FormVectorType1 formVector = new FormVectorType1(n1, f, initMatrix.h, ds1, ds2);

            CalculateSpline calculateSpline = new CalculateSpline();
            var spline = calculateSpline.InitSplineXType1Or2(
                n1,
                initMatrix.h,
                initMatrix.p,
                f,
                a1,
                initMatrix.matrix,
                formVector.vector);

            var d1Spline = calculateSpline.InitD1SplineXType1Or2(
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

        private void CalcType2()
        {
            int n1 = 100; //100
            float x1 = 0.02f; //0.02f
            float a1 = 0.0007499f;// 0.003162f; //0.0007499f;
            float[] f = new float[n1];
            float ds1 = 0.04f;
            float ds2 = 0.001f;

            InitMatrixType2 initMatrix = new InitMatrixType2(n1, x1, a1);
            initMatrix.CreateMatrix();

            WindowOpener windowOpener = new WindowOpener();
            if (!string.IsNullOrEmpty(windowOpener.filePath))
            {
                using (ExcelConnector excelConnector = new ExcelConnector())
                {
                    if (excelConnector.OpenExcelFile(windowOpener.filePath))
                    {
                        //excelConnector.SaveMatrix2(initMatrix.matrix);
                        //dataGridView1 = excelConnector.OpenTable(dataGridView1);
                        f = excelConnector.InitVectrorFFromExcel(f);
                    }
                }
            }

            FormVectorType2 formVector = new FormVectorType2(n1, f, initMatrix.h, 0, 0);

            CalculateSpline calculateSpline = new CalculateSpline();
            var spline = calculateSpline.InitSplineXType1Or2(
                n1,
                initMatrix.h,
                initMatrix.p,
                f,
                a1,
                initMatrix.matrix,
                formVector.vector);

            var d1Spline = calculateSpline.InitD1SplineXType1Or2(
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

        private void ChooseD1()
        {
            int n1 = 100; //100
            float x1 = 0.02f; //0.02f
            float a1 = 0.0007499f;// 0.003162f; //0.0007499f;
            float[] f = new float[n1];
            float ds1 = 0.04f;
            float ds2 = 0.001f;

            InitMatrixType2_0 initMatrix2_0 = new InitMatrixType2_0(n1, x1, 0.003162f);
            initMatrix2_0.CreateMatrix();
            InitMatrixType1 initMatrix1 = new InitMatrixType1(n1, x1, a1);
            initMatrix1.CreateMatrix();
            InitMatrixType2 initMatrix2 = new InitMatrixType2(n1, x1, a1);
            initMatrix2.CreateMatrix();

            WindowOpener windowOpener = new WindowOpener();
            if (!string.IsNullOrEmpty(windowOpener.filePath))
            {
                using (ExcelConnector excelConnector = new ExcelConnector())
                {
                    if (excelConnector.OpenExcelFile(windowOpener.filePath))
                    {
                        //excelConnector.SaveMatrix2(initMatrix2.matrix);
                        //dataGridView1 = excelConnector.OpenTable(dataGridView1);
                        f = excelConnector.InitVectrorFFromExcel(f);
                    }
                }
            }



            FormVectorType2_0 formVector2_0 = new FormVectorType2_0(n1, f, initMatrix2_0.h);
            FormVectorType1 formVector1 = new FormVectorType1(n1, f, initMatrix1.h, ds1, ds2);
            FormVectorType2 formVector2 = new FormVectorType2(n1, f, initMatrix2.h, 0, 0);

            CalculateSpline calculateSpline = new CalculateSpline();

            var d1Spline2_0 = calculateSpline.InitD1SplineXType2_0(
                n1,
                initMatrix2_0.m_X,
                initMatrix2_0.h,
                initMatrix2_0.p,
                f,
                0.003162f,
                initMatrix2_0.matrix,
                formVector2_0.vector);

            var d1Spline1 = calculateSpline.InitD1SplineXType1Or2(
                n1,
                initMatrix1.m_X,
                initMatrix1.h,
                initMatrix1.p,
                f,
                0.0007499f,
                initMatrix1.matrix,
                formVector1.vector);

            var d1Spline2 = calculateSpline.InitD1SplineXType1Or2(
                n1,
                initMatrix2.m_X,
                initMatrix2.h,
                initMatrix2.p,
                f,
                0.0007499f,
                initMatrix2.matrix,
                formVector2.vector);


            ChartsEditor splineChart = new ChartsEditor();
            splineChart.InputChart(d1Spline2_0, x1);
            splineChart.InputChart(d1Spline1, x1);
            splineChart.InputChart(d1Spline2, x1);
            splineChart.ShowSpline(MainCartesianChart);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            //ChooseD1();
            //CalcType1();
            CalcType2();
        }
    }
}
