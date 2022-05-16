namespace MathematicalPackage_Smoothing.Caclulations.Matrices
{
    public class InitMatrix : MatrixCalculation
    {
        public float[,] matrix;

        public InitMatrix(int n, float[] x, float[] p, float a, BoundaryConditions leftType, BoundaryConditions rightType)
        {
            float[] h = new float[n];
            m_Mu = new float[n];
            m_Lambda = new float[n];
            m_Beta = new float[n];

            matrix = new float[n, n];

            for (int i = 0; i < n - 1; i++)
            {
                h[i] = InitH(x[i], x[i + 1]);
            }

            ChooseLambda(n, leftType, rightType, h, a, p);
            ChooseMu(n, leftType, rightType, h, a, p);
            ChooseBeta(n, leftType, rightType, h, a, p);

            CreateMatrix(n);
        }

        private void CreateMatrix(int n)
        {
            ShapeLambdaDiag(n);
            ShapeMuDiag(n);
            ShapeBetaDiag(n);
        }

        private readonly float[] m_Lambda;
        private readonly float[] m_Mu;
        private readonly float[] m_Beta;

        private void ChooseLambda(int n, BoundaryConditions leftType, BoundaryConditions rightType, float[] h, float a, float[] p)
        {
            for (int i = 1; i < n - 1; i++)
            {
                m_Lambda[i] = InitLambda(h[i - 1], h[i], a, p[i - 1], p[i], p[i + 1]);
            }

            if (leftType == BoundaryConditions.Type_1)
            {
                m_Lambda[0] = InitFirstLambdaType1(h[0], a, p[0], p[1]);
            }
            else if (leftType == BoundaryConditions.Type_2)
            {
                m_Lambda[0] = InitFirstLambdaType2();
            }
            else if (leftType == BoundaryConditions.Type_2_0)
            {
                m_Lambda[0] = InitFirstLambdaType2_0();
            }

            if (rightType == BoundaryConditions.Type_1)
            {
                m_Lambda[n - 1] = InitLastLambdaType1(h[n - 2], a, p[n - 2], p[n - 1]);
            }
            else if (rightType == BoundaryConditions.Type_2)
            {
                m_Lambda[n - 1] = InitLastLambdaType2();
            }
            else if (rightType == BoundaryConditions.Type_2_0)
            {
                m_Lambda[n - 1] = InitLastLambdaType2_0();
            }
        }
        private void ChooseMu(int n, BoundaryConditions leftType, BoundaryConditions rightType, float[] h, float a, float[] p)
        {
            for (int i = 1; i < n - 2; i++)
            {
                m_Mu[i] = InitMu(h[i], a, p[i], h[i - 1], p[i + 1], h[i + 1]);
            }

            if (leftType == BoundaryConditions.Type_1)
            {
                m_Mu[0] = InitFirstMuType1(h[0], a, p[0], p[1], h[1]);
            }
            else if (leftType == BoundaryConditions.Type_2)
            {
                m_Mu[0] = InitFirstMuType2();
            }
            else if (leftType == BoundaryConditions.Type_2_0)
            {
                m_Mu[0] = InitFirstMuType2_0();
            }

            if (rightType == BoundaryConditions.Type_1)
            {
                m_Mu[n - 2] = InitLastMuType1(h[n - 2], a, p[n - 1], p[n - 2], h[n - 3]);
            }
            else if (rightType == BoundaryConditions.Type_2)
            {
                m_Mu[n - 2] = InitLastMuType2();
            }
            else if (rightType == BoundaryConditions.Type_2_0)
            {
                m_Mu[n - 2] = InitLastMuType2_0();
            }
        }
        private void ChooseBeta(int n, BoundaryConditions leftType, BoundaryConditions rightType, float[] h, float a, float[] p)
        {
            for (int i = 0; i < n - 2; i++)
            {
                m_Beta[i] = InitBeta(a, p[i + 1], h[i], h[i + 1]);
            }

            if (leftType == BoundaryConditions.Type_1)
            {
                // ignore
            }
            else if (leftType == BoundaryConditions.Type_2)
            {
                m_Beta[0] = InitFirstBetaType2();
            }
            else if (leftType == BoundaryConditions.Type_2_0)
            {
                m_Beta[0] = InitFirstBetaType2_0();
            }

            if (rightType == BoundaryConditions.Type_1)
            {
                // ignore
            }
            else if (rightType == BoundaryConditions.Type_2)
            {
                m_Beta[n - 3] = InitLastBetaType2();
            }
            else if (rightType == BoundaryConditions.Type_2_0)
            {
                m_Beta[n - 3] = InitLastBetaType2_0();
            }
        }
        private void ShapeLambdaDiag(int n)
        {
            for (int i = 0; i < n; i++)
            {
                matrix[i, i] = m_Lambda[i];
            }
        }
        private void ShapeMuDiag(int n)
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
        private void ShapeBetaDiag(int n)
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
    }
}
