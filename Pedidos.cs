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
    public partial class Pedidos : Form
    {
        System.Net.Sockets.TcpClient clientSocket;
        NetworkStream serverStream;
        string readData = null;
        Thread ctThread;
        string IdClient = null;
        public GetElementsData elementos = new GetElementsData();
        int Level = 0;
        int IndexAbs = 0;
        List<Path> Path = new List<Path>();
        int ContNodos = 0;
        int NodoPadre = 0;
        
        public Pedidos()
        {
            InitializeComponent();
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            Path ini = new Path();
            ini.PadreId = 0;
            ini.Final = 0;
            Path.Add(ini);

            TreeNode treeNode = new TreeNode();
            InfoNodo infoNodo = new InfoNodo();
            infoNodo.IdNodo = 0;
            infoNodo.IdPadre = 0;
            treeNode.Name = "0";
            treeNode.Text = "ORDEN:";
            treeNode.Tag = infoNodo;
            tvOrden.Nodes.Add(treeNode);
            
            //Conectar
            clientSocket = new System.Net.Sockets.TcpClient();
            serverStream = default(NetworkStream);
            clientSocket.Connect("192.168.1.2", 8888);
            serverStream = clientSocket.GetStream();

            FuncionesAuxiliares funcionAuxiliar = new FuncionesAuxiliares();
            IdClient = funcionAuxiliar.GenerarIdCliente();
            
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(IdClient + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            ctThread = new Thread(getMessage);
            ctThread.Start();
        }        

        private void getMessage()
        {
            string NombreEvento = null;
                        
            while (true)
            {
                serverStream = clientSocket.GetStream();
                int buffSize = 0;
                byte[] inStream = new byte[10025];
                buffSize = clientSocket.ReceiveBufferSize;
                serverStream.Read(inStream, 0, buffSize);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                returndata = returndata.Substring(0, returndata.IndexOf("$"));
                readData = "" + returndata;

                var definition = new { NombreEvento = "" };
                var EventosControl = JsonConvert.DeserializeAnonymousType(readData, definition);
                NombreEvento = EventosControl.NombreEvento;

                if (NombreEvento == "SendElementsDataBak")
                {
                    elementos = JsonConvert.DeserializeObject<GetElementsData>(readData);
                    DrawElements();
                }
            }
            
        }

        private void Pedidos_FormClosing(object sender, FormClosingEventArgs e)
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

        private void DrawElements()
        {
            int Cont = elementos.data.Count;
            PictureBox control2 = new PictureBox();
            Label control = new Label();

            for (int i = 0; i < 24; i++)
            {
                Control[] controls2 = this.panel1.Controls.Find("pictureBox" + (i + 1).ToString(), true);
                control2 = controls2[0] as PictureBox;
                control2.Image = null;
                if (i < Cont)
                {
                    string path = elementos.data.ElementAt(i).PathImg;
                    if (path != "")
                    {
                        try
                        {
                            control2.Image = Image.FromFile(path);
                        }
                        catch (System.IO.FileNotFoundException)
                        {
                            MessageBox.Show("There was an error opening the image file." +
                                "Please check the path.");
                        }
                    }
                }                                
                Control[] controls = this.panel1.Controls.Find("label" + (i + 1).ToString(), true);
                control = controls[0] as Label;                        
                if (i < Cont)
                {
                    control.Text = elementos.data.ElementAt(i).Descripcion;
                }
                else
                {
                    control.Text = string.Empty;
                }                    
            }            
        }

        private void Element_Click(object sender, EventArgs e)
        {            
            PictureBox Pb = sender as PictureBox;
            IndexAbs = Convert.ToInt32(Pb.Tag);

            if (IndexAbs <= elementos.data.Count)
            {
                if (Convert.ToBoolean(elementos.data.ElementAt(IndexAbs - 1).Final))
                {
                    //Elemento Final
                    TreeNode[] MyNode;
                    MyNode = tvOrden.Nodes.Find(NodoPadre.ToString(),true);
                    
                    ContNodos++;

                    var nodeText = elementos.data.ElementAt(IndexAbs - 1).Descripcion;
                    TreeNode treeNode = new TreeNode();
                    InfoNodo infoNodo = new InfoNodo();
                    infoNodo.IdNodo = ContNodos;
                    infoNodo.IdPadre = NodoPadre;
                    treeNode.Name = ContNodos.ToString();
                    treeNode.Text = nodeText;
                    treeNode.Tag = infoNodo;                    

                    MyNode[0].Nodes.Add(treeNode);

                    MyNode[0].Expand();

                    btEntrar.Enabled = true;
                }
                else
                {
                    //Load next
                    EventoAskForElements eventoAskForElements = new EventoAskForElements();
                    eventoAskForElements.NombreEvento = "AskForElements";
                    eventoAskForElements.PadreId = elementos.data.ElementAt(IndexAbs-1).ElementoId;
                    string output = JsonConvert.SerializeObject(eventoAskForElements);

                    byte[] outStream = System.Text.Encoding.ASCII.GetBytes(output + "$");
                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();

                    Level++;
                    if (Path.Count == Level)
                    {
                        Path path = new Path();
                        path.PadreId = eventoAskForElements.PadreId;
                        path.Final = 0;
                        Path.Add(path);
                    }
                    else
                    {
                        Path path = new Path();
                        path.PadreId = eventoAskForElements.PadreId;
                        path.Final = 0;
                        Path[Level] = path;
                    }
                }
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            btEntrar.Enabled = false;
            
            if (Path[Level].Final == 1)
            {
                TreeNode[] MyNode;
                MyNode = tvOrden.Nodes.Find(NodoPadre.ToString(), true);
                InfoNodo infoNodo = new InfoNodo();
                infoNodo = (InfoNodo)MyNode[0].Tag;
                NodoPadre = infoNodo.IdPadre;
            }
            
            Level--;
            if (Level == -1)
            {
                Level = 0;
            }
            int PadreId = Path[Level].PadreId;            

            EventoAskForElements eventoAskForElements = new EventoAskForElements();
            eventoAskForElements.NombreEvento = "AskForElements";
            eventoAskForElements.PadreId = PadreId;
            string output = JsonConvert.SerializeObject(eventoAskForElements);

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(output + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {
            //Elemento Final
            NodoPadre = ContNodos;

            btEntrar.Enabled = false;
            
            EventoAskForElements eventoAskForElements = new EventoAskForElements();
            eventoAskForElements.NombreEvento = "AskForElements";
            eventoAskForElements.PadreId = elementos.data.ElementAt(IndexAbs - 1).ElementoId;
            string output = JsonConvert.SerializeObject(eventoAskForElements);

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(output + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            Level++;
            if (Path.Count == Level)
            {
                Path path = new Path();
                path.PadreId = eventoAskForElements.PadreId;
                path.Final = 1;
                Path.Add(path);
            }
            else
            {
                Path path = new Path();
                path.PadreId = eventoAskForElements.PadreId;
                path.Final = 1;
                Path[Level] = path;
            }
        }        
    }
}
