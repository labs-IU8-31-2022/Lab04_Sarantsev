using System;

namespace lab04
{
    public class MyMatrix
    {
        private int lines_; 
        private int columns_; 
        private int[,] matrix_; 
        public int Lines { get; set; }
        public int Columns { get; set; }
        public MyMatrix()
        {
            lines_ = 0;
            columns_ = 0;
        }
        public MyMatrix(int input_lines, int input_columns)
        {
            lines_ = input_lines;
            columns_ = input_columns;
            matrix_ = new int[input_lines, input_columns];
            if (input_lines == 0 || input_columns == 0)
            {
                throw new Exception("Lines and columns != 0");
            }
        }
        public void FillMatrix()
        {
            Random rangom = new Random();
            Console.WriteLine("Enter an gap: ");
            int first = Convert.ToInt16(Console.ReadLine());
            int last = Convert.ToInt16(Console.ReadLine());
            for (int i = 0; i < lines_; ++i)
            {
                for (int j = 0; j < columns_; ++j)
                {
                    matrix_[i, j] = rangom.Next(first, last);
                }
            }
        }
        public void Print()
        {
            for (int i = 0; i < lines_; ++i)
            {
                for (int j = 0; j < columns_; ++j)
                {
                    Console.Write(matrix_[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static MyMatrix operator +(MyMatrix obj1, MyMatrix obj2)
        {
            if (obj1.lines_ != obj2.lines_ || obj1.lines_ != obj2.columns_)
            {
                throw new Exception("The sizes of the matrix must match");
            }
            MyMatrix result = new MyMatrix(obj1.lines_, obj1.columns_);
            for (int i = 0; i < obj1.lines_; ++i)
            {
                for (int j = 0; j < obj1.columns_; ++j)
                {
                    result.matrix_[i, j] = obj1.matrix_[i, j] + obj2.matrix_[i, j];
                }
            }
            return result;
        }
        public static MyMatrix operator -(MyMatrix obj1, MyMatrix obj2)
        {
            if (obj1.lines_ != obj2.lines_ || obj1.lines_ != obj2.columns_)
            {
                throw new Exception("The sizes of the matrix must match");
            }
            MyMatrix result = new MyMatrix(obj1.lines_, obj1.columns_);
            for (int i = 0; i < obj1.lines_; ++i)
            {
                for (int j = 0; j < obj1.columns_; ++j)
                {
                    result.matrix_[i, j] = obj1.matrix_[i, j] - obj2.matrix_[i, j];
                }
            }
            return result;
        }
        public static MyMatrix operator *(MyMatrix obj1, MyMatrix obj2)
        {
            if (obj1.columns_ != obj2.lines_)
            {
                throw new Exception("The sizes of the matrix must match");
            }
            MyMatrix result = new MyMatrix(obj1.lines_, obj2.columns_);
            for (int i = 0; i < obj1.lines_; ++i)
            {
                for (int j = 0; j < obj2.lines_; ++j)
                {
                    for (int k = 0; k < obj2.columns_; ++k)
                    {
                        result.matrix_[i, j] += obj1.matrix_[i, k] * obj2.matrix_[k, j];
                    }
                }
            }
            return result;
        }
        public static MyMatrix operator *(MyMatrix obj1, int value)
        {
            if (obj1.lines_ == 0 && obj1.columns_ == 0)
            {
                throw new Exception("Matrix != 0");
            }
            MyMatrix result = new MyMatrix(obj1.lines_, obj1.columns_);
            for (int i = 0; i < obj1.lines_; ++i)
            {
                for (int j = 0; j < obj1.columns_; ++j)
                {
                    result.matrix_[i,j] = obj1.matrix_[i,j] * value;
                }
            }
            return result;
        }
        public static MyMatrix operator /(MyMatrix obj1, int value)
        {
            if (obj1.lines_ == 0 && obj1.columns_ == 0)
            {
                throw new Exception("Matrix != 0");
            }
            MyMatrix result = new MyMatrix(obj1.lines_, obj1.columns_);
            for (int i = 0; i < obj1.lines_; ++i)
            {
                for (int j = 0; j < obj1.columns_; ++j)
                {
                    result.matrix_[i, j] = obj1.matrix_[i, j] / value;
                }
            }
            return result;
        }
        public int this[int index1, int index2]
        {
            get => matrix_[index1, index2];
        }

    }
}

