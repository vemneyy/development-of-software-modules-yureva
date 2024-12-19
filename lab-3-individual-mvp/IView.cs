// IView.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3_individual_mvp
{
    public interface IView
    {
        // Числитель первой дроби
        string NumeratorA { get; set; }

        // Знаменатель первой дроби
        string DenominatorA { get; set; }

        // Числитель второй дроби
        string NumeratorB { get; set; }

        // Знаменатель второй дроби
        string DenominatorB { get; set; }

        // Результат операции с дробями
        string Result { get; set; }

        // Событие для сложения дробей
        event EventHandler AddFractions;

        // Событие для вычитания дробей
        event EventHandler SubtractFractions;

        // Событие для умножения дробей
        event EventHandler MultiplyFractions;

        // Событие для деления дробей
        event EventHandler DivideFractions;
    }

}
