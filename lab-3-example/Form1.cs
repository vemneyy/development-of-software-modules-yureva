namespace lab_3_example_mvp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            presenter = new Presenter(this);
        }
    }
}
