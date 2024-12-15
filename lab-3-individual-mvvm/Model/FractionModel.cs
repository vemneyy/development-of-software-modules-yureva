using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3_individual_mvvm.Model
{
    public class Fraction
    {
        public int Numerator { get; }
        public int Denominator { get; }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Делитель не может быть нулём.");
            Numerator = numerator;
            Denominator = denominator;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }

    public class FractionModel
    {
        public Fraction Add(Fraction a, Fraction b)
        {
            int numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            int denominator = a.Denominator * b.Denominator;
            return new Fraction(numerator, denominator);
        }

        public Fraction Subtract(Fraction a, Fraction b)
        {
            int numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            int denominator = a.Denominator * b.Denominator;
            return new Fraction(numerator, denominator);
        }

        public Fraction Multiply(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public Fraction Divide(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
                throw new DivideByZeroException("Нельзя делить на ноль.");
            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }
    }
}
