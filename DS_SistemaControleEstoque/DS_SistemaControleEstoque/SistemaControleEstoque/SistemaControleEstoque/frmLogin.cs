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
    public partial class frmLogin: Form {

        private MySqlConnection conexao = new MySqlConnection("Server=localhost;Port=3306;Database=briet_sitema_controle_estoque;User=root");

        public frmLogin() {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e) {
            if(txtUsuarioLogin.Text == "") {
                MessageBox.Show("É necessário informar um usuário.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuarioLogin.Focus();
                return;
            }

            if(txtSenhaLogin.Text == "") {
                MessageBox.Show("É necessário informar uma senha.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenhaLogin.Focus();
                return;
            }

            try {
                string query = "SELECT log_senha FROM tb_login WHERE log_usuario = @usuario";
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@usuario", txtUsuarioLogin.Text);
                conexao.Open();
                var result = comando.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Usuário não cadastrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuarioLogin.Focus();
                    return;
                }

                if (result.ToString() != txtSenhaLogin.Text)
                {
                    MessageBox.Show("Senha inválida.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSenhaLogin.Focus();
                    return;
                }

                Form frmPrincipal = new frmPrincipal();
                frmPrincipal.Show();
                frmPrincipal.FormClosing += frmPrincipal_FormClosing;
                Hide();
            }
            catch(MySqlException err) {
                MessageBox.Show(err.Message, "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                conexao.Close();
            }
        }

        void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Show();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e) {
            Form frmCadastroUsuário = new frmCadastroUsuario();
            frmCadastroUsuário.Show();
        }
    }
}
