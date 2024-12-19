using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lab_3_individual_mvvm.Commands
{
    // Класс RelayCommand реализует интерфейс ICommand
    public class RelayCommand : ICommand
    {
        // Поля для хранения делегатов действий и условий выполнения
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        // Конструктор класса, принимающий делегаты действий и условий выполнения
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            // Проверка на null и инициализация делегатов
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // Метод, определяющий, может ли команда выполняться
        public bool CanExecute(object parameter)
        {
            // Если делегат условия выполнения не задан, команда может выполняться всегда
            return _canExecute == null || _canExecute();
        }

        // Метод, выполняющий команду
        public void Execute(object parameter)
        {
            // Вызов делегата действия
            _execute();
        }

        // Событие, уведомляющее об изменении состояния выполнения команды
        public event EventHandler CanExecuteChanged
        {
            // Добавление и удаление обработчиков событий
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
