using System.Collections.Generic;

namespace MathematicalPackage_Smoothing.Caclulations.Matrices
{
    class InitMatrixType1 : MatrixCalculation
    {
        public float[,] matrix;
        public List<object> matrixInputData = new List<object>();
        public readonly float[] h;
        public readonly float[] m_X;
        public readonly float[] p;

        public InitMatrixType1(int n, float x, float a)
        {
            this.n = n;
            this.a = a;
            h = new float[n];
            m_X = new float[n];
            p = new float[n];
            m_Mu = new float[n];
            m_Lambda = new float[n];
            m_Beta = new float[n];
            matrix = new float[n, n];

            for (int i = 0; i < n; i++)
            {
                m_X[i] = InitX(x, i);
            }

            for (int i = 0; i < n; i++)
            {
                p[i] = InitP();
            }

            for (int i = 0; i < n - 1; i++)
            {
                h[i] = InitH(m_X[i], m_X[i + 1]);
            }

            m_Lambda[0] = InitFirstLambdaType1(h[0], a, p[0], p[1]);
            m_Lambda[n - 1] = InitLastLambdaType1(h[n - 2], a, p[n - 2], p[n - 1]);
            for (int i = 1; i < n - 1; i++)
            {
                m_Lambda[i] = InitLambdaType2_0(h[i - 1], h[i], a, p[i - 1], p[i], p[i + 1]);
            }

            m_Mu[0] = InitFirstMuType2_0(h[0], a, p[0], p[1], h[1]);
            m_Mu[n - 2] = InitLastMuType2_0(h[n - 2], a, p[n - 1], p[n - 2], h[n - 3]);
            for (int i = 1; i < n - 2; i++)
            {
                m_Mu[i] = InitMuType2_0(h[i], a, p[i], h[i - 1], p[i + 1], h[i + 1]);
            }

            for (int i = 0; i < n - 2; i++)
            {
                m_Beta[i] = InitBetaType2_0(a, p[i + 1], h[i], h[i + 1]);
            }
        }

        public void CreateMatrix()
        {
            ShapeMuDiag();
            ShapeBetaDiag();
            ShapeLambdaDiag();
            InitMatrixInputData();
        }

        private readonly int n;
        private readonly float a;

        private readonly float[] m_Lambda;
        private readonly float[] m_Mu;
        private readonly float[] m_Beta;

        private void InitMatrixInputData()
        {
            matrixInputData.Add(m_X);
            matrixInputData.Add(p);
            matrixInputData.Add(a);
        }

        private void ShapeBetaDiag()
        {
            for (int i = 0; i < n - 2; i++)
            {
                matrix[i, i + 2] = m_Beta[i];
            }

            for (int i = 0; i < n - 2; i++)
            {
                matrix[i + 2, i] = m_Beta[i];
            }
        }

        private void ShapeMuDiag()
        {
            for (int i = 0; i < n - 1; i++)
            {
                matrix[i, i + 1] = m_Mu[i];
            }

            for (int i = 0; i < n - 1; i++)
            {
                matrix[i + 1, i] = m_Mu[i];
            }
        }

        private void ShapeLambdaDiag()
        {
            for (int i = 0; i < n; i++)
            {
                matrix[i, i] = m_Lambda[i];
            }
        }
    }
}
