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
            conexao.ConnectionString = "Data Source=DESKTOP-V3GENC1;Initial Catalog=Sorteio;Integrated Security=True";
            SqlCommand sql = new SqlCommand();
            sql.Connection = conexao;

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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = "Data Source=DESKTOP-V3GENC1;Initial Catalog=Sorteio;Integrated Security=True";
            SqlCommand sql = new SqlCommand();
            sql.Connection = conexao;

            sql.CommandText = "DELETE FROM PESSOAS";
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
                dataGridView1.ClearSelection();
                AtualizarPessoas();
                conexao.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = "Data Source=DESKTOP-V3GENC1;Initial Catalog=Sorteio;Integrated Security=True";
            SqlCommand sql = new SqlCommand();
            sql.Connection = conexao;

            try
            {
                conexao.Open();
                sql.CommandText = $"INSERT INTO Pessoas (Nome) Values (@nome)";
                sql.Parameters.AddWithValue("@nome", tbNomeAdd.Text);
                int i = sql.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                tbNomeAdd.Clear();
                AtualizarPessoas();
                conexao.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           string conexion = "Data Source=DESKTOP-V3GENC1;Initial Catalog=Sorteio;Integrated Security=True";
            SqlConnection conexao = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand($"SELECT TOP 1 * FROM Pessoas ORDER BY NEWID()", conexao);
            SqlDataReader mreader;
            lblresultadosorteio.Visible = true;
            try
            {
                conexao.Open();
                mreader = cmd.ExecuteReader();

                while (mreader.Read())
                {
                    lblresultadosorteio.Text = Convert.ToString(mreader["Nome"]);
                    deletarsorteado();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conexao.Close();
            }
        }
        public void deletarsorteado()
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = "Data Source=DESKTOP-V3GENC1;Initial Catalog=Sorteio;Integrated Security=True";
            SqlCommand sql = new SqlCommand();
            sql.Connection = conexao;
            sql.CommandText = $"DELETE FROM PESSOAS WHERE Nome = '{lblresultadosorteio.Text}'";
            try
            {
                conexao.Open();
                int i = sql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dataGridView1.ClearSelection();
            
                conexao.Close();
            }
        }
    }

    
}
