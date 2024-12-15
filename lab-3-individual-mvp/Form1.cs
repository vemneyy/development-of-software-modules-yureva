using System.ComponentModel;

namespace lab_3_individual_mvp
{
    public partial class Form1 : Form, IView
    {
        private Presenter _presenter;

        public Form1()
        {
            InitializeComponent();
            _presenter = new Presenter(this);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Result
        {
            get => labelResult.Text;
            set => labelResult.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NumeratorA
        {
            get => textBoxNumeratorA.Text;
            set => textBoxNumeratorA.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DenominatorA
        {
            get => textBoxDenominatorA.Text;
            set => textBoxDenominatorA.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NumeratorB
        {
            get => textBoxNumeratorB.Text;
            set => textBoxNumeratorB.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DenominatorB
        {
            get => textBoxDenominatorB.Text;
            set => textBoxDenominatorB.Text = value;
        }

        public event EventHandler AddFractions;
        public event EventHandler SubtractFractions;
        public event EventHandler MultiplyFractions;
        public event EventHandler DivideFractions;

        private void buttonAdd_Click(object sender, EventArgs e) => AddFractions?.Invoke(this, EventArgs.Empty);
        private void buttonSubtract_Click(object sender, EventArgs e) => SubtractFractions?.Invoke(this, EventArgs.Empty);
        private void buttonMultiply_Click(object sender, EventArgs e) => MultiplyFractions?.Invoke(this, EventArgs.Empty);
        private void buttonDivide_Click(object sender, EventArgs e) => DivideFractions?.Invoke(this, EventArgs.Empty);
    }
}
