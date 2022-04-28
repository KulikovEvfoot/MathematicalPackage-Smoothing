using System.Collections.Generic;

namespace MathematicalPackage_Smoothing.Caclulations
{
    public class InitMatrix : MatrixCalculation
    {
        public float[,] matrix;
        public List<object> matrixInputData = new List<object>();
        public readonly float[] h;
        public readonly float[] m_X;
        public readonly float[] p;

        public InitMatrix(int n, float x, float a)
        {
            this.n = n;
            this.a = a;
            h = new float[n];
            m_X = new float[n];
            p = new float[n];
            m_Mu = new float[n];
            m_Lambda = new float[n];
            m_Beta = new float[n];
            matrix = new float[n - 2, n - 2];

            for (int i = 0; i < n; i++)
            {
                m_X[i] = InitX(x ,i);
            }

            for (int i = 0; i < n; i++)
            {
                p[i] = InitP();
            }

            for (int i = 0; i < n - 1; i++)
            {
                h[i] = InitH(m_X[i], m_X[i + 1]);
            }

            for (int i = 1; i < n - 1; i++)
            {
                m_Lambda[i] = InitLambda(h[i - 1], h[i], a, p[i - 1], p[i], p[i + 1]);
            }

            for (int i = 1; i < n - 2; i++)
            {
                m_Mu[i] = InitMu(h[i], a, p[i], h[i - 1], p[i + 1], h[i + 1]);
            }

            for (int i = 1; i < n - 2; i++)
            {
                m_Beta[i] = InitBeta(a, p[i + 1], h[i], h[i + 1]);
            }

            /// нигде не используются ///
            //m_FirstMu = InitFirstMu(m_H[0], a, m_P[0], m_P[1], m_H[1]);
            //m_LastMu = InitLastMu(m_H[n - 2], a, m_P[n - 1], m_P[n - 2], m_H[n - 3]);
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
        //private float m_FirstMu;
        //private float m_LastMu;
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
            for (int i = 0; i < n - 4; i++)
            {
                matrix[i, i + 2] = m_Beta[i + 1];
            }

            for (int i = 0; i < n - 4; i++)
            {
                matrix[i + 2, i] = m_Beta[i + 1];
            }
        }

        private void ShapeMuDiag()
        {
            for (int i = 0; i < n - 3; i++)
            {
                matrix[i, i + 1] = m_Mu[i + 1]; 
            }

            for (int i = 0; i < n - 3; i++)
            {
                matrix[i + 1, i] = m_Mu[i + 1]; 
            }
        }

        private void ShapeLambdaDiag()
        {
            for (int i = 0; i < n - 2; i++)
            {
                matrix[i, i] = m_Lambda[i + 1];
            }
        }
    }
}
