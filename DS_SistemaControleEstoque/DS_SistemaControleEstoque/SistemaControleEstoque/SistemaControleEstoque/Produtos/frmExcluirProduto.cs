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
    public partial class frmExcluirProduto : Form
    {
        private MySqlConnection conexao = new MySqlConnection("Server=localhost;Port=3306;Database=briet_sitema_controle_estoque;User=root");

        public frmExcluirProduto()
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
                        btnExcluir.Enabled = true;
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

        private void btnExcluir_Click(object sender, EventArgs e) {
            try {
                string query = "DELETE FROM tb_produto WHERE prod_codigo = @codigo";
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                conexao.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Produto removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
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
            btnExcluir.Enabled = false;
        }
    }
}
