namespace SGMDT_Wifimex
{
    partial class frmAddModyContratos
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
            this.txtIdCo = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.dtpIni = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.cbxCliente = new System.Windows.Forms.ComboBox();
            this.gbxEstatus = new System.Windows.Forms.GroupBox();
            this.rbInactivo = new System.Windows.Forms.RadioButton();
            this.rbActivo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbxEstatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIdCo
            // 
            this.txtIdCo.Location = new System.Drawing.Point(167, 77);
            this.txtIdCo.MaxLength = 10;
            this.txtIdCo.Name = "txtIdCo";
            this.txtIdCo.Size = new System.Drawing.Size(313, 26);
            this.txtIdCo.TabIndex = 0;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(167, 113);
            this.txtPrecio.MaxLength = 6;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(313, 26);
            this.txtPrecio.TabIndex = 1;
            this.txtPrecio.Text = "0";
            // 
            // dtpIni
            // 
            this.dtpIni.Location = new System.Drawing.Point(167, 149);
            this.dtpIni.Name = "dtpIni";
            this.dtpIni.Size = new System.Drawing.Size(313, 26);
            this.dtpIni.TabIndex = 2;
            // 
            // dtpFin
            // 
            this.dtpFin.Location = new System.Drawing.Point(167, 185);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(313, 26);
            this.dtpFin.TabIndex = 3;
            // 
            // cbxCliente
            // 
            this.cbxCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCliente.FormattingEnabled = true;
            this.cbxCliente.Location = new System.Drawing.Point(167, 221);
            this.cbxCliente.Name = "cbxCliente";
            this.cbxCliente.Size = new System.Drawing.Size(313, 28);
            this.cbxCliente.TabIndex = 4;
            // 
            // gbxEstatus
            // 
            this.gbxEstatus.AutoSize = true;
            this.gbxEstatus.Controls.Add(this.rbInactivo);
            this.gbxEstatus.Controls.Add(this.rbActivo);
            this.gbxEstatus.Location = new System.Drawing.Point(146, 268);
            this.gbxEstatus.Name = "gbxEstatus";
            this.gbxEstatus.Size = new System.Drawing.Size(230, 78);
            this.gbxEstatus.TabIndex = 8;
            this.gbxEstatus.TabStop = false;
            this.gbxEstatus.Text = "Estatus";
            // 
            // rbInactivo
            // 
            this.rbInactivo.AutoSize = true;
            this.rbInactivo.Location = new System.Drawing.Point(129, 26);
            this.rbInactivo.Name = "rbInactivo";
            this.rbInactivo.Size = new System.Drawing.Size(82, 24);
            this.rbInactivo.TabIndex = 1;
            this.rbInactivo.Text = "Inactivo";
            this.rbInactivo.UseVisualStyleBackColor = true;
            // 
            // rbActivo
            // 
            this.rbActivo.AutoSize = true;
            this.rbActivo.Checked = true;
            this.rbActivo.Location = new System.Drawing.Point(6, 26);
            this.rbActivo.Name = "rbActivo";
            this.rbActivo.Size = new System.Drawing.Size(70, 24);
            this.rbActivo.TabIndex = 0;
            this.rbActivo.TabStop = true;
            this.rbActivo.Text = "Activo";
            this.rbActivo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Clave contrato";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Precio del servicio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Inicio Contrato";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Fin Contrato";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Nombre del Cliente";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(24, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 37);
            this.button1.TabIndex = 14;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(291, 363);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 37);
            this.button2.TabIndex = 15;
            this.button2.Text = "Aceptar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(501, 51);
            this.lblTitulo.TabIndex = 16;
            this.lblTitulo.Text = "Crear / Actualizar Contrato";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAddModyContratos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(501, 423);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbxEstatus);
            this.Controls.Add(this.cbxCliente);
            this.Controls.Add(this.dtpFin);
            this.Controls.Add(this.dtpIni);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtIdCo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddModyContratos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddModyContratos";
            this.gbxEstatus.ResumeLayout(false);
            this.gbxEstatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdCo;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.DateTimePicker dtpIni;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.ComboBox cbxCliente;
        private System.Windows.Forms.GroupBox gbxEstatus;
        private System.Windows.Forms.RadioButton rbInactivo;
        private System.Windows.Forms.RadioButton rbActivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblTitulo;
    }
}