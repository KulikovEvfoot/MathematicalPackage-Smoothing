using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalPackage_Smoothing.Caclulations
{
    public class InitCoefficients : MatrixCalculation
    {
        public double[] InitCoefC(double[,] matrix, double[] vector)
        {
            var solve = new double[vector.Length];
            var coefC = new double[vector.Length + 2];

            for (int i = 0; i < solve.Length; i++)
            {
                for (int j = 0; j < solve.Length; j++)
                {
                    solve[i] += matrix[i, j] * vector[i];
                }
            }

            coefC[0] = 0;
            for (int i = 1; i < coefC.Length - 1; i++)
            {
                coefC[i] = solve[i - 1];
            }
            coefC[coefC.Length - 1] = 0;
            return coefC;
        }

        public double[] InitCoefA(int n,double[] x, double[] h, double[] p, double[] f, double a, double[] CoefC)
        {
            var coefA = new double[n];

            x = new double[n];
            h = new double[n];

            for (int i = 0; i < n; i++)
            {
                x[i] = InitX(i);
            }

            for (int i = 0; i < n - 1; i++)
            {
                h[i] = InitH(x[i], x[i + 1]);
            }

            for (int i = 0; i < n; i++)
            {
                p[i] = InitP();
            }

            for (int i = 1; i < coefA.Length - 1; i++)
            {
                coefA[i] = f[i] - a * p[i] * (((CoefC[i + 1] - CoefC[i]) / h[i]) - (CoefC[i] - CoefC[i - 1]) / h[i - 1]);
            }

            coefA[0] = f[0] - a * p[0] * ((CoefC[1] - CoefC[0]) / h[0]);
            coefA[n - 1] = f[n - 1] - a * p[n - 1] * ((CoefC[n - 2] - CoefC[n - 1]) / h[n - 2]);

            return coefA;
        }
    }
}
