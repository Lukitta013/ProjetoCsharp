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

namespace SistemaControleEstoque.Produtos {
    public partial class frmCadastroProduto: Form {
        private MySqlConnection conexao = new MySqlConnection("Server=localhost;Port=3306;Database=briet_sitema_controle_estoque;User=root");

        public frmCadastroProduto() {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtCodigo.Text) ||
                string.IsNullOrEmpty(txtDescricao.Text) ||
                string.IsNullOrEmpty(txtQtdEstoque.Text) ||
                string.IsNullOrEmpty(txtLocacao.Text) ||
                string.IsNullOrEmpty(txtPrecoCusto.Text) ||
                string.IsNullOrEmpty(txtMargemLucro.Text) ||
                cmbUnidade.SelectedIndex < 0)
            {
                MessageBox.Show("Todos os campos devem ser preenchidos para que o produto seja cadastrado.", "Cadastro incompletp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {
                string query = "INSERT INTO tb_produto (prod_codigo, prod_descricao, prod_qtd_estoque, " +
                               "prod_estoque_min, prod_unidade, prod_locacao, prod_preco_custo, prod_margem_lucro) " +
                               "VALUES (@codigo, @descricao, @qtd_estoque, @estoque_min, @unidade, @locacao, "+
                               "@preco_custo, @margem_lucro)";
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                comando.Parameters.AddWithValue("@descricao", txtDescricao.Text);
                comando.Parameters.AddWithValue("@qtd_estoque", txtQtdEstoque.Text.Replace(',', '.'));
                comando.Parameters.AddWithValue("@estoque_min", txtEstoqueMin.Text.Replace(',', '.'));
                comando.Parameters.AddWithValue("@unidade", cmbUnidade.Text);
                comando.Parameters.AddWithValue("@locacao", txtLocacao.Text);
                comando.Parameters.AddWithValue("@preco_custo", txtPrecoCusto.Text.Replace(',', '.'));
                comando.Parameters.AddWithValue("@margem_lucro", txtMargemLucro.Text.Replace(',', '.'));
                conexao.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Prodto cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearForm();
            }
            catch(MySqlException err) {
                MessageBox.Show(err.Message, "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                conexao.Close();
            }
        }

        private void clearForm()
        {
            toolStripStatusLlblMsg.Text = "Informe o código do produto e pressione <ENTER>";
            txtCodigo.Clear();
            txtDescricao.Clear();
            txtQtdEstoque.Clear();
            txtEstoqueMin.Clear();
            cmbUnidade.SelectedIndex = -1;
            txtLocacao.Clear();
            txtPrecoCusto.Clear();
            txtMargemLucro.Clear();
            txtPrecoVenda.Clear();
            btnCadastrar.Enabled = false;
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            try
            {
                string query = "SELECT prod_codigo FROM tb_produto WHERE prod_codigo = @codigo";
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                conexao.Open();
                MySqlDataReader dataReader = comando.ExecuteReader();

                if (dataReader.HasRows)
                {
                    toolStripStatusLlblMsg.Text = "Produto já cadastrado. Digite outro código e pressione <ENTER> novamente.";
                    btnCadastrar.Enabled = false;
                }
                else
                {
                    toolStripStatusLlblMsg.Text = "Preencha o formulário e clique no botão cadastrar.";
                    btnCadastrar.Enabled = true;
                    txtDescricao.Focus();
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
            clearForm();
        }

        private void atualizarPrecoVenda(object sender, EventArgs e) {
            decimal margem = 0;

            if(decimal.TryParse(txtMargemLucro.Text, out margem)) {
                margem = 1.0m + (margem / 100.0m);
            }

            decimal precoCusto = 0;
            decimal.TryParse(txtPrecoCusto.Text, out precoCusto);

            decimal precoVenda = precoCusto * margem;
            txtPrecoVenda.Text = precoVenda.ToString();
        }

        private void txtPrecoCusto_TextChanged(object sender, EventArgs e) {
            TextBox textBox = sender as TextBox;

            if(textBox.Modified == false) {
                return;
            }

            atualizarPrecoVenda(sender, e);
        }

        private void txtMargemLucro_TextChanged(object sender, EventArgs e) {
            TextBox textBox = sender as TextBox;

            if(textBox.Modified == false) {
                return;
            }

            atualizarPrecoVenda(sender, e);
        }

        private void txtPrecoVenda_TextChanged(object sender, EventArgs e) {
            TextBox textBox = sender as TextBox;

            if(textBox.Modified == false) {
                return;
            }

            decimal precoVenda = 0;
            decimal.TryParse(txtPrecoVenda.Text, out precoVenda);

            decimal precoCusto = 0;
            decimal.TryParse(txtPrecoCusto.Text, out precoCusto);

            decimal margem = 0;

            if(decimal.TryParse(txtMargemLucro.Text, out margem) && precoVenda > 0) {
                margem = (precoVenda - precoCusto) / precoCusto * 100m;
                txtMargemLucro.Text = margem.ToString();
            }
        }
    }
}
