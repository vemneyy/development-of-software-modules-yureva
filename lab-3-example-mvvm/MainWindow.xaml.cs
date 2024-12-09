using System.ComponentModel;
using System.Windows;

namespace lab_3_example_mvvm
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }
    class ViewModel
    {
        public Model model { get; set; }
        public ViewModel()
        {
            model = new Model();
        }
    }

    public class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private double length;
        public double Length
        {
            get { return length; }
            set
            {
                length = value;
                OnPropertyChanged("Sq"); // уведомление View о том, что изменилась площадь
            }
        }
        private double width;
        public double Width
        {
            get { return width; }
            set
            {
                width = value;
                OnPropertyChanged("Sq"); // уведомление View о том, что изменилась площадь
            }
        }
        public double Sq
        {
            //  get { return square(); }
            get { return width * length; }
        }
    }
}