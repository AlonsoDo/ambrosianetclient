namespace Ambrosia
{
    partial class Caja
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.GridDatosFacturas = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbFactCerradas = new System.Windows.Forms.CheckBox();
            this.cbFactPendientes = new System.Windows.Forms.CheckBox();
            this.cbFactAbiertas = new System.Windows.Forms.CheckBox();
            this.RecargarFacturas = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btImprimirFactura = new System.Windows.Forms.Button();
            this.cbFormaPago = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNumeCuen = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btCobrarFactura = new System.Windows.Forms.Button();
            this.btAbrirFactura = new System.Windows.Forms.Button();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCambio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbEntrega = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt3 = new System.Windows.Forms.Button();
            this.bt2 = new System.Windows.Forms.Button();
            this.bt6 = new System.Windows.Forms.Button();
            this.bt1 = new System.Windows.Forms.Button();
            this.bt5 = new System.Windows.Forms.Button();
            this.bt0 = new System.Windows.Forms.Button();
            this.bt4 = new System.Windows.Forms.Button();
            this.bt9 = new System.Windows.Forms.Button();
            this.bt8 = new System.Windows.Forms.Button();
            this.bt7 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDatosFacturas)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 427);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.Size = new System.Drawing.Size(353, 392);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel2.Controls.Add(this.GridDatosFacturas);
            this.panel2.Location = new System.Drawing.Point(404, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(552, 427);
            this.panel2.TabIndex = 1;
            // 
            // GridDatosFacturas
            // 
            this.GridDatosFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDatosFacturas.Location = new System.Drawing.Point(12, 17);
            this.GridDatosFacturas.Name = "GridDatosFacturas";
            this.GridDatosFacturas.RowHeadersVisible = false;
            this.GridDatosFacturas.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.GridDatosFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridDatosFacturas.Size = new System.Drawing.Size(525, 392);
            this.GridDatosFacturas.TabIndex = 1;
            this.GridDatosFacturas.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.GridDatosFacturas_RowsAdded);
            this.GridDatosFacturas.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GridDatosFacturas_DataError);
            this.GridDatosFacturas.Click += new System.EventHandler(this.GridDatosFacturas_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel3.Controls.Add(this.cbFactCerradas);
            this.panel3.Controls.Add(this.cbFactPendientes);
            this.panel3.Controls.Add(this.cbFactAbiertas);
            this.panel3.Controls.Add(this.RecargarFacturas);
            this.panel3.Location = new System.Drawing.Point(774, 447);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(182, 287);
            this.panel3.TabIndex = 2;
            // 
            // cbFactCerradas
            // 
            this.cbFactCerradas.AutoSize = true;
            this.cbFactCerradas.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFactCerradas.Location = new System.Drawing.Point(30, 130);
            this.cbFactCerradas.Name = "cbFactCerradas";
            this.cbFactCerradas.Size = new System.Drawing.Size(115, 26);
            this.cbFactCerradas.TabIndex = 32;
            this.cbFactCerradas.Text = "Cerradas";
            this.cbFactCerradas.UseVisualStyleBackColor = true;
            // 
            // cbFactPendientes
            // 
            this.cbFactPendientes.AutoSize = true;
            this.cbFactPendientes.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFactPendientes.Location = new System.Drawing.Point(30, 79);
            this.cbFactPendientes.Name = "cbFactPendientes";
            this.cbFactPendientes.Size = new System.Drawing.Size(133, 26);
            this.cbFactPendientes.TabIndex = 31;
            this.cbFactPendientes.Text = "Pendientes";
            this.cbFactPendientes.UseVisualStyleBackColor = true;
            // 
            // cbFactAbiertas
            // 
            this.cbFactAbiertas.AutoSize = true;
            this.cbFactAbiertas.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFactAbiertas.Location = new System.Drawing.Point(30, 28);
            this.cbFactAbiertas.Name = "cbFactAbiertas";
            this.cbFactAbiertas.Size = new System.Drawing.Size(106, 26);
            this.cbFactAbiertas.TabIndex = 30;
            this.cbFactAbiertas.Text = "Abiertas";
            this.cbFactAbiertas.UseVisualStyleBackColor = true;
            // 
            // RecargarFacturas
            // 
            this.RecargarFacturas.BackColor = System.Drawing.Color.Gold;
            this.RecargarFacturas.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecargarFacturas.ForeColor = System.Drawing.Color.Red;
            this.RecargarFacturas.Image = global::Ambrosia.Properties.Resources.actualizar;
            this.RecargarFacturas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RecargarFacturas.Location = new System.Drawing.Point(17, 184);
            this.RecargarFacturas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RecargarFacturas.Name = "RecargarFacturas";
            this.RecargarFacturas.Size = new System.Drawing.Size(150, 78);
            this.RecargarFacturas.TabIndex = 29;
            this.RecargarFacturas.Text = "Recarga  ";
            this.RecargarFacturas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RecargarFacturas.UseVisualStyleBackColor = false;
            this.RecargarFacturas.Click += new System.EventHandler(this.RecargarFacturas_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.btImprimirFactura);
            this.panel4.Controls.Add(this.cbFormaPago);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.tbNumeCuen);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.btCobrarFactura);
            this.panel4.Controls.Add(this.btAbrirFactura);
            this.panel4.Controls.Add(this.tbTotal);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.tbCambio);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.tbEntrega);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.bt3);
            this.panel4.Controls.Add(this.bt2);
            this.panel4.Controls.Add(this.bt6);
            this.panel4.Controls.Add(this.bt1);
            this.panel4.Controls.Add(this.bt5);
            this.panel4.Controls.Add(this.bt0);
            this.panel4.Controls.Add(this.bt4);
            this.panel4.Controls.Add(this.bt9);
            this.panel4.Controls.Add(this.bt8);
            this.panel4.Controls.Add(this.bt7);
            this.panel4.Location = new System.Drawing.Point(12, 446);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(756, 287);
            this.panel4.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(574, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 22);
            this.label6.TabIndex = 44;
            this.label6.Text = "Abierta";
            // 
            // btImprimirFactura
            // 
            this.btImprimirFactura.BackColor = System.Drawing.Color.Gold;
            this.btImprimirFactura.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImprimirFactura.ForeColor = System.Drawing.Color.Red;
            this.btImprimirFactura.Image = global::Ambrosia.Properties.Resources.imprimir;
            this.btImprimirFactura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btImprimirFactura.Location = new System.Drawing.Point(578, 185);
            this.btImprimirFactura.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btImprimirFactura.Name = "btImprimirFactura";
            this.btImprimirFactura.Size = new System.Drawing.Size(154, 78);
            this.btImprimirFactura.TabIndex = 43;
            this.btImprimirFactura.Text = "Imprimir  ";
            this.btImprimirFactura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btImprimirFactura.UseVisualStyleBackColor = false;
            this.btImprimirFactura.Click += new System.EventHandler(this.btImprimirFactura_Click);
            // 
            // cbFormaPago
            // 
            this.cbFormaPago.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFormaPago.ForeColor = System.Drawing.Color.Red;
            this.cbFormaPago.FormattingEnabled = true;
            this.cbFormaPago.Items.AddRange(new object[] {
            "Contado",
            "Tarjeta",
            "Otros"});
            this.cbFormaPago.Location = new System.Drawing.Point(578, 121);
            this.cbFormaPago.Name = "cbFormaPago";
            this.cbFormaPago.Size = new System.Drawing.Size(154, 30);
            this.cbFormaPago.TabIndex = 42;
            this.cbFormaPago.Text = "Contado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(574, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 22);
            this.label5.TabIndex = 41;
            this.label5.Text = "Forma Pago:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(574, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 22);
            this.label4.TabIndex = 35;
            this.label4.Text = "Estado Factura:";
            // 
            // tbNumeCuen
            // 
            this.tbNumeCuen.BackColor = System.Drawing.Color.Black;
            this.tbNumeCuen.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNumeCuen.ForeColor = System.Drawing.Color.White;
            this.tbNumeCuen.Location = new System.Drawing.Point(234, 25);
            this.tbNumeCuen.MaxLength = 5;
            this.tbNumeCuen.Multiline = true;
            this.tbNumeCuen.Name = "tbNumeCuen";
            this.tbNumeCuen.Size = new System.Drawing.Size(150, 66);
            this.tbNumeCuen.TabIndex = 34;
            this.tbNumeCuen.Click += new System.EventHandler(this.tbNumeCuen_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.button2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(75, 214);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(54, 53);
            this.button2.TabIndex = 31;
            this.button2.Text = ",";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btCobrarFactura
            // 
            this.btCobrarFactura.BackColor = System.Drawing.Color.Gold;
            this.btCobrarFactura.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCobrarFactura.ForeColor = System.Drawing.Color.Red;
            this.btCobrarFactura.Image = global::Ambrosia.Properties.Resources.cobrar;
            this.btCobrarFactura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCobrarFactura.Location = new System.Drawing.Point(234, 190);
            this.btCobrarFactura.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btCobrarFactura.Name = "btCobrarFactura";
            this.btCobrarFactura.Size = new System.Drawing.Size(150, 78);
            this.btCobrarFactura.TabIndex = 30;
            this.btCobrarFactura.Text = "Cobrar    ";
            this.btCobrarFactura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCobrarFactura.UseVisualStyleBackColor = false;
            this.btCobrarFactura.Click += new System.EventHandler(this.btCobrarFactura_Click);
            // 
            // btAbrirFactura
            // 
            this.btAbrirFactura.BackColor = System.Drawing.Color.Gold;
            this.btAbrirFactura.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAbrirFactura.ForeColor = System.Drawing.Color.Red;
            this.btAbrirFactura.Image = global::Ambrosia.Properties.Resources.open;
            this.btAbrirFactura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAbrirFactura.Location = new System.Drawing.Point(234, 104);
            this.btAbrirFactura.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btAbrirFactura.Name = "btAbrirFactura";
            this.btAbrirFactura.Size = new System.Drawing.Size(150, 78);
            this.btAbrirFactura.TabIndex = 29;
            this.btAbrirFactura.Text = "Cargar    ";
            this.btAbrirFactura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAbrirFactura.UseVisualStyleBackColor = false;
            this.btAbrirFactura.Click += new System.EventHandler(this.btAbrirFactura_Click);
            // 
            // tbTotal
            // 
            this.tbTotal.BackColor = System.Drawing.Color.Black;
            this.tbTotal.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotal.ForeColor = System.Drawing.Color.White;
            this.tbTotal.Location = new System.Drawing.Point(419, 225);
            this.tbTotal.MaxLength = 10;
            this.tbTotal.Multiline = true;
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ReadOnly = true;
            this.tbTotal.Size = new System.Drawing.Size(124, 38);
            this.tbTotal.TabIndex = 27;
            this.tbTotal.Text = "0";
            this.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(415, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 22);
            this.label3.TabIndex = 26;
            this.label3.Text = "Total";
            // 
            // tbCambio
            // 
            this.tbCambio.BackColor = System.Drawing.Color.Black;
            this.tbCambio.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCambio.ForeColor = System.Drawing.Color.White;
            this.tbCambio.Location = new System.Drawing.Point(419, 139);
            this.tbCambio.MaxLength = 10;
            this.tbCambio.Multiline = true;
            this.tbCambio.Name = "tbCambio";
            this.tbCambio.ReadOnly = true;
            this.tbCambio.Size = new System.Drawing.Size(124, 38);
            this.tbCambio.TabIndex = 25;
            this.tbCambio.Text = "0";
            this.tbCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(415, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 22);
            this.label2.TabIndex = 24;
            this.label2.Text = "Cambio";
            // 
            // tbEntrega
            // 
            this.tbEntrega.BackColor = System.Drawing.Color.Black;
            this.tbEntrega.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEntrega.ForeColor = System.Drawing.Color.White;
            this.tbEntrega.Location = new System.Drawing.Point(419, 53);
            this.tbEntrega.MaxLength = 10;
            this.tbEntrega.Multiline = true;
            this.tbEntrega.Name = "tbEntrega";
            this.tbEntrega.Size = new System.Drawing.Size(124, 38);
            this.tbEntrega.TabIndex = 23;
            this.tbEntrega.Text = "0";
            this.tbEntrega.Click += new System.EventHandler(this.tbEntrega_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(415, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 22);
            this.label1.TabIndex = 22;
            this.label1.Text = "Entrega";
            // 
            // bt3
            // 
            this.bt3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.bt3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt3.Location = new System.Drawing.Point(135, 148);
            this.bt3.Name = "bt3";
            this.bt3.Size = new System.Drawing.Size(54, 53);
            this.bt3.TabIndex = 19;
            this.bt3.Text = "3";
            this.bt3.UseVisualStyleBackColor = false;
            this.bt3.Click += new System.EventHandler(this.bt3_Click);
            // 
            // bt2
            // 
            this.bt2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.bt2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt2.Location = new System.Drawing.Point(75, 148);
            this.bt2.Name = "bt2";
            this.bt2.Size = new System.Drawing.Size(54, 53);
            this.bt2.TabIndex = 18;
            this.bt2.Text = "2";
            this.bt2.UseVisualStyleBackColor = false;
            this.bt2.Click += new System.EventHandler(this.bt2_Click);
            // 
            // bt6
            // 
            this.bt6.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.bt6.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt6.Location = new System.Drawing.Point(135, 80);
            this.bt6.Name = "bt6";
            this.bt6.Size = new System.Drawing.Size(54, 54);
            this.bt6.TabIndex = 17;
            this.bt6.Text = "6";
            this.bt6.UseVisualStyleBackColor = false;
            this.bt6.Click += new System.EventHandler(this.bt6_Click);
            // 
            // bt1
            // 
            this.bt1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.bt1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt1.Location = new System.Drawing.Point(15, 148);
            this.bt1.Name = "bt1";
            this.bt1.Size = new System.Drawing.Size(54, 53);
            this.bt1.TabIndex = 16;
            this.bt1.Text = "1";
            this.bt1.UseVisualStyleBackColor = false;
            this.bt1.Click += new System.EventHandler(this.bt1_Click);
            // 
            // bt5
            // 
            this.bt5.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.bt5.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt5.Location = new System.Drawing.Point(75, 80);
            this.bt5.Name = "bt5";
            this.bt5.Size = new System.Drawing.Size(54, 54);
            this.bt5.TabIndex = 15;
            this.bt5.Text = "5";
            this.bt5.UseVisualStyleBackColor = false;
            this.bt5.Click += new System.EventHandler(this.bt5_Click);
            // 
            // bt0
            // 
            this.bt0.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.bt0.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt0.Location = new System.Drawing.Point(15, 214);
            this.bt0.Name = "bt0";
            this.bt0.Size = new System.Drawing.Size(54, 53);
            this.bt0.TabIndex = 14;
            this.bt0.Text = "0";
            this.bt0.UseVisualStyleBackColor = false;
            this.bt0.Click += new System.EventHandler(this.bt0_Click);
            // 
            // bt4
            // 
            this.bt4.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.bt4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt4.Location = new System.Drawing.Point(15, 80);
            this.bt4.Name = "bt4";
            this.bt4.Size = new System.Drawing.Size(54, 54);
            this.bt4.TabIndex = 13;
            this.bt4.Text = "4";
            this.bt4.UseVisualStyleBackColor = false;
            this.bt4.Click += new System.EventHandler(this.bt4_Click);
            // 
            // bt9
            // 
            this.bt9.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.bt9.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt9.Location = new System.Drawing.Point(135, 15);
            this.bt9.Name = "bt9";
            this.bt9.Size = new System.Drawing.Size(54, 52);
            this.bt9.TabIndex = 12;
            this.bt9.Text = "9";
            this.bt9.UseVisualStyleBackColor = false;
            this.bt9.Click += new System.EventHandler(this.bt9_Click);
            // 
            // bt8
            // 
            this.bt8.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.bt8.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt8.Location = new System.Drawing.Point(75, 15);
            this.bt8.Name = "bt8";
            this.bt8.Size = new System.Drawing.Size(54, 52);
            this.bt8.TabIndex = 11;
            this.bt8.Text = "8";
            this.bt8.UseVisualStyleBackColor = false;
            this.bt8.Click += new System.EventHandler(this.bt8_Click);
            // 
            // bt7
            // 
            this.bt7.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.bt7.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt7.Location = new System.Drawing.Point(15, 15);
            this.bt7.Name = "bt7";
            this.bt7.Size = new System.Drawing.Size(54, 52);
            this.bt7.TabIndex = 10;
            this.bt7.Text = "7";
            this.bt7.UseVisualStyleBackColor = false;
            this.bt7.Click += new System.EventHandler(this.bt7_Click);
            // 
            // Caja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 746);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(120, 30);
            this.Name = "Caja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Caja";
            this.Load += new System.EventHandler(this.Caja_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Caja_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridDatosFacturas)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button bt3;
        private System.Windows.Forms.Button bt2;
        private System.Windows.Forms.Button bt6;
        private System.Windows.Forms.Button bt1;
        private System.Windows.Forms.Button bt5;
        private System.Windows.Forms.Button bt0;
        private System.Windows.Forms.Button bt4;
        private System.Windows.Forms.Button bt9;
        private System.Windows.Forms.Button bt8;
        private System.Windows.Forms.Button bt7;
        private System.Windows.Forms.TextBox tbEntrega;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCambio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btCobrarFactura;
        private System.Windows.Forms.Button btAbrirFactura;
        private System.Windows.Forms.Button RecargarFacturas;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox cbFactAbiertas;
        private System.Windows.Forms.CheckBox cbFactCerradas;
        private System.Windows.Forms.CheckBox cbFactPendientes;
        private System.Windows.Forms.DataGridView GridDatosFacturas;
        private System.Windows.Forms.TextBox tbNumeCuen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btImprimirFactura;
        private System.Windows.Forms.ComboBox cbFormaPago;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;

    }
}