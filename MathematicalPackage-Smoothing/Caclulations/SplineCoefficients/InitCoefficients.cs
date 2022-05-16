using MathematicalPackage_Smoothing.Caclulations.Matrices;
using MathematicalPackage_Smoothing.Caclulations.Vectors;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Single;
using System;

namespace MathematicalPackage_Smoothing.Caclulations.SplineCoefficients
{
    public class InitCoefficients : MatrixInputData
    {
        protected float[] h;

        protected InitCoefficients(int n, float[] x)
        {
            h = new float[n];
            for (int i = 0; i < n - 1; i++)
            {
                h[i] = InitH(x[i], x[i + 1]);
            }
        }

        protected float[] InitCoefC(int n, float[] x, float[] p, float[] f, float a, float ds1, float ds2, BoundaryConditions leftType, BoundaryConditions rightType)
        {
            InitMatrix initMatrix = new InitMatrix(
                n,
                x,
                p,
                a,
                leftType,
                rightType);

            FormVector formVector = new FormVector(
                n,
                x,
                f,
                ds1,
                ds2,
                leftType,
                rightType);

            var coefC = new float[n];

            float[,] newMatrix;
            newMatrix = ChooseMatrixSize(initMatrix, leftType, rightType);
            float[] newVector;
            newVector = ChooseVectorSize(formVector, leftType, rightType);

            Matrix<float> matrixNumerics = DenseMatrix.OfArray(newMatrix);
            Vector<float> vectorNumerics = DenseVector.OfArray(newVector);
            var solve = matrixNumerics.Solve(vectorNumerics);

            coefC = PullingCoefC(coefC, solve, leftType, rightType);
            coefC = ChooseCoefCType(coefC, leftType, rightType);

            return coefC;
        }

        private float[] PullingCoefC(float[] coefC, Vector<float> solve, BoundaryConditions leftType, BoundaryConditions rightType)
        {
            if (leftType == BoundaryConditions.Type_2_0 && rightType == BoundaryConditions.Type_2_0)
            {
                for (int i = 1; i < coefC.Length - 1; i++)
                {
                    coefC[i] = solve[i - 1];
                }
            }
            else if (leftType == BoundaryConditions.Type_2_0)
            {
                for (int i = 0; i < coefC.Length - 1; i++)
                {
                    coefC[i + 1] = solve[i];
                }
            }
            else if (rightType == BoundaryConditions.Type_2_0)
            {
                for (int i = 0; i < coefC.Length - 1; i++)
                {
                    coefC[i] = solve[i];
                }
            }
            else
            {
                for (int i = 0; i < coefC.Length; i++)
                {
                    coefC[i] = solve[i];
                }
            }

            return coefC;
        }

        protected float[] InitCoefA(int n, float[] p, float[] f, float a, float[] coefC)
        {
            var coefA = new float[n];

            for (int i = 1; i < coefA.Length - 1; i++)
            {
                coefA[i] = f[i] - a * p[i] * ((coefC[i + 1] - coefC[i]) / h[i] - (coefC[i] - coefC[i - 1]) / h[i - 1]);
            }

            coefA[0] = f[0] - a * p[0] * ((coefC[1] - coefC[0]) / h[0]);
            coefA[n - 1] = f[n - 1] - a * p[n - 1] * ((coefC[n - 2] - coefC[n - 1]) / h[n - 2]);

            return coefA;
        }

        protected float[] InitCoefB(int n, float[] coefA, float[] coefC)
        {
            var coefB = new float[n];

            for (int i = 0; i < n - 1; i++)
            {
                coefB[i] = ((coefA[i + 1] - coefA[i]) / h[i]) - (h[i] / 6 * (coefC[i + 1] + 2 * coefC[i]));
            }

            return coefB;
        }

