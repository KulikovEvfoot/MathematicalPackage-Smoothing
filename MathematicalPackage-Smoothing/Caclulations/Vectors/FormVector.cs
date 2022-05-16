using MathematicalPackage_Smoothing.Caclulations.Matrices;

namespace MathematicalPackage_Smoothing.Caclulations.Vectors
{
    public class FormVector : MatrixInputData
    {
        public float[] vector;
        public FormVector(int n, float[] x, float[] f, float ds1, float ds2, BoundaryConditions leftType, BoundaryConditions rightType)
        {
            float[] h = new float[n];

            for (int i = 0; i < n - 1; i++)
            {
                h[i] = InitH(x[i], x[i + 1]);
            }

            vector = new float[n];

            ChooseFormType(n, h, f, ds1, ds2, leftType, rightType);
        }

        private float NoiseDispersion(float[] vector)
        {
            float mean = 0;
            float[] variance = new float[vector.Length];
            float sum = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                mean += vector[i];
            }
            mean /= vector.Length;

            for (int i = 0; i < vector.Length; i++)
            {
                variance[i] = vector[i] - mean;
                variance[i] *= variance[i];
                sum += variance[i];
            }

            float dispersion = sum / variance.Length;

            return dispersion;
        }

        private void ChooseFormType(int n, float[] h, float[] f, float ds1, float ds2, BoundaryConditions leftType, BoundaryConditions rightType)
        {
            for (int i = 1; i < n - 1; i++)
            {
                vector[i] = ((f[i - 1] - f[i]) / h[i - 1]) + ((f[i + 1] - f[i]) / h[i]);
            }

            if (leftType == BoundaryConditions.Type_1)
            {
                vector[0] = (f[1] - f[0]) / h[0] - ds1;
            }
            else if (leftType == BoundaryConditions.Type_2)
            {
                vector[0] = ds1;
            }
            else if (leftType == BoundaryConditions.Type_2_0)
            {
                vector[0] = 0;
            }

            if (rightType == BoundaryConditions.Type_1)
            {
                vector[n - 1] = -(f[n - 1] - f[n - 2]) / h[n - 2] + ds2;
            }
            else if (rightType == BoundaryConditions.Type_2)
            {
                vector[n - 1] = ds2;
            }
            else if (rightType == BoundaryConditions.Type_2_0)
            {
                vector[n - 1] = 0;
            }
        }
    }
}
