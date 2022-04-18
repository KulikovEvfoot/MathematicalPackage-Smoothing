namespace MathematicalPackage_Smoothing.Caclulations
{
    public class InitMatrix : InitializateParameters
    {
        public float[,] matrix;

        public InitMatrix(int n, float a)
        {
            this.n = n;

            m_H = new float[n];
            m_X = new float[n];
            m_P = new float[n];
            m_Mu = new float[n];
            m_Lambda = new float[n];
            m_Mu = new float[n];
            m_Beta = new float[n];
            matrix = new float[n,n];

            for (int i = 0; i < n; i++)
            {
                m_X[i] = InitX(i);
            }

            for (int i = 0; i < n; i++)
            {
                m_P[i] = InitP();
            }

            for (int i = 0; i < n - 2; i++)
            {
                m_H[i] = InitH(m_X[i], m_X[i + 1]);
            }

            for (int i = 1; i < n - 2; i++)
            {
                m_Lambda[i] = InitLambda(m_H[i - 1], m_H[i], a, m_P[i - 1], m_P[i], m_P[i + 1]);
            }

            for (int i = 1; i < n - 3; i++)
            {
                m_Mu[i] = InitMu(m_H[i], a, m_P[i], m_H[i - 1], m_P[i + 1], m_H[i + 1]);
            }

            for (int i = 1; i < n - 3; i++)
            {
                m_Beta[i] = InitBeta(a, m_P[i + 1], m_H[i], m_H[i + 1]);
            }

            /// нигде не используются ///
            m_FirstMu = InitFirstMu(m_H[0], a, m_P[0], m_P[1], m_H[1]);
            m_LastMu = InitLastMu(m_H[n - 2], a, m_P[n - 1], m_P[n - 2], m_H[n - 3]);
            /// ///
        }

        public void CreateMatrix()
        {
            ShapeMuDiag();
            ShapeBetaDiag();
            ShapeLambdaDiag();
        }

        private readonly int n;

        private float[] m_H;
        private float[] m_X;
        private float[] m_P;
        private float[] m_Lambda;
        private float m_FirstMu;
        private float m_LastMu;
        private float[] m_Mu;
        private float[] m_Beta;

        private void ShapeBetaDiag()
        {

            for (int i = 2; i < n - 2; i++)
            {
                matrix[i - 2, i] = m_Beta[i];
            }

            for (int i = 2; i < n - 2; i++)
            {
                matrix[i, i - 2] = m_Beta[i];
            }
        }

        private void ShapeMuDiag()
        {

            for (int i = 1; i < n - 2; i++)
            {
                matrix[i - 1, i] = m_Mu[i]; 
            }

            for (int i = 1; i < n - 2; i++)
            {
                matrix[i, i - 1] = m_Mu[i]; 
            }
        }

        private void ShapeLambdaDiag()
        {

            for (int i = 0; i < n - 2; i++)
            {
                matrix[i, i] = m_Lambda[i];
            }
        } 
    }
}
