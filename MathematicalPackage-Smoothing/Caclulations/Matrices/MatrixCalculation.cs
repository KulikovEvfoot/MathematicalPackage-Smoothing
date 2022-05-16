using System;

namespace MathematicalPackage_Smoothing.Caclulations.Matrices
{
    public class MatrixCalculation : MatrixInputData
    {
        protected float InitLambda(float h1, float h2, float a, float p1, float p2, float p3)
        {
            return ((h1 + h2) / 3) +  a * (((p1 + p2) / (float)Math.Pow(h1 ,2)) + 
                                           ((p2 + p3) / (float)Math.Pow(h2, 2)) + 
                                           ((2 * p2)  / (h1 * h2)));
        }

        protected float InitMu(float h1, float a, float p1, float h2, float p2, float h3)
        {
            return (h1 / 6) - (a / h1) * (p1 * ((1 / h2) + (1 / h1)) + p2 * ((1 / h1) + (1 / h3)));
        }

        protected float InitBeta(float a, float p1, float h1, float h2)
        {
            return a * (p1 / (h1 * h2));
        }

        // type 1
        protected float InitFirstLambdaType1(float h1, float a, float p1, float p2)
        {
            return (h1 / 3) + a * ((p1 + p2) / (float)Math.Pow(h1, 2));
        }

        protected float InitLastLambdaType1(float h1, float a, float p1, float p2)
        {
            return (h1 / 3) + a * ((p1 + p2) / (float)Math.Pow(h1, 2));
        }

        protected float InitFirstMuType1(float firstH, float a, float firstP, float secondP, float secondH)
        {
            return (firstH / 6) - a * ((firstP / (float)Math.Pow(firstH, 2)) +
                                       ((secondP / firstH) * ((1 / firstH) + (1 / secondH))));
        }

        protected float InitLastMuType1(float h1, float a, float p1, float p2, float h2)
        {
            return (h1 / 6) - a * ((p1 / (float)Math.Pow(h1, 2)) +
                                  ((p2 / h1) * ((1 / h2) + (1 / h1))));
        }

        // type 2
        protected float InitFirstLambdaType2()
        {
            return 1;
        }

        protected float InitLastLambdaType2()
        {
            return 1;
        }

        protected float InitFirstMuType2()
        {
            return 0;
        }

        protected float InitLastMuType2()
        {
            return 0;
        }

        protected float InitFirstBetaType2()
        {
            return 0;
        }

        protected float InitLastBetaType2()
        {
            return 0;
        }

        // type 2.0

        protected float InitFirstLambdaType2_0()
        {
            return 0;
        }

        protected float InitLastLambdaType2_0()
        {
            return 0;
        }

        protected float InitFirstMuType2_0()
        {
            return 0;
        }

        protected float InitLastMuType2_0()
        {
            return 0;
        }

        protected float InitFirstBetaType2_0()
        {
            return 0;
        }

        protected float InitLastBetaType2_0()
        {
            return 0;
        }
    }
}
