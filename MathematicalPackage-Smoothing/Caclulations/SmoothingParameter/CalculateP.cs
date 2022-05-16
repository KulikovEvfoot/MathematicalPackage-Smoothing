using System;
using MathematicalPackage_Smoothing.Caclulations.SplineCoefficients;

namespace MathematicalPackage_Smoothing.Caclulations.SmoothingParameter
{
    public class CalculateP : InitCoefficients
    {

        protected CalculateP(int n, float[] x) : base(n, x)
        {
            for (int i = 0; i < n - 1; i++)
            {
                h[i] = InitH(x[i], x[i + 1]);
            }
        }

        protected float InitPLCurve(int n, float[] x, float[] p, float[] f, float a, float ds1, float ds2, BoundaryConditions leftType, BoundaryConditions rightType)
        {
            float P = 0;
            CalculateSpline calculateSpline = new CalculateSpline(n, x);
            var spline = calculateSpline.InitSplineX(n, x, p, f, a, ds1, ds2, leftType, rightType);
            for (int i = 0; i < spline.Length; i++)
            {
                P += (float)Math.Pow(p[i], -1) * (float)Math.Pow(f[i] - spline[i], 2);
            }

            return P;
        }


        protected float InitPOptimality(int n, float[] x, float[] p, float[] f, float noise, float a, float ds1, float ds2, BoundaryConditions leftType, BoundaryConditions rightType)
        {
            float P = 0;
            var coefC = InitCoefC(n, x, p, f, a, ds1, ds2, leftType, rightType);
            var coefA = InitCoefA(n, p, f, a, coefC);

            float[] e = new float[coefA.Length];
            for (int i = 0; i < coefA.Length; i++)
            {
                e[i] = f[i] - coefA[i];
            }

            for (int i = 0; i < e.Length; i++)
            {
                P += (e[i] * f[i]) / noise;
            }
            return P;
        }
    }
}
