using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ambrosia
{
    public partial class VentInic : Form
    {
        public int BufferEmpleadoId = 0;
        public VentInic()
        {
            InitializeComponent();
        }

        private void pbPedidos_Click(object sender, EventArgs e)
        {
            Pedidos FormPedidos = new Pedidos();
            FormPedidos.EmpleadoId = this.BufferEmpleadoId;
            FormPedidos.ShowDialog(this);            
        }

        private void pbTerminal_Click(object sender, EventArgs e)
        {
            Terminal FormTerminal = new Terminal();
            FormTerminal.ShowDialog(this);
        }

        private void pbClientes_Click(object sender, EventArgs e)
        {
            Clientes FormClientes = new Clientes();
            FormClientes.ShowDialog(this);
        }

        private void pbCaja_Click(object sender, EventArgs e)
        {
            Caja FormCaja = new Caja();
            FormCaja.ShowDialog(this);
        }

        private void pbCaja2_Click(object sender, EventArgs e)
        {
            Caja2 FormCaja2 = new Caja2();
            FormCaja2.ShowDialog(this);
        }

        private void VentInic_Activated(object sender, EventArgs e)
        {
            
        }
    }
}