        protected float[] InitCoefD(int n, float[] coefC)
        {
            var coefD = new float[n - 1];

            for (int i = 0; i < n - 1; i++)
            {
                coefD[i] = 1 / (6 * h[i]) * (coefC[i + 1] - coefC[i]);
            }

            return coefD;
        }

        private float[,] ChooseMatrixSize(InitMatrix initMatrix, BoundaryConditions leftType, BoundaryConditions rightType)
        {
            float[,] newMatrix = null;
            if (leftType == BoundaryConditions.Type_2_0 && rightType == BoundaryConditions.Type_2_0)
            {
                newMatrix = new float[(int)Math.Sqrt(initMatrix.matrix.Length) - 2, (int)Math.Sqrt(initMatrix.matrix.Length) - 2];

                for (int i = 0; i < Math.Sqrt(newMatrix.Length); i++)
                {
                    for (int j = 0; j < Math.Sqrt(newMatrix.Length); j++)
                    {
                        newMatrix[i, j] = initMatrix.matrix[i + 1, j + 1];
                    }
                }
            }
            else if (leftType == BoundaryConditions.Type_2_0)
            {
                newMatrix = new float[(int)Math.Sqrt(initMatrix.matrix.Length) - 1, (int)Math.Sqrt(initMatrix.matrix.Length) - 1];

                for (int i = 0; i < Math.Sqrt(newMatrix.Length); i++)
                {
                    for (int j = 0; j < Math.Sqrt(newMatrix.Length); j++)
                    {
                        newMatrix[i, j] = initMatrix.matrix[i + 1, j + 1];
                    }
                }
            }
            else if (rightType == BoundaryConditions.Type_2_0)
            {
                newMatrix = new float[(int)Math.Sqrt(initMatrix.matrix.Length) - 1, (int)Math.Sqrt(initMatrix.matrix.Length) - 1];

                for (int i = 0; i < Math.Sqrt(newMatrix.Length); i++)
                {
                    for (int j = 0; j < Math.Sqrt(newMatrix.Length); j++)
                    {
                        newMatrix[i, j] = initMatrix.matrix[i, j];
                    }
                }
            }
            else
            {
                newMatrix = initMatrix.matrix;
            }
            return newMatrix;
        }

        private float[] ChooseVectorSize(FormVector formVector, BoundaryConditions leftType, BoundaryConditions rightType)
        {
            float[] newVector = null;
            if (leftType == BoundaryConditions.Type_2_0 && rightType == BoundaryConditions.Type_2_0)
            {
                newVector = new float[formVector.vector.Length - 2];
                for (int i = 0; i < newVector.Length; i++)
                {
                    newVector[i] = formVector.vector[i + 1];
                }
            }
            else if (leftType == BoundaryConditions.Type_2_0)
            {
                newVector = new float[formVector.vector.Length - 1];
                for (int i = 0; i < newVector.Length; i++)
                {
                    newVector[i] = formVector.vector[i + 1];
                }
            }
            else if (rightType == BoundaryConditions.Type_2_0)
            {
                newVector = new float[formVector.vector.Length - 1];
                for (int i = 0; i < newVector.Length; i++)
                {
                    newVector[i] = formVector.vector[i];
                }
            }
            else
            {
                newVector = formVector.vector;
            }

            return newVector;
        }

        private float[] ChooseCoefCType(float[] coefC, BoundaryConditions leftType, BoundaryConditions rightType)
        {
            if (leftType == BoundaryConditions.Type_1)
            {
                //ignore
            }
            else if (leftType == BoundaryConditions.Type_2)
            {
                //ignore
            }
            else if (leftType == BoundaryConditions.Type_2_0)
            {
                coefC[0] = 0;
            }

            if (rightType == BoundaryConditions.Type_1)
            {
                //ignore
            }
            else if (rightType == BoundaryConditions.Type_2)
            {
                //ignore
            }
            else if (rightType == BoundaryConditions.Type_2_0)
            {
                coefC[coefC.Length - 1] = 0;
            }

            return coefC;
        }
    }
}
