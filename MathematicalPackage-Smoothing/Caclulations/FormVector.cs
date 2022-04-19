using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalPackage_Smoothing.Caclulations
{
    public class FormVector : MatrixCalculation
    {
        public double[] vector;
        public FormVector(int n, double[] f, double[] x, double[] h)
        {
            vector = new double[n-2];
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

            for (int j = 0; j < n - 3; j++)
            {
                int i = j + 1;
                vector[j] = (f[i - 1] - f[i]) / h[i - 1] + (f[i + 1] - f[i]) / h[i];
            }
        }
    }
}
