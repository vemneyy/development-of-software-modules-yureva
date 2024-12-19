using lab_3_individual_mvvm.Model;
using System;
using System.ComponentModel;
using System.Windows.Input;
using lab_3_individual_mvvm.Commands;

namespace lab_3_individual_mvvm.ViewModels
{
    // Класс MainViewModel реализует интерфейс INotifyPropertyChanged для уведомления об изменениях свойств
    public class MainViewModel : INotifyPropertyChanged
    {
        // Модель для работы с дробями
        private readonly FractionModel _model = new();
        // Поля для хранения значений числителей и знаменателей дробей, а также результата операции
        private string _numeratorA;
        private string _denominatorA;
        private string _numeratorB;
        private string _denominatorB;
        private string _result;

        // Свойства для привязки к элементам интерфейса
        public string NumeratorA
        {
            get => _numeratorA;
            set
            {
                _numeratorA = value;
                OnPropertyChanged(nameof(NumeratorA));
            }
        }

        public string DenominatorA
        {
            get => _denominatorA;
            set
            {
                _denominatorA = value;
                OnPropertyChanged(nameof(DenominatorA));
            }
        }

        public string NumeratorB
        {
            get => _numeratorB;
            set
            {
                _numeratorB = value;
                OnPropertyChanged(nameof(NumeratorB));
            }
        }

        public string DenominatorB
        {
            get => _denominatorB;
            set
            {
                _denominatorB = value;
                OnPropertyChanged(nameof(DenominatorB));
            }
        }

        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        // Команды для выполнения операций с дробями
        public ICommand AddCommand { get; }
        public ICommand SubtractCommand { get; }
        public ICommand MultiplyCommand { get; }
        public ICommand DivideCommand { get; }

        // Конструктор, инициализирующий команды
        public MainViewModel()
        {
            AddCommand = new RelayCommand(AddFractions);
            SubtractCommand = new RelayCommand(SubtractFractions);
            MultiplyCommand = new RelayCommand(MultiplyFractions);
            DivideCommand = new RelayCommand(DivideFractions);
        }

        // Методы для выполнения операций с дробями
        private void AddFractions()
        {
            ExecuteOperation((a, b) => _model.Add(a, b));
        }

        private void SubtractFractions()
        {
            ExecuteOperation((a, b) => _model.Subtract(a, b));
        }

        private void MultiplyFractions()
        {
            ExecuteOperation((a, b) => _model.Multiply(a, b));
        }

        private void DivideFractions()
        {
            try
            {
                ExecuteOperation((a, b) => _model.Divide(a, b));
            }
            catch (DivideByZeroException ex)
            {
                Result = $"Error: {ex.Message}";
            }
        }

        // Метод для выполнения операции с дробями и обработки ошибок
        private void ExecuteOperation(Func<Fraction, Fraction, Fraction> operation)
        {
            try
            {
                var fractionA = new Fraction(int.Parse(NumeratorA), int.Parse(DenominatorA));
                var fractionB = new Fraction(int.Parse(NumeratorB), int.Parse(DenominatorB));
                var result = operation(fractionA, fractionB);
                Result = result.ToString();
            }
            catch (Exception ex)
            {
                Result = $"Error: {ex.Message}";
            }
        }

        // Событие для уведомления об изменении свойств
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
