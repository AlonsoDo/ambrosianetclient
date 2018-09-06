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
        public Cliente BufferCliente = new Cliente();
        public List<Cliente> listaClientes = new List<Cliente>();
        string EstadoCliente = "ModificarCliente";
        int IndexClientes = 0;
        int IndexAbsoluto = 0;
        string UltimoBoton = "";
        //int UltimoClienteMostrado = 0;
        int ContDif = 0;
        bool Filtrando = false;        
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
            if (tbCodigoCliente.Text == "")
            {
                cliente.ClienteId = -1;
            }
            else
            {
                cliente.ClienteId = Convert.ToInt32(tbCodigoCliente.Text);
            }
            cliente.NombreComercial = tbNombreComercial.Text;
            cliente.NombreFiscal = tbNombreFiscal.Text;
            cliente.Direccion = tbDireccion.Text;
            cliente.NIF = tbNIF.Text;
            cliente.Mobil = tbMovil.Text;
            cliente.Fijo = tbFijo.Text;

            SalvarCliente salvarCliente = new SalvarCliente();
            salvarCliente.cliente = cliente;

            if (EstadoCliente == "NuevoCliente")
            {
                salvarCliente.NombreEvento = "SalvarCliente";                
            }
            else
            {
                salvarCliente.NombreEvento = "ActualizarCliente";
            }
            EstadoCliente = "ModificarCliente";

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
                        btAnular.Enabled = false;
                        btBorrar.Enabled = true;
                        MessageBox.Show( this , "Datos clientes guardados" );
                    }
                }
                else if (NombreEvento == "BorrarCliente")
                {
                    ClienteIdBak clienteIdBak = new ClienteIdBak();
                    clienteIdBak = JsonConvert.DeserializeObject<ClienteIdBak>(readData);
                    int LastClientId = clienteIdBak.clienteId;
                    if (LastClientId == -1)
                    {
                        tbCodigoCliente.Text = "-1";
                        MessageBox.Show(this , "Error en el servidor");
                    }
                    else
                    {
                        //Exito
                        tbCodigoCliente.Text = LastClientId.ToString();
                        btConfirmar.Enabled = false;
                        btAnular.Enabled = false;
                        btBorrar.Enabled = false;
                        MessageBox.Show(this , "Datos cliente borrados");
                    }
                }
                else if (NombreEvento == "BuscarClienteBak")
                {
                    BuscarClienteBak buscarClienteBak = JsonConvert.DeserializeObject<BuscarClienteBak>(readData);

                    listaClientes.Clear(); 
                    listaClientes = buscarClienteBak.listaClientes;

                    Application.UseWaitCursor = false;

                    if ((UltimoBoton == "BuscarCliente") || (UltimoBoton == "FiltrarCliente"))
                    {
                        if (listaClientes.Count > 0)
                        {
                            ActivarTbClientes();
                            MostrarCliente();
                            if (listaClientes.Count > 1)
                            {
                                btSiguiente.Enabled = true;
                                btUltimo.Enabled = true;
                            }
                        }
                        else
                        {
                            DesactivarTbClientes();
                            MessageBox.Show(this , "Ningun cliente encontrado");
                            btSiguiente.Enabled = false;
                            btUltimo.Enabled = false;
                            btPrevio.Enabled = false;
                            btPrimero.Enabled = false;
                        }
                    }
                    else if (UltimoBoton == "SiguienteCliente")
                    {
                        if (listaClientes.Count > 0)
                        {
                            IndexClientes = 0;
                            MostrarCliente();
                            if (listaClientes.Count > 1)
                            {
                                btSiguiente.Enabled = true;
                                btUltimo.Enabled = true;
                            }
                        }
                        else
                        {
                            btSiguiente.Enabled = false;
                            btUltimo.Enabled = false;
                            MessageBox.Show(this , "No hay mas resultados");
                            IndexAbsoluto--;
                            IndexClientes = 0;
                        }                
                    }
                    else if (UltimoBoton == "PrevioCliente")
                    {
                        if (IndexAbsoluto > 4)
                        {
                            IndexClientes = listaClientes.Count - ContDif - 1;
                        }
                        else
                        {
                            IndexClientes = ContDif - 1;
                            IndexAbsoluto = IndexClientes + 1;
                        }
                        IndexAbsoluto--;                        
                        MostrarCliente();
                        btUltimo.Enabled = true;
                        btSiguiente.Enabled = true;
                    }
                    else if (UltimoBoton == "PrimerCliente")
                    {
                        if (listaClientes.Count > 0)
                        {
                            MostrarCliente();
                            if (listaClientes.Count > 1)
                            {
                                btSiguiente.Enabled = true;
                                btUltimo.Enabled = true;
                            }
                        }
                        else
                        {
                            btPrevio.Enabled = false;
                            btPrimero.Enabled = false;
                            MessageBox.Show(this , "No hay mas resultados");                            
                        }
                    }
                    else if (UltimoBoton == "UltimoCliente")
                    {
                        if (listaClientes.Count > 0)
                        {
                            IndexClientes = buscarClienteBak.IndiceCliente - 1;
                            if (IndexClientes == -1)
                            {
                                IndexClientes = 4;
                            }
                            IndexAbsoluto = buscarClienteBak.IndiceAbsoluto + IndexClientes;
                            MostrarCliente();
                            if (IndexAbsoluto > 1)
                            {
                                btPrimero.Enabled = true;
                                btPrevio.Enabled = true;
                            }
                        }
                        else
                        {
                            btUltimo.Enabled = false;
                            btSiguiente.Enabled = false;
                            MessageBox.Show(this , "No hay mas resultados");                           
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
            Filtrando = false;            
            Application.UseWaitCursor = true;
            IndexAbsoluto = 0;
            IndexClientes = 0;
            btPrimero.Enabled = false;
            btPrevio.Enabled = false;
            BuscarCliente(false,false);            
        }

        private void btFiltrarCliente_Click(object sender, EventArgs e)
        {
            UltimoBoton = "FiltrarCliente";
            Filtrando = true;
            Application.UseWaitCursor = true;
            IndexAbsoluto = 0;
            IndexClientes = 0;
            btPrimero.Enabled = false;
            btPrevio.Enabled = false;
            BuscarCliente(true,false); 
        } 

        private void BuscarCliente(bool Filtrar,bool BtUltimoCliente)
        {
            ComoBuscarCliente comoBuscarCliente = new ComoBuscarCliente();
            comoBuscarCliente.NombreEvento = "ComoBuscarCliente";
            comoBuscarCliente.CadenaBusqueda = tbContenidoBuscarCliente.Text;
            comoBuscarCliente.Index = IndexAbsoluto;
            comoBuscarCliente.Filtrar = Filtrar;
            comoBuscarCliente.BtUltimoCliente = BtUltimoCliente;

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

        private void BorrarCliente()
        {
            ClienteId clienteId = new ClienteId();
            clienteId.NombreEvento = "BorrarCliente";
            //clienteId.clienteId = listaClientes[UltimoClienteMostrado].ClienteId;
            clienteId.clienteId = Int32.Parse(tbCodigoCliente.Text);

            string output = JsonConvert.SerializeObject(clienteId);

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(output + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        private void btNuevoCliente_Click(object sender, EventArgs e)
        {
            if (listaClientes.Count > 0)
            {
                BufferCliente = listaClientes[IndexClientes];
            }            
            tbNombreComercial.Text = "";
            tbNombreFiscal.Text = "";
            tbDireccion.Text = "";
            tbNIF.Text = "";
            tbMovil.Text = "";
            tbFijo.Text = "";
            tbCodigoCliente.Text = "";

            ActivarTbClientes();
            EstadoCliente = "NuevoCliente";
            btConfirmar.Enabled = true;
            btAnular.Enabled = true;
            btBorrar.Enabled = false;
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

        private void DesactivarTbClientes()
        {
            tbNombreComercial.Enabled = false;
            tbNombreFiscal.Enabled = false;
            tbDireccion.Enabled = false;
            tbNIF.Enabled = false;
            tbMovil.Enabled = false;
            tbFijo.Enabled = false;
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
            BufferCliente = listaClientes[IndexClientes];
            btBorrar.Enabled = true;
            if (listaClientes[IndexClientes].Borrado == true)
            {
                DesactivarTbClientes();
                btBorrar.Enabled = false;
            }
            else
            {
                ActivarTbClientes();
                btBorrar.Enabled = true;
            }
        }

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            UltimoBoton = "SiguienteCliente";
            if (listaClientes.Count > 0)
            {
                IndexAbsoluto++;
                IndexClientes++;
                if (IndexAbsoluto > 0)
                {
                    btPrevio.Enabled = true;
                    btPrimero.Enabled = true;
                }
                if (IndexClientes == listaClientes.Count)
                {
                    if (Filtrando == false)
                    {
                        BuscarCliente(false, false);
                    }
                    else
                    {
                        BuscarCliente(true, false);
                    }
                }
                else
                {
                    MostrarCliente();
                }
            }
            else
            {
                btSiguiente.Enabled = false;
                btUltimo.Enabled = false;
                MessageBox.Show(this , "No hay mas resultados");               
            }
        }

        private void btPrevio_Click(object sender, EventArgs e)
        {
            UltimoBoton = "PrevioCliente";

            if (IndexAbsoluto == 0)
            {
                btPrimero.Enabled = false;
                btPrevio.Enabled = false;
                MessageBox.Show( this , "No hay mas resultados" );
                IndexClientes = 0;
                return;
            }

            if (IndexClientes == 0)
            {
                IndexAbsoluto = IndexAbsoluto - 5;
                if (IndexAbsoluto < 0)
                {
                    ContDif = 5 + IndexAbsoluto;
                    IndexAbsoluto = 0;
                }
                else
                {
                    ContDif = 0;
                }
                if (Filtrando == false)
                {
                    BuscarCliente(false, false);
                }
                else
                {
                    BuscarCliente(true, false);
                }
                IndexAbsoluto = IndexAbsoluto + 5 - ContDif;
            }
            else
            {
                IndexClientes--;
                IndexAbsoluto--;
                MostrarCliente();
                btUltimo.Enabled = true;
                btSiguiente.Enabled = true;
            }
        }

        private void btPrimero_Click(object sender, EventArgs e)
        {
            UltimoBoton = "PrimerCliente";
            IndexAbsoluto = 0;
            IndexClientes = 0;
            if (Filtrando == false)
            {
                BuscarCliente(false, false);
            }
            else
            {
                BuscarCliente(true, false);
            }
            btPrimero.Enabled = false;
            btPrevio.Enabled = false;
        }

        private void btUltimo_Click(object sender, EventArgs e)
        {
            UltimoBoton = "UltimoCliente";
            if (Filtrando == false)
            {
                BuscarCliente(false, true);
            }
            else
            {
                BuscarCliente(true, true);
            }
            btSiguiente.Enabled = false;
            btUltimo.Enabled = false;
        }

        private void btAnular_Click(object sender, EventArgs e)
        {
            tbNombreComercial.Text = BufferCliente.NombreComercial;
            tbNombreFiscal.Text = BufferCliente.NombreFiscal;
            tbDireccion.Text = BufferCliente.Direccion;
            tbNIF.Text = BufferCliente.NIF;
            tbMovil.Text = BufferCliente.Mobil;
            tbFijo.Text = BufferCliente.Fijo;
            tbCodigoCliente.Text = BufferCliente.ClienteId.ToString();
            btConfirmar.Enabled = false;
            btAnular.Enabled = false;
            btBorrar.Enabled = true;
        }

        private void tbNombreComercial_KeyPress(object sender, KeyPressEventArgs e)
        {
            btConfirmar.Enabled = true;
            btAnular.Enabled = true;
        }

        private void tbNombreFiscal_KeyPress(object sender, KeyPressEventArgs e)
        {
            btConfirmar.Enabled = true;
            btAnular.Enabled = true;
        }

        private void tbDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            btConfirmar.Enabled = true;
            btAnular.Enabled = true;
        }        

        private void tbContenidoBuscarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            btBuscarCliente.Enabled = true;
            btFiltrarCliente.Enabled = true;            
        }

        private void tbNIF_KeyPress(object sender, KeyPressEventArgs e)
        {
            btConfirmar.Enabled = true;
            btAnular.Enabled = true;
        }

        private void tbMovil_KeyPress(object sender, KeyPressEventArgs e)
        {
            btConfirmar.Enabled = true;
            btAnular.Enabled = true;
        }

        private void tbFijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            btConfirmar.Enabled = true;
            btAnular.Enabled = true;
        }

        private void btBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this , "Esta seguro de eliminar este cliente", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BorrarCliente();
                DesactivarTbClientes();
                if (listaClientes.Count > 0)
                {
                    listaClientes[IndexClientes].Borrado = true;
                }
                btBorrar.Enabled = false;
            }
        }                     
    }
}
