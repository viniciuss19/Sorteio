using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sorteador
{
    public partial class SorteioPessoa : Form
    {
        
        public SorteioPessoa()
        {
            InitializeComponent();
            
        }

        private void SorteioPessoa_Load(object sender, EventArgs e)
        {
            lblresultadosorteio.Visible = false;
            AtualizarPessoas();
           
        }
        public void AtualizarPessoas()
        {

        }
    }
}
