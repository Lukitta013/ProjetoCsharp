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

namespace SistemaControleEstoque.Consulta
{
    public partial class frmConsultaProduto : Form
    {
        private MySqlConnection conexao = new MySqlConnection("Server=localhost;Port=3306;Database=briet_sitema_controle_estoque;User=root");

        public frmConsultaProduto()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmConsultaProduto_Activated(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM tb_produto";
                MySqlCommand comando = new MySqlCommand(query, conexao);
                conexao.Open();
                MySqlDataReader dataReader = comando.ExecuteReader();

                if (dataReader.HasRows)
                {
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        ColumnHeader header = new ColumnHeader();
                        header.Text = dataReader.GetName(i);
                        listView.Columns.Add(header);
                    }

                    ListViewItem viewItem = new ListViewItem();

                    while (dataReader.Read())
                    {
                        viewItem = new ListViewItem();
                        viewItem.Text = dataReader.GetValue(0).ToString();

                        for (int i = 1; i < dataReader.FieldCount; i++)
                        {
                            viewItem.SubItems.Add(dataReader.GetValue(i).ToString());
                        }

                        listView.Items.Add(viewItem);
                    }
                }
                else
                {
                    toolStripStatusLlblMsg.Text = "Nenhum produto encontrado.";
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
