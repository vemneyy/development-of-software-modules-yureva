using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3_individual_mvp
{
    internal class Presenter
    {
        private readonly IView _view;
        private readonly FractionModel _model;

        public Presenter(IView view)
        {
            _view = view;
            _model = new FractionModel();

            _view.AddFractions += OnAddFractions;
            _view.SubtractFractions += OnSubtractFractions;
            _view.MultiplyFractions += OnMultiplyFractions;
            _view.DivideFractions += OnDivideFractions;
        }

        private void OnAddFractions(object sender, EventArgs e)
        {
            var result = _model.Add(
                new Fraction(int.Parse(_view.NumeratorA), int.Parse(_view.DenominatorA)),
                new Fraction(int.Parse(_view.NumeratorB), int.Parse(_view.DenominatorB))
            );
            _view.Result = result.ToString();
        }

        private void OnSubtractFractions(object sender, EventArgs e)
        {
            var result = _model.Subtract(
                new Fraction(int.Parse(_view.NumeratorA), int.Parse(_view.DenominatorA)),
                new Fraction(int.Parse(_view.NumeratorB), int.Parse(_view.DenominatorB))
            );
            _view.Result = result.ToString();
        }

        private void OnMultiplyFractions(object sender, EventArgs e)
        {
            var result = _model.Multiply(
                new Fraction(int.Parse(_view.NumeratorA), int.Parse(_view.DenominatorA)),
                new Fraction(int.Parse(_view.NumeratorB), int.Parse(_view.DenominatorB))
            );
            _view.Result = result.ToString();
        }

        private void OnDivideFractions(object sender, EventArgs e)
        {
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
                _view.Result = "Error: " + ex.Message;
            }
        }
    }
}
