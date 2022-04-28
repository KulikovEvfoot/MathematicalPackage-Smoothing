using System;
using System.Windows.Forms;

namespace MathematicalPackage_Smoothing.Caclulations
{
    public class CalculateSpline : InitCoefficients
    {
        public float[] InitSplineX(int n, float[] h, float[] p, float[] f, float a, float[,] matrix, float[] vector)
        {
            var CoefC = InitCoefC(matrix, vector);
            var CoefA = InitCoefA(n, h, p, f, a, CoefC);
            var spline = new float[CoefA.Length];
            for (int i = 0; i < CoefA.Length; i++)
            {
                spline[i] = CoefA[i];
            }
            return spline;
        }

        public float[] InitD1SplineX(int n, float[] x, float[] h, float[] p, float[] f, float a, float[,] matrix, float[] vector)
        {
            var coefC = InitCoefC(matrix, vector);
            var coefA = InitCoefA(n, h, p, f, a, coefC);
            var coefB = InitCoefB(n, h, coefA, coefC);
            var coefD = InitCoefD(n,h,coefC);
            var dSpline = new float[coefB.Length];

            for (int i = 0; i < coefB.Length - 1; i++)
            {
                dSpline[i] = coefB[i];
            }
            dSpline[n - 1] = coefB[n - 2] + coefC[n - 2] * (x[n - 1] - x[n - 2]) + 3 * coefD[n - 2] * (float)Math.Pow((x[n - 1] - x[n - 2]), 2);

            return dSpline;
        }

        public void ShowSpline(float[] spline)
        {
            string s = string.Empty;
            for (int i = 0; i < spline.Length; i++)
            {
                s += spline[i] + "\n";
            }
            MessageBox.Show(s);
        }
    }
}
