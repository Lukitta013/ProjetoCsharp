using SistemaControleEstoque.Clientes;
using SistemaControleEstoque.Consulta;
using SistemaControleEstoque.Estoque;
using SistemaControleEstoque.Produtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SistemaControleEstoque {
    public partial class frmPrincipal: Form {
        public frmPrincipal() {
            InitializeComponent();
        }

        private void sairDaAplicaçãoToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e) {
            frmCadastroProduto frmCadastroProduto = new frmCadastroProduto();
            frmCadastroProduto.MdiParent = this;
            frmCadastroProduto.Show();
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlterarProduto frmAlterarProduto = new frmAlterarProduto();
            frmAlterarProduto.MdiParent = this;
            frmAlterarProduto.Show();
        }

        private void exluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExcluirProduto frmRemoverProduto = new frmExcluirProduto();
            frmRemoverProduto.MdiParent = this;
            frmRemoverProduto.Show();
        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCadastrarCliente frmCadastrarCliente = new frmCadastrarCliente();
            frmCadastrarCliente.MdiParent = this;
            frmCadastrarCliente.Show();
        }

        private void alterarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAlterarCliente frmAlterarCliente = new frmAlterarCliente();
            frmAlterarCliente.MdiParent = this;
            frmAlterarCliente.Show();
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExcluirCliente frmExcluirCliente = new frmExcluirCliente();
            frmExcluirCliente.MdiParent = this;
            frmExcluirCliente.Show();
        }

        private void saidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueSaida frmEstoqueSaida = new frmEstoqueSaida();
            frmEstoqueSaida.MdiParent = this;
            frmEstoqueSaida.Show();
        }

        private void entradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueEntrada frmEstoqueEntrada = new frmEstoqueEntrada();
            frmEstoqueEntrada.MdiParent = this;
            frmEstoqueEntrada.Show();
        }

        private void produtosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaProduto frmConsultaProduto = new frmConsultaProduto();
            frmConsultaProduto.MdiParent = this;
            frmConsultaProduto.Show();
        }
    }
}
