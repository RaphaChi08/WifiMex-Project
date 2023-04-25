namespace SGMDT_Wifimex
{
    partial class frmMenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuPrincipal));
            this.mtsAcceder = new System.Windows.Forms.MenuStrip();
            this.mtsEmpleados = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsInstalaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsContratos = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsAlmacen = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAlmacen = new System.Windows.Forms.Button();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnContratos = new System.Windows.Forms.Button();
            this.btnInstalaciones = new System.Windows.Forms.Button();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.mtsAcceder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mtsAcceder
            // 
            this.mtsAcceder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtsEmpleados,
            this.mtsInstalaciones,
            this.mtsClientes,
            this.mtsContratos,
            this.mtsProveedores,
            this.mtsProductos,
            this.mtsAlmacen});
            this.mtsAcceder.Location = new System.Drawing.Point(0, 0);
            this.mtsAcceder.Name = "mtsAcceder";
            this.mtsAcceder.Size = new System.Drawing.Size(540, 24);
            this.mtsAcceder.TabIndex = 7;
            this.mtsAcceder.Text = "menuStrip1";
            // 
            // mtsEmpleados
            // 
            this.mtsEmpleados.Name = "mtsEmpleados";
            this.mtsEmpleados.Size = new System.Drawing.Size(77, 20);
            this.mtsEmpleados.Text = "Empleados";
            this.mtsEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // mtsInstalaciones
            // 
            this.mtsInstalaciones.Name = "mtsInstalaciones";
            this.mtsInstalaciones.Size = new System.Drawing.Size(87, 20);
            this.mtsInstalaciones.Text = "Instalaciones";
            this.mtsInstalaciones.Click += new System.EventHandler(this.btnInstalaciones_Click);
            // 
            // mtsClientes
            // 
            this.mtsClientes.Name = "mtsClientes";
            this.mtsClientes.Size = new System.Drawing.Size(61, 20);
            this.mtsClientes.Text = "Clientes";
            this.mtsClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // mtsContratos
            // 
            this.mtsContratos.Name = "mtsContratos";
            this.mtsContratos.Size = new System.Drawing.Size(71, 20);
            this.mtsContratos.Text = "Contratos";
            this.mtsContratos.Click += new System.EventHandler(this.btnContratos_Click);
            // 
            // mtsProveedores
            // 
            this.mtsProveedores.Name = "mtsProveedores";
            this.mtsProveedores.Size = new System.Drawing.Size(84, 20);
            this.mtsProveedores.Text = "Proveedores";
            this.mtsProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // mtsProductos
            // 
            this.mtsProductos.Name = "mtsProductos";
            this.mtsProductos.Size = new System.Drawing.Size(73, 20);
            this.mtsProductos.Text = "Productos";
            this.mtsProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // mtsAlmacen
            // 
            this.mtsAlmacen.Name = "mtsAlmacen";
            this.mtsAlmacen.Size = new System.Drawing.Size(66, 20);
            this.mtsAlmacen.Text = "Almacen";
            this.mtsAlmacen.Click += new System.EventHandler(this.btnAlmacen_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(94, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 57);
            this.label1.TabIndex = 8;
            this.label1.Text = "Crea, actualiza, borra o visualiza los datos para los Empleados.\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(93, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 57);
            this.label2.TabIndex = 9;
            this.label2.Text = "Crea, actualiza, borra o visualiza los datos de las Instalaciones.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(93, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 57);
            this.label3.TabIndex = 10;
            this.label3.Text = "Crea, actualiza, borra o visualiza los datos para los Clientes.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(93, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 57);
            this.label4.TabIndex = 11;
            this.label4.Text = "Crea, actualiza, borra o visualiza los datos sobre los Contratos.\r\n";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(352, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 57);
            this.label5.TabIndex = 12;
            this.label5.Text = "Crea, actualiza, borra o visualiza los datos para los Proveedores.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(352, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 57);
            this.label6.TabIndex = 13;
            this.label6.Text = "Crea, actualiza, borra o visualiza los datos de los Productos.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(352, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 57);
            this.label7.TabIndex = 14;
            this.label7.Text = "Crea, actualiza, borra o visualiza los datos del Almacen";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(120, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(278, 46);
            this.label8.TabIndex = 15;
            this.label8.Text = "Menu Principal";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SGMDT_Wifimex.Properties.Resources.WifiMex;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(315, 339);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 75);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // btnAlmacen
            // 
            this.btnAlmacen.BackgroundImage = global::SGMDT_Wifimex.Properties.Resources.frmAlmacen;
            this.btnAlmacen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAlmacen.Location = new System.Drawing.Point(270, 267);
            this.btnAlmacen.Margin = new System.Windows.Forms.Padding(2);
            this.btnAlmacen.Name = "btnAlmacen";
            this.btnAlmacen.Size = new System.Drawing.Size(77, 57);
            this.btnAlmacen.TabIndex = 6;
            this.btnAlmacen.UseVisualStyleBackColor = true;
            this.btnAlmacen.Click += new System.EventHandler(this.btnAlmacen_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.BackgroundImage = global::SGMDT_Wifimex.Properties.Resources.frmProveedores;
            this.btnProveedores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProveedores.Location = new System.Drawing.Point(270, 87);
            this.btnProveedores.Margin = new System.Windows.Forms.Padding(2);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(77, 57);
            this.btnProveedores.TabIndex = 5;
            this.btnProveedores.UseVisualStyleBackColor = true;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackgroundImage = global::SGMDT_Wifimex.Properties.Resources.frmCliente;
            this.btnClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClientes.Location = new System.Drawing.Point(11, 267);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(2);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(77, 57);
            this.btnClientes.TabIndex = 4;
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.BackgroundImage = global::SGMDT_Wifimex.Properties.Resources.frmProducto;
            this.btnProductos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProductos.Location = new System.Drawing.Point(270, 177);
            this.btnProductos.Margin = new System.Windows.Forms.Padding(2);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(77, 57);
            this.btnProductos.TabIndex = 3;
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnContratos
            // 
            this.btnContratos.BackgroundImage = global::SGMDT_Wifimex.Properties.Resources.frmContrato;
            this.btnContratos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnContratos.Location = new System.Drawing.Point(11, 357);
            this.btnContratos.Margin = new System.Windows.Forms.Padding(2);
            this.btnContratos.Name = "btnContratos";
            this.btnContratos.Size = new System.Drawing.Size(77, 57);
            this.btnContratos.TabIndex = 2;
            this.btnContratos.UseVisualStyleBackColor = true;
            this.btnContratos.Click += new System.EventHandler(this.btnContratos_Click);
            // 
            // btnInstalaciones
            // 
            this.btnInstalaciones.BackgroundImage = global::SGMDT_Wifimex.Properties.Resources.frmInstalacion;
            this.btnInstalaciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInstalaciones.Location = new System.Drawing.Point(11, 177);
            this.btnInstalaciones.Margin = new System.Windows.Forms.Padding(2);
            this.btnInstalaciones.Name = "btnInstalaciones";
            this.btnInstalaciones.Size = new System.Drawing.Size(77, 57);
            this.btnInstalaciones.TabIndex = 1;
            this.btnInstalaciones.UseVisualStyleBackColor = true;
            this.btnInstalaciones.Click += new System.EventHandler(this.btnInstalaciones_Click);
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEmpleados.BackgroundImage")));
            this.btnEmpleados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEmpleados.Location = new System.Drawing.Point(11, 87);
            this.btnEmpleados.Margin = new System.Windows.Forms.Padding(2);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(77, 57);
            this.btnEmpleados.TabIndex = 0;
            this.btnEmpleados.UseVisualStyleBackColor = true;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // frmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(540, 425);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAlmacen);
            this.Controls.Add(this.btnProveedores);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnProductos);
            this.Controls.Add(this.btnContratos);
            this.Controls.Add(this.btnInstalaciones);
            this.Controls.Add(this.btnEmpleados);
            this.Controls.Add(this.mtsAcceder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mtsAcceder;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMenuPrincipal_FormClosed);
            this.mtsAcceder.ResumeLayout(false);
            this.mtsAcceder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.Button btnInstalaciones;
        private System.Windows.Forms.Button btnContratos;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnAlmacen;
        private System.Windows.Forms.MenuStrip mtsAcceder;
        private System.Windows.Forms.ToolStripMenuItem mtsEmpleados;
        private System.Windows.Forms.ToolStripMenuItem mtsInstalaciones;
        private System.Windows.Forms.ToolStripMenuItem mtsClientes;
        private System.Windows.Forms.ToolStripMenuItem mtsContratos;
        private System.Windows.Forms.ToolStripMenuItem mtsProveedores;
        private System.Windows.Forms.ToolStripMenuItem mtsProductos;
        private System.Windows.Forms.ToolStripMenuItem mtsAlmacen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}