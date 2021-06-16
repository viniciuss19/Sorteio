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
            SqlConnection conexao = new SqlConnection();
          
            
           
        }
        public void AtualizarPessoas()
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = $"Data Source = DESKTOP - V3GENC1; Initial Catalog = Exercicio; Integrated Security = True";
            SqlCommand sql = new SqlCommand();
            sql.CommandText = "Select Nome FROM Pessoas";
            try
            {

                conexao.Open();
                int i = sql.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(sql.CommandText, conexao);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
                conexao.Close();
            }
        }
    }
}
