namespace WinFormCBU
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxCbu = new TextBox();
            label1 = new Label();
            button1 = new Button();
            labelResultado = new Label();
            SuspendLayout();
            // 
            // textBoxCbu
            // 
            textBoxCbu.Location = new Point(232, 104);
            textBoxCbu.Name = "textBoxCbu";
            textBoxCbu.Size = new Size(321, 23);
            textBoxCbu.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(129, 107);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 1;
            label1.Text = "Ingrese el CBU:";
            // 
            // button1
            // 
            button1.Location = new Point(232, 152);
            button1.Name = "button1";
            button1.Size = new Size(148, 38);
            button1.TabIndex = 2;
            button1.Text = "Validar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // labelResultado
            // 
            labelResultado.AutoSize = true;
            labelResultado.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelResultado.Location = new Point(232, 209);
            labelResultado.Name = "labelResultado";
            labelResultado.Size = new Size(110, 30);
            labelResultado.TabIndex = 3;
            labelResultado.Text = "Resultado";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelResultado);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBoxCbu);
            Name = "Form1";
            Text = "Validador CBU";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxCbu;
        private Label label1;
        private Button button1;
        private Label labelResultado;
    }
}