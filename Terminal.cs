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
    public partial class Terminal : Form
    {
        public static System.Net.Sockets.TcpClient clientSocket;
        NetworkStream serverStream;
        string readData = null;
        Thread ctThread;
        string IdClient = null;
        PedidoCompleto pedidoCompleto = new PedidoCompleto();
        public List<MemoPedido> memoPedidos = new List<MemoPedido>();
        public int IndexMemo = 0;                  
        
        public Terminal()
        {
            InitializeComponent();
        }

        private void Terminal_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column7 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column8 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column9 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column10 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column11 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column12 = new DataGridViewTextBoxColumn();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            
            column1.Name = "Unids";
            column1.HeaderText = "Uds";
            column1.DataPropertyName = "Unids";
            column1.ReadOnly = true;
            column1.Width = 30;
            dataGridView1.Columns.Add(column1);
            
            column2.Name = "Descripcion";
            column2.HeaderText = "Descripcion";
            column2.DataPropertyName = "Descripcion";
            column2.ReadOnly = true;
            column2.Width = 140;
            dataGridView1.Columns.Add(column2);

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.AllowUserToAddRows = false;
            
            column3.Name = "Unids";
            column3.HeaderText = "Uds";
            column3.DataPropertyName = "Unids";
            column3.ReadOnly = true;
            column3.Width = 30;
            dataGridView2.Columns.Add(column3);
            
            column4.Name = "Descripcion";
            column4.HeaderText = "Descripcion";
            column4.DataPropertyName = "Descripcion";
            column4.ReadOnly = true;
            column4.Width = 140;
            dataGridView2.Columns.Add(column4);

            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.AllowUserToAddRows = false;
            
            column5.Name = "Unids";
            column5.HeaderText = "Uds";
            column5.DataPropertyName = "Unids";
            column5.ReadOnly = true;
            column5.Width = 30;
            dataGridView3.Columns.Add(column5);
            
            column6.Name = "Descripcion";
            column6.HeaderText = "Descripcion";
            column6.DataPropertyName = "Descripcion";
            column6.ReadOnly = true;
            column6.Width = 140;
            dataGridView3.Columns.Add(column6);

            dataGridView4.AutoGenerateColumns = false;
            dataGridView4.AllowUserToAddRows = false;
            
            column7.Name = "Unids";
            column7.HeaderText = "Uds";
            column7.DataPropertyName = "Unids";
            column7.ReadOnly = true;
            column7.Width = 30;
            dataGridView4.Columns.Add(column7);
            
            column8.Name = "Descripcion";
            column8.HeaderText = "Descripcion";
            column8.DataPropertyName = "Descripcion";
            column8.ReadOnly = true;
            column8.Width = 140;
            dataGridView4.Columns.Add(column8);

            dataGridView5.AutoGenerateColumns = false;
            dataGridView5.AllowUserToAddRows = false;
            
            column9.Name = "Unids";
            column9.HeaderText = "Uds";
            column9.DataPropertyName = "Unids";
            column9.ReadOnly = true;
            column9.Width = 30;
            dataGridView5.Columns.Add(column9);
            
            column10.Name = "Descripcion";
            column10.HeaderText = "Descripcion";
            column10.DataPropertyName = "Descripcion";
            column10.ReadOnly = true;
            column10.Width = 140;
            dataGridView5.Columns.Add(column10);

            dataGridView6.AutoGenerateColumns = false;
            dataGridView6.AllowUserToAddRows = false;
            
            column11.Name = "Unids";
            column11.HeaderText = "Uds";
            column11.DataPropertyName = "Unids";
            column11.ReadOnly = true;
            column11.Width = 30;
            dataGridView6.Columns.Add(column11);
            
            column12.Name = "Descripcion";
            column12.HeaderText = "Descripcion";
            column12.DataPropertyName = "Descripcion";
            column12.ReadOnly = true;
            column12.Width = 140;
            dataGridView6.Columns.Add(column12);

            //Conectar
            clientSocket = new System.Net.Sockets.TcpClient();
            serverStream = default(NetworkStream);
            clientSocket.Connect("192.168.1.2",10001);
            serverStream = clientSocket.GetStream();            

            ctThread = new Thread(getMessage);
            ctThread.Start();

            FuncionesAuxiliares funcionAuxiliar = new FuncionesAuxiliares();
            IdClient = funcionAuxiliar.GenerarIdCliente();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(IdClient + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        private void Terminal_Activated(object sender, EventArgs e)
        {
            
        }

        private void getMessage()
        {
            string NombreEvento = null;

            while (true)
            {
                int buffSize = 0;
                byte[] inStream = new byte[262144];
                buffSize = clientSocket.ReceiveBufferSize;
                serverStream.Read(inStream, 0, buffSize);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                returndata = returndata.Substring(0, returndata.IndexOf("$"));
                readData = "" + returndata;
                
                var definition = new { NombreEvento = "" };
                var EventosControl = JsonConvert.DeserializeAnonymousType(readData, definition);
                NombreEvento = EventosControl.NombreEvento;

                if (NombreEvento == "PedidoDesglosadoBack")
                {                    
                    pedidoCompleto = JsonConvert.DeserializeObject<PedidoCompleto>(readData);
                    CargarPedido();
                }
                else if (NombreEvento == "SendTerminalesBack")
                {
                    ListaTerminalesTer listTerminal = new ListaTerminalesTer();
                    listTerminal = JsonConvert.DeserializeObject<ListaTerminalesTer>(readData);
                    CargarTerminales(listTerminal);                                                         
                }
                else if (NombreEvento == "SendPrintersBack")
                {                    
                    ListaImpresorasTer listPrinter = new ListaImpresorasTer(); 
                    listPrinter = JsonConvert.DeserializeObject<ListaImpresorasTer>(readData);
                    CargarImpresoras(listPrinter);                    
                }                
            }
        }

        private void CargarTerminales(ListaTerminalesTer listTerminal)
        {
            //MessageBox.Show("Cargando terminales");
            cbTerminales.DisplayMember = "NombreTerminal";
            cbTerminales.DataSource = listTerminal.terminalesTer;
        }

        private void CargarImpresoras(ListaImpresorasTer listPrinter)
        {
            //MessageBox.Show("Cargando impresoras");
            cbImpresoras.DisplayMember = "NombreImpresora";
            cbImpresoras.DataSource = listPrinter.impresorasTer;
        }

        private void Terminal_FormClosing(object sender, FormClosingEventArgs e)
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

        private void CargarPedido()
        {
            for (int i = 0; i < pedidoCompleto.impresoraSalida.Count; i++)
            {
                MemoPedido pedido = new MemoPedido();
                pedido.NombCuen = pedidoCompleto.NombreCuenta;
                pedido.NombImprTerm = pedidoCompleto.impresoraSalida[i].NombreImpresora;
                pedido.salidaPedido = pedidoCompleto.impresoraSalida[i].dataLinea;
                memoPedidos.Add(pedido);                
            }
            for (int i = 0; i < pedidoCompleto.terminalSalida.Count; i++)
            {
                MemoPedido pedido = new MemoPedido();
                pedido.NombCuen = pedidoCompleto.NombreCuenta;
                pedido.NombImprTerm = pedidoCompleto.terminalSalida[i].NombreTerminal;
                pedido.salidaPedido = pedidoCompleto.terminalSalida[i].dataLinea;
                memoPedidos.Add(pedido);
            }

            MostrarPedido();
        }

        private void MostrarPedido()
        {
            int i = 0;
            for (int j = IndexMemo; j < memoPedidos.Count; j++)
            {
                Control[] controls = this.Controls.Find("lNombCuen" + (i+1).ToString(), true);
                Label control = new Label();
                control = controls[0] as Label;
                control.Text = "N:" + memoPedidos[j].NombCuen + " " + memoPedidos[j].NombImprTerm + " " + DateTime.Now.ToString("HH:mm");
                
                Control[] controls2 = this.Controls.Find("dataGridView" + (i+1).ToString(), true);
                DataGridView control2 = new DataGridView();
                control2 = controls2[0] as DataGridView;

                control2.DataSource = typeof(SalidaPedido);
                control2.DataSource = memoPedidos[j].salidaPedido;

                i++;
                if (i == 6)
                {
                    break;
                }
            }
        }                              
    }
}
