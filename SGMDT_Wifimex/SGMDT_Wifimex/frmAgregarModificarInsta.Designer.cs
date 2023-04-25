namespace SGMDT_Wifimex
{
    partial class frmAgregarModificarInsta
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInstalacion = new System.Windows.Forms.TextBox();
            this.txtContrato = new System.Windows.Forms.TextBox();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.dtpInstalacion = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id Instalacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Num. Empleado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Id Contrato";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha de Instalacion";
            // 
            // txtInstalacion
            // 
            this.txtInstalacion.Location = new System.Drawing.Point(182, 44);
            this.txtInstalacion.MaxLength = 10;
            this.txtInstalacion.Name = "txtInstalacion";
            this.txtInstalacion.Size = new System.Drawing.Size(224, 26);
            this.txtInstalacion.TabIndex = 4;
            // 
            // txtContrato
            // 
            this.txtContrato.Location = new System.Drawing.Point(182, 145);
            this.txtContrato.MaxLength = 10;
            this.txtContrato.Name = "txtContrato";
            this.txtContrato.Size = new System.Drawing.Size(224, 26);
            this.txtContrato.TabIndex = 5;
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Location = new System.Drawing.Point(182, 98);
            this.txtEmpleado.MaxLength = 10;
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.Size = new System.Drawing.Size(224, 26);
            this.txtEmpleado.TabIndex = 6;
            // 
            // dtpInstalacion
            // 
            this.dtpInstalacion.Location = new System.Drawing.Point(182, 189);
            this.dtpInstalacion.Name = "dtpInstalacion";
            this.dtpInstalacion.Size = new System.Drawing.Size(224, 26);
            this.dtpInstalacion.TabIndex = 7;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Black;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(60, 263);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(109, 36);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Black;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(259, 263);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 36);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAgregarModificarInsta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 330);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dtpInstalacion);
            this.Controls.Add(this.txtEmpleado);
            this.Controls.Add(this.txtContrato);
            this.Controls.Add(this.txtInstalacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAgregarModificarInsta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAgregarModificarInsta";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInstalacion;
        private System.Windows.Forms.TextBox txtContrato;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.DateTimePicker dtpInstalacion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}