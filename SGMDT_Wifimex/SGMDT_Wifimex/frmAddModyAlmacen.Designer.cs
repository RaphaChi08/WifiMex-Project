namespace SGMDT_Wifimex
{
    partial class frmAddModyAlmacen
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
            this.gbxEstatus = new System.Windows.Forms.GroupBox();
            this.rbInactivo = new System.Windows.Forms.RadioButton();
            this.rbActivo = new System.Windows.Forms.RadioButton();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.cbxBarra = new System.Windows.Forms.ComboBox();
            this.cbxEmpleado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCant = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAcep = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbxEstatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxEstatus
            // 
            this.gbxEstatus.AutoSize = true;
            this.gbxEstatus.Controls.Add(this.rbInactivo);
            this.gbxEstatus.Controls.Add(this.rbActivo);
            this.gbxEstatus.Location = new System.Drawing.Point(148, 162);
            this.gbxEstatus.Name = "gbxEstatus";
            this.gbxEstatus.Size = new System.Drawing.Size(200, 63);
            this.gbxEstatus.TabIndex = 9;
            this.gbxEstatus.TabStop = false;
            this.gbxEstatus.Text = "Estatus";
            // 
            // rbInactivo
            // 
            this.rbInactivo.AutoSize = true;
            this.rbInactivo.Location = new System.Drawing.Point(115, 21);
            this.rbInactivo.Name = "rbInactivo";
            this.rbInactivo.Size = new System.Drawing.Size(74, 20);
            this.rbInactivo.TabIndex = 1;
            this.rbInactivo.Text = "Inactivo";
            this.rbInactivo.UseVisualStyleBackColor = true;
            // 
            // rbActivo
            // 
            this.rbActivo.AutoSize = true;
            this.rbActivo.Checked = true;
            this.rbActivo.Location = new System.Drawing.Point(6, 21);
            this.rbActivo.Name = "rbActivo";
            this.rbActivo.Size = new System.Drawing.Size(65, 20);
            this.rbActivo.TabIndex = 0;
            this.rbActivo.TabStop = true;
            this.rbActivo.Text = "Activo";
            this.rbActivo.UseVisualStyleBackColor = true;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(159, 29);
            this.txtClave.MaxLength = 10;
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(315, 22);
            this.txtClave.TabIndex = 10;
            // 
            // cbxBarra
            // 
            this.cbxBarra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBarra.FormattingEnabled = true;
            this.cbxBarra.Location = new System.Drawing.Point(167, 86);
            this.cbxBarra.Name = "cbxBarra";
            this.cbxBarra.Size = new System.Drawing.Size(307, 24);
            this.cbxBarra.TabIndex = 12;
            // 
            // cbxEmpleado
            // 
            this.cbxEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEmpleado.FormattingEnabled = true;
            this.cbxEmpleado.Location = new System.Drawing.Point(200, 116);
            this.cbxEmpleado.Name = "cbxEmpleado";
            this.cbxEmpleado.Size = new System.Drawing.Size(274, 24);
            this.cbxEmpleado.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Clave Almacen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Cantidad del producto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Codigo de Barra";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Empleado Encargado";
            // 
            // txtCant
            // 
            this.txtCant.Location = new System.Drawing.Point(200, 58);
            this.txtCant.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtCant.Name = "txtCant";
            this.txtCant.Size = new System.Drawing.Size(273, 22);
            this.txtCant.TabIndex = 18;
            this.txtCant.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(58, 231);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(161, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAcep
            // 
            this.btnAcep.Location = new System.Drawing.Point(312, 231);
            this.btnAcep.Name = "btnAcep";
            this.btnAcep.Size = new System.Drawing.Size(161, 23);
            this.btnAcep.TabIndex = 20;
            this.btnAcep.Text = "Aceptar";
            this.btnAcep.UseVisualStyleBackColor = true;
            this.btnAcep.Click += new System.EventHandler(this.btnAcep_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddModyAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(524, 269);
            this.Controls.Add(this.btnAcep);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtCant);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxEmpleado);
            this.Controls.Add(this.cbxBarra);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.gbxEstatus);
            this.Name = "frmAddModyAlmacen";
            this.Text = "frmAddModyAlmacen";
            this.gbxEstatus.ResumeLayout(false);
            this.gbxEstatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxEstatus;
        private System.Windows.Forms.RadioButton rbInactivo;
        private System.Windows.Forms.RadioButton rbActivo;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.ComboBox cbxBarra;
        private System.Windows.Forms.ComboBox cbxEmpleado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtCant;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAcep;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}