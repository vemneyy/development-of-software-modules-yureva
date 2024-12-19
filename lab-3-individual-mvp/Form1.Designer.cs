namespace lab_3_individual_mvp
{
    partial class Form1
    {
        private TextBox textBoxNumeratorA;
        private TextBox textBoxDenominatorA;
        private TextBox textBoxNumeratorB;
        private TextBox textBoxDenominatorB;
        private Label labelResult;
        private Button buttonAdd;
        private Button buttonSubtract;
        private Button buttonMultiply;
        private Button buttonDivide;

        private void InitializeComponent()
        {
            textBoxNumeratorA = new TextBox();
            textBoxDenominatorA = new TextBox();
            textBoxNumeratorB = new TextBox();
            textBoxDenominatorB = new TextBox();
            labelResult = new Label();
            buttonAdd = new Button();
            buttonSubtract = new Button();
            buttonMultiply = new Button();
            buttonDivide = new Button();
            groupBoxA = new GroupBox();
            groupBoxB = new GroupBox();
            groupBoxA.SuspendLayout();
            groupBoxB.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxNumeratorA
            // 
            textBoxNumeratorA.Location = new Point(50, 30);
            textBoxNumeratorA.Name = "textBoxNumeratorA";
            textBoxNumeratorA.Size = new Size(50, 35);
            textBoxNumeratorA.TabIndex = 0;
            // 
            // textBoxDenominatorA
            // 
            textBoxDenominatorA.Location = new Point(50, 70);
            textBoxDenominatorA.Name = "textBoxDenominatorA";
            textBoxDenominatorA.Size = new Size(50, 35);
            textBoxDenominatorA.TabIndex = 1;
            // 
            // textBoxNumeratorB
            // 
            textBoxNumeratorB.Location = new Point(50, 30);
            textBoxNumeratorB.Name = "textBoxNumeratorB";
            textBoxNumeratorB.Size = new Size(50, 35);
            textBoxNumeratorB.TabIndex = 2;
            // 
            // textBoxDenominatorB
            // 
            textBoxDenominatorB.Location = new Point(50, 70);
            textBoxDenominatorB.Name = "textBoxDenominatorB";
            textBoxDenominatorB.Size = new Size(50, 35);
            textBoxDenominatorB.TabIndex = 3;
            // 
            // labelResult
            // 
            labelResult.BorderStyle = BorderStyle.FixedSingle;
            labelResult.Location = new Point(380, 40);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(150, 100);
            labelResult.TabIndex = 4;
            labelResult.Text = "Результат";
            labelResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(50, 160);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(100, 78);
            buttonAdd.TabIndex = 5;
            buttonAdd.Text = "A + B";
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonSubtract
            // 
            buttonSubtract.Location = new Point(160, 160);
            buttonSubtract.Name = "buttonSubtract";
            buttonSubtract.Size = new Size(100, 78);
            buttonSubtract.TabIndex = 6;
            buttonSubtract.Text = "A - B";
            buttonSubtract.Click += buttonSubtract_Click;
            // 
            // buttonMultiply
            // 
            buttonMultiply.Location = new Point(270, 160);
            buttonMultiply.Name = "buttonMultiply";
            buttonMultiply.Size = new Size(100, 78);
            buttonMultiply.TabIndex = 7;
            buttonMultiply.Text = "A × B";
            buttonMultiply.Click += buttonMultiply_Click;
            // 
            // buttonDivide
            // 
            buttonDivide.Location = new Point(380, 160);
            buttonDivide.Name = "buttonDivide";
            buttonDivide.Size = new Size(100, 78);
            buttonDivide.TabIndex = 8;
            buttonDivide.Text = "A ÷ B";
            buttonDivide.Click += buttonDivide_Click;
            // 
            // groupBoxA
            // 
            groupBoxA.Controls.Add(textBoxNumeratorA);
            groupBoxA.Controls.Add(textBoxDenominatorA);
            groupBoxA.Location = new Point(20, 20);
            groupBoxA.Name = "groupBoxA";
            groupBoxA.Size = new Size(150, 120);
            groupBoxA.TabIndex = 0;
            groupBoxA.TabStop = false;
            groupBoxA.Text = "Дробь №1";
            // 
            // groupBoxB
            // 
            groupBoxB.Controls.Add(textBoxNumeratorB);
            groupBoxB.Controls.Add(textBoxDenominatorB);
            groupBoxB.Location = new Point(200, 20);
            groupBoxB.Name = "groupBoxB";
            groupBoxB.Size = new Size(150, 120);
            groupBoxB.TabIndex = 1;
            groupBoxB.TabStop = false;
            groupBoxB.Text = "Дробь №2";
            // 
            // Form1
            // 
            ClientSize = new Size(600, 250);
            Controls.Add(groupBoxA);
            Controls.Add(groupBoxB);
            Controls.Add(labelResult);
            Controls.Add(buttonAdd);
            Controls.Add(buttonSubtract);
            Controls.Add(buttonMultiply);
            Controls.Add(buttonDivide);
            Name = "Form1";
            Text = "Операции над дробями";
            groupBoxA.ResumeLayout(false);
            groupBoxA.PerformLayout();
            groupBoxB.ResumeLayout(false);
            groupBoxB.PerformLayout();
            ResumeLayout(false);
        }

        private GroupBox groupBoxA;
        private GroupBox groupBoxB;
    }
}
