using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();            
        }
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string num1 = this.txtNumero1.Text;
            string num2 = this.txtNumero2.Text;
            string op = this.cmbOperador.Text.Trim();

            if (op.Length == 0) {
                op = "+";
                this.cmbOperador.SelectedIndex = 1;
            }

            double resultado = Operar(num1, num2, op);            
            this.lblResultado.Text = resultado.ToString();

            StringBuilder strResult = new StringBuilder();

            if (num1.Length == 0 || !num1.All(Char.IsDigit)) { 
                num1="0";
            }

            if (num2.Length == 0 || !num2.All(Char.IsDigit))
            {
                num2 = "0";
            }

            strResult.Append(num1 + " " + op + " " + num2 + " = " + resultado.ToString());
            this.lstResultado.Items.Add(strResult);
        }

        private void Limpiar() 
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "";            
            this.cmbOperador.SelectedIndex = 0;
        }
        private double Operar(string numero1, string numero2, string operador) 
        {

            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);

            return Calculadora.Operar(num1, num2, operador[0]);
        }



        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando oOperando = new Operando();

            string result = oOperando.DecimalBinario(lblResultado.Text);
            this.lblResultado.Text = result;
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando oOperando = new Operando();

            string result = oOperando.BinarioDecimal(lblResultado.Text);
            this.lblResultado.Text = result;
        }
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "Esta seguro que desea salir?";
            string caption = "Salir";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            
            result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.Yes)
            {
                this.FormClosing -= FormCalculadora_FormClosing;                
                this.Close();
            }
            else 
            { 
                e.Cancel = true;
            }
        }
    }
}
