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
    public partial class frmEstoqueEntrada : Form
    {
        private MySqlConnection conexao = new MySqlConnection("Server=localhost;Port=3306;Database=briet_sitema_controle_estoque;User=root");

        public frmEstoqueEntrada()
        {
            InitializeComponent();
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
            txtPrecoCustoNovo.Clear();
            txtPrecoCustoAtual.Clear();
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
                        txtPrecoCustoAtual.Text = dataReader["prod_preco_custo"].ToString();

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

            decimal quantidade = 0;

            if (decimal.TryParse(txtQuantidade.Text, out quantidade) == false || quantidade <= 0)
            {
                toolStripStatusLlblMsg.Text = "A quantidade deve ser um número.";
                txtQuantidade.Focus();
                txtQuantidade.SelectAll();
                return;
            }

            if (quantidade <= 0)
            {
                toolStripStatusLlblMsg.Text = "Informe uma quantidade válida.";
                txtQuantidade.Focus();
                txtQuantidade.SelectAll();
                return;
            }

            toolStripStatusLlblMsg.Text = "Clique em <Confirmar> para dar entrada.";
        }

        private void txtPrecoCustoNovo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrecoCustoNovo.Text))
            {
                return;
            }

            decimal precoCusto = 0;

            if (decimal.TryParse(txtPrecoCustoNovo.Text, out precoCusto) == false || precoCusto < 0)
            {
                toolStripStatusLlblMsg.Text = "O preço de custo deve ser um número.";
                txtQuantidade.Focus();
                txtQuantidade.SelectAll();
                return;
            }

            if (precoCusto < 0)
            {
                toolStripStatusLlblMsg.Text = "Informe um preço de custo válido.";
                txtQuantidade.Focus();
                txtQuantidade.SelectAll();
                return;
            }

            toolStripStatusLlblMsg.Text = "Clique em <Confirmar> para dar entrada.";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                toolStripStatusLlblMsg.Text = "Informe um produto e/ou uma quantidade";
                txtCodigo.Focus();
                txtCodigo.SelectAll();
                return;
            }

            decimal quantidade = 0;

            if (decimal.TryParse(txtQuantidade.Text, out quantidade) == false || quantidade <= 0)
            {
                toolStripStatusLlblMsg.Text = "Informe um produto e/ou uma quantidade.";
                txtQuantidade.Focus();
                txtQuantidade.SelectAll();
                return;
            }

            decimal precoCusto = 0;

            if (decimal.TryParse(txtPrecoCustoNovo.Text, out precoCusto) == false || precoCusto < 0)
            {
                toolStripStatusLlblMsg.Text = "Informe um precço de custo válido.";
                txtPrecoCustoNovo.Focus();
                txtPrecoCustoNovo.SelectAll();
                return;
            }

            conexao.Open();
            var transaction = conexao.BeginTransaction();

            try
            {
                // Criar uma nova movimentação
                string queryMovimentacao = "INSERT INTO tb_movimentacao (mov_tipo, mov_log_usuario) VALUES (@tipo, @usuario)";
                MySqlCommand comandoMovimentacao = new MySqlCommand(queryMovimentacao, conexao, transaction);
                comandoMovimentacao.Parameters.AddWithValue("@tipo", "ENTRADA");
                comandoMovimentacao.Parameters.AddWithValue("@usuario", "rafael");
                comandoMovimentacao.ExecuteNonQuery();

                // Registrar qual produto foi movimentado
                string queryProdutoMovimentacao = "INSERT INTO tb_movimentacao_entrada (mov_entrada_quantidade, mov_entrada_preco_custo, mov_id, prod_id) VALUES (@quantidade, @preco_custo, @mov_id, @prod_id)";
                MySqlCommand comandoProdutoMovimentacao = new MySqlCommand(queryProdutoMovimentacao, conexao, transaction);
                comandoProdutoMovimentacao.Parameters.AddWithValue("@quantidade", quantidade);
                comandoProdutoMovimentacao.Parameters.AddWithValue("@preco_custo", precoCusto);
                comandoProdutoMovimentacao.Parameters.AddWithValue("@mov_id", comandoMovimentacao.LastInsertedId);
                comandoProdutoMovimentacao.Parameters.AddWithValue("@prod_id", txtCodigo.Text);
                comandoProdutoMovimentacao.ExecuteNonQuery();

                // Atualizar quantidade de produto no estoque
                string queryAtualizaProduto = "UPDATE tb_produto SET prod_qtd_estoque = @qtd_estoque WHERE prod_codigo = @codigo";
                MySqlCommand comandoAtualizaProduto = new MySqlCommand(queryAtualizaProduto, conexao, transaction);
                comandoAtualizaProduto.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                comandoAtualizaProduto.Parameters.AddWithValue("@qtd_estoque", (decimal.Parse(txtQtdEstoque.Text) + quantidade));
                comandoAtualizaProduto.ExecuteNonQuery();

                transaction.Commit();

                MessageBox.Show("Movimentação realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolStripStatusLlblMsg.Text = "Informe outro produto ou clique em <FECHAR> para encerrar.";
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
