// Fraction.cs

using System;

namespace lab_3_mvvm
{
    public class Fraction
    {
        public int Numerator { get; set; }     // Числитель дроби
        public int Denominator { get; set; }   // Знаменатель дроби

        // Конструктор с проверкой знаменателя и упрощением дроби
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Знаменатель не может быть нулём.");
            Numerator = numerator;
            Denominator = denominator;
            Simplify();
        }

        // Метод для упрощения дроби
        public void Simplify()
        {
            int gcd = GCD(Math.Abs(Numerator), Math.Abs(Denominator));
            Numerator /= gcd;
            Denominator /= gcd;
            // Переносим знак в числитель
            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }

        // Метод для нахождения наибольшего общего делителя
        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Переопределение метода ToString для удобного вывода дроби
        public override string ToString()
        {
            if (Denominator == 1)
                return $"{Numerator}";
            else if (Numerator == 0)
                return "0";
            else
                return $"{Numerator}/{Denominator}";
        }

        // Перегрузка оператора сложения
        public static Fraction operator +(Fraction a, Fraction b)
        {
            int numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            int denominator = a.Denominator * b.Denominator;
            return new Fraction(numerator, denominator);
        }

        // Перегрузка оператора вычитания
        public static Fraction operator -(Fraction a, Fraction b)
        {
            int numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            int denominator = a.Denominator * b.Denominator;
            return new Fraction(numerator, denominator);
        }

        // Перегрузка оператора умножения
        public static Fraction operator *(Fraction a, Fraction b)
        {
            int numerator = a.Numerator * b.Numerator;
            int denominator = a.Denominator * b.Denominator;
            return new Fraction(numerator, denominator);
        }

        // Перегрузка оператора деления с проверкой на деление на ноль
        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
                throw new DivideByZeroException("Нельзя делить на ноль.");
            int numerator = a.Numerator * b.Denominator;
            int denominator = a.Denominator * b.Numerator;
            return new Fraction(numerator, denominator);
        }
    }
}