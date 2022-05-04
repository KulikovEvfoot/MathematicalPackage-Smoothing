namespace MathematicalPackage_Smoothing.Caclulations.Vectors
{
    public class FormVectorType2_0
    {
        public float[] vector;
        public FormVectorType2_0(int n, float[] f, float[] h)
        {
            vector = new float[n-2];      

            for (int j = 0; j < n - 2; j++)
            {
                int i = j + 1;
                vector[j] = ((f[i - 1] - f[i]) / h[i - 1]) + ((f[i + 1] - f[i]) / h[i]);               
            }
        }
    }
}
