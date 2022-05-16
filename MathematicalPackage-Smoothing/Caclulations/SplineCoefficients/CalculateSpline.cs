using System;
using System.Windows.Forms;

namespace MathematicalPackage_Smoothing.Caclulations.SplineCoefficients
{
    public class CalculateSpline : InitCoefficients
    {
        public CalculateSpline(int n, float[] x) : base(n, x) 
        {
            for (int i = 0; i < n - 1; i++)
            {
                h[i] = InitH(x[i], x[i + 1]);
            }
        }

        public float[] InitSplineX(int n, float[] x, float[] p, float[] f, float a, float ds1, float ds2, BoundaryConditions leftType, BoundaryConditions rightType)
        {
            var coefC = InitCoefC(n, x, p, f, a, ds1, ds2 , leftType, rightType);
            var coefA = InitCoefA(n, p, f, a, coefC);
            var spline = new float[coefA.Length];
            for (int i = 0; i < coefA.Length; i++)
            {
                spline[i] = coefA[i];
            }
            return spline;
        }

        public float[] InitD1SplineX(int n, float[] x, float[] p, float[] f, float a, float ds1, float ds2, BoundaryConditions leftType, BoundaryConditions rightType)
        {
            var coefC = InitCoefC(n, x, p, f, a, ds1, ds2, leftType, rightType);
            var coefA = InitCoefA(n, p, f, a, coefC);
            var coefB = InitCoefB(n, coefA, coefC);
            var coefD = InitCoefD(n, coefC);
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
