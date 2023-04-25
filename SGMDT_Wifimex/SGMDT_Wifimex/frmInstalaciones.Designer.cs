namespace SGMDT_Wifimex
{
    partial class frmInstalaciones
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
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvInstalaciones = new System.Windows.Forms.DataGridView();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstalaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.DimGray;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(11, 11);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(134, 40);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.DimGray;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(149, 11);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(134, 40);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(435, 17);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(243, 26);
            this.txtBuscar.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.Location = new System.Drawing.Point(682, 8);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(63, 40);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvInstalaciones
            // 
            this.dgvInstalaciones.AllowUserToAddRows = false;
            this.dgvInstalaciones.AllowUserToDeleteRows = false;
            this.dgvInstalaciones.AllowUserToResizeRows = false;
            this.dgvInstalaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInstalaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInstalaciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvInstalaciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInstalaciones.Location = new System.Drawing.Point(0, 55);
            this.dgvInstalaciones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvInstalaciones.MultiSelect = false;
            this.dgvInstalaciones.Name = "dgvInstalaciones";
            this.dgvInstalaciones.ReadOnly = true;
            this.dgvInstalaciones.RowHeadersWidth = 51;
            this.dgvInstalaciones.RowTemplate.Height = 24;
            this.dgvInstalaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInstalaciones.Size = new System.Drawing.Size(756, 286);
            this.dgvInstalaciones.TabIndex = 0;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Image = global::SGMDT_Wifimex.Properties.Resources.Buscar;
            this.pictureBox4.Location = new System.Drawing.Point(690, 15);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(47, 26);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Image = global::SGMDT_Wifimex.Properties.Resources.Actualizar;
            this.pictureBox2.Location = new System.Drawing.Point(153, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(47, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::SGMDT_Wifimex.Properties.Resources.Agregar;
            this.pictureBox1.Location = new System.Drawing.Point(15, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // frmInstalaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(756, 341);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvInstalaciones);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnAgregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInstalaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventana principal de instalaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstalaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvInstalaciones;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}