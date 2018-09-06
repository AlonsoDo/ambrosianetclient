using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;


namespace Ambrosia
{
    public partial class Caja : Form
    {
        public static System.Net.Sockets.TcpClient clientSocket;
        NetworkStream serverStream;
        string readData = null;
        Thread ctThread;
        string IdClient = null;
        BindingList<LineaDetalleFactura> listaDetalleFactura = new BindingList<LineaDetalleFactura>();
        BindingList<LineaDetalleFactura> listaBufferFactura = new BindingList<LineaDetalleFactura>();
        string UltimoClick = "Numero";
        bool FlagDecimal = false;        
        string UltimoBoton = "Nulo";
        
        public Caja()
        {
            InitializeComponent();
        }

        private void Caja_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            listaDetalleFactura.AllowNew = true;
            listaDetalleFactura.AllowRemove = true;

            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;

            column1.Name = "Unidades";
            column1.HeaderText = "Unid";
            column1.DataPropertyName = "Unidades";
            column1.ReadOnly = true;
            column1.Width = 32;
            column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns.Add(column1);

            column2.Name = "Descripcion";
            column2.HeaderText = "Descripcion";
            column2.DataPropertyName = "Descripcion";
            column2.ReadOnly = true;
            column2.Width = 240;
            dataGridView1.Columns.Add(column2);

            column3.Name = "Precio";
            column3.HeaderText = "Precio";
            column3.DataPropertyName = "Precio";
            column3.ReadOnly = true;
            column3.Width = 56;
            column3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column3.DefaultCellStyle.Format = "N2";

            dataGridView1.Columns.Add(column3);

            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column7 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column8 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column9 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column10 = new DataGridViewTextBoxColumn();

            GridDatosFacturas.AutoGenerateColumns = false;
            GridDatosFacturas.AllowUserToAddRows = false;

            column4.Name = "Nombre";
            column4.HeaderText = "Cuenta";
            column4.DataPropertyName = "Nombre";
            column4.ReadOnly = true;
            column4.Width = 50;
            GridDatosFacturas.Columns.Add(column4);

            column5.Name = "Estado";
            column5.HeaderText = "Estado";
            column5.DataPropertyName = "Estado";
            column5.ReadOnly = true;
            column5.Width = 72;
            GridDatosFacturas.Columns.Add(column5);

            column6.Name = "FormaPago";
            column6.HeaderText = "Forma Pago";
            column6.DataPropertyName = "FormaPago";
            column6.ReadOnly = true;
            column6.Width = 90;
            GridDatosFacturas.Columns.Add(column6);

            column7.Name = "Total";
            column7.HeaderText = "Total";
            column7.DataPropertyName = "Total";
            column7.ReadOnly = true;
            column7.Width = 80;
            column7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column7.DefaultCellStyle.Format = "N2";
            GridDatosFacturas.Columns.Add(column7);

            column8.Name = "Cantidad";
            column8.HeaderText = "Entrega";
            column8.DataPropertyName = "Cantidad";
            column8.ReadOnly = true;
            column8.Width = 80;
            column8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column8.DefaultCellStyle.Format = "N2";
            GridDatosFacturas.Columns.Add(column8);

            column9.Name = "Cambio";
            column9.HeaderText = "Cambio";
            column9.DataPropertyName = "Cambio";
            column9.ReadOnly = true;
            column9.Width = 80;
            column9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            column9.DefaultCellStyle.Format = "N2";
            GridDatosFacturas.Columns.Add(column9);

            column10.Name = "FechaHora";
            column10.HeaderText = "Hora";
            column10.DataPropertyName = "FechaHora";
            column10.ReadOnly = true;
            column10.Width = 50;
            column10.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            GridDatosFacturas.Columns.Add(column10);
            
            //Conectar
            clientSocket = new System.Net.Sockets.TcpClient();
            serverStream = default(NetworkStream);
            clientSocket.Connect("192.168.1.2", 10001);
            serverStream = clientSocket.GetStream();
            clientSocket.ReceiveBufferSize = 2097152;

