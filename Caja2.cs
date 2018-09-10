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
    public partial class Caja2 : Form
    {
        public static System.Net.Sockets.TcpClient clientSocket;
        NetworkStream serverStream;
        string readData = null;
        Thread ctThread;
        string IdClient = null;
        
        public Caja2()
        {
            InitializeComponent();
        }

        private void Caja2_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

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
                returndata = returndata.Substring(0, returndata.IndexOf("$"));
                readData = "" + returndata;

                var definition = new { NombreEvento = "" };
                var EventosControl = JsonConvert.DeserializeAnonymousType(readData, definition);
                NombreEvento = EventosControl.NombreEvento;

                if (NombreEvento == "TotalesCuentasBak")
                {
                    TotalesCuentas totalesCuentas = JsonConvert.DeserializeObject<TotalesCuentas>(readData);
                    MostrarConsultaTotalesCuentas(totalesCuentas);
                }
                else if (NombreEvento == "ResultadoCierreCaja")
                {
                    ResultadoCierreCaja resultado = JsonConvert.DeserializeObject<ResultadoCierreCaja>(readData);
                    MessageBox.Show(resultado.Mensaje, "Aviso");
                }
                else if (NombreEvento == "TotalEmpleadoBack")
                {
                    TotalEmpleadoBack totalEmpleado = JsonConvert.DeserializeObject<TotalEmpleadoBack>(readData);
                    tbTotalEmpl.Text = totalEmpleado.TotalEmpleado.ToString();
                }
            }
        }

        private void Caja2_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btConsultar_Click(object sender, EventArgs e)
        {
            Evento evento = new Evento();
            evento.NombreEvento = "TotalesCuentas";           
            string output = JsonConvert.SerializeObject(evento);

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(output + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        private void MostrarConsultaTotalesCuentas(TotalesCuentas totalesCuentas)
        {
            tbUnidAbiertas.Text = Convert.ToString(totalesCuentas.Abiertas);
            tbUnidPendientes.Text = Convert.ToString(totalesCuentas.Pendientes);
            tbUnidCerradas.Text = Convert.ToString(totalesCuentas.Cerradas);
            tbTotalAbiertas.Text = String.Format("{0:0.00}", totalesCuentas.TotalAbiertas);
            tbTotalPendientes.Text = String.Format("{0:0.00}", totalesCuentas.TotalPendientes);
            tbTotalCerradas.Text = String.Format("{0:0.00}", totalesCuentas.TotalCerradas);
        }

        private void btCerrarCaja_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se va a proceder a cerrar la caja. Esta seguro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string Fecha = monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd");
                string Hora = DateTime.Now.ToString("HH:mm:ss");
                CierreCaja cierreCaja = new CierreCaja();
                cierreCaja.NombreEvento = "CierreCaja";
                cierreCaja.Fecha = Fecha;
                cierreCaja.Hora = Hora;

                string output = JsonConvert.SerializeObject(cierreCaja);

                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(output + "$");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
            }
            else
            {
                MessageBox.Show("Ningun cambio realizado", "Aviso");
            }
        }

        private void tbCodiEmpl_Click(object sender, EventArgs e)
        {
            tbCodiEmpl.Text = "";
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            if (tbCodiEmpl.Text.Length < 5)
            {
                tbCodiEmpl.Text = tbCodiEmpl.Text + "1";
            }
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            if (tbCodiEmpl.Text.Length < 5)
            {
                tbCodiEmpl.Text = tbCodiEmpl.Text + "2";
            }
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            if (tbCodiEmpl.Text.Length < 5)
            {
                tbCodiEmpl.Text = tbCodiEmpl.Text + "3";
            }
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            if (tbCodiEmpl.Text.Length < 5)
            {
                tbCodiEmpl.Text = tbCodiEmpl.Text + "4";
            }
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            if (tbCodiEmpl.Text.Length < 5)
            {
                tbCodiEmpl.Text = tbCodiEmpl.Text + "5";
            }
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            if (tbCodiEmpl.Text.Length < 5)
            {
                tbCodiEmpl.Text = tbCodiEmpl.Text + "6";
            }
        }

        private void bt7_Click(object sender, EventArgs e)
        {
            if (tbCodiEmpl.Text.Length < 5)
            {
                tbCodiEmpl.Text = tbCodiEmpl.Text + "7";
            }
        }

        private void bt8_Click(object sender, EventArgs e)
        {
            if (tbCodiEmpl.Text.Length < 5)
            {
                tbCodiEmpl.Text = tbCodiEmpl.Text + "8";
            }
        }

        private void bt9_Click(object sender, EventArgs e)
        {
            if (tbCodiEmpl.Text.Length < 5)
            {
                tbCodiEmpl.Text = tbCodiEmpl.Text + "9";
            }
        }

        private void bt0_Click(object sender, EventArgs e)
        {
            if (tbCodiEmpl.Text.Length < 5)
            {
                tbCodiEmpl.Text = tbCodiEmpl.Text + "0";
            }
        }

        private void CalcularTotalEmpleado_Click(object sender, EventArgs e)
        {
            CalcularTotalEmpleado calcularTotalEmpleado = new CalcularTotalEmpleado();
            calcularTotalEmpleado.NombreEvento = "CalcularTotalEmpleado";
            calcularTotalEmpleado.CodigoEmpleado = tbCodiEmpl.Text;

            if (tbCodiEmpl.Text == "")
                MessageBox.Show("Debe indicar un codigo para el empleado", "Aviso");

            string output = JsonConvert.SerializeObject(calcularTotalEmpleado);

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(output + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

    }
}
