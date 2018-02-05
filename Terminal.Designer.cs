namespace Ambrosia
{
    partial class Terminal
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
            this.panelbotones = new System.Windows.Forms.Panel();
            this.labelimpresora = new System.Windows.Forms.Label();
            this.labelterminal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cbTerminales = new System.Windows.Forms.ComboBox();
            this.cbImpresoras = new System.Windows.Forms.ComboBox();
            this.panelbotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelbotones
            // 
            this.panelbotones.BackColor = System.Drawing.Color.LavenderBlush;
            this.panelbotones.Controls.Add(this.cbImpresoras);
            this.panelbotones.Controls.Add(this.cbTerminales);
            this.panelbotones.Controls.Add(this.labelimpresora);
            this.panelbotones.Controls.Add(this.labelterminal);
            this.panelbotones.Location = new System.Drawing.Point(764, 12);
            this.panelbotones.Name = "panelbotones";
            this.panelbotones.Size = new System.Drawing.Size(197, 742);
            this.panelbotones.TabIndex = 0;
            // 
            // labelimpresora
            // 
            this.labelimpresora.AutoSize = true;
            this.labelimpresora.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelimpresora.ForeColor = System.Drawing.Color.Black;
            this.labelimpresora.Location = new System.Drawing.Point(3, 76);
            this.labelimpresora.Name = "labelimpresora";
            this.labelimpresora.Size = new System.Drawing.Size(105, 22);
            this.labelimpresora.TabIndex = 1;
            this.labelimpresora.Text = "Impresora";
            // 
            // labelterminal
            // 
            this.labelterminal.AutoSize = true;
            this.labelterminal.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelterminal.ForeColor = System.Drawing.Color.Black;
            this.labelterminal.Location = new System.Drawing.Point(3, 11);
            this.labelterminal.Name = "labelterminal";
            this.labelterminal.Size = new System.Drawing.Size(92, 22);
            this.labelterminal.TabIndex = 0;
            this.labelterminal.Text = "Terminal";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 365);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel2.Location = new System.Drawing.Point(12, 389);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(241, 365);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel3.Location = new System.Drawing.Point(262, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(241, 365);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel4.Location = new System.Drawing.Point(262, 389);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(241, 365);
            this.panel4.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel5.Location = new System.Drawing.Point(512, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(241, 365);
            this.panel5.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel6.Location = new System.Drawing.Point(512, 389);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(241, 365);
            this.panel6.TabIndex = 6;
            // 
            // cbTerminales
            // 
            this.cbTerminales.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTerminales.ForeColor = System.Drawing.Color.Red;
            this.cbTerminales.FormattingEnabled = true;
            this.cbTerminales.Items.AddRange(new object[] {
            "Todas",
            "Ninguna"});
            this.cbTerminales.Location = new System.Drawing.Point(7, 36);
            this.cbTerminales.Name = "cbTerminales";
            this.cbTerminales.Size = new System.Drawing.Size(185, 30);
            this.cbTerminales.TabIndex = 2;
            this.cbTerminales.Text = "Todas";
            // 
            // cbImpresoras
            // 
            this.cbImpresoras.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbImpresoras.ForeColor = System.Drawing.Color.Red;
            this.cbImpresoras.FormattingEnabled = true;
            this.cbImpresoras.Items.AddRange(new object[] {
            "Todas",
            "Ninguna"});
            this.cbImpresoras.Location = new System.Drawing.Point(7, 101);
            this.cbImpresoras.Name = "cbImpresoras";
            this.cbImpresoras.Size = new System.Drawing.Size(185, 30);
            this.cbImpresoras.TabIndex = 3;
            this.cbImpresoras.Text = "Todas";
            // 
            // Terminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 766);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelbotones);
            this.Location = new System.Drawing.Point(122, 30);
            this.Name = "Terminal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Terminal";
            this.Load += new System.EventHandler(this.Terminal_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Terminal_FormClosing);
            this.panelbotones.ResumeLayout(false);
            this.panelbotones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelbotones;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label labelterminal;
        private System.Windows.Forms.Label labelimpresora;
        private System.Windows.Forms.ComboBox cbImpresoras;
        private System.Windows.Forms.ComboBox cbTerminales;
    }
}