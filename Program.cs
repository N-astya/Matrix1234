using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix1234
{
    internal class Matrix
    {
        private float[,] matrix;
        private int column;
        private int rows;
        public int GetColumns()
        {
            return column;
        }
        public int GetRows()
        {
            return rows;
        }
        public void Multiplication(Matrix matrix)
        {
            float[,] Result = new float[matrix.GetRows(), matrix.GetColumns()];
            for (int x = 0; x < this.rows; x++)
            {
                for (int y = 0; y < matrix.GetColumns(); y++)
                {
                    for (int z = 0; z < matrix.GetRows(); z++)
                    {
                        Result[x, y] += matrix.GetMatrix()[x, z] * this.GetMatrix()[z, y];
                    }
                }
            }
            this.matrix = Result;
        }
        public static Matrix Multiplication(Matrix matrix, Matrix matrixSecond)
        {
            float[,] Result = new float[matrix.GetRows(), matrix.GetColumns()];
            for (int x = 0; x < matrix.rows; x++)
            {
                for (int y = 0; y < matrixSecond.GetColumns(); y++)
                {
                    for (int z = 0; z < matrixSecond.GetRows(); z++)
                    {
                        Result[x, y] += matrix.GetMatrix()[x, z] * matrixSecond.GetMatrix()[z, y];
                    }
                }
            }
            return new Matrix(Result);
        }
        public void Addition(Matrix additionMatrix)
        {
            for (int x = 0; x < this.rows; x++)
            {
                for (int y = 0; y < this.column; y++)
                {
                    matrix[x, y] += additionMatrix.GetMatrix()[x, y];
                }
            }
        }
        public static Matrix Addition(Matrix additionMatrix, Matrix otherMatrix)
        {
            float[,] Result = new float[additionMatrix.GetRows(), additionMatrix.GetColumns()];
            for (int x = 0; x < additionMatrix.GetRows(); x++)
            {
                for (int y = 0; y < additionMatrix.GetColumns(); y++)
                {
                    Result[x, y] = additionMatrix.GetMatrix()[x, y] + otherMatrix.GetMatrix()[x, y];
                }
            }
            return new Matrix(Result);
        }
        public static Matrix MultiplyByNumber(int number, Matrix firstMatrix)
        {
            float[,] Result = new float[firstMatrix.GetRows(), firstMatrix.GetColumns()];
            for (int x = 0; x < firstMatrix.GetRows(); x++)
            {
                for (int y = 0; y < firstMatrix.GetColumns(); y++)
                {
                    Result[x, y] = firstMatrix.GetMatrix()[x, y] * number;
                }
            }
            return new Matrix(Result);
        }
        public void MultiplyByNumber(int number)
        {
            for (int x = 0; x < this.rows; x++)
            {
                for (int y = 0; y < this.column; y++)
                {
                    matrix[x, y] = matrix[x, y] * number;
                }
            }
        }
        public void Print()
        {
            for (int x = 0; x < this.rows; x++)
            {
                for (int y = 0; y < this.column; y++)
                {
                    Console.WriteLine(matrix[x, y] + "\n");
                }
            }
        }
        public Matrix(float[,] matrix, int rows, int columns)
        {
            this.matrix = matrix;
            this.column = columns;
            this.rows = rows;
        }
        public Matrix(float[,] matrix)
        {
            this.matrix = matrix;
            this.column = matrix.GetLength(1);
            this.rows = matrix.GetLength(0);
        }
        public float[,] GetMatrix()
        {
            return matrix;
        }
        public void SetMatrix(float[,] matrix)
        {
            this.matrix = matrix;
        }
        public void SetMatrixCase(int row, int column, float value)
        {
            this.matrix[row, column] = value;
        }
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(new float[,] { { 5, 10 }, { 12, 7 } });
            Matrix matrixSecond = new Matrix(new float[,] { { 3, 47 }, { 36, 11 } });
            Matrix matrixThird = Matrix.Addition(matrix, matrixSecond);
            matrixThird.Print();
            matrixThird = Matrix.MultiplyByNumber(2, matrixThird);
            matrixThird.Print();
            matrixThird = Matrix.Multiplication(matrix, matrixSecond);
            matrixThird.Print();
        }
    }
}
