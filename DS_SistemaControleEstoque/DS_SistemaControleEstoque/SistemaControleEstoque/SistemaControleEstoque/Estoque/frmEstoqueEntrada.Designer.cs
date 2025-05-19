namespace SistemaControleEstoque.Estoque
{
    partial class frmEstoqueEntrada
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripStatusLlblMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUnidade = new System.Windows.Forms.TextBox();
            this.txtEstoqueMin = new System.Windows.Forms.TextBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtPrecoCustoNovo = new System.Windows.Forms.TextBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.txtLocacao = new System.Windows.Forms.TextBox();
            this.txtQtdEstoque = new System.Windows.Forms.TextBox();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPrecoCustoAtual = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripStatusLlblMsg
            // 
            this.toolStripStatusLlblMsg.Name = "toolStripStatusLlblMsg";
            this.toolStripStatusLlblMsg.Size = new System.Drawing.Size(277, 17);
            this.toolStripStatusLlblMsg.Text = "Informe o código do produto e pressione <ENTER>";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(559, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Entrada de Estoque";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUnidade
            // 
            this.txtUnidade.Location = new System.Drawing.Point(272, 157);
            this.txtUnidade.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtUnidade.MaxLength = 3;
            this.txtUnidade.Name = "txtUnidade";
            this.txtUnidade.ReadOnly = true;
            this.txtUnidade.Size = new System.Drawing.Size(81, 20);
            this.txtUnidade.TabIndex = 69;
            this.txtUnidade.TabStop = false;
            // 
            // txtEstoqueMin
            // 
            this.txtEstoqueMin.Location = new System.Drawing.Point(144, 157);
            this.txtEstoqueMin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtEstoqueMin.MaxLength = 7;
            this.txtEstoqueMin.Name = "txtEstoqueMin";
            this.txtEstoqueMin.ReadOnly = true;
            this.txtEstoqueMin.Size = new System.Drawing.Size(115, 20);
            this.txtEstoqueMin.TabIndex = 60;
            this.txtEstoqueMin.TabStop = false;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(11, 317);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(109, 45);
            this.btnFechar.TabIndex = 67;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(324, 317);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(109, 45);
            this.btnLimpar.TabIndex = 66;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(437, 317);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(109, 45);
            this.btnConfirmar.TabIndex = 65;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtPrecoCustoNovo
            // 
            this.txtPrecoCustoNovo.Location = new System.Drawing.Point(143, 231);
            this.txtPrecoCustoNovo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPrecoCustoNovo.MaxLength = 6;
            this.txtPrecoCustoNovo.Name = "txtPrecoCustoNovo";
            this.txtPrecoCustoNovo.Size = new System.Drawing.Size(116, 20);
            this.txtPrecoCustoNovo.TabIndex = 63;
            this.txtPrecoCustoNovo.TabStop = false;
            this.txtPrecoCustoNovo.TextChanged += new System.EventHandler(this.txtPrecoCustoNovo_TextChanged);
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(11, 231);
            this.txtQuantidade.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtQuantidade.MaxLength = 8;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(122, 20);
            this.txtQuantidade.TabIndex = 62;
            this.txtQuantidade.TextChanged += new System.EventHandler(this.txtQuantidade_TextChanged);
            // 
            // txtLocacao
            // 
            this.txtLocacao.Location = new System.Drawing.Point(367, 157);
            this.txtLocacao.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtLocacao.MaxLength = 3;
            this.txtLocacao.Name = "txtLocacao";
            this.txtLocacao.ReadOnly = true;
            this.txtLocacao.Size = new System.Drawing.Size(179, 20);
            this.txtLocacao.TabIndex = 61;
            this.txtLocacao.TabStop = false;
            // 
            // txtQtdEstoque
            // 
            this.txtQtdEstoque.Location = new System.Drawing.Point(9, 157);
            this.txtQtdEstoque.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtQtdEstoque.MaxLength = 7;
            this.txtQtdEstoque.Name = "txtQtdEstoque";
            this.txtQtdEstoque.ReadOnly = true;
            this.txtQtdEstoque.Size = new System.Drawing.Size(122, 20);
            this.txtQtdEstoque.TabIndex = 59;
            this.txtQtdEstoque.TabStop = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel1.Text = "Mensagem";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLlblMsg});
            this.statusStrip.Location = new System.Drawing.Point(0, 413);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip.Size = new System.Drawing.Size(559, 22);
            this.statusStrip.TabIndex = 68;
            this.statusStrip.Text = "statusStrip1";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(192, 81);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDescricao.MaxLength = 30;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ReadOnly = true;
            this.txtDescricao.Size = new System.Drawing.Size(353, 20);
            this.txtDescricao.TabIndex = 58;
            this.txtDescricao.TabStop = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(9, 81);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCodigo.MaxLength = 5;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(166, 20);
            this.txtCodigo.TabIndex = 57;
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(143, 215);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 55;
            this.label9.Text = "Preço de Custo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 215);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 54;
            this.label8.Text = "Quantidade";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(144, 134);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 53;
            this.label7.Text = "Estoque Mínimo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(367, 134);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "Locação";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(272, 134);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Unidade";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 134);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Quantidade em Estoque";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Descrição do Produto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Código do Produto";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 40);
            this.panel1.TabIndex = 47;
            // 
            // txtPrecoCustoAtual
            // 
            this.txtPrecoCustoAtual.Location = new System.Drawing.Point(272, 231);
            this.txtPrecoCustoAtual.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPrecoCustoAtual.MaxLength = 6;
            this.txtPrecoCustoAtual.Name = "txtPrecoCustoAtual";
            this.txtPrecoCustoAtual.ReadOnly = true;
            this.txtPrecoCustoAtual.Size = new System.Drawing.Size(116, 20);
            this.txtPrecoCustoAtual.TabIndex = 71;
            this.txtPrecoCustoAtual.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(272, 215);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 13);
            this.label10.TabIndex = 70;
            this.label10.Text = "Preço de Custo (Atual)";
            // 
            // frmEstoqueEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 435);
            this.ControlBox = false;
            this.Controls.Add(this.txtPrecoCustoAtual);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtUnidade);
            this.Controls.Add(this.txtEstoqueMin);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtPrecoCustoNovo);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.txtLocacao);
            this.Controls.Add(this.txtQtdEstoque);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "frmEstoqueEntrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrada de Estoque";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLlblMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUnidade;
        private System.Windows.Forms.TextBox txtEstoqueMin;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox txtPrecoCustoNovo;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.TextBox txtLocacao;
        private System.Windows.Forms.TextBox txtQtdEstoque;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPrecoCustoAtual;
        private System.Windows.Forms.Label label10;
    }
}