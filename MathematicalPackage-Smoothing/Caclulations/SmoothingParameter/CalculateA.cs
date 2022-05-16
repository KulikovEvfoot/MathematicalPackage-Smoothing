using MathematicalPackage_Smoothing.Caclulations.SplineCoefficients;
using System;

namespace MathematicalPackage_Smoothing.Caclulations.SmoothingParameter
{
    public class CalculateA : CalculateP
    {
        public CalculateA(int n, float[] x) : base(n, x)
        {
            for (int i = 0; i < n - 1; i++)
            {
                h[i] = InitH(x[i], x[i + 1]);
            }
        }

        public float InitALCurve(int n, float[] x, float[] p, float[] f, float aMin, float aMax, float ds1, float ds2, BoundaryConditions leftType, BoundaryConditions rightType)
        {
            float aL = 0;
            int L = Convert.ToInt32(Math.Truncate(6 * Math.Log10(aMax / aMin)));
            float[] pL = new float[L];
            float[] localA = new float[L];
            float[] PP = new float[L];
            float[] lP = new float[L];
            float[] ly = new float[L];
            float[] la = new float[L];

            for (int i = 0; i < pL.Length; i++)
            {
                float yVector = 0;
                pL[i] = 1;

                localA[i] = aMin * (float)Math.Pow(10, (i) / 6f);

                var coefC = InitCoefC(n, x, p, f, localA[i], ds1, ds2, leftType, rightType);
                var coefD = InitCoefD(n, coefC);
                for (int j = 0; j < coefC.Length; j++)
                {
                    coefC[j] = coefC[j] / 2;
                }

                for (int j = 0; j < n - 1; j++)
                {
                    yVector += (4 * (float)Math.Pow(coefC[j], 2) * h[j]) +
                        (12 * coefC[j] * coefD[j] * (float)Math.Pow(h[j], 2)) +
                        (12 * (float)Math.Pow(coefD[j], 2) * (float)Math.Pow(h[j], 3));
                }


                PP[i] = InitPLCurve(n, x, p, f, localA[i], ds1, ds2, leftType, rightType);
                lP[i] = (float)Math.Log(PP[i]);
                ly[i] = (float)Math.Log(yVector);
                la[i] = (float)Math.Log(localA[i]);
            }

            CalculateSpline calculateSpline = new CalculateSpline(L, la);
            var d1P = calculateSpline.InitD1SplineX(L, la, pL, lP, 0, ds1, ds2, leftType, rightType);
            var d2P = calculateSpline.InitD1SplineX(L, la, pL, d1P, 0, ds1, ds2, leftType, rightType);
            var d1y = calculateSpline.InitD1SplineX(L, la, pL, ly, 0, ds1, ds2, leftType, rightType);
            var d2y = calculateSpline.InitD1SplineX(L, la, pL, d1y, 0, ds1, ds2, leftType, rightType);

            var k = new float[L];
            for (int i = 0; i < pL.Length; i++)
            {
                k[i] = 2 * (((d1P[i] * d2y[i]) - (d2P[i] * d1y[i])) /
                    (float)Math.Pow((float)Math.Pow(d1P[i], 2) + (float)Math.Pow(d1y[i], 2), 3f / 2f));
            }

            float max = -1;
            int index = -1;
            for (int i = 0; i < k.Length; i++)
                if (max <= k[i])
                {
                    max = k[i];
                    index = i;
                }

            aL = localA[index];
            return aL;
        }

        //public float InitAOptimality(int n, float[] h, float[] p, float[] f, float[,] matrix, float[] vector, float noise)
        //{
        //    float o1 = n;
        //    float o2 = n + 3 * (float)Math.Sqrt(2 * n);
        //    float a = (float)Math.Pow(10, 20);
        //    float a1 = -40;
        //    float a2 = 40;
        //    float localA = 0;
        //    float y = 0;
        //    float P = 0;
        //    float z = InitPOptimality(n, h, p, f, noise, matrix, vector, (float)Math.Pow(10, a1)) - n;
        //    if (Single.IsInfinity(z))
        //    {
        //        z = 0 - n;
        //    }
        //    for (int i = 0; i < 300; i++)
        //    {
        //        localA = (a1 + a2) / 2;
        //        P = InitPOptimality(n, h, p, f, noise, matrix, vector, (float)Math.Pow(10, localA));
        //        if (Single.IsInfinity(P))
        //        {
        //            P = 0;
        //        }

        //        if ((o1 <= P) && (o2 >= P))
        //        {
        //            a = (float)Math.Pow(10, localA);
        //            break;
        //        }

        //        y = P - n;

        //        if (y * z > 0)
        //        {
        //            a1 = localA;
        //            z = y;
        //        }
        //        else
        //        {
        //            a2 = localA;
        //        }
        //    }
        //    return a;
        //}
    }
}
