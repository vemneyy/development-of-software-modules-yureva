using System;
using System.Windows.Forms;

namespace lab_3_example_mvp
{
    public partial class Form1 : Form, IView
    {
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label labelWidth;
        private Label labelHeight;
        private Presenter presenter;

        #region IView Implementation

        public event EventHandler<EventArgs> SetA;
        public event EventHandler<EventArgs> SetB;

        public string Sq
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public double InputA
        {
            set { textBox1.Text = value.ToString(); }
            get { return string.IsNullOrWhiteSpace(textBox1.Text) ? 0 : Convert.ToDouble(textBox1.Text); }
        }

        public double InputB
        {
            set { textBox2.Text = value.ToString(); }
            get { return string.IsNullOrWhiteSpace(textBox2.Text) ? 0 : Convert.ToDouble(textBox2.Text); }
        }

        #endregion

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            this.textBox2 = new TextBox();
            this.labelWidth = new Label();
            this.labelHeight = new Label();
            this.SuspendLayout();

            // Label1
            this.label1.Location = new System.Drawing.Point(150, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 30);
            this.label1.Text = "0";

            // TextBox1
            this.textBox1.Location = new System.Drawing.Point(50, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TextChanged += new EventHandler(this.TextBox1_TextChanged);

            // LabelWidth
            this.labelWidth.Location = new System.Drawing.Point(50, 30);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(100, 20);
            this.labelWidth.Text = "Width";

            // TextBox2
            this.textBox2.Location = new System.Drawing.Point(200, 50);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TextChanged += new EventHandler(this.TextBox2_TextChanged);

            // LabelHeight
            this.labelHeight.Location = new System.Drawing.Point(200, 30);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(100, 20);
            this.labelHeight.Text = "Height";

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.labelHeight);
            this.Name = "Form1";
            this.Text = "Rectangle Area Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out _))
            {
                SetA?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                textBox1.Text = "0";
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox2.Text, out _))
            {
                SetB?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                textBox2.Text = "0";
            }
        }
    }

    public class Model
    {
        private double a;
        private double b;

        public double A
        {
            get { return a; }
            set { a = value; }
        }

        public double B
        {
            get { return b; }
            set { b = value; }
        }

        public double Square()
        {
            return a * b;
        }
    }

    public interface IView
    {
        string Sq { get; set; }
        double InputA { get; set; }
        double InputB { get; set; }

        event EventHandler<EventArgs> SetA;
        event EventHandler<EventArgs> SetB;
    }

    public class Presenter
    {
        private Model _model = new Model();
        private IView _view;

        public Presenter(IView view)
        {
            _view = view;
            _view.SetA += OnSetA;
            _view.SetB += OnSetB;
            RefreshView();
        }

        public void OnSetA(object sender, EventArgs e)
        {
            _model.A = _view.InputA;
            RefreshView();
        }

        public void OnSetB(object sender, EventArgs e)
        {
            _model.B = _view.InputB;
            RefreshView();
        }

        public void RefreshView()
        {
            _view.Sq = _model.Square().ToString();
        }
    }
}
