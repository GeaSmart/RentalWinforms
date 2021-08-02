using Mach.Entities;
using Mach.Shared;
using Newtonsoft.Json;
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
    public partial class frmContratosListado : Form
    {
        public frmContratosListado()
        {
            InitializeComponent();
        }

        private async void frmContratosListado_Load(object sender, EventArgs e)
        {
            var response = await ApiHelper.GetAll();
            var listado = JsonConvert.DeserializeObject<List<Contrato>>(response);

            this.dgvListadoContratos.DataSource = listado;
        }

        private void btnNuevoContrato_Click(object sender, EventArgs e)
        {
            frmContratosNuevo nuevo = new frmContratosNuevo();
            nuevo.ShowDialog();
        }

        private void dgvListadoContratos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(this.dgvListadoContratos.CurrentRow.Cells["id"].Value.ToString());
            frmContratosNuevo nuevo = new frmContratosNuevo(id);
            nuevo.ShowDialog();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var response = await ApiHelper.GetAll();
            var listado = JsonConvert.DeserializeObject<List<Contrato>>(response);

            this.dgvListadoContratos.DataSource = listado;
        }
    }
}
