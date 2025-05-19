using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaControleEstoque.Clientes
{
    public partial class frmExcluirCliente : Form
    {
        private MySqlConnection conexao = new MySqlConnection("Server=localhost;Port=3306;Database=briet_sitema_controle_estoque;User=root");

        public frmExcluirCliente()
        {
            InitializeComponent();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM tb_cliente WHERE cli_rg = @rg";
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@rg", txtRG.Text);
                conexao.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cliente removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpar();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.Message, "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void txtRG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            try
            {
                string query = "SELECT * FROM tb_cliente WHERE cli_rg = @rg";
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@rg", txtRG.Text);
                conexao.Open();
                MySqlDataReader dataReader = comando.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        txtNome.Text = dataReader["cli_nome"].ToString();
                        txtEndereco.Text = dataReader["cli_endereco"].ToString();
                        txtCidade.Text = dataReader["cli_cidade"].ToString();
                        cmbEstado.Text = dataReader["cli_uf"].ToString();
                        txtFone.Text = dataReader["cli_fone"].ToString();
                    }

                    toolStripStatusLlblMsg.Text = "Preencha o formulário e clique no botão cadastrar.";
                    btnExcluir.Enabled = true;
                    txtRG.ReadOnly = true;
                }
                else
                {
                    toolStripStatusLlblMsg.Text = "Cliente não cadastrado. Cadastre primeiro ou digite outro RG e pressione <ENTER>.";
                }
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.Message, "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Limpar()
        {
            toolStripStatusLlblMsg.Text = "Informe o RG do Cliente e pressione <ENTER>";
            txtRG.Clear();
            txtNome.Clear();
            txtEndereco.Clear();
            txtCidade.Clear();
            cmbEstado.SelectedIndex = -1;
            txtFone.Clear();

            txtRG.ReadOnly = false;
            txtRG.Focus();
            txtNome.ReadOnly = true;
            txtEndereco.ReadOnly = true;
            txtCidade.ReadOnly = true;
            cmbEstado.Enabled = false;
            txtFone.ReadOnly = true;
            btnExcluir.Enabled = false;
        }
    }
}
