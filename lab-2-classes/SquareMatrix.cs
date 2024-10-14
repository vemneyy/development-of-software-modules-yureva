using System;
using System.Text;

public class SquareMatrix
{
    private int dimension; // Размерность квадратной матрицы
    private double[,] elements; // Двумерный массив элементов матрицы

    // Свойство для получения размерности матрицы
    public int Dimension
    {
        get { return dimension; }
    }

    // Конструктор, принимающий размерность матрицы
    public SquareMatrix(int dimension)
    {
        this.dimension = dimension;
        elements = new double[dimension, dimension]; // Инициализация массива элементов
    }

    // Конструктор, принимающий двумерный массив элементов
    public SquareMatrix(double[,] elements)
    {
        int rows = elements.GetLength(0);
        int cols = elements.GetLength(1);

        if (rows != cols)
            throw new ArgumentException("Матрица должна быть квадратной."); // Проверка на квадратность матрицы

        this.dimension = rows;
        this.elements = (double[,])elements.Clone(); // Клонирование массива элементов
    }

    // Индексатор для доступа к элементам матрицы
    public double this[int i, int j]
    {
        get { return elements[i, j]; }
        set { elements[i, j] = value; }
    }

    // Метод проверки, является ли матрица верхнетреугольной
    public bool IsUpperTriangular()
    {
        for (int i = 1; i < dimension; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (elements[i, j] != 0)
                    return false; // Если элемент ниже главной диагонали не равен нулю, матрица не верхнетреугольная
            }
        }
        return true; // Матрица верхнетреугольная
    }

    // Метод проверки, является ли матрица нижнетреугольной
    public bool IsLowerTriangular()
    {
        for (int i = 0; i < dimension - 1; i++)
        {
            for (int j = i + 1; j < dimension; j++)
            {
                if (elements[i, j] != 0)
                    return false; // Если элемент выше главной диагонали не равен нулю, матрица не нижнетреугольная
            }
        }
        return true; // Матрица нижнетреугольная
    }

    // Переопределение метода ToString для представления матрицы в виде строки
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < dimension; i++)
        {
            for (int j = 0; j < dimension; j++)
            {
                sb.AppendFormat("{0}\t", elements[i, j]); // Добавляем элемент и табуляцию
            }
            sb.AppendLine(); // Переход на новую строку после каждой строки матрицы
        }
        return sb.ToString();
    }

    // Оператор сложения матриц
    public static SquareMatrix operator +(SquareMatrix a, SquareMatrix b)
    {
        if (a.dimension != b.dimension)
            throw new ArgumentException("Матрицы должны быть одной размерности."); // Проверка совместимости размерностей

        SquareMatrix result = new SquareMatrix(a.dimension);
        for (int i = 0; i < a.dimension; i++)
        {
            for (int j = 0; j < a.dimension; j++)
            {
                result[i, j] = a[i, j] + b[i, j]; // Поэлементное сложение
            }
        }
        return result;
    }

    // Оператор вычитания матриц
    public static SquareMatrix operator -(SquareMatrix a, SquareMatrix b)
    {
        if (a.dimension != b.dimension)
            throw new ArgumentException("Матрицы должны быть одной размерности."); // Проверка совместимости размерностей

        SquareMatrix result = new SquareMatrix(a.dimension);
        for (int i = 0; i < a.dimension; i++)
        {
            for (int j = 0; j < a.dimension; j++)
            {
                result[i, j] = a[i, j] - b[i, j]; // Поэлементное вычитание
            }
        }
        return result;
    }

    // Оператор умножения матриц
    public static SquareMatrix operator *(SquareMatrix a, SquareMatrix b)
    {
        if (a.dimension != b.dimension)
            throw new ArgumentException("Матрицы должны быть одной размерности."); // Проверка совместимости размерностей

        SquareMatrix result = new SquareMatrix(a.dimension);
        for (int i = 0; i < a.dimension; i++)
        {
            for (int j = 0; j < a.dimension; j++)
            {
                double sum = 0;
                for (int k = 0; k < a.dimension; k++)
                {
                    sum += a[i, k] * b[k, j]; // Суммирование произведений для элемента [i, j]
                }
                result[i, j] = sum;
            }
        }
        return result;
    }

    // Оператор умножения матрицы на число
    public static SquareMatrix operator *(SquareMatrix a, double scalar)
    {
        SquareMatrix result = new SquareMatrix(a.dimension);
        for (int i = 0; i < a.dimension; i++)
        {
            for (int j = 0; j < a.dimension; j++)
            {
                result[i, j] = a[i, j] * scalar; // Умножение каждого элемента на скаляр
            }
        }
        return result;
    }

    // Дополнительный оператор для умножения числа на матрицу
    public static SquareMatrix operator *(double scalar, SquareMatrix a)
    {
        return a * scalar; // Использование ранее определенного оператора
    }
}