            ctThread = new Thread(getMessage);
            ctThread.Start();

            FuncionesAuxiliares funcionAuxiliar = new FuncionesAuxiliares();
            IdClient = funcionAuxiliar.GenerarIdCliente();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(IdClient + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        private void getMessage()
        {
            string NombreEvento = null;

            while (true)
            {
                int buffSize = 0;
                byte[] inStream = new byte[2097152]; // 2Mbyte
                buffSize = clientSocket.ReceiveBufferSize;
                serverStream.Read(inStream, 0, buffSize);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                int test = returndata.IndexOf("$");
                returndata = returndata.Substring(0, returndata.IndexOf("$"));
                readData = "" + returndata;

                var definition = new { NombreEvento = "" };
                var EventosControl = JsonConvert.DeserializeAnonymousType(readData, definition);
                NombreEvento = EventosControl.NombreEvento;

                if (NombreEvento == "FacturaBak")
                {
                    Factura factura = new Factura();
                    factura = JsonConvert.DeserializeObject<Factura>(readData);
                    listaDetalleFactura = factura.listaDetalleFactura;
                    CargarCuentaBak();  
                    //Estado
                    if (factura.Estado == "A")
                    {
                        label6.Text = "Abierta";
                    }
                    else if (factura.Estado == "P")
                    {
                        label6.Text = "Pendiente";
                    }
                }
                else if (NombreEvento == "DatosFacturasBak")
                {
                    DatosFacturas ListaFacturas = new DatosFacturas();
                    ListaFacturas = JsonConvert.DeserializeObject<DatosFacturas>(readData);
                    RecargarFacturasBak(ListaFacturas);
                }
                else if (NombreEvento == "ImpresorasTerminalesBak")
                {
                    ImpresorasTerminales impresorasTerminales = new ImpresorasTerminales();
                    impresorasTerminales = JsonConvert.DeserializeObject<ImpresorasTerminales>(readData);                    
                    cbImpresoras.DisplayMember = "NombreImpresora";
                    if (impresorasTerminales.impresorasTer.Any()) //prevent IndexOutOfRangeException for empty list
                    {
                        impresorasTerminales.impresorasTer.RemoveAt(impresorasTerminales.impresorasTer.Count - 1);
                    }
                    if (impresorasTerminales.impresorasTer.Any()) //prevent IndexOutOfRangeException for empty list
                    {
                        impresorasTerminales.impresorasTer.RemoveAt(impresorasTerminales.impresorasTer.Count - 1);
                    }
                    cbImpresoras.DataSource = impresorasTerminales.impresorasTer;
                    cbImpresoras.Text = "Caja";
                }
            }
        }

        private void Caja_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventoDesconectar eventoDesconectar = new EventoDesconectar();
            eventoDesconectar.NombreEvento = "Desconectar";
            eventoDesconectar.IdCliente = IdClient;
            string output = JsonConvert.SerializeObject(eventoDesconectar);

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(output + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            ctThread.Abort();
            clientSocket.Close();
            serverStream.Close();
        }

        private void btAbrirFactura_Click(object sender, EventArgs e)
        {
            if (tbNumeCuen.Text == "")
            {
                MessageBox.Show("Debe de introducir un numero de cuenta", "Aviso");
            }
            else
            {
                string NumeCuenta = tbNumeCuen.Text;
                label6.Text = "Abierta";
                AbrirCuenta(NumeCuenta);
            }            
        }

        private void AbrirCuenta(string NumeroCuenta)
        {
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.DataSource = listaDetalleFactura;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            
            NumeroCuenta numeroCuenta = new NumeroCuenta();
            numeroCuenta.NombreEvento = "AbrirCuenta";
            numeroCuenta.NumeCuenta = NumeroCuenta;

            string output = JsonConvert.SerializeObject(numeroCuenta);

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(output + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        private void CargarCuentaBak()
        {
            if (listaDetalleFactura.Count == 0)
            {
                MessageBox.Show("Cuenta vacia o no existe", "Aviso");
                this.dataGridView1.Rows.Clear();
                this.dataGridView1.Refresh();
                tbEntrega.Text = "0";
                tbCambio.Text = "0";
                tbTotal.Text = "0";
            }
            else
            {                
                try
                {
                   dataGridView1.DataSource = listaDetalleFactura;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message.ToString());
                }
                CalcularTotalCuenta();
            }
            UltimoBoton = "Cargar";
        }

        private void CalcularTotalCuenta()
        {
            Decimal TotalCuenta = 0;
            Decimal Impuesto = 0;
            Decimal Importe = 0;
            for (var i = 0; i < listaDetalleFactura.Count; i++)
            {
                Importe = listaDetalleFactura[i].Unidades * listaDetalleFactura[i].Precio;
                Impuesto = Importe * (listaDetalleFactura[i].Impuesto / 100);
                TotalCuenta = TotalCuenta + Importe + Impuesto;
            }
            tbTotal.Text = String.Format("{0:0.00}", TotalCuenta);             
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {            
        }

        private void tbNumeCuen_Click(object sender, EventArgs e)
        {
            tbNumeCuen.Text = "";
            UltimoClick = "Numero";
            this.dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.DataSource = listaDetalleFactura;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            UltimoBoton = "Nulo";
            tbEntrega.Text = "0";
            tbCambio.Text = "0";
            tbTotal.Text = "0";
        }

        private void tbEntrega_Click(object sender, EventArgs e)
        {
            FlagDecimal = false;
            tbEntrega.Text = "";
            UltimoClick = "Entrega";
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            if (UltimoClick == "Numero")
            {
                if (tbNumeCuen.Text.Length < 5)
                    tbNumeCuen.Text = tbNumeCuen.Text + "1";
            }
            else
            {
                if (tbEntrega.Text.Length < 10)
                {
                    tbEntrega.Text = tbEntrega.Text + "1";
                    CalcularCambio();
                }
            }
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            if (UltimoClick == "Numero")
            {
                if (tbNumeCuen.Text.Length < 5)
                    tbNumeCuen.Text = tbNumeCuen.Text + "2";
            }
            else
            {
                if (tbEntrega.Text.Length < 10)
                {
                    tbEntrega.Text = tbEntrega.Text + "2";
                    CalcularCambio();
                }
            }
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            if (UltimoClick == "Numero")
            {
                if (tbNumeCuen.Text.Length < 5)
                    tbNumeCuen.Text = tbNumeCuen.Text + "3";
            }
            else
            {
                if (tbEntrega.Text.Length < 10)
                {
                    tbEntrega.Text = tbEntrega.Text + "3";
                    CalcularCambio();
                }
            }
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            if (UltimoClick == "Numero")
            {
                if (tbNumeCuen.Text.Length < 5)
                    tbNumeCuen.Text = tbNumeCuen.Text + "4";
            }
            else
            {
                if (tbEntrega.Text.Length < 10)
                {
                    tbEntrega.Text = tbEntrega.Text + "4";
                    CalcularCambio();
                }
            }
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            if (UltimoClick == "Numero")
            {
                if (tbNumeCuen.Text.Length < 5)
                    tbNumeCuen.Text = tbNumeCuen.Text + "5";
            }
            else
            {
                if (tbEntrega.Text.Length < 10)
                {
                    tbEntrega.Text = tbEntrega.Text + "5";
                    CalcularCambio();
                }
            }
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            if (UltimoClick == "Numero")
            {
                if (tbNumeCuen.Text.Length < 5)
                    tbNumeCuen.Text = tbNumeCuen.Text + "6";
            }
            else
            {
                if (tbEntrega.Text.Length < 10)
                {
                    tbEntrega.Text = tbEntrega.Text + "6";
                    CalcularCambio();
                }
            }
        }

        private void bt7_Click(object sender, EventArgs e)
        {
            if (UltimoClick == "Numero")
            {
                if (tbNumeCuen.Text.Length < 5)
                    tbNumeCuen.Text = tbNumeCuen.Text + "7";
            }
            else
            {
                if (tbEntrega.Text.Length < 10)
                {
                    tbEntrega.Text = tbEntrega.Text + "7";
                    CalcularCambio();
                }
            }
        }

        private void bt8_Click(object sender, EventArgs e)
        {
            if (UltimoClick == "Numero")
            {
                if (tbNumeCuen.Text.Length < 5)
                    tbNumeCuen.Text = tbNumeCuen.Text + "8";
            }
            else
            {
                if (tbEntrega.Text.Length < 10)
                {
                    tbEntrega.Text = tbEntrega.Text + "8";
                    CalcularCambio();
                }
            }
        }

        private void bt9_Click(object sender, EventArgs e)
        {
            if (UltimoClick == "Numero")
            {
                if (tbNumeCuen.Text.Length < 5)
                    tbNumeCuen.Text = tbNumeCuen.Text + "9";
            }
            else
            {
                if (tbEntrega.Text.Length < 10)
                {
                    tbEntrega.Text = tbEntrega.Text + "9";
                    CalcularCambio();
                }
            }
        }

        private void bt0_Click(object sender, EventArgs e)
        {
            if (UltimoClick == "Numero")
            {
                if (tbNumeCuen.Text.Length < 5)
                    tbNumeCuen.Text = tbNumeCuen.Text + "0";
            }
            else
            {
                if (tbEntrega.Text.Length < 10)
                {
                    tbEntrega.Text = tbEntrega.Text + "0";
                    CalcularCambio();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {           
           if (FlagDecimal == false)
           {
               tbEntrega.Text = tbEntrega.Text + ",";
               FlagDecimal = true;
           }           
           CalcularCambio();
        }

        private void CalcularCambio()
        {
            Decimal Entrega = Convert.ToDecimal(tbEntrega.Text);
            Decimal Total = Convert.ToDecimal(tbTotal.Text);
            Decimal Cambio = Entrega - Total;
            tbCambio.Text = string.Format("{0:0.00}", Cambio);
        }

        private void RecargarFacturas_Click(object sender, EventArgs e)
        {
            GridDatosFacturas.ScrollBars = ScrollBars.None;
            
            RecargarFacturas recargarFacturas = new RecargarFacturas();
            recargarFacturas.NombreEvento = "RecargarFacturas";
            recargarFacturas.Abiertas = cbFactAbiertas.Checked;
            recargarFacturas.Pendientes = cbFactPendientes.Checked;
            recargarFacturas.Cerradas = cbFactCerradas.Checked;

            string output = JsonConvert.SerializeObject(recargarFacturas);

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(output + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        private void RecargarFacturasBak(DatosFacturas Facturas)
        {            
            try
            {
                this.GridDatosFacturas.ScrollBars = ScrollBars.None;
                this.GridDatosFacturas.Rows.Clear();
                this.GridDatosFacturas.Refresh();
                if (Facturas.datosFacturas.Any())
                    this.GridDatosFacturas.DataSource = Facturas.datosFacturas;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());                
            }
        }

        private void GridDatosFacturas_Click(object sender, EventArgs e)
        {
            GridDatosFacturas.ScrollBars = ScrollBars.Both;
        }

        private void GridDatosFacturas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Error al cargar datos " + e.Exception.ToString(), "Aviso");
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Error al cargar datos " + e.Exception.ToString(), "Aviso");
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            dataGridView1.ScrollBars = ScrollBars.Both;
        }

        private void btImprimirFactura_Click(object sender, EventArgs e)
        {
            if (UltimoBoton == "Cargar")
            {
                if (MessageBox.Show("Pasar la cuenta a Pendiente?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    label6.Text = "Pendiente";
                    PasarCuentaAPendiente();
                }
                ImprimirFactura();
                MessageBox.Show("Imprimiendo Factura", "Aviso");
            }
            else if (UltimoBoton == "Cobrar")
            {
                ImprimirFactura();
                MessageBox.Show("Imprimiendo Factura", "Aviso");
            }
            else
            {
                MessageBox.Show("Debe cargar Factura", "Aviso");
            }
        }

        private void PasarCuentaAPendiente()
        {
            PasarAPendiente pasarAPendiente = new PasarAPendiente();
            pasarAPendiente.NombreEvento = "PasarAPendiente";
            pasarAPendiente.NombreFactura = tbNumeCuen.Text;
            
            string output = JsonConvert.SerializeObject(pasarAPendiente);

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(output + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        private void btCobrarFactura_Click(object sender, EventArgs e)
        {
            if (UltimoBoton == "Cargar")
            {
                if (MessageBox.Show("Cerrar cuenta?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    label6.Text = "Cerrada";
                    CerrarCuenta cerrarCuenta = new CerrarCuenta();
                    cerrarCuenta.NombreEvento = "CerrarCuenta";
                    cerrarCuenta.NombreFactura = tbNumeCuen.Text;
                    cerrarCuenta.Total = Convert.ToDecimal(tbTotal.Text);
                    if (tbEntrega.Text == "")
                    {
                        tbEntrega.Text = "0";
                    }
                    cerrarCuenta.Entrega = Convert.ToDecimal(tbEntrega.Text);
                    cerrarCuenta.Cambio = Convert.ToDecimal(tbCambio.Text);
                    cerrarCuenta.FormaPago = cbFormaPago.Text;
                    CerrarCuenta(cerrarCuenta);
                }
                UltimoBoton = "Cobrar";
            }
            else
            {
                MessageBox.Show("Debe cargar Factura", "Aviso");
            }
        }

        private void CerrarCuenta(CerrarCuenta cerrarCuenta)
        {
            string output = JsonConvert.SerializeObject(cerrarCuenta);

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(output + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }        

        private void GridDatosFacturas_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow row in GridDatosFacturas.Rows)
            {
                if (Convert.ToString(row.Cells[1].Value) == "Abierta")
                {
                    row.Cells[1].Style.BackColor = Color.LightGreen;
                }
                else if (Convert.ToString(row.Cells[1].Value) == "Pendiente")
                {
                    row.Cells[1].Style.BackColor = Color.LightSalmon;
                }
                else if (Convert.ToString(row.Cells[1].Value) == "Cerrada")
                {
                    row.Cells[1].Style.BackColor = Color.LightSkyBlue;
                }
            }
        }

        private void ImprimirFactura()
        {
            List<LineaDetalleFactura> FacturaLimpia = new List<LineaDetalleFactura>();
            List<LineaDetalleFactura> FacturaCompacta = new List<LineaDetalleFactura>();
            List<LineaDetalleFactura> FacturaOrdenada = new List<LineaDetalleFactura>();

            //Limpiar Factura
            for (int i = 0; i < listaDetalleFactura.Count; i++)
            {
                if (listaDetalleFactura[i].ImpEnFac == 1)
                {
                    FacturaLimpia.Add(listaDetalleFactura[i]);
                }
            }            

            //Compactar Factura
            int Uni = 0;
            string Descripcion = null;
            bool Encontrado = false;
            
            for (int i = 0; i < FacturaLimpia.Count; i++)
            {
                //Buscar
                Encontrado = false;
                Uni = FacturaLimpia[i].Unidades;
                Descripcion = FacturaLimpia[i].Descripcion;
                for (int j = 0; j < FacturaCompacta.Count; j++)
                {
                    if (Descripcion == FacturaCompacta[j].Descripcion)
                    {
                        FacturaCompacta[j].Unidades = FacturaCompacta[j].Unidades + Uni;
                        Encontrado = true;
                        break;
                    }
                }
                if (Encontrado == false)
                {                    
                    FacturaCompacta.Add(FacturaLimpia[i]);                        
                }
            }

            FacturaOrdenada = FacturaCompacta.OrderByDescending(o => o.Preferencia).ToList();

            this.dataGridView1.ScrollBars = ScrollBars.None;
            this.dataGridView1.DataSource = listaDetalleFactura;
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Refresh();
            this.dataGridView1.DataSource = FacturaOrdenada; 
        }        
    }
}
