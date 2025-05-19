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
    public partial class frmSplash: Form {
        public frmSplash() {
            InitializeComponent();
        }

        private void timerSplash_Tick(object sender, EventArgs e) {
            if(progressBarSplash.Value < 100) {
                progressBarSplash.Value += 1;
            }
            else
            {
                timerSplash.Enabled = false;
                Form loginForm = new frmLogin();
                loginForm.Show();
                Hide();
            }
        }
    }
}
