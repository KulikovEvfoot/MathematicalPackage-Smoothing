using System;

namespace MathematicalPackage_Smoothing.Caclulations
{
    public class MatrixCalculation
    {
        protected double InitH(double x1, double x2)
        {
            return x2 - x1;
        }

        protected double InitLambda(double h1, double h2, double a, double p1, double p2, double p3)
        {
            return ((h1 + h2) / 3) +  a * (((p1 + p2) / Math.Pow(h1 ,2)) + 
                                           ((p2 + p3) / Math.Pow(h2, 2)) + 
                                           ((2 * p2)  / (h1 * h2)));
        }

        protected double InitX(int i)
        {
            return 0.2f * (i);
        }

        protected double InitP()
        {
            return 1;
        }

        protected double InitFirstMu(double firstH, double a, double firstP, double secondP, double secondH)
        {
            return  (firstH / 6) - a * ((firstP / Math.Pow(firstH, 2)) + 
                                       ((secondP / firstH) * ((1 / firstH) + (1 / secondH))));
        }

        protected double InitLastMu(double h1, double a, double p1, double p2, double h2)
        {
            return (h1 / 6) - a * ((p1 / Math.Pow(h1, 2)) +
                                  ((p2 / h1) * ((1 / h2) + (1 / h1))));
        }

        protected double InitMu(double h1, double a, double p1, double h2, double p2, double h3)
        {
            return (h1 / 6) - (a / h1) * (p1 * ((1 / h2) + (1 / h1)) + p2 * ((1 / h1) + (1 / h3)));
        }

        protected double InitBeta(double a, double p1, double h1, double h2)
        {
            return a * (p1 / (h1 + h2));
        }
    }
}
