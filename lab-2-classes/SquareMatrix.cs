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

    // Переопределение метода ToString для представления матрицы в виде строки
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < dimension; i++)
        {
            for (int j = 0; j < dimension; j++)
            {
                sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "{0}\t", elements[i, j]); // Добавляем элемент и табуляцию
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

    // Метод проверки, является ли матрица верхнетреугольной
    public bool IsUpperTriangular()
    {
        for (int i = 0; i < dimension; i++)
        {
            // Проверяем, что диагональный элемент не нулевой
            if (elements[i, i] == 0)
                return false;

            for (int j = 0; j < i; j++)
            {
                // Элементы ниже главной диагонали должны быть нулями
                if (elements[i, j] != 0)
                    return false;
            }
        }
        return true; // Матрица верхнетреугольная
    }

    // Метод проверки, является ли матрица нижнетреугольной
    public bool IsLowerTriangular()
    {
        for (int i = 0; i < dimension; i++)
        {
            // Проверяем, что диагональный элемент не нулевой
            if (elements[i, i] == 0)
                return false;

            for (int j = i + 1; j < dimension; j++)
            {
                // Элементы выше главной диагонали должны быть нулями
                if (elements[i, j] != 0)
                    return false;
            }
        }
        return true; // Матрица нижнетреугольная
    }

}