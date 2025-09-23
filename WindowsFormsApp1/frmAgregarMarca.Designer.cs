namespace WindowsFormsApp1
{
    partial class frmAgregarMarca
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
            this.btnAceptarMarca = new System.Windows.Forms.Button();
            this.btnCancelarMarca = new System.Windows.Forms.Button();
            this.lblDescripcionMarca = new System.Windows.Forms.Label();
            this.txtDescripcionMarca = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAceptarMarca
            // 
            this.btnAceptarMarca.Location = new System.Drawing.Point(54, 165);
            this.btnAceptarMarca.Name = "btnAceptarMarca";
            this.btnAceptarMarca.Size = new System.Drawing.Size(91, 30);
            this.btnAceptarMarca.TabIndex = 0;
            this.btnAceptarMarca.Text = "Aceptar";
            this.btnAceptarMarca.UseVisualStyleBackColor = true;
            this.btnAceptarMarca.Click += new System.EventHandler(this.btnAceptarMarca_Click);
            // 
            // btnCancelarMarca
            // 
            this.btnCancelarMarca.Location = new System.Drawing.Point(164, 165);
            this.btnCancelarMarca.Name = "btnCancelarMarca";
            this.btnCancelarMarca.Size = new System.Drawing.Size(91, 30);
            this.btnCancelarMarca.TabIndex = 1;
            this.btnCancelarMarca.Text = "Cancelar";
            this.btnCancelarMarca.UseVisualStyleBackColor = true;
            this.btnCancelarMarca.Click += new System.EventHandler(this.btnCancelarMarca_Click);
            // 
            // lblDescripcionMarca
            // 
            this.lblDescripcionMarca.AutoSize = true;
            this.lblDescripcionMarca.Location = new System.Drawing.Point(69, 89);
            this.lblDescripcionMarca.Name = "lblDescripcionMarca";
            this.lblDescripcionMarca.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcionMarca.TabIndex = 2;
            this.lblDescripcionMarca.Text = "Descripcion";
            // 
            // txtDescripcionMarca
            // 
            this.txtDescripcionMarca.Location = new System.Drawing.Point(139, 89);
            this.txtDescripcionMarca.Name = "txtDescripcionMarca";
            this.txtDescripcionMarca.Size = new System.Drawing.Size(116, 20);
            this.txtDescripcionMarca.TabIndex = 3;
            // 
            // frmAgregarMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 247);
            this.Controls.Add(this.txtDescripcionMarca);
            this.Controls.Add(this.lblDescripcionMarca);
            this.Controls.Add(this.btnCancelarMarca);
            this.Controls.Add(this.btnAceptarMarca);
            this.Name = "frmAgregarMarca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAgregarMarca";
            this.Load += new System.EventHandler(this.frmAgregarMarca_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptarMarca;
        private System.Windows.Forms.Button btnCancelarMarca;
        private System.Windows.Forms.Label lblDescripcionMarca;
        private System.Windows.Forms.TextBox txtDescripcionMarca;
    }
}