using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace lab_3_mvvm
{
    // Класс главного окна приложения
    public partial class MainWindow : Window
    {
        // Конструктор главного окна
        public MainWindow()
        {
            InitializeComponent(); // Инициализация компонентов окна
            DataContext = new ViewModel(); // Установка контекста данных для привязки
        }
    }

    // Класс ViewModel, реализующий интерфейс INotifyPropertyChanged для поддержки привязки данных
    public class ViewModel : INotifyPropertyChanged
    {
        // Приватные поля для хранения значений числителей и знаменателей дробей, а также результата
        private int numeratorA;
        private int denominatorA;
        private int numeratorB;
        private int denominatorB;
        private string result;

        // Свойства для доступа к числителю и знаменателю первой дроби
        public int NumeratorA
        {
            get => numeratorA;
            set
            {
                numeratorA = value;
                OnPropertyChanged(nameof(NumeratorA)); // Уведомление об изменении свойства
            }
        }

        public int DenominatorA
        {
            get => denominatorA;
            set
            {
                denominatorA = value;
                OnPropertyChanged(nameof(DenominatorA)); // Уведомление об изменении свойства
            }
        }

        // Свойства для доступа к числителю и знаменателю второй дроби
        public int NumeratorB
        {
            get => numeratorB;
            set
            {
                numeratorB = value;
                OnPropertyChanged(nameof(NumeratorB)); // Уведомление об изменении свойства
            }
        }

        public int DenominatorB
        {
            get => denominatorB;
            set
            {
                denominatorB = value;
                OnPropertyChanged(nameof(DenominatorB)); // Уведомление об изменении свойства
            }
        }

        // Свойство для доступа к результату операции
        public string Result
        {
            get => result;
            set
            {
                result = value;
                OnPropertyChanged(nameof(Result)); // Уведомление об изменении свойства
            }
        }

        // Команды для выполнения арифметических операций
        public ICommand AddCommand { get; }
        public ICommand SubtractCommand { get; }
        public ICommand MultiplyCommand { get; }
        public ICommand DivideCommand { get; }

        // Конструктор ViewModel
        public ViewModel()
        {
            DenominatorA = 1; // Инициализация знаменателя первой дроби
            DenominatorB = 1; // Инициализация знаменателя второй дроби

            // Инициализация команд
            AddCommand = new AddCommandImpl(this);
            SubtractCommand = new SubtractCommandImpl(this);
            MultiplyCommand = new MultiplyCommandImpl(this);
            DivideCommand = new DivideCommandImpl(this);
        }

        // Метод для выполнения арифметической операции с обработкой исключений
        private void TryCalculate(Func<Fraction, Fraction, Fraction> operation)
        {
            try
            {
                // Создание объектов дробей
                var fractionA = new Fraction(NumeratorA, DenominatorA);
                var fractionB = new Fraction(NumeratorB, DenominatorB);
                // Выполнение операции
                var res = operation(fractionA, fractionB);
                // Установка результата
                Result = res.ToString();
            }
            catch (Exception ex)
            {
                // Установка сообщения об ошибке
                Result = "Ошибка: " + ex.Message;
            }
        }

        // Событие для уведомления об изменении свойства
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        // Класс команды для сложения дробей
        private class AddCommandImpl : ICommand
        {
            private readonly ViewModel vm;
            public AddCommandImpl(ViewModel vm) { this.vm = vm; }
            public bool CanExecute(object? parameter) => true;
            public void Execute(object? parameter) => vm.TryCalculate((a, b) => a + b);
            public event EventHandler? CanExecuteChanged { add { } remove { } }
        }

        // Класс команды для вычитания дробей
        private class SubtractCommandImpl : ICommand
        {
            private readonly ViewModel vm;
            public SubtractCommandImpl(ViewModel vm) { this.vm = vm; }
            public bool CanExecute(object? parameter) => true; // Команда всегда может быть выполнена
            public void Execute(object? parameter) => vm.TryCalculate((a, b) => a - b);
            public event EventHandler? CanExecuteChanged { add { } remove { } }
        }

        // Класс команды для умножения дробей
        private class MultiplyCommandImpl : ICommand
        {
            private readonly ViewModel vm;
            public MultiplyCommandImpl(ViewModel vm) { this.vm = vm; }
            public bool CanExecute(object? parameter) => true;
            public void Execute(object? parameter) => vm.TryCalculate((a, b) => a * b); // Выполнение операции умножения
            public event EventHandler? CanExecuteChanged { add { } remove { } }
        }

        // Класс команды для деления дробей
        private class DivideCommandImpl : ICommand
        {
            private readonly ViewModel vm;
            public DivideCommandImpl(ViewModel vm) { this.vm = vm; }
            public bool CanExecute(object? parameter) => true;
            public void Execute(object? parameter) => vm.TryCalculate((a, b) => a / b); // Выполнение операции деления
            public event EventHandler? CanExecuteChanged { add { } remove { } }
        }
    }
}
