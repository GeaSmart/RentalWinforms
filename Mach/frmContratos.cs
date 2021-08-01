using Mach.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mach
{
    public partial class frmContratos : Form
    {
        public frmContratos()
        {
            InitializeComponent();
        }

        private async void frmContratos_Load(object sender, EventArgs e)
        {
            var response = await ApiHelper.Get(3);
            this.textBox1.Text = ApiHelper.BeautifyJson(response);
        }
    }
}
