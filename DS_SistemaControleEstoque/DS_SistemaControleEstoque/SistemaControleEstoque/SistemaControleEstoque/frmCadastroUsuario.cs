using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SistemaControleEstoque {
    public partial class frmCadastroUsuario: Form {

        private MySqlConnection conexao = new MySqlConnection("Server=localhost;Port=3306;Database=briet_sitema_controle_estoque;User=root");
        private bool isUserRegistered;

        public frmCadastroUsuario() {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e) {
            Close();
        }

        private void frmCadastroUsuario_Activated(object sender, EventArgs e) {
            txtUsuario.Focus();
        }

        private void btnCadastrar_Click(object sender, EventArgs e) {
            try {
                string query = "INSERT INTO tb_login (log_usuario, log_senha, log_nome, log_ult_atualizacao) " +
                               "VALUES (@usuario, @senha, @nome, CURRENT_TIMESTAMP)";

                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                comando.Parameters.AddWithValue("@senha", txtSenha.Text);
                comando.Parameters.AddWithValue("@nome", txtNome.Text);
                conexao.Open();
                comando.ExecuteNonQuery();
                limparFormulario();
                MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolStripStatusLlblMsg.Text = "Informe o usuário <ENTER>";
                limparFormulario();
            }
            catch(MySqlException err) {
                MessageBox.Show(err.Message, "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                conexao.Close();
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e) {
            
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtSenha.Text) || isUserRegistered)
            {
                btnCadastrar.Enabled = false;
            }
            else
            {
                btnCadastrar.Enabled = true;
            }
        }

        private void limparFormulario()
        {
            txtNome.Text = "";
            txtNome.ReadOnly = false;

            txtUsuario.Text = "";
            txtUsuario.Focus();

            txtSenha.Text = "";
            txtSenha.ReadOnly = false;

            btnCadastrar.Enabled = false;

            isUserRegistered = false;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparFormulario();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            try
            {
                string query = "SELECT * FROM tb_login WHERE log_usuario = @usuario";
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                conexao.Open();
                MySqlDataReader dataReader = comando.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        toolStripStatusLlblMsg.Text = "Usuário já cadastrado.";

                        txtNome.Text = dataReader["log_nome"].ToString();
                        txtSenha.Text = dataReader["log_senha"].ToString();
                    }

                    txtNome.ReadOnly = true;
                    txtSenha.ReadOnly = true;

                    isUserRegistered = true;

                }
                else
                {
                    toolStripStatusLlblMsg.Text = "Usuário ainda não cadastrado. Digite o NOME e SENHA do usuário";

                    txtNome.ReadOnly = false;
                    txtNome.Text = "";

                    txtSenha.ReadOnly = false;
                    txtSenha.Text = "";

                    isUserRegistered = false;
                }

                if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtSenha.Text) || isUserRegistered)
                {
                    btnCadastrar.Enabled = false;
                }
                else
                {
                    btnCadastrar.Enabled = true;
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
    }
}
