namespace WindowsFormsApp1
{
    partial class frmDetallesArticulos
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
            this.lblCodigoValor = new System.Windows.Forms.Label();
            this.lblNombreValor = new System.Windows.Forms.Label();
            this.lblDescripcionValor = new System.Windows.Forms.Label();
            this.lblMarcaValor = new System.Windows.Forms.Label();
            this.lblCategoriaValor = new System.Windows.Forms.Label();
            this.lblPrecioValor = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pbxDetalles = new System.Windows.Forms.PictureBox();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCodigoValor
            // 
            this.lblCodigoValor.AutoSize = true;
            this.lblCodigoValor.Location = new System.Drawing.Point(43, 55);
            this.lblCodigoValor.Name = "lblCodigoValor";
            this.lblCodigoValor.Size = new System.Drawing.Size(40, 13);
            this.lblCodigoValor.TabIndex = 0;
            this.lblCodigoValor.Text = "Codigo";
            // 
            // lblNombreValor
            // 
            this.lblNombreValor.AutoSize = true;
            this.lblNombreValor.Location = new System.Drawing.Point(43, 84);
            this.lblNombreValor.Name = "lblNombreValor";
            this.lblNombreValor.Size = new System.Drawing.Size(44, 13);
            this.lblNombreValor.TabIndex = 1;
            this.lblNombreValor.Text = "Nombre";
            // 
            // lblDescripcionValor
            // 
            this.lblDescripcionValor.AutoSize = true;
            this.lblDescripcionValor.Location = new System.Drawing.Point(43, 113);
            this.lblDescripcionValor.Name = "lblDescripcionValor";
            this.lblDescripcionValor.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcionValor.TabIndex = 2;
            this.lblDescripcionValor.Text = "Descripcion";
            // 
            // lblMarcaValor
            // 
            this.lblMarcaValor.AutoSize = true;
            this.lblMarcaValor.Location = new System.Drawing.Point(43, 142);
            this.lblMarcaValor.Name = "lblMarcaValor";
            this.lblMarcaValor.Size = new System.Drawing.Size(37, 13);
            this.lblMarcaValor.TabIndex = 3;
            this.lblMarcaValor.Text = "Marca";
            // 
            // lblCategoriaValor
            // 
            this.lblCategoriaValor.AutoSize = true;
            this.lblCategoriaValor.Location = new System.Drawing.Point(43, 171);
            this.lblCategoriaValor.Name = "lblCategoriaValor";
            this.lblCategoriaValor.Size = new System.Drawing.Size(52, 13);
            this.lblCategoriaValor.TabIndex = 4;
            this.lblCategoriaValor.Text = "Categoria";
            // 
            // lblPrecioValor
            // 
            this.lblPrecioValor.AutoSize = true;
            this.lblPrecioValor.Location = new System.Drawing.Point(43, 200);
            this.lblPrecioValor.Name = "lblPrecioValor";
            this.lblPrecioValor.Size = new System.Drawing.Size(37, 13);
            this.lblPrecioValor.TabIndex = 5;
            this.lblPrecioValor.Text = "Precio";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(225, 598);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(121, 31);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pbxDetalles
            // 
            this.pbxDetalles.Location = new System.Drawing.Point(133, 219);
            this.pbxDetalles.Name = "pbxDetalles";
            this.pbxDetalles.Size = new System.Drawing.Size(316, 230);
            this.pbxDetalles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxDetalles.TabIndex = 7;
            this.pbxDetalles.TabStop = false;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(334, 511);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(75, 23);
            this.btnSiguiente.TabIndex = 8;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(187, 511);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(75, 23);
            this.btnAtras.TabIndex = 9;
            this.btnAtras.Text = "Atrás";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click_1);
            // 
            // frmDetallesArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 654);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.pbxDetalles);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblPrecioValor);
            this.Controls.Add(this.lblCategoriaValor);
            this.Controls.Add(this.lblMarcaValor);
            this.Controls.Add(this.lblDescripcionValor);
            this.Controls.Add(this.lblNombreValor);
            this.Controls.Add(this.lblCodigoValor);
            this.Name = "frmDetallesArticulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVerDetalles";
            this.Load += new System.EventHandler(this.frmDetallesArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDetalles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodigoValor;
        private System.Windows.Forms.Label lblNombreValor;
        private System.Windows.Forms.Label lblDescripcionValor;
        private System.Windows.Forms.Label lblMarcaValor;
        private System.Windows.Forms.Label lblCategoriaValor;
        private System.Windows.Forms.Label lblPrecioValor;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.PictureBox pbxDetalles;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAtras;
    }
}