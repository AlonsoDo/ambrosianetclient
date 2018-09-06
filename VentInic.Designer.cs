namespace Ambrosia
{
    partial class VentInic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentInic));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pbCaja2 = new System.Windows.Forms.PictureBox();
            this.pbTerminal = new System.Windows.Forms.PictureBox();
            this.pbClientes = new System.Windows.Forms.PictureBox();
            this.pbCaja = new System.Windows.Forms.PictureBox();
            this.pbPedidos = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaja2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTerminal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pedido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cobros";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 762);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Clientes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 443);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 26);
            this.label4.TabIndex = 10;
            this.label4.Text = "Terminal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 605);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 26);
            this.label5.TabIndex = 13;
            this.label5.Text = "Caja";
            // 
            // pbCaja2
            // 
            this.pbCaja2.Image = global::Ambrosia.Properties.Resources.caja;
            this.pbCaja2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbCaja2.InitialImage")));
            this.pbCaja2.Location = new System.Drawing.Point(12, 506);
            this.pbCaja2.Name = "pbCaja2";
            this.pbCaja2.Size = new System.Drawing.Size(96, 96);
            this.pbCaja2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCaja2.TabIndex = 12;
            this.pbCaja2.TabStop = false;
            this.pbCaja2.Click += new System.EventHandler(this.pbCaja2_Click);
            // 
            // pbTerminal
            // 
            this.pbTerminal.Image = global::Ambrosia.Properties.Resources.terminal;
            this.pbTerminal.Location = new System.Drawing.Point(12, 344);
            this.pbTerminal.Name = "pbTerminal";
            this.pbTerminal.Size = new System.Drawing.Size(96, 96);
            this.pbTerminal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTerminal.TabIndex = 9;
            this.pbTerminal.TabStop = false;
            this.pbTerminal.Click += new System.EventHandler(this.pbTerminal_Click);
            // 
            // pbClientes
            // 
            this.pbClientes.Image = global::Ambrosia.Properties.Resources.group;
            this.pbClientes.Location = new System.Drawing.Point(10, 663);
            this.pbClientes.Name = "pbClientes";
            this.pbClientes.Size = new System.Drawing.Size(96, 96);
            this.pbClientes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbClientes.TabIndex = 4;
            this.pbClientes.TabStop = false;
            this.pbClientes.Click += new System.EventHandler(this.pbClientes_Click);
            // 
            // pbCaja
            // 
            this.pbCaja.Image = global::Ambrosia.Properties.Resources.cash;
            this.pbCaja.InitialImage = global::Ambrosia.Properties.Resources.Strong_box_money_icon_128;
            this.pbCaja.Location = new System.Drawing.Point(12, 183);
            this.pbCaja.Name = "pbCaja";
            this.pbCaja.Size = new System.Drawing.Size(96, 96);
            this.pbCaja.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCaja.TabIndex = 3;
            this.pbCaja.TabStop = false;
            this.pbCaja.Click += new System.EventHandler(this.pbCaja_Click);
            // 
            // pbPedidos
            // 
            this.pbPedidos.Image = global::Ambrosia.Properties.Resources.edit;
            this.pbPedidos.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbPedidos.InitialImage")));
            this.pbPedidos.Location = new System.Drawing.Point(12, 12);
            this.pbPedidos.Name = "pbPedidos";
            this.pbPedidos.Size = new System.Drawing.Size(96, 96);
            this.pbPedidos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPedidos.TabIndex = 1;
            this.pbPedidos.TabStop = false;
            this.pbPedidos.Click += new System.EventHandler(this.pbPedidos_Click);
            // 
            // VentInic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Salmon;
            this.ClientSize = new System.Drawing.Size(292, 797);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pbCaja2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pbTerminal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbClientes);
            this.Controls.Add(this.pbCaja);
            this.Controls.Add(this.pbPedidos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Name = "VentInic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.VentInic_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaja2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTerminal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPedidos;
        private System.Windows.Forms.PictureBox pbCaja;
        private System.Windows.Forms.PictureBox pbClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbTerminal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbCaja2;
        private System.Windows.Forms.Label label5;
    }
}