﻿using System;
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
        public VentInic()
        {
            InitializeComponent();
        }

        private void pbPedidos_Click(object sender, EventArgs e)
        {
            Pedidos FormPedidos = new Pedidos();
            FormPedidos.ShowDialog(this);
            //FormPedidos.MdiParent = this;
        }
    }
}