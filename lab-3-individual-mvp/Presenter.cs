using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3_individual_mvp
{
    // Класс Presenter, реализующий логику взаимодействия между представлением и моделью
    internal class Presenter
    {
        // Поля для хранения ссылки на представление и модель
        private readonly IView _view;
        private readonly FractionModel _model;

        // Конструктор, принимающий представление и инициализирующий модель
        public Presenter(IView view)
        {
            _view = view;
            _model = new FractionModel();

            // Подписка на события представления
            _view.AddFractions += OnAddFractions;
            _view.SubtractFractions += OnSubtractFractions;
            _view.MultiplyFractions += OnMultiplyFractions;
            _view.DivideFractions += OnDivideFractions;
        }

        // Обработчик события сложения дробей
        private void OnAddFractions(object sender, EventArgs e)
        {
            if (!ValidateInput(out string errorMessage))
            {
                _view.Result = errorMessage;
                return;
            }

            var result = _model.Add(
                new Fraction(int.Parse(_view.NumeratorA), int.Parse(_view.DenominatorA)),
                new Fraction(int.Parse(_view.NumeratorB), int.Parse(_view.DenominatorB))
            );
            _view.Result = result.ToString();
        }

        // Обработчик события вычитания дробей
        private void OnSubtractFractions(object sender, EventArgs e)
        {
            if (!ValidateInput(out string errorMessage))
            {
                _view.Result = errorMessage;
                return;
            }

            var result = _model.Subtract(
                new Fraction(int.Parse(_view.NumeratorA), int.Parse(_view.DenominatorA)),
                new Fraction(int.Parse(_view.NumeratorB), int.Parse(_view.DenominatorB))
            );
            _view.Result = result.ToString();
        }

        // Обработчик события умножения дробей
        private void OnMultiplyFractions(object sender, EventArgs e)
        {
            if (!ValidateInput(out string errorMessage))
            {
                _view.Result = errorMessage;
                return;
            }

            var result = _model.Multiply(
                new Fraction(int.Parse(_view.NumeratorA), int.Parse(_view.DenominatorA)),
                new Fraction(int.Parse(_view.NumeratorB), int.Parse(_view.DenominatorB))
            );
            _view.Result = result.ToString();
        }

        // Обработчик события деления дробей
        private void OnDivideFractions(object sender, EventArgs e)
        {
            if (!ValidateInput(out string errorMessage))
            {
                _view.Result = errorMessage;
                return;
            }

            try
            {
                var result = _model.Divide(
                    new Fraction(int.Parse(_view.NumeratorA), int.Parse(_view.DenominatorA)),
                    new Fraction(int.Parse(_view.NumeratorB), int.Parse(_view.DenominatorB))
                );
                _view.Result = result.ToString();
            }
            catch (DivideByZeroException ex)
            {
                _view.Result = "Ошибка: " + ex.Message;
            }
        }

        // Проверка на пустые поля ввода
        private bool ValidateInput(out string errorMessage)
        {
            errorMessage = "";

            if (
                string.IsNullOrWhiteSpace(_view.NumeratorA) || string.IsNullOrWhiteSpace(_view.DenominatorA) 
                ||
                string.IsNullOrWhiteSpace(_view.NumeratorB) || string.IsNullOrWhiteSpace(_view.DenominatorB)
                )
            {
                errorMessage = "Заполните все поля для дробей.";
                return false;
            }

            return true;
        }
    }
}
