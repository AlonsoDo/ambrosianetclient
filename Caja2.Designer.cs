namespace Ambrosia
{
    partial class Caja2
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
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btConsultar = new System.Windows.Forms.Button();
            this.tbTotalCerradas = new System.Windows.Forms.TextBox();
            this.tbUnidCerradas = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbTotalPendientes = new System.Windows.Forms.TextBox();
            this.tbUnidPendientes = new System.Windows.Forms.TextBox();
            this.tbTotalAbiertas = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbUnidAbiertas = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btCerrarCaja = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel1.Controls.Add(this.btCerrarCaja);
            this.panel1.Controls.Add(this.monthCalendar1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 385);
            this.panel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 29);
            this.label4.TabIndex = 36;
            this.label4.Text = "Cierre de caja";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel2.Controls.Add(this.btConsultar);
            this.panel2.Controls.Add(this.tbTotalCerradas);
            this.panel2.Controls.Add(this.tbUnidCerradas);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.tbTotalPendientes);
            this.panel2.Controls.Add(this.tbUnidPendientes);
            this.panel2.Controls.Add(this.tbTotalAbiertas);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.tbUnidAbiertas);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(252, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(471, 385);
            this.panel2.TabIndex = 2;
            // 
            // btConsultar
            // 
            this.btConsultar.BackColor = System.Drawing.Color.Gold;
            this.btConsultar.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConsultar.ForeColor = System.Drawing.Color.Red;
            this.btConsultar.Image = global::Ambrosia.Properties.Resources.mas;
            this.btConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btConsultar.Location = new System.Drawing.Point(120, 278);
            this.btConsultar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btConsultar.Name = "btConsultar";
            this.btConsultar.Size = new System.Drawing.Size(221, 78);
            this.btConsultar.TabIndex = 49;
            this.btConsultar.Text = "  Consultar";
            this.btConsultar.UseVisualStyleBackColor = false;
            this.btConsultar.Click += new System.EventHandler(this.btConsultar_Click);
            // 
            // tbTotalCerradas
            // 
            this.tbTotalCerradas.BackColor = System.Drawing.Color.Black;
            this.tbTotalCerradas.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotalCerradas.ForeColor = System.Drawing.Color.White;
            this.tbTotalCerradas.Location = new System.Drawing.Point(282, 212);
            this.tbTotalCerradas.MaxLength = 10;
            this.tbTotalCerradas.Multiline = true;
            this.tbTotalCerradas.Name = "tbTotalCerradas";
            this.tbTotalCerradas.ReadOnly = true;
            this.tbTotalCerradas.Size = new System.Drawing.Size(153, 38);
            this.tbTotalCerradas.TabIndex = 48;
            this.tbTotalCerradas.Text = "0";
            this.tbTotalCerradas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbUnidCerradas
            // 
            this.tbUnidCerradas.BackColor = System.Drawing.Color.Black;
            this.tbUnidCerradas.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUnidCerradas.ForeColor = System.Drawing.Color.White;
            this.tbUnidCerradas.Location = new System.Drawing.Point(153, 212);
            this.tbUnidCerradas.MaxLength = 10;
            this.tbUnidCerradas.Multiline = true;
            this.tbUnidCerradas.Name = "tbUnidCerradas";
            this.tbUnidCerradas.ReadOnly = true;
            this.tbUnidCerradas.Size = new System.Drawing.Size(93, 38);
            this.tbUnidCerradas.TabIndex = 47;
            this.tbUnidCerradas.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(21, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 22);
            this.label8.TabIndex = 46;
            this.label8.Text = "Cerradas:";
            // 
            // tbTotalPendientes
            // 
            this.tbTotalPendientes.BackColor = System.Drawing.Color.Black;
            this.tbTotalPendientes.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotalPendientes.ForeColor = System.Drawing.Color.White;
            this.tbTotalPendientes.Location = new System.Drawing.Point(282, 158);
            this.tbTotalPendientes.MaxLength = 10;
            this.tbTotalPendientes.Multiline = true;
            this.tbTotalPendientes.Name = "tbTotalPendientes";
            this.tbTotalPendientes.ReadOnly = true;
            this.tbTotalPendientes.Size = new System.Drawing.Size(153, 38);
            this.tbTotalPendientes.TabIndex = 45;
            this.tbTotalPendientes.Text = "0";
            this.tbTotalPendientes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbUnidPendientes
            // 
            this.tbUnidPendientes.BackColor = System.Drawing.Color.Black;
            this.tbUnidPendientes.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUnidPendientes.ForeColor = System.Drawing.Color.White;
            this.tbUnidPendientes.Location = new System.Drawing.Point(153, 158);
            this.tbUnidPendientes.MaxLength = 10;
            this.tbUnidPendientes.Multiline = true;
            this.tbUnidPendientes.Name = "tbUnidPendientes";
            this.tbUnidPendientes.ReadOnly = true;
            this.tbUnidPendientes.Size = new System.Drawing.Size(93, 38);
            this.tbUnidPendientes.TabIndex = 44;
            this.tbUnidPendientes.Text = "0";
            // 
            // tbTotalAbiertas
            // 
            this.tbTotalAbiertas.BackColor = System.Drawing.Color.Black;
            this.tbTotalAbiertas.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotalAbiertas.ForeColor = System.Drawing.Color.White;
            this.tbTotalAbiertas.Location = new System.Drawing.Point(282, 104);
            this.tbTotalAbiertas.MaxLength = 10;
            this.tbTotalAbiertas.Multiline = true;
            this.tbTotalAbiertas.Name = "tbTotalAbiertas";
            this.tbTotalAbiertas.ReadOnly = true;
            this.tbTotalAbiertas.Size = new System.Drawing.Size(153, 38);
            this.tbTotalAbiertas.TabIndex = 43;
            this.tbTotalAbiertas.Text = "0";
            this.tbTotalAbiertas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(21, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 22);
            this.label7.TabIndex = 42;
            this.label7.Text = "Pendientes:";
            // 
            // tbUnidAbiertas
            // 
            this.tbUnidAbiertas.BackColor = System.Drawing.Color.Black;
            this.tbUnidAbiertas.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUnidAbiertas.ForeColor = System.Drawing.Color.White;
            this.tbUnidAbiertas.Location = new System.Drawing.Point(153, 104);
            this.tbUnidAbiertas.MaxLength = 10;
            this.tbUnidAbiertas.Multiline = true;
            this.tbUnidAbiertas.Name = "tbUnidAbiertas";
            this.tbUnidAbiertas.ReadOnly = true;
            this.tbUnidAbiertas.Size = new System.Drawing.Size(93, 38);
            this.tbUnidAbiertas.TabIndex = 41;
            this.tbUnidAbiertas.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(21, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 22);
            this.label6.TabIndex = 40;
            this.label6.Text = "Abiertas:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(278, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 22);
            this.label5.TabIndex = 39;
            this.label5.Text = "Totales";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(149, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 22);
            this.label3.TabIndex = 38;
            this.label3.Text = "Unidades";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(21, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 22);
            this.label2.TabIndex = 37;
            this.label2.Text = "Estado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 29);
            this.label1.TabIndex = 36;
            this.label1.Text = "Consulta de cuentas";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(23, 87);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 37;
            // 
            // btCerrarCaja
            // 
            this.btCerrarCaja.BackColor = System.Drawing.Color.Gold;
            this.btCerrarCaja.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCerrarCaja.ForeColor = System.Drawing.Color.Red;
            this.btCerrarCaja.Image = global::Ambrosia.Properties.Resources.mas;
            this.btCerrarCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCerrarCaja.Location = new System.Drawing.Point(23, 278);
            this.btCerrarCaja.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btCerrarCaja.Name = "btCerrarCaja";
            this.btCerrarCaja.Size = new System.Drawing.Size(164, 78);
            this.btCerrarCaja.TabIndex = 50;
            this.btCerrarCaja.Text = "  Cerrar";
            this.btCerrarCaja.UseVisualStyleBackColor = false;
            this.btCerrarCaja.Click += new System.EventHandler(this.btCerrarCaja_Click);
            // 
            // Caja2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 409);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Caja2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Caja";
            this.Load += new System.EventHandler(this.Caja2_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Caja2_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUnidAbiertas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbUnidPendientes;
        private System.Windows.Forms.TextBox tbTotalAbiertas;
        private System.Windows.Forms.TextBox tbTotalCerradas;
        private System.Windows.Forms.TextBox tbUnidCerradas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbTotalPendientes;
        private System.Windows.Forms.Button btConsultar;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btCerrarCaja;
    }
}