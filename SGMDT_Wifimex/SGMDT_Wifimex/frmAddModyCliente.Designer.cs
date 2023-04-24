namespace SGMDT_Wifimex
{
    partial class frmAddModyCliente
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
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtRfc = new System.Windows.Forms.TextBox();
            this.txtCurp = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtCorr = new System.Windows.Forms.TextBox();
            this.gbxEstatus = new System.Windows.Forms.GroupBox();
            this.rbInactivo = new System.Windows.Forms.RadioButton();
            this.rbActivo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbxEstatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(142, 18);
            this.txtId.MaxLength = 10;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(258, 22);
            this.txtId.TabIndex = 0;
            // 
            // txtRfc
            // 
            this.txtRfc.Location = new System.Drawing.Point(142, 46);
            this.txtRfc.MaxLength = 13;
            this.txtRfc.Name = "txtRfc";
            this.txtRfc.Size = new System.Drawing.Size(258, 22);
            this.txtRfc.TabIndex = 1;
            // 
            // txtCurp
            // 
            this.txtCurp.Location = new System.Drawing.Point(142, 74);
            this.txtCurp.MaxLength = 18;
            this.txtCurp.Name = "txtCurp";
            this.txtCurp.Size = new System.Drawing.Size(258, 22);
            this.txtCurp.TabIndex = 2;
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(142, 102);
            this.txtNom.MaxLength = 50;
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(258, 22);
            this.txtNom.TabIndex = 3;
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(142, 130);
            this.txtDir.MaxLength = 100;
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(258, 22);
            this.txtDir.TabIndex = 4;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(142, 158);
            this.txtTel.MaxLength = 10;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(258, 22);
            this.txtTel.TabIndex = 5;
            // 
            // txtCorr
            // 
            this.txtCorr.Location = new System.Drawing.Point(142, 186);
            this.txtCorr.MaxLength = 100;
            this.txtCorr.Name = "txtCorr";
            this.txtCorr.Size = new System.Drawing.Size(258, 22);
            this.txtCorr.TabIndex = 6;
            // 
            // gbxEstatus
            // 
            this.gbxEstatus.AutoSize = true;
            this.gbxEstatus.Controls.Add(this.rbInactivo);
            this.gbxEstatus.Controls.Add(this.rbActivo);
            this.gbxEstatus.Location = new System.Drawing.Point(115, 239);
            this.gbxEstatus.Name = "gbxEstatus";
            this.gbxEstatus.Size = new System.Drawing.Size(200, 63);
            this.gbxEstatus.TabIndex = 7;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Clave Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "RFC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "CURP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nombre Completo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Direccion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(75, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Telefono";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(88, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Correo";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 30);
            this.button1.TabIndex = 14;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(228, 326);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 30);
            this.button2.TabIndex = 15;
            this.button2.Text = "Aceptar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddModyCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(440, 361);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbxEstatus);
            this.Controls.Add(this.txtCorr);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.txtCurp);
            this.Controls.Add(this.txtRfc);
            this.Controls.Add(this.txtId);
            this.Name = "frmAddModyCliente";
            this.Text = "frmAddModyCliente";
            this.gbxEstatus.ResumeLayout(false);
            this.gbxEstatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtRfc;
        private System.Windows.Forms.TextBox txtCurp;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtCorr;
        private System.Windows.Forms.GroupBox gbxEstatus;
        private System.Windows.Forms.RadioButton rbInactivo;
        private System.Windows.Forms.RadioButton rbActivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}