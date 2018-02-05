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
        public static System.Net.Sockets.TcpClient clientSocket;
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
        bool TreeMode = false;
        bool bNumeCuen = true;
        bool bPor = false;
        bool bUnid = false;
        bool bNuevaUnid = true;
        public Decimal Total = 0;
        List<LineaPedido> dataLinea = new List<LineaPedido>();
        
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
            infoNodo.Precio = 0;
            infoNodo.Impuesto = 0;
            infoNodo.Unid = 0;
            infoNodo.ImprimirEnComanda = 0;
            infoNodo.ImprimirEnFactura = 0;
            treeNode.Tag = infoNodo;
            tvOrden.Nodes.Add(treeNode);
            
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
            if (Cont == 0)
            {
                btEntrar.Enabled = false;
            }
            
            PictureBox control2 = new PictureBox();
            Label control = new Label();

            for (int i = 0; i < 24; i++)
            {
                Control[] controls2 = this.panel1.Controls.Find("pictureBox" + (i + 1).ToString(), true);
                control2 = controls2[0] as PictureBox;
                control2.Image = null; // Reset
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
            //Unidades
            int Unidades = 1;
            if (bPor & bUnid)
            {
                if (tbUnid.Text == "")
                {
                    Unidades = 1;
                }
                else
                {
                    Unidades = int.Parse(tbUnid.Text);
                }
            }
            else
            {
                Unidades = 1;
                tbUnid.Text = "1";
                tbPor.Text = "X";
            }

            PictureBox Pb = sender as PictureBox;
            IndexAbs = Convert.ToInt32(Pb.Tag);

            if (IndexAbs <= elementos.data.Count)
            {
                if (Convert.ToBoolean(elementos.data.ElementAt(IndexAbs - 1).Final))
                {                    
                    //Elemento Final
                    btBorrar.Enabled = true;
                    TreeNode[] MyNode;
                    MyNode = tvOrden.Nodes.Find(NodoPadre.ToString(),true);
                    
                    ContNodos++;

                    var nodeText = elementos.data.ElementAt(IndexAbs - 1).Descripcion;
                    tbDescripcion.Text = nodeText;
                    TreeNode treeNode = new TreeNode();
                    InfoNodo infoNodo = new InfoNodo();
                    infoNodo.IdNodo = ContNodos;
                    infoNodo.IdPadre = NodoPadre;
                    infoNodo.IdRefMenu = elementos.data.ElementAt(IndexAbs - 1).PadreId;
                    infoNodo.IdElemento = elementos.data.ElementAt(IndexAbs - 1).ElementoId;
                    infoNodo.Unid = Unidades;
                    infoNodo.Descripcion = nodeText;
                    infoNodo.Precio = elementos.data.ElementAt(IndexAbs - 1).Precio;
                    infoNodo.Impuesto = elementos.data.ElementAt(IndexAbs - 1).Impuesto;
                    infoNodo.ImprimirEnComanda = elementos.data.ElementAt(IndexAbs - 1).ImprimirEnComanda;
                    infoNodo.ImprimirEnFactura = elementos.data.ElementAt(IndexAbs - 1).ImprimirEnFactura;
                    

                    treeNode.Name = ContNodos.ToString();
                    treeNode.Text = Unidades.ToString() + " " + nodeText;
                    treeNode.Tag = infoNodo;                    

                    MyNode[0].Nodes.Add(treeNode);
                    
                    MyNode[0].Expand();
                    tvOrden.SelectedNode = treeNode;
                    //int TabLevel = tvOrden.SelectedNode.Level;
                    
                    btEntrar.Enabled = true;
                    btMas.Enabled = true;
                    btMenos.Enabled = true;

                    if (tvOrden.SelectedNode.Parent.Nodes.Count > 1)
                    {
                        btArriba.Enabled = true;
                        btAbajo.Enabled = true;
                    }
                    else
                    { 
                        btArriba.Enabled = false;
                        btAbajo.Enabled = false;
                    }
                    bPor = false;
                    bUnid = false;
                    bNuevaUnid = true;

                    Total = 0;
                    dataLinea.Clear();
                    
                    TreeNodeCollection nodes = tvOrden.Nodes;
                    //Aqui recorres todos los nodos
                    foreach (TreeNode n in nodes)
                    {
                        RecorrerNodos(n); 
                    }
                    tbTotal.Text = String.Format("{0:0.00}",Total); 
                }
                else
                {
                    btBack.Enabled = true;
                    
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

        private void RecorrerNodos(TreeNode treeNode)
        {
            try
            {
                //Si el nodo que recibimos tiene hijos se recorrerá                
                foreach (TreeNode tn in treeNode.Nodes)
                {
                    InfoNodo infoNodo = new InfoNodo();
                    infoNodo = (InfoNodo)tn.Tag;

                    Total = Total + (infoNodo.Unid * ((infoNodo.Precio) + ((infoNodo.Impuesto * infoNodo.Precio) / 100)));
                    
                    //Rellenar pedido con el arbol
                    dataLinea.Add(new LineaPedido()
                    {
                        IdElemento = infoNodo.IdElemento,
                        Unids = infoNodo.Unid,
                        Descripcion = infoNodo.Descripcion,
                        Precio = infoNodo.Precio,
                        Impuesto = infoNodo.Impuesto,
                        ImprimirEnComanda = infoNodo.ImprimirEnComanda,
                        ImprimirEnFactura = infoNodo.ImprimirEnFactura,
                        TabLevel = tn.Level
                    });
                    
                    //Ahora hago verificacion a los hijos del nodo actual
                    //Esta iteración no acabara hasta llegar al ultimo nodo principal
                    RecorrerNodos(tn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            btEntrar.Enabled = false;
            int PadreId = 0;

            if (TreeMode)
            {
                TreeMode = false;
                NodoPadre = 0;
                Level = 0;
                PadreId = 0;
                TreeNode[] MyNode;
                MyNode = tvOrden.Nodes.Find(NodoPadre.ToString(), true);
                
                tvOrden.SelectedNode = MyNode[0];
                btBack.Enabled = false;
            }
            else
            {
                TreeNode[] MyNode;
                MyNode = tvOrden.Nodes.Find(NodoPadre.ToString(), true);
                InfoNodo infoNodo = new InfoNodo();
                infoNodo = (InfoNodo)MyNode[0].Tag;
                NodoPadre = infoNodo.IdPadre;
                tvOrden.SelectedNode = MyNode[0];
                
                Level--;
                if (Level == 0)
                {
                    btBack.Enabled = false;
                }
                else if (Level == -1)
                {
                    Level = 0;
                }
                PadreId = Path[Level].PadreId;
            }

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
            InfoNodo infoNodo = new InfoNodo();
            infoNodo = (InfoNodo)tvOrden.SelectedNode.Tag;
            int Index = 0;

            if (TreeMode)
            {                
                NodoPadre = infoNodo.IdNodo;
                Index = infoNodo.IdElemento;
                //TreeMode = false;
            }
            else
            {
                NodoPadre = ContNodos;
                Index = elementos.data.ElementAt(IndexAbs - 1).ElementoId;
            }            

            btEntrar.Enabled = false;
            
            EventoAskForElements eventoAskForElements = new EventoAskForElements();
            eventoAskForElements.NombreEvento = "AskForElements";
            eventoAskForElements.PadreId = Index;
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
            btBack.Enabled = true;
        }               

        private void tvOrden_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeMode = true;
            
            InfoNodo infoNodo = new InfoNodo();

            infoNodo = (InfoNodo)e.Node.Tag;
            NodoPadre = infoNodo.IdPadre;

            EventoAskForElements eventoAskForElements = new EventoAskForElements();
            eventoAskForElements.NombreEvento = "AskForElements";
            eventoAskForElements.PadreId = infoNodo.IdRefMenu;
            string output = JsonConvert.SerializeObject(eventoAskForElements);

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(output + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        private void btMas_Click(object sender, EventArgs e)
        {
            int Unids = 0;
            InfoNodo infoNodo = new InfoNodo();

            if (tvOrden.SelectedNode.Text != "ORDEN:")
            {
                infoNodo = (InfoNodo)tvOrden.SelectedNode.Tag;
                Unids = infoNodo.Unid;
                Unids++;
                infoNodo.Unid = Unids;
                tvOrden.SelectedNode.Text = Convert.ToString(Unids) + " " + infoNodo.Descripcion;
                tvOrden.SelectedNode.Tag = infoNodo;

                Total = 0;
                dataLinea.Clear();

                TreeNodeCollection nodes = tvOrden.Nodes;
                //Aqui recorres todos los nodos
                foreach (TreeNode n in nodes)
                {
                    RecorrerNodos(n);
                }
                tbTotal.Text = String.Format("{0:0.00}", Total);
            }
        }

        private void btMenos_Click(object sender, EventArgs e)
        {
            int Unids = 0;
            InfoNodo infoNodo = new InfoNodo();

            if (tvOrden.SelectedNode.Text != "ORDEN:")
            {
                infoNodo = (InfoNodo)tvOrden.SelectedNode.Tag;
                Unids = infoNodo.Unid;
                Unids--;
                infoNodo.Unid = Unids;
                tvOrden.SelectedNode.Text = Convert.ToString(Unids) + " " + infoNodo.Descripcion;
                tvOrden.SelectedNode.Tag = infoNodo;

                Total = 0;
                dataLinea.Clear();

                TreeNodeCollection nodes = tvOrden.Nodes;
                //Aqui recorres todos los nodos
                foreach (TreeNode n in nodes)
                {
                    RecorrerNodos(n);
                }
                tbTotal.Text = String.Format("{0:0.00}", Total);
            }
        }

        private void btArriba_Click(object sender, EventArgs e)
        {
            TreeNode node = tvOrden.SelectedNode;
            TreeNode parent = tvOrden.SelectedNode.Parent;
            TreeView view = tvOrden.SelectedNode.TreeView;
            if (parent != null)
            {
                int index = parent.Nodes.IndexOf(node);
                if (index > 0)
                {
                    parent.Nodes.RemoveAt(index);
                    parent.Nodes.Insert(index - 1, node);
                }
            }
            else if (node.TreeView.Nodes.Contains(node)) //root node
            {
                int index = view.Nodes.IndexOf(node);
                if (index > 0)
                {
                    view.Nodes.RemoveAt(index);
                    view.Nodes.Insert(index - 1, node);
                }
            }
            tvOrden.SelectedNode = node;            
        }

        private void btAbajo_Click(object sender, EventArgs e)
        {
            TreeNode node = tvOrden.SelectedNode;
            TreeNode parent = node.Parent;
            TreeView view = node.TreeView;
            if (parent != null)
            {
                int index = parent.Nodes.IndexOf(node);
                if (index < parent.Nodes.Count - 1)
                {
                    parent.Nodes.RemoveAt(index);
                    parent.Nodes.Insert(index + 1, node);
                }
            }
            else if (view != null && view.Nodes.Contains(node)) //root node
            {
                int index = view.Nodes.IndexOf(node);
                if (index < view.Nodes.Count - 1)
                {
                    view.Nodes.RemoveAt(index);
                    view.Nodes.Insert(index + 1, node);
                }
            }
            tvOrden.SelectedNode = node;
        }

        private void btBorrar_Click(object sender, EventArgs e)
        {
            TreeNode node = tvOrden.SelectedNode;
            TreeNode parent = node.Parent;

            if (node.Text != "ORDEN:")
            {
                btBack.Enabled = false;
                TreeMode = false;
                NodoPadre = 0;
                Level = 0;
                int index = parent.Nodes.IndexOf(node);

                parent.Nodes.RemoveAt(index);

                if (tvOrden.Nodes.Count < 3)
                {
                    btArriba.Enabled = false;
                    btAbajo.Enabled = false;
                }
                if (tvOrden.Nodes.Count == 1)
                {
                    btBorrar.Enabled = false;
                    btEntrar.Enabled = false;
                    btMas.Enabled = false;
                    btMenos.Enabled = false;
                }

                TreeNode[] MyNode;
                MyNode = tvOrden.Nodes.Find(NodoPadre.ToString(),true);
                tvOrden.SelectedNode = MyNode[0];
                EventoAskForElements eventoAskForElements = new EventoAskForElements();
                eventoAskForElements.NombreEvento = "AskForElements";
                eventoAskForElements.PadreId = 0;
                string output = JsonConvert.SerializeObject(eventoAskForElements);

                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(output + "$");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();

                Total = 0;
                dataLinea.Clear();

                TreeNodeCollection nodes = tvOrden.Nodes;
                //Aqui recorres todos los nodos
                foreach (TreeNode n in nodes)
                {
                    RecorrerNodos(n);
                }
                tbTotal.Text = String.Format("{0:0.00}", Total);
            }
        }

        private void tvOrden_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvOrden.SelectedNode.Text != "ORDEN:")
            {
                btEntrar.Enabled = true;
                btBack.Enabled = true;
                btBorrar.Enabled = true;
                btMas.Enabled = true;
                btMenos.Enabled = true;
                if (tvOrden.SelectedNode.Parent.Nodes.Count > 1)
                {
                    btArriba.Enabled = true;
                    btAbajo.Enabled = true;
                }
                else
                {
                    btArriba.Enabled = false;
                    btAbajo.Enabled = false;
                }
            }
            else
            {
                btEntrar.Enabled = false;
                btBack.Enabled = false;
                btArriba.Enabled = false;
                btAbajo.Enabled = false;
                btBorrar.Enabled = false;
                btMas.Enabled = false;
                btMenos.Enabled = false;
            }            
        }

        private void tbNumeCuen_Click(object sender, EventArgs e)
        {
            tbNumeCuen.Text = string.Empty;
            bNumeCuen = true;
            bPor = false;
            bUnid = false;
        }

        private void tbUnid_Click(object sender, EventArgs e)
        {
            tbUnid.Text = string.Empty;
            tbPor.Text = string.Empty;
            tbDescripcion.Text = string.Empty;
            bUnid = true;
            bPor = false;
            bNumeCuen = false;
        }

        private void btX_Click(object sender, EventArgs e)
        {
            if (bUnid)
            {
                tbPor.Text = "X";
                bPor = true;
            }
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            if (bNumeCuen)
            {
                if (tbNumeCuen.Text.Length < 5)
                    tbNumeCuen.Text = tbNumeCuen.Text + "1";
            }
            else
            {
                if (bNuevaUnid)
                {
                    tbUnid.Text = "1";
                    bNuevaUnid = false;
                    bPor = false;
                    tbPor.Text = "";
                    tbDescripcion.Text = "";
                    bUnid = true;
                }
                else
                {
                    if (tbUnid.Text.Length < 5)
                        tbUnid.Text = tbUnid.Text + "1";
                }
            }
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            if (bNumeCuen)
            {
                if (tbNumeCuen.Text.Length < 5)
                    tbNumeCuen.Text = tbNumeCuen.Text + "2";
            }
            else
            {
                if (bNuevaUnid)
                {
                    tbUnid.Text = "2";
                    bNuevaUnid = false;
                    bPor = false;
                    tbPor.Text = "";
                    tbDescripcion.Text = "";
                    bUnid = true;
                }
                else
                {
                    if (tbUnid.Text.Length < 5)
                        tbUnid.Text = tbUnid.Text + "2";
                }
            }
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            if (bNumeCuen)
            {
                if (tbNumeCuen.Text.Length < 5)
                    tbNumeCuen.Text = tbNumeCuen.Text + "3";
            }
            else
            {
                if (bNuevaUnid)
                {
                    tbUnid.Text = "3";
                    bNuevaUnid = false;
                    bPor = false;
                    tbPor.Text = "";
                    tbDescripcion.Text = "";
                    bUnid = true;
                }
                else
                {
                    if (tbUnid.Text.Length < 5)
                        tbUnid.Text = tbUnid.Text + "3";
                }
            }
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            if (bNumeCuen)
            {
                if (tbNumeCuen.Text.Length < 5)
                    tbNumeCuen.Text = tbNumeCuen.Text + "4";
            }
            else
            {
                if (bNuevaUnid)
                {
                    tbUnid.Text = "4";
                    bNuevaUnid = false;
                    bPor = false;
                    tbPor.Text = "";
                    tbDescripcion.Text = "";
                    bUnid = true;
                }
                else
                {
                    if (tbUnid.Text.Length < 5)
                        tbUnid.Text = tbUnid.Text + "4";
                }
            }
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            if (bNumeCuen)
            {
                if (tbNumeCuen.Text.Length < 5)
                    tbNumeCuen.Text = tbNumeCuen.Text + "5";
            }
            else
            {
                if (bNuevaUnid)
                {
                    tbUnid.Text = "5";
                    bNuevaUnid = false;
                    bPor = false;
                    tbPor.Text = "";
                    tbDescripcion.Text = "";
                    bUnid = true;
                }
                else
                {
                    if (tbUnid.Text.Length < 5)
                        tbUnid.Text = tbUnid.Text + "5";
                }
            }
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            if (bNumeCuen)
            {
                if (tbNumeCuen.Text.Length < 5)
                    tbNumeCuen.Text = tbNumeCuen.Text + "6";
            }
            else
            {
                if (bNuevaUnid)
                {
                    tbUnid.Text = "6";
                    bNuevaUnid = false;
                    bPor = false;
                    tbPor.Text = "";
                    tbDescripcion.Text = "";
                    bUnid = true;
                }
                else
                {
                    if (tbUnid.Text.Length < 5)
                        tbUnid.Text = tbUnid.Text + "6";
                }
            }
        }

        private void bt7_Click(object sender, EventArgs e)
        {
            if (bNumeCuen)
            {
                if (tbNumeCuen.Text.Length < 5)
                    tbNumeCuen.Text = tbNumeCuen.Text + "7";
            }
            else
            {
                if (bNuevaUnid)
                {
                    tbUnid.Text = "7";
                    bNuevaUnid = false;
                    bPor = false;
                    tbPor.Text = "";
                    tbDescripcion.Text = "";
                    bUnid = true;
                }
                else
                {
                    if (tbUnid.Text.Length < 5)
                        tbUnid.Text = tbUnid.Text + "7";
                }
            }
        }

        private void bt8_Click(object sender, EventArgs e)
        {
            if (bNumeCuen)
            {
                if (tbNumeCuen.Text.Length < 5)
                    tbNumeCuen.Text = tbNumeCuen.Text + "8";
            }
            else
            {
                if (bNuevaUnid)
                {
                    tbUnid.Text = "8";
                    bNuevaUnid = false;
                    bPor = false;
                    tbPor.Text = "";
                    tbDescripcion.Text = "";
                    bUnid = true;
                }
                else
                {
                    if (tbUnid.Text.Length < 5)
                        tbUnid.Text = tbUnid.Text + "8";
                }
            }
        }

        private void bt9_Click(object sender, EventArgs e)
        {
            if (bNumeCuen)
            {
                if (tbNumeCuen.Text.Length < 5)
                    tbNumeCuen.Text = tbNumeCuen.Text + "9";
            }
            else
            {
                if (bNuevaUnid)
                {
                    tbUnid.Text = "9";
                    bNuevaUnid = false;
                    bPor = false;
                    tbPor.Text = "";
                    tbDescripcion.Text = "";
                    bUnid = true;
                }
                else
                {
                    if (tbUnid.Text.Length < 5)
                        tbUnid.Text = tbUnid.Text + "9";
                }
            }
        }

        private void bt0_Click(object sender, EventArgs e)
        {
            if (bNumeCuen)
            {
                if (tbNumeCuen.Text.Length < 5)
                    tbNumeCuen.Text = tbNumeCuen.Text + "0";
            }
            else
            {
                if (bNuevaUnid)
                {
                    tbUnid.Text = "0";
                    bNuevaUnid = false;
                    bPor = false;
                    tbPor.Text = "";
                    tbDescripcion.Text = "";
                    bUnid = true;
                }
                else
                {
                    if (tbUnid.Text.Length < 5)
                        tbUnid.Text = tbUnid.Text + "0";
                }
            }
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            if (tbNumeCuen.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Debe de indicar un numero de cuenta");
            }
            else if (tvOrden.Nodes[0].GetNodeCount(true) == 0)
            {
                MessageBox.Show("Debe de introducir un pedido");
            }
            else
            {
                Envio DatosEnvio = new Envio();
                DatosEnvio.NombreEvento = "EnvioPedido";
                DatosEnvio.NumeCuen = tbNumeCuen.Text.Trim();
                DatosEnvio.dataLinea = dataLinea;
                string output = JsonConvert.SerializeObject(DatosEnvio);

                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(output + "$");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();

                //Reset
                tbNumeCuen.Text = string.Empty;
                tvOrden.Nodes.Clear();                
                ContNodos = 0;
                NodoPadre = 0;
                TreeMode = false;
                bNumeCuen = true;
                bPor = false;
                bUnid = false;
                bNuevaUnid = true;

                TreeNode treeNode = new TreeNode();
                InfoNodo infoNodo = new InfoNodo();
                infoNodo.IdNodo = 0;
                infoNodo.IdPadre = 0;
                treeNode.Name = "0";
                treeNode.Text = "ORDEN:";
                infoNodo.Precio = 0;
                infoNodo.Impuesto = 0;
                infoNodo.Unid = 0;
                infoNodo.ImprimirEnComanda = 0;
                infoNodo.ImprimirEnFactura = 0;
                treeNode.Tag = infoNodo;
                tvOrden.Nodes.Add(treeNode);
                tvOrden.SelectedNode = tvOrden.Nodes[0];

                Level = 0;
                btEntrar.Enabled = false;
                btBack.Enabled = false;
                btArriba.Enabled = false;
                btAbajo.Enabled = false;
                btBorrar.Enabled = false;
                btMas.Enabled = false;
                btMenos.Enabled = false;

                EventoAskForElements eventoAskForElements = new EventoAskForElements();
                eventoAskForElements.NombreEvento = "AskForElements";
                eventoAskForElements.PadreId = 0;
                output = JsonConvert.SerializeObject(eventoAskForElements);

                outStream = System.Text.Encoding.ASCII.GetBytes(output + "$");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
                
                MessageBox.Show("Pedido enviado");
            }
        }        
    }
}
