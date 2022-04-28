using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Single;
using System;

namespace MathematicalPackage_Smoothing.Caclulations
{
    public class InitCoefficients
    {
        protected float[] InitCoefC(float[,] matrix, float[] vector)
        {
            var coefC = new float[vector.Length + 2];

            Matrix<float> matrixNumerics = DenseMatrix.OfArray(matrix);
            Vector<float> vectorNumerics = DenseVector.OfArray(vector);

            ///Распараллеливание от microsoft
            //float[][] micr = new float[vector.Length][];
            //for (int i = 0; i < vector.Length; i++)
            //{
            //    micr[i] = new float[vector.Length];
            //    for (int j = 0; j < vector.Length; j++)
            //    {
            //        micr[i][j] = matrix[i, j];
            //    }
            //}
            //var ssx = SystemSolve(micr, vector);

            var x = matrixNumerics.Solve(vectorNumerics);
            var solve = x.ToArray();

            coefC[0] = 0;
            for (int i = 1; i < coefC.Length - 1; i++)
            {
                coefC[i] = solve[i - 1];
            }
            coefC[coefC.Length - 1] = 0;
            return coefC;
        }

        protected float[] InitCoefA(int n, float[] h, float[] p, float[] f, float a, float[] coefC)
        {
            var coefA = new float[n];

            for (int i = 1; i < coefA.Length - 1; i++)
            {
                coefA[i] = f[i] - a * p[i] * (((coefC[i + 1] - coefC[i]) / h[i]) - (coefC[i] - coefC[i - 1]) / h[i - 1]);
            }

            coefA[0] = f[0] - a * p[0] * ((coefC[1] - coefC[0]) / h[0]);
            coefA[n - 1] = f[n - 1] - a * p[n - 1] * ((coefC[n - 2] - coefC[n - 1]) / h[n - 2]);

            return coefA;
        }

        protected float[] InitCoefB(int n, float[] h, float[] coefA, float[] coefC)
        {
            var coefB = new float[n];

            for (int i = 0; i < n - 1; i++) 
            {
                coefB[i] = ((coefA[i + 1] - coefA[i]) / h[i]) - (h[i] / 6 * (coefC[i + 1] + 2 * coefC[i]));
            }

            return coefB;
        }

        protected float[] InitCoefD(int n, float[] h, float[] coefC)
        {
            var coefD = new float[n - 1];

            for (int i = 0; i < n - 1; i++)
            {
                coefD[i] = (1 / (6 * h[i])) * (coefC[i + 1] - coefC[i]);
            }

            return coefD;
        }


        private float[][] MatrixCreate(int rows, int cols)
        {
            // Создаем матрицу, полностью инициализированную
            // значениями 0.0. Проверка входных параметров опущена.
            float[][] result = new float[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new float[cols]; // автоинициализация в 0.0
            return result;
        }

        private float[][] MatrixDecompose(float[][] matrix, out int[] perm, out int toggle)
        {
            // Разложение LUP Дулитла. Предполагается,
            // что матрица квадратная.
            int n = matrix.Length; // для удобства
            float[][] result = MatrixDuplicate(matrix);
            perm = new int[n];
            for (int i = 0; i < n; ++i) { perm[i] = i; }
            toggle = 1;
            for (int j = 0; j < n - 1; ++j) // каждый столбец
            {
                float colMax = Math.Abs(result[j][j]); // Наибольшее значение в столбце j
                int pRow = j;
                for (int i = j + 1; i < n; ++i)
                {
                    if (result[i][j] > colMax)
                    {
                        colMax = result[i][j];
                        pRow = i;
                    }
                }
                if (pRow != j) // перестановка строк
                {
                    float[] rowPtr = result[pRow];
                    result[pRow] = result[j];
                    result[j] = rowPtr;
                    int tmp = perm[pRow]; // Меняем информацию о перестановке
                    perm[pRow] = perm[j];
                    perm[j] = tmp;
                    toggle = -toggle; // переключатель перестановки строк
                }
                if (Math.Abs(result[j][j]) < 1.0E-20)
                    return null;
                for (int i = j + 1; i < n; ++i)
                {
                    result[i][j] /= result[j][j];
                    for (int k = j + 1; k < n; ++k)
                        result[i][k] -= result[i][j] * result[j][k];
                }
            } // основной цикл по столбцу j
            return result;
        }

        private float[][] MatrixDuplicate(float[][] matrix)
        {
            // Предполагается, что матрица не нулевая
            float[][] result = MatrixCreate(matrix.Length, matrix[0].Length);
            for (int i = 0; i < matrix.Length; ++i) // Копирование значений
                for (int j = 0; j < matrix[i].Length; ++j)
                    result[i][j] = matrix[i][j];
            return result;
        }

        private float[] HelperSolve(float[][] luMatrix, float[] b)
        {
            // Решаем luMatrix * x = b
            int n = luMatrix[0].Length;
            float[] x = new float[n];
            b.CopyTo(x, 0);
            for (int i = 1; i < n; ++i)
            {
                float sum = x[i];
                for (int j = 0; j < i; ++j)
                    sum -= luMatrix[i][j] * x[j];
                x[i] = sum;
            }
            x[n - 1] /= luMatrix[n - 1][n - 1];
            for (int i = n - 2; i >= 0; --i)
            {
                float sum = x[i];
                for (int j = i + 1; j < n; ++j)
                    sum -= luMatrix[i][j] * x[j];
                x[i] = sum / luMatrix[i][i];
            }
            return x;
        }

        private float[][] MatrixInverse(float[][] matrix)
        {
            int n = matrix.Length;
            float[][] result = MatrixDuplicate(matrix);
            int[] perm;
            int toggle;
            float[][] lum = MatrixDecompose(matrix, out perm, out toggle);
            if (lum == null)
                throw new Exception("Unable to compute inverse");
            float[] b = new float[n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i == perm[j])
                        b[j] = 1.0f;
                    else
                        b[j] = 0.0f;
                }
                float[] x = HelperSolve(lum, b);
                for (int j = 0; j < n; ++j)
                    result[j][i] = x[j];
            }
            return result;
        }

        private float[] SystemSolve(float[][] A, float[] b)
        {
            // Решаем Ax = b
            int n = A.Length;
            int[] perm;
            int toggle;
            float[][] luMatrix = MatrixDecompose(
              A, out perm, out toggle);
            if (luMatrix == null)
                return null; // или исключение
            float[] bp = new float[b.Length];
            for (int i = 0; i < n; ++i)
                bp[i] = b[perm[i]];
            float[] x = HelperSolve(luMatrix, bp);
            return x;
        }
    }
}
