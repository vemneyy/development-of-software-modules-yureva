using System;
using System.Windows;
using System.Windows.Controls;

namespace lab_2_classes
{
    public partial class MainWindow : Window
    {
        private int dimension = 3;
        private TextBox[,] matrixATextBoxes = null!;
        private TextBox[,] matrixBTextBoxes = null!;

        public MainWindow()
        {
            InitializeComponent();
            InitializeMatrices();
        }

        // Инициализация матриц
        private void InitializeMatrices()
        {
            // Очистка предыдущих элементов управления
            MatrixAGrid.Children.Clear();
            MatrixBGrid.Children.Clear();

            // Установка количества строк и столбцов в сетках
            MatrixAGrid.Rows = dimension;
            MatrixAGrid.Columns = dimension;

            MatrixBGrid.Rows = dimension;
            MatrixBGrid.Columns = dimension;

            // Создание массивов TextBox для ввода элементов матриц
            matrixATextBoxes = new TextBox[dimension, dimension];
            matrixBTextBoxes = new TextBox[dimension, dimension];

            // Заполнение сеток TextBox для матриц A и B
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    // Создание TextBox для матрицы A
                    TextBox textBoxA = new TextBox
                    {
                        Text = "0",
                        Margin = new Thickness(2),
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center
                    };
                    MatrixAGrid.Children.Add(textBoxA);
                    matrixATextBoxes[i, j] = textBoxA;

                    // Создание TextBox для матрицы B
                    TextBox textBoxB = new TextBox
                    {
                        Text = "0",
                        Margin = new Thickness(2),
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center
                    };
                    MatrixBGrid.Children.Add(textBoxB);
                    matrixBTextBoxes[i, j] = textBoxB;
                }
            }
        }

        // Обработчик события для кнопки "Установить размерность"
        private void SetDimensionButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка корректности введенной размерности
            if (int.TryParse(DimensionTextBox.Text, out int dim) && dim > 0 && dim <= 10)
            {
                dimension = dim;
                InitializeMatrices(); // Инициализация матриц с новой размерностью
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректное положительное целое число для размерности (1-10).");
            }
        }

        // Метод для получения матрицы из TextBox
        private SquareMatrix GetMatrixFromTextBoxes(TextBox[,] textBoxes)
        {
            double[,] elements = new double[dimension, dimension];
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    // Преобразование текста в число
                    if (double.TryParse(textBoxes[i, j].Text, out double value))
                    {
                        elements[i, j] = value;
                    }
                    else
                    {
                        throw new FormatException($"Некорректное число в позиции [{i + 1},{j + 1}].");
                    }
                }
            }
            return new SquareMatrix(elements);
        }

        // Обработчик события для кнопки "Сложить матрицы"
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получение матриц A и B из TextBox
                SquareMatrix matrixA = GetMatrixFromTextBoxes(matrixATextBoxes);
                SquareMatrix matrixB = GetMatrixFromTextBoxes(matrixBTextBoxes);

                // Сложение матриц
                SquareMatrix result = matrixA + matrixB;

                // Отображение результата
                ResultTextBlock.Text = "Результат A + B:\n" + result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Обработчик события для кнопки "Вычесть матрицы"
        private void SubtractButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получение матриц A и B из TextBox
                SquareMatrix matrixA = GetMatrixFromTextBoxes(matrixATextBoxes);
                SquareMatrix matrixB = GetMatrixFromTextBoxes(matrixBTextBoxes);

                // Вычитание матриц
                SquareMatrix result = matrixA - matrixB;

                // Отображение результата
                ResultTextBlock.Text = "Результат A - B:\n" + result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Обработчик события для кнопки "Умножить матрицы"
        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получение матриц A и B из TextBox
                SquareMatrix matrixA = GetMatrixFromTextBoxes(matrixATextBoxes);
                SquareMatrix matrixB = GetMatrixFromTextBoxes(matrixBTextBoxes);

                // Умножение матриц
                SquareMatrix result = matrixA * matrixB;

                // Отображение результата
                ResultTextBlock.Text = "Результат A * B:\n" + result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Обработчик события для кнопки "Умножить A на скаляр"
        private void ScalarMultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получение матрицы A из TextBox
                SquareMatrix matrixA = GetMatrixFromTextBoxes(matrixATextBoxes);

                // Преобразование текста скаляра в число
                if (double.TryParse(ScalarTextBox.Text, out double scalar))
                {
                    // Умножение матрицы на скаляр
                    SquareMatrix result = matrixA * scalar;

                    // Отображение результата
                    ResultTextBlock.Text = $"Результат A * {scalar}:\n" + result.ToString();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректное число для скалярного значения.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Обработчик события для проверки, является ли матрица A верхнетреугольной
        private void CheckUpperButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получение матрицы A из TextBox
                SquareMatrix matrixA = GetMatrixFromTextBoxes(matrixATextBoxes);

                // Проверка на верхнетреугольность
                bool isUpper = matrixA.IsUpperTriangular();

                // Отображение результата
                ResultTextBlock.Text = $"Матрица A {(isUpper ? "является" : "не является")} верхнетреугольной.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Обработчик события для проверки, является ли матрица A нижнетреугольной
        private void CheckLowerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получение матрицы A из TextBox
                SquareMatrix matrixA = GetMatrixFromTextBoxes(matrixATextBoxes);

                // Проверка на нижнетреугольность
                bool isLower = matrixA.IsLowerTriangular();

                // Отображение результата
                ResultTextBlock.Text = $"Матрица A {(isLower ? "является" : "не является")} нижнетреугольной.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Обработчик изменения текста в TextBox для размерности матрицы
        private void DimensionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(DimensionTextBox.Text, out int dimension))
            {
                if (dimension > 10)
                {
                    MessageBox.Show("Размерность матрицы должна быть меньше или равна 10.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    DimensionTextBox.Text = "10";
                    DimensionTextBox.SelectionStart = DimensionTextBox.Text.Length;
                }
                else if (dimension <= 0)
                {
                    MessageBox.Show("Размерность матрицы должна быть положительным числом.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    DimensionTextBox.Text = "1";
                    DimensionTextBox.SelectionStart = DimensionTextBox.Text.Length;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(DimensionTextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите целое число.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    DimensionTextBox.Text = "3";
                    DimensionTextBox.SelectionStart = DimensionTextBox.Text.Length;
                }
            }
        }

        // Вспомогательный метод для получения дроби из TextBox
        private Fraction GetFractionFromInput(TextBox numeratorTextBox, TextBox denominatorTextBox)
        {
            if (int.TryParse(numeratorTextBox.Text, out int numerator) &&
                int.TryParse(denominatorTextBox.Text, out int denominator))
            {
                if (denominator == 0)
                {
                    throw new DivideByZeroException("Знаменатель не может быть равен нулю.");
                }
                return new Fraction(numerator, denominator);
            }
            else
            {
                throw new FormatException("Пожалуйста, введите корректные целые числа для числителя и знаменателя.");
            }
        }

        // Обработчик события для сложения дробей
        private void FractionAddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получение дробей A и B из TextBox
                Fraction fractionA = GetFractionFromInput(NumeratorATextBox, DenominatorATextBox);
                Fraction fractionB = GetFractionFromInput(NumeratorBTextBox, DenominatorBTextBox);

                // Сложение дробей
                Fraction result = fractionA + fractionB;

                // Отображение результата
                FractionResultTextBlock.Text = $"{fractionA} + {fractionB} = {result}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Обработчик события для вычитания дробей
        private void FractionSubtractButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получение дробей A и B из TextBox
                Fraction fractionA = GetFractionFromInput(NumeratorATextBox, DenominatorATextBox);
                Fraction fractionB = GetFractionFromInput(NumeratorBTextBox, DenominatorBTextBox);

                // Вычитание дробей
                Fraction result = fractionA - fractionB;

                // Отображение результата
                FractionResultTextBlock.Text = $"{fractionA} - {fractionB} = {result}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Обработчик события для умножения дробей
        private void FractionMultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получение дробей A и B из TextBox
                Fraction fractionA = GetFractionFromInput(NumeratorATextBox, DenominatorATextBox);
                Fraction fractionB = GetFractionFromInput(NumeratorBTextBox, DenominatorBTextBox);

                // Умножение дробей
                Fraction result = fractionA * fractionB;

                // Отображение результата
                FractionResultTextBlock.Text = $"{fractionA} × {fractionB} = {result}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Обработчик события для деления дробей
        private void FractionDivideButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получение дробей A и B из TextBox
                Fraction fractionA = GetFractionFromInput(NumeratorATextBox, DenominatorATextBox);
                Fraction fractionB = GetFractionFromInput(NumeratorBTextBox, DenominatorBTextBox);

                // Деление дробей
                Fraction result = fractionA / fractionB;

                // Отображение результата
                FractionResultTextBlock.Text = $"{fractionA} ÷ {fractionB} = {result}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
