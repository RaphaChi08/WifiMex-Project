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
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.btnInstalaciones = new System.Windows.Forms.Button();
            this.btnContratos = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnAlmacen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.Location = new System.Drawing.Point(65, 48);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(75, 23);
            this.btnEmpleados.TabIndex = 0;
            this.btnEmpleados.Text = "Empleados";
            this.btnEmpleados.UseVisualStyleBackColor = true;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // btnInstalaciones
            // 
            this.btnInstalaciones.Location = new System.Drawing.Point(449, 48);
            this.btnInstalaciones.Name = "btnInstalaciones";
            this.btnInstalaciones.Size = new System.Drawing.Size(75, 23);
            this.btnInstalaciones.TabIndex = 1;
            this.btnInstalaciones.Text = "Instalaciones";
            this.btnInstalaciones.UseVisualStyleBackColor = true;
            this.btnInstalaciones.Click += new System.EventHandler(this.btnInstalaciones_Click);
            // 
            // btnContratos
            // 
            this.btnContratos.Location = new System.Drawing.Point(65, 197);
            this.btnContratos.Name = "btnContratos";
            this.btnContratos.Size = new System.Drawing.Size(75, 23);
            this.btnContratos.TabIndex = 2;
            this.btnContratos.Text = "Contratos";
            this.btnContratos.UseVisualStyleBackColor = true;
            // 
            // btnProductos
            // 
            this.btnProductos.Location = new System.Drawing.Point(261, 117);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(75, 23);
            this.btnProductos.TabIndex = 3;
            this.btnProductos.Text = "Productos";
            this.btnProductos.UseVisualStyleBackColor = true;
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(65, 117);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(75, 23);
            this.btnClientes.TabIndex = 4;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            // 
            // btnProveedores
            // 
            this.btnProveedores.Location = new System.Drawing.Point(449, 197);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(75, 23);
            this.btnProveedores.TabIndex = 5;
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.UseVisualStyleBackColor = true;
            // 
            // btnAlmacen
            // 
            this.btnAlmacen.Location = new System.Drawing.Point(449, 117);
            this.btnAlmacen.Name = "btnAlmacen";
            this.btnAlmacen.Size = new System.Drawing.Size(75, 23);
            this.btnAlmacen.TabIndex = 6;
            this.btnAlmacen.Text = "Almacen";
            this.btnAlmacen.UseVisualStyleBackColor = true;
            // 
            // frmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAlmacen);
            this.Controls.Add(this.btnProveedores);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnProductos);
            this.Controls.Add(this.btnContratos);
            this.Controls.Add(this.btnInstalaciones);
            this.Controls.Add(this.btnEmpleados);
            this.Name = "frmMenuPrincipal";
            this.Text = "frmMenuPrincipal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.Button btnInstalaciones;
        private System.Windows.Forms.Button btnContratos;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnAlmacen;
    }
}