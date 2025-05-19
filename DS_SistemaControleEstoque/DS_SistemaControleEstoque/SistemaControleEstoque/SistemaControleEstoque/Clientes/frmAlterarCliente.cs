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
    public partial class frmAlterarCliente : Form
    {
        private MySqlConnection conexao = new MySqlConnection("Server=localhost;Port=3306;Database=briet_sitema_controle_estoque;User=root");

        public frmAlterarCliente()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
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
                    btnAlterar.Enabled = true;
                    txtNome.Focus();
                    Liberar();
                }
                else
                {
                    toolStripStatusLlblMsg.Text = "Clente não cadastrado. Cadastre primeiro ou digite outro RG e pressione <ENTER>.";
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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRG.Text) ||
                string.IsNullOrEmpty(txtNome.Text) ||
                string.IsNullOrEmpty(txtEndereco.Text) ||
                string.IsNullOrEmpty(txtCidade.Text) ||
                string.IsNullOrEmpty(txtFone.Text) ||
                cmbEstado.SelectedIndex < 0)
            {
                toolStripStatusLlblMsg.Text = "Todos os campos devem ser preenchidos para que o cliente seja alterado.";
                return;
            }

            try
            {
                string query = "UPDATE tb_cliente SET cli_nome = @nome, cli_endereco = @endereco, cli_cidade = @cidade, cli_uf = @uf, cli_fone = @fone WHERE cli_rg = @rg";
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@rg", txtRG.Text);
                comando.Parameters.AddWithValue("@nome", txtNome.Text);
                comando.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                comando.Parameters.AddWithValue("@cidade", txtCidade.Text);
                comando.Parameters.AddWithValue("@uf", cmbEstado.Text);
                comando.Parameters.AddWithValue("@fone", txtFone.Text);
                conexao.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cliente alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Liberar()
        {
            txtRG.ReadOnly = true;
            txtNome.ReadOnly = false;
            txtEndereco.ReadOnly = false;
            txtCidade.ReadOnly = false;
            cmbEstado.Enabled = true;
            txtFone.ReadOnly = false;
            btnAlterar.Enabled = true;
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
            btnAlterar.Enabled = false;
        }
    }
}
