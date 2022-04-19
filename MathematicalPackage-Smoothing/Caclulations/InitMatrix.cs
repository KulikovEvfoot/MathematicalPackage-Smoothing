using System.Collections.Generic;

namespace MathematicalPackage_Smoothing.Caclulations
{
    public class InitMatrix : MatrixCalculation
    {
        public double[,] matrix;
        public List<object> matrixInputData = new List<object>();
        public readonly double[] m_H;
        public readonly double[] m_X;
        public readonly double[] m_P;
        public readonly double[] m_Lambda;
        //private double m_FirstMu;
        //private double m_LastMu;
        public readonly double[] m_Mu;
        public readonly double[] m_Beta;

        public InitMatrix()
        {

        }

        public InitMatrix(int n, double a)
        {
            this.n = n;
            this.a = a;
            m_H = new double[n];
            m_X = new double[n];
            m_P = new double[n];
            m_Mu = new double[n];
            m_Lambda = new double[n];
            m_Beta = new double[n];
            matrix = new double[n - 2, n - 2];

            for (int i = 0; i < n; i++)
            {
                m_X[i] = InitX(i);
            }

            for (int i = 0; i < n; i++)
            {
                m_P[i] = InitP();
            }

            for (int i = 0; i < n - 1; i++)
            {
                m_H[i] = InitH(m_X[i], m_X[i + 1]);
            }

            for (int i = 1; i < n - 1; i++)
            {
                m_Lambda[i] = InitLambda(m_H[i - 1], m_H[i], a, m_P[i - 1], m_P[i], m_P[i + 1]);
            }

            for (int i = 1; i < n - 2; i++)
            {
                m_Mu[i] = InitMu(m_H[i], a, m_P[i], m_H[i - 1], m_P[i + 1], m_H[i + 1]);
            }

            for (int i = 1; i < n - 2; i++)
            {
                m_Beta[i] = InitBeta(a, m_P[i + 1], m_H[i], m_H[i + 1]);
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
        private readonly double a;



        private void InitMatrixInputData()
        {
            matrixInputData.Add(m_X);
            matrixInputData.Add(m_P);
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
