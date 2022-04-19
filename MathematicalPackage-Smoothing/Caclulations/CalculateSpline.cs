using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalPackage_Smoothing.Caclulations
{
    public class CalculateSpline : InitCoefficients
    {
        public double[] InitSplineX(int n, double[] x, double[] h, double[] p, double[] f, double a, double[,] matrix, double[] vector)
        {
            var CoefC = InitCoefC(matrix, vector);
            var CoefA = InitCoefA(n, x, h, p, f, a, CoefC);
            var spline = new double[CoefA.Length];
            for (int i = 0; i < CoefA.Length; i++)
            {
                spline[i] = CoefA[i];
            }
            return spline;
        }
    }
}
