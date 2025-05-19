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

namespace SistemaControleEstoque.Estoque
{
    public partial class frmEstoqueSaida : Form
    {

        private MySqlConnection conexao = new MySqlConnection("Server=localhost;Port=3306;Database=briet_sitema_controle_estoque;User=root");

        public frmEstoqueSaida()
        {
            InitializeComponent();
        }

        private void AtualizarPrecoUnitario(string precoCusto, string margemLucro)
        {
            decimal margem = 1.0m + (decimal.Parse(margemLucro) / 100.0m);
            decimal valorUnitario = decimal.Parse(precoCusto) * margem;
            txtValorUnitario.Text = valorUnitario.ToString("F2");
        }

        private void AtualizaPrecoVenda()
        {
            decimal precoUnitario = decimal.Parse(txtValorUnitario.Text);
            decimal quantiade = 0;
            decimal.TryParse(txtQuantidade.Text, out quantiade);
            decimal precoVenda = precoUnitario * quantiade;
            txtValorVenda.Text = precoVenda.ToString("F2");
        }

        private void Limpar()
        {
            txtCodigo.Clear();
            txtCodigo.Focus(); 
            txtDescricao.Clear();
            txtQtdEstoque.Clear();
            txtEstoqueMin.Clear();
            txtUnidade.Clear();
            txtLocacao.Clear();
            txtQuantidade.Clear();
            txtValorUnitario.Clear();
            txtValorVenda.Clear();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode != Keys.Enter) {
                return;
            }

            try
            {
                string query = "SELECT * FROM tb_produto WHERE prod_codigo = @codigo";
                MySqlCommand comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                conexao.Open();
                MySqlDataReader dataReader = comando.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        txtDescricao.Text = dataReader["prod_descricao"].ToString();
                        txtQtdEstoque.Text = dataReader["prod_qtd_estoque"].ToString();
                        txtEstoqueMin.Text = dataReader["prod_estoque_min"].ToString();
                        txtUnidade.Text = dataReader["prod_unidade"].ToString();
                        txtLocacao.Text = dataReader["prod_locacao"].ToString();
                        
                        AtualizarPrecoUnitario(dataReader["prod_preco_custo"].ToString(), dataReader["prod_margem_lucro"].ToString());

                        txtQuantidade.Focus();
                        toolStripStatusLlblMsg.Text = "Informe a quantidade do produto.";
                    }
                }
                else
                {
                    toolStripStatusLlblMsg.Text = "Produto não encontrado. Tente outro código.";
                    //string codigo = txtCodigo.Text;
                    //ClearForm();
                    //txtCodigo.Text = codigo;
                    //txtCodigo.SelectAll();
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

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuantidade.Text))
            {
                return;
            }

            if (string.IsNullOrEmpty(txtQtdEstoque.Text))
            {
                return;
            }

            decimal quantidade = 0;
            decimal.TryParse(txtQuantidade.Text, out quantidade);
            decimal quantidadeEstoque = decimal.Parse(txtQtdEstoque.Text);

            if (quantidade > quantidadeEstoque)
            {
                txtQuantidade.Text = quantidadeEstoque.ToString();
                txtQuantidade.Focus();
                txtQuantidade.SelectAll();
            }

            AtualizaPrecoVenda();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                toolStripStatusLlblMsg.Text = "Informe um produto e/ou uma quantidade";
                txtCodigo.Focus();
                return;
            }

            decimal quantidade = 0;

            if (decimal.TryParse(txtQuantidade.Text, out quantidade) == false || quantidade <= 0)
            {
                toolStripStatusLlblMsg.Text = "Informe um produto e/ou uma quantidade.";
                txtQuantidade.Focus();
                return;
            }

            conexao.Open();
            var transaction = conexao.BeginTransaction();

            try
            {
                // Criar uma nova movimentação
                string queryMovimentacao = "INSERT INTO tb_movimentacao (mov_tipo, mov_log_usuario) VALUES (@tipo, @usuario)";
                MySqlCommand comandoMovimentacao = new MySqlCommand(queryMovimentacao, conexao, transaction);
                comandoMovimentacao.Parameters.AddWithValue("@tipo", "SAIDA");
                comandoMovimentacao.Parameters.AddWithValue("@usuario", "rafael");
                comandoMovimentacao.ExecuteNonQuery();

                // Registrar qual produto foi movimentado
                string queryProdutoMovimentacao = "INSERT INTO tb_movimentacao_saida (mov_saida_quantidade, mov_saida_valor_unitario, mov_id, prod_id) VALUES (@quantidade, @valor_unitario, @mov_id, @prod_id)";
                MySqlCommand comandoProdutoMovimentacao = new MySqlCommand(queryProdutoMovimentacao, conexao, transaction);
                comandoProdutoMovimentacao.Parameters.AddWithValue("@quantidade", quantidade);
                comandoProdutoMovimentacao.Parameters.AddWithValue("@valor_unitario", decimal.Parse(txtValorUnitario.Text));
                comandoProdutoMovimentacao.Parameters.AddWithValue("@mov_id", comandoMovimentacao.LastInsertedId);
                comandoProdutoMovimentacao.Parameters.AddWithValue("@prod_id", txtCodigo.Text);
                comandoProdutoMovimentacao.ExecuteNonQuery();

                // Atualizar quantidade de produto no estoque
                string queryAtualizaProduto = "UPDATE tb_produto SET prod_qtd_estoque = @qtd_estoque WHERE prod_codigo = @codigo";
                MySqlCommand comandoAtualizaProduto = new MySqlCommand(queryAtualizaProduto, conexao, transaction);
                comandoAtualizaProduto.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                comandoAtualizaProduto.Parameters.AddWithValue("@qtd_estoque", (decimal.Parse(txtQtdEstoque.Text) - quantidade));
                comandoAtualizaProduto.ExecuteNonQuery();

                transaction.Commit();

                MessageBox.Show("Movimentação realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolStripStatusLlblMsg.Text = "Informe um produto ou clique em <CONFIRMAR> para encerrar.";
                Limpar();
            }
            catch (MySqlException err)
            {
                transaction.Rollback();
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
    }
}
