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

namespace SistemaControleEstoque.Produtos
{
    public partial class frmAlterarProduto : Form
    {
        private MySqlConnection conexao = new MySqlConnection("Server=localhost;Port=3306;Database=briet_sitema_controle_estoque;User=root");

        public frmAlterarProduto()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e) {
            ClearForm();
        }

        private void txtPrecoCusto_TextChanged(object sender, EventArgs e) {
            TextBox textBox = sender as TextBox;

            if(textBox.Modified == false) {
                return;
            }

            AtualizarPrecoVenda(sender, e);
        }

        private void txtMargemLucro_TextChanged(object sender, EventArgs e) {
            TextBox textBox = sender as TextBox;

            if(textBox.Modified == false) {
                return;
            }

            AtualizarPrecoVenda(sender, e);
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
                txtMargemLucro.Text = margem.ToString("F2");
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode != Keys.Enter) {
                return;
            }

            try {
                string query = "SELECT * FROM tb_produto WHERE prod_codigo = @codigo";
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                conexao.Open();
                MySqlDataReader dataReader = comando.ExecuteReader();

                if(dataReader.HasRows)
                {
                    while(dataReader.Read())
                    {
                        txtDescricao.Text = dataReader["prod_descricao"].ToString();
                        txtQtdEstoque.Text = dataReader["prod_qtd_estoque"].ToString();
                        txtEstoqueMin.Text = dataReader["prod_estoque_min"].ToString();
                        cmbUnidade.Text = dataReader["prod_unidade"].ToString();
                        txtLocacao.Text = dataReader["prod_locacao"].ToString();
                        txtPrecoCusto.Text = dataReader["prod_preco_custo"].ToString();
                        txtMargemLucro.Text = dataReader["prod_margem_lucro"].ToString();

                        AtualizarPrecoVenda();

                        txtCodigo.ReadOnly = true;
                        txtDescricao.ReadOnly = false;
                        txtDescricao.Focus();
                        txtQtdEstoque.ReadOnly = false;
                        txtEstoqueMin.ReadOnly = false;
                        txtLocacao.ReadOnly = false;
                        txtPrecoCusto.ReadOnly = false;
                        txtMargemLucro.ReadOnly = false;
                        txtPrecoVenda.ReadOnly = false;
                        cmbUnidade.Enabled = true;
                        btnAlterar.Enabled = true;
                    }
                }
                else {
                    toolStripStatusLlblMsg.Text = "Produto não encontrado.";
                    string codigo = txtCodigo.Text;
                    ClearForm();
                    txtCodigo.Text = codigo;
                    txtCodigo.SelectAll();
                }
            }
            catch(MySqlException err) {
                MessageBox.Show(err.Message, "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                conexao.Close();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e) {
            if(string.IsNullOrEmpty(txtCodigo.Text) ||
                string.IsNullOrEmpty(txtDescricao.Text) ||
                string.IsNullOrEmpty(txtQtdEstoque.Text) ||
                string.IsNullOrEmpty(txtLocacao.Text) ||
                string.IsNullOrEmpty(txtPrecoCusto.Text) ||
                string.IsNullOrEmpty(txtMargemLucro.Text) ||
                cmbUnidade.SelectedIndex < 0) {
                MessageBox.Show("Todos os campos devem ser preenchidos para que o produto seja cadastrado.", "Dados incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {
                string query = "UPDATE tb_produto SET prod_descricao = @descricao, prod_qtd_estoque = @qtd_estoque, prod_estoque_min = @estoque_min, prod_unidade = @unidade, prod_locacao = @locacao, prod_preco_custo = @preco_custo, prod_margem_lucro = @margem_lucro WHERE prod_codigo = @codigo";
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
                MessageBox.Show("Produto alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(MySqlException err) {
                MessageBox.Show(err.Message, "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                conexao.Close();
            }
        }

        private void AtualizarPrecoVenda(object sender, EventArgs e) {
            AtualizarPrecoVenda();
        }

        private void AtualizarPrecoVenda() {
            decimal margem = 0;

            if(decimal.TryParse(txtMargemLucro.Text, out margem)) {
                margem = 1.0m + (margem / 100.0m);
            }

            decimal precoCusto = 0;
            decimal.TryParse(txtPrecoCusto.Text, out precoCusto);

            decimal precoVenda = precoCusto * margem;
            txtPrecoVenda.Text = precoVenda.ToString("F2");
        }

        private void ClearForm()
        {
            txtCodigo.Clear();
            txtDescricao.Clear();
            txtQtdEstoque.Clear();
            txtEstoqueMin.Clear();
            cmbUnidade.SelectedIndex = -1;
            txtLocacao.Clear();
            txtPrecoCusto.Clear();
            txtMargemLucro.Clear();
            txtPrecoVenda.Clear();

            txtCodigo.ReadOnly = false;
            txtCodigo.Focus();
            txtDescricao.ReadOnly = true;
            txtQtdEstoque.ReadOnly = true;
            txtEstoqueMin.ReadOnly = true;
            txtLocacao.ReadOnly = true;
            txtPrecoCusto.ReadOnly = true;
            txtMargemLucro.ReadOnly = true;
            txtPrecoVenda.ReadOnly = true;
            cmbUnidade.Enabled = false;
            btnAlterar.Enabled = false;
        }
    }
}
