namespace MathematicalPackage_Smoothing.Caclulations.Matrices
{
    public class MatrixInputData
    {
        protected float InitX(float x, int i)
        {
            return x * (i);
        }

        protected float InitH(float x1, float x2)
        {
            return x2 - x1;
        }

        protected float InitP()
        {
            return 1;
        }
    }
}
