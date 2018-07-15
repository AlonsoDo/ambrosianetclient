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
    public partial class Clientes : Form
    {
        public Cliente cliente = new Cliente();
        public List<Cliente> listaClientes = new List<Cliente>();
        int IndexClientes = 0;
        int IndexAbsoluto = 0;
        string UltimoBoton = "";
        int Cont = 0;
        int ClientesCount = 0;
        bool FinalClientes = false;
        public static System.Net.Sockets.TcpClient clientSocket;
        NetworkStream serverStream;
        string readData = null;
        Thread ctThread;
        string IdClient = null;
        
        public Clientes()
        {
            InitializeComponent();
        }       

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            cliente.ClienteId = -1;
            cliente.NombreComercial = tbNombreComercial.Text;
            cliente.NombreFiscal = tbNombreFiscal.Text;
            cliente.Direccion = tbDireccion.Text;
            cliente.NIF = tbNIF.Text;
            cliente.Mobil = tbMovil.Text;
            cliente.Fijo = tbFijo.Text;

            SalvarCliente salvarCliente = new SalvarCliente();
            salvarCliente.cliente = cliente;
            salvarCliente.NombreEvento = "SalvarCliente";

           string output = JsonConvert.SerializeObject(salvarCliente);

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(output + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            //Conectar
            clientSocket = new System.Net.Sockets.TcpClient();
            serverStream = default(NetworkStream);
            clientSocket.Connect("192.168.1.2", 10001);
            serverStream = clientSocket.GetStream();

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
                byte[] inStream = new byte[1048576]; // 1Mbyte
                buffSize = clientSocket.ReceiveBufferSize;
                serverStream.Read(inStream, 0, buffSize);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                returndata = returndata.Substring(0, returndata.IndexOf("$"));
                readData = "" + returndata;

                var definition = new { NombreEvento = "" };
                var EventosControl = JsonConvert.DeserializeAnonymousType(readData, definition);
                NombreEvento = EventosControl.NombreEvento;

                if (NombreEvento == "ClienteIdBak")
                {
                    ClienteIdBak clienteIdBak = new ClienteIdBak();
                    clienteIdBak = JsonConvert.DeserializeObject<ClienteIdBak>(readData);
                    int LastClientId = clienteIdBak.clienteId;
                    if (LastClientId == -1)
                    {
                        tbCodigoCliente.Text = "-1";
                        MessageBox.Show("Error en el servidor");
                    }
                    else
                    {
                        //Exito
                        tbCodigoCliente.Text = LastClientId.ToString();
                        btConfirmar.Enabled = false;
                        MessageBox.Show("Datos clientes guardados");
                    }
                }
                else if (NombreEvento == "BuscarClienteBak")
                {
                    BuscarClienteBak buscarClienteBak = JsonConvert.DeserializeObject<BuscarClienteBak>(readData);

                    listaClientes.Clear(); 
                    listaClientes = buscarClienteBak.listaClientes;                    

                    if (UltimoBoton == "BuscarCliente")
                    {
                        Cursor.Current = Cursors.Default; 
                        if (listaClientes.Count > 0)
                        {
                            ClientesCount = listaClientes.Count;
                            IndexAbsoluto = 0;
                            IndexClientes = 0;
                            MostrarCliente();
                            IndexClientes++;
                            IndexAbsoluto++;
                            btSiguiente.Enabled = true;
                        }
                        else
                        {
                            btSiguiente.Enabled = false;
                            btPrevio.Enabled = false;
                            MessageBox.Show("Ningun clientes encontrado");
                        }
                    }
                    else if (UltimoBoton == "SiguienteCliente")
                    {
                        Cursor.Current = Cursors.Default;
                        if (listaClientes.Count > 0)
                        {
                            IndexClientes = 0;
                            MostrarCliente();
                            IndexClientes++;
                            IndexAbsoluto++;
                            btSiguiente.Enabled = true;
                            if (listaClientes.Count == 1)
                            {
                                btSiguiente.Enabled = false;
                                MessageBox.Show("No hay mas resultados");
                            }
                        }
                        else
                        {
                            btSiguiente.Enabled = false;
                            FinalClientes = true;
                            MessageBox.Show("No hay mas resultados");                            
                        }
                    }
                    else if (UltimoBoton == "PrevioCliente")
                    {
                        Cursor.Current = Cursors.Default;
                        if (listaClientes.Count > 0)
                        {
                            IndexClientes = listaClientes.Count - 1;
                            if (FinalClientes)
                            {
                                FinalClientes = false;
                                IndexClientes--;
                                IndexAbsoluto--;
                            }
                            MostrarCliente();                            
                            IndexAbsoluto = IndexAbsoluto + Cont - 1;                            
                            btPrevio.Enabled = true;
                            btSiguiente.Enabled = true;
                        }
                        else
                        {
                            btPrevio.Enabled = false;
                            MessageBox.Show("No hay mas resultados");
                        }
                    }
                }
            }
        }

        private void Clientes_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btBuscarCliente_Click(object sender, EventArgs e)
        {
            UltimoBoton = "BuscarCliente";
            Cursor.Current = Cursors.WaitCursor;
            IndexAbsoluto = 0;
            btPrevio.Enabled = false;
            BuscarCliente();            
        }

        private void BuscarCliente()
        {
            ComoBuscarCliente comoBuscarCliente = new ComoBuscarCliente();
            comoBuscarCliente.NombreEvento = "ComoBuscarCliente";
            comoBuscarCliente.CadenaBusqueda = tbContenidoBuscarCliente.Text;
            comoBuscarCliente.Index = IndexAbsoluto;

            if (cbCargarClientes.Text == "Nombre Comercial")
            {
                comoBuscarCliente.Orden = "NombreComercial";
            }
            else if (cbCargarClientes.Text == "Nombre Fiscal")
            {
                comoBuscarCliente.Orden = "NombreFiscal";
            }
            else if (cbCargarClientes.Text == "Direccion")
            {
                comoBuscarCliente.Orden = "Direccion";
            }
            else if (cbCargarClientes.Text == "NIF")
            {
                comoBuscarCliente.Orden = "NIF";
            }
            else if (cbCargarClientes.Text == "Codigo Cliente")
            {
                comoBuscarCliente.Orden = "ClienteId";
            }
            else if (cbCargarClientes.Text == "Movil")
            {
                comoBuscarCliente.Orden = "Mobil";
            }
            else if (cbCargarClientes.Text == "Telefono Fijo")
            {
                comoBuscarCliente.Orden = "Fijo";
            }

            string output = JsonConvert.SerializeObject(comoBuscarCliente);

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(output + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        private void btNuevoCliente_Click(object sender, EventArgs e)
        {
            tbNombreComercial.Text = "";
            tbNombreFiscal.Text = "";
            tbDireccion.Text = "";
            tbNIF.Text = "";
            tbMovil.Text = "";
            tbFijo.Text = "";
            tbCodigoCliente.Text = "";
        }        

        private void ActivarTbClientes()
        {
            tbNombreComercial.Enabled = true;
            tbNombreFiscal.Enabled = true;
            tbDireccion.Enabled = true;
            tbNIF.Enabled = true;
            tbMovil.Enabled = true;
            tbFijo.Enabled = true;            
        }

        private void MostrarCliente()
        {
            tbNombreComercial.Text = listaClientes[IndexClientes].NombreComercial;
            tbNombreFiscal.Text = listaClientes[IndexClientes].NombreFiscal;
            tbDireccion.Text = listaClientes[IndexClientes].Direccion;
            tbNIF.Text = listaClientes[IndexClientes].NIF;
            tbMovil.Text = listaClientes[IndexClientes].Mobil;
            tbFijo.Text = listaClientes[IndexClientes].Fijo;
            tbCodigoCliente.Text = listaClientes[IndexClientes].ClienteId.ToString();
        }

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            if (UltimoBoton == "PrevioCliente")
            {
                IndexClientes++;
                IndexAbsoluto++;
            }
            
            UltimoBoton = "SiguienteCliente";
            if (listaClientes.Count == IndexClientes)
            {
                if (listaClientes.Count < 5)
                {
                    btSiguiente.Enabled = false;
                    MessageBox.Show("No hay mas resultados");
                }
                else
                {
                    BuscarCliente();
                    Cursor.Current = Cursors.WaitCursor;
                    btSiguiente.Enabled = false;
                }                                                                                               
            }
            else
            {
                MostrarCliente();
                IndexClientes++;
                IndexAbsoluto++;
                if (IndexClientes > 1)
                {
                    btPrevio.Enabled = true;
                }
                if ((IndexClientes == listaClientes.Count) && (listaClientes.Count < 5))
                {
                    btSiguiente.Enabled = false;
                    MessageBox.Show("No hay mas resultados");

                }            
            }                          
        }

        private void btPrevio_Click(object sender, EventArgs e)
        {
            if (UltimoBoton == "SiguienteCliente")
            {
                IndexClientes--;
                if (listaClientes.Count > 0)
                {
                    IndexAbsoluto--;
                }
            }            
            UltimoBoton = "PrevioCliente";
            if ((IndexClientes == 0) || (listaClientes.Count == 0))
            {
                IndexAbsoluto = IndexAbsoluto - 5;
                if (IndexAbsoluto < 0)
                {
                    Cont = 5 - IndexAbsoluto;
                    IndexAbsoluto = 0;
                }
                else
                {
                    Cont = 5;
                }
                BuscarCliente();
                Cursor.Current = Cursors.WaitCursor;
                btPrevio.Enabled = false;    
            }
            else
            {
                IndexClientes--;
                IndexAbsoluto--;
                MostrarCliente();
                if (listaClientes.Count > 0)
                {
                    btSiguiente.Enabled = true;
                }
                if ((IndexClientes == 0) && (IndexAbsoluto == 0))
                {
                    btPrevio.Enabled = false;
                    MessageBox.Show("No hay mas resultados");
                    //IndexClientes++;
                    //IndexAbsoluto++;
                }                                
            }
        }
    }
}
