using ValidadorCBU;

namespace WinFormCBU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCbu.Text))
                MessageBox.Show("El CBU no debe ser vacio");
            else
            {
                try
                {
                    ValidadorCbu varlidador = new ValidadorCbu(textBoxCbu.Text);
                    labelResultado.Text = $"CBU Correcto. Banco: {varlidador.bancoActual}";
                    MessageBox.Show("CBU Correcto!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"CBU NO VALIDO! {ex.Message}");
                }
            }
        }
    }
}