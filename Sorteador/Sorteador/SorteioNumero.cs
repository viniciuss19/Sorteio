using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sorteador
{
    public partial class SorteioNumero : Form
    {
        public SorteioNumero()
        {
            InitializeComponent();
        }

        private void SorteioNumero_Load(object sender, EventArgs e)
        {
            lblresultado.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblresultado.Visible = true;
            Random numerorandom = new Random();
            int Inicial = Convert.ToInt32(tbInicio.Text);
            int Final = Convert.ToInt32(tbFinal.Text);
            int QuantidadeSorteio = Convert.ToInt32(tbQuantidade.Text);
            string resultado = "";
            for (int i = 0; i <= QuantidadeSorteio -1; i++)
            {
                resultado = resultado + " " + numerorandom.Next(Inicial,Final);
                lblresultado.Text = resultado;
                
            }
        }
    }
}
