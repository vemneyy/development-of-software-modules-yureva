using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3_individual_mvvm.Model
{
    // Класс для представления дроби
    public class Fraction
    {
        // Числитель дроби
        public int Numerator { get; }
        // Знаменатель дроби
        public int Denominator { get; }

        // Конструктор с проверкой знаменателя
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Делитель не может быть нулём.");
            Numerator = numerator;
            Denominator = denominator;
        }

        // Переопределение метода ToString для удобного вывода дроби
        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }

    // Класс для работы с дробями
    public class FractionModel
    {
        // Метод для сложения двух дробей
        public Fraction Add(Fraction a, Fraction b)
        {
            int numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            int denominator = a.Denominator * b.Denominator;
            return new Fraction(numerator, denominator);
        }

        // Метод для вычитания одной дроби из другой
        public Fraction Subtract(Fraction a, Fraction b)
        {
            int numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            int denominator = a.Denominator * b.Denominator;
            return new Fraction(numerator, denominator);
        }

        // Метод для умножения двух дробей
        public Fraction Multiply(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        // Метод для деления одной дроби на другую
        public Fraction Divide(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
                throw new DivideByZeroException("Нельзя делить на ноль.");
            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }
    }
}
