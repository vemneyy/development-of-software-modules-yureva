using lab_3_individual_mvvm.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab_3_individual_mvvm
{
    // Определение частичного класса MainWindow, наследующего от Window
    public partial class MainWindow : Window
    {
        // Конструктор класса MainWindow
        public MainWindow()
        {
            // Инициализация компонентов
            InitializeComponent();
            // Установка DataContext для привязки данных к MainViewModel
            DataContext = new MainViewModel();
        }
    }
}