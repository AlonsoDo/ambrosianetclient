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
        
        public Terminal()
        {
            InitializeComponent();
        }

        private void Terminal_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            //Conectar
            clientSocket = new System.Net.Sockets.TcpClient();
            serverStream = default(NetworkStream);
            clientSocket.Connect("192.168.1.2",10001);
            serverStream = clientSocket.GetStream();

            FuncionesAuxiliares funcionAuxiliar = new FuncionesAuxiliares();
            IdClient = funcionAuxiliar.GenerarIdCliente();

            ctThread = new Thread(getMessage);
            ctThread.Start();

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
                    MessageBox.Show("NombreEvento:PedidoDesglosadoBack");
                }
                else if (NombreEvento == "SendTerminalesBack")
                {                    
                    ListaTerminalesTer listTerminal = new ListaTerminalesTer();
                    listTerminal = JsonConvert.DeserializeObject<ListaTerminalesTer>(readData);
                    for (int i = 0; i < listTerminal.terminalesTer.Count; i++)
                    {
                        cbTerminales.Items.Add(listTerminal.terminalesTer[i].NombreTerminal);
                    }
                }
                else if (NombreEvento == "SendPrintersBack")
                {
                    ListaImpresorasTer listPrinter = new ListaImpresorasTer();
                    listPrinter = JsonConvert.DeserializeObject<ListaImpresorasTer>(readData);
                    for (int i = 0; i < listPrinter.impresorasTer.Count; i++)
                    {
                        cbImpresoras.Items.Add(listPrinter.impresorasTer[i].NombreImpresora);
                    }
                }                
            }
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
    }
}
