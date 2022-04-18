using System;

namespace MathematicalPackage_Smoothing.Caclulations
{
    public class InitializateParameters
    {
        protected float InitH(float x1, float x2)
        {
            return x2 - x1;
        }

        protected float InitLambda(float h1, float h2, float a, float p1, float p2, float p3)
        {
            return ((h1 + h2) / 3) +  a * (((p1 + p2) / (float)Math.Pow(h1 ,2)) + 
                                           ((p2 + p3) / (float)Math.Pow(h2, 2)) + 
                                           ((2 * p2)  / (h1 * h2)));
        }

        protected float InitX(int i)
        {
            return 0.2f * (i);
        }

        protected float InitP()
        {
            return 1;
        }

        protected float InitFirstMu(float firstH,  float a, float firstP, float secondP, float secondH)
        {
            return  (firstH / 6) - a * ((firstP / (float)Math.Pow(firstH, 2)) + 
                                       ((secondP / firstH) * ((1 / firstH) + (1 / secondH))));
        }

        protected float InitLastMu(float h1, float a, float p1, float p2, float h2)
        {
            return (h1 / 6) - a * ((p1 / (float)Math.Pow(h1, 2)) +
                                  ((p2 / h1) * ((1 / h2) + (1 / h1))));
        }

        protected float InitMu(float h1, float a, float p1, float h2, float p2, float h3)
        {
            return (h1 / 6) - (a / h1) * (p1 * ((1 / h2) + (1 / h1)) + p2 * ((1 / h1) + (1 / h3)));
        }

        protected float InitBeta(float a, float p1, float h1, float h2)
        {
            return a * (p1 / (h1 + h2));
        }
    }
}
