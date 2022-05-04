namespace MathematicalPackage_Smoothing.Caclulations.Vectors
{
    class FormVectorType2
    {
        public float[] vector;
        public FormVectorType2(int n, float[] f, float[] h, float ds1, float ds2)
        {
            vector = new float[n];

            vector[0] = ds1;
            vector[n - 1] = ds2;

            for (int i = 1; i < n - 1; i++)
            {
                vector[i] = ((f[i - 1] - f[i]) / h[i - 1]) + ((f[i + 1] - f[i]) / h[i]);
            }
        }
    }
}
