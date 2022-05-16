using System;
using MaterialSkin.Controls;
using MathematicalPackage_Smoothing.Design;
using MathematicalPackage_Smoothing.FileHelper;
using MathematicalPackage_Smoothing.Charts;
using MathematicalPackage_Smoothing.Caclulations.Matrices;
using MathematicalPackage_Smoothing.Caclulations.Vectors;
using MathematicalPackage_Smoothing.Caclulations.SplineCoefficients;
using MathematicalPackage_Smoothing.Caclulations;
using MathematicalPackage_Smoothing.Caclulations.SmoothingParameter;

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

        private void Calc()
        {

            BoundaryConditions leftType = BoundaryConditions.Type_2;
            BoundaryConditions rightType = BoundaryConditions.Type_2;
            int n1 = 100; //100
            float[] x1 = new float[n1];
            float[] p1 = new float[n1];
            float a1 = 0.006813f; //type 20 L
            a1 = 0.002154f; //type 1 L
            a1 = 0.007499f; // type 1 Op
            a1 = 0.003162f; // type 20 op
            //a1 = 0.001f;
            float[] f = new float[n1];

            for (int i = 0; i < x1.Length; i++)
            {
                p1[i] = 1;
                x1[i] += 0.02f * i;
            }

            float ds1 = 0.04f;
            float ds2 = 0.001f;
            if (leftType == BoundaryConditions.Type_2)
            {
                ds1 = 0;
            }
            if (rightType == BoundaryConditions.Type_2)
            {
                ds2 = 0;
            }

            float aMin = 0.000001f;
            float aMax = 1f;

            //---------------------------


            WindowOpener windowOpener = new WindowOpener();
            if (!string.IsNullOrEmpty(windowOpener.filePath))
            {
                using (ExcelConnector excelConnector = new ExcelConnector())
                {
                    if (excelConnector.OpenExcelFile(windowOpener.filePath))
                    {
                        //excelConnector.SaveMatrix2(initMatrix.matrix);
                        f = excelConnector.InitVectrorFFromExcel(f);
                    }
                }
            }

            CalculateA calculateA = new CalculateA(n1, x1);
            a1 = calculateA.InitALCurve(
                n1,
                x1,
                p1,
                f,
                aMin,
                aMax,
                ds1,
                ds2,
                leftType,
                rightType);

            MaterialMessageBox.Show(a1.ToString());

            InitMatrix initMatrix = new InitMatrix(
                n1,
                x1,
                p1,
                a1,
                leftType,
                rightType);





            FormVector formVector = new FormVector(n1, x1, f, ds1, ds2, leftType, rightType);

            //WindowOpener windowOpener2 = new WindowOpener();
            //if (!string.IsNullOrEmpty(windowOpener2.filePath))
            //{
            //    using (ExcelConnector excelConnector = new ExcelConnector())
            //    {
            //        if (excelConnector.OpenExcelFile(windowOpener2.filePath))
            //        {
            //            //excelConnector.SaveMatrix2(initMatrix.matrix);
            //            f = excelConnector.InitVectrorFFromExcel(f);
            //            //excelConnector.SaveVector(formVector.vector);
            //        }
            //    }
            //}

            CalculateSpline calculateSpline = new CalculateSpline(
                n1,
                x1);
            var spline = calculateSpline.InitSplineX(
                n1,
                x1,
                p1,
                f,
                a1,
                ds1,
                ds2,
                leftType,
                rightType);

            var d1Spline = calculateSpline.InitD1SplineX(
                n1,
                x1,
                p1,
                f,
                a1,
                ds1,
                ds2,
                leftType,
                rightType);

            ChartsEditor chartsEditor = new ChartsEditor();
            chartsEditor.InputChart(spline, 0.02f);
            chartsEditor.InputChart(f, 0.02f);
            chartsEditor.InputChart(d1Spline, 0.02f);
            chartsEditor.ShowSpline(MainCartesianChart);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            Calc();
        }

        private void ChooseMatrixButton_Click(object sender, EventArgs e)
        {

        }
    }
}
