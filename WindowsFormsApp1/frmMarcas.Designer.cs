namespace WindowsFormsApp1
{
    partial class frmMarcas
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
            this.btnAgregarMarcas = new System.Windows.Forms.Button();
            this.btnModificarMarcas = new System.Windows.Forms.Button();
            this.btnEliminarMarcas = new System.Windows.Forms.Button();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregarMarcas
            // 
            this.btnAgregarMarcas.Location = new System.Drawing.Point(58, 274);
            this.btnAgregarMarcas.Name = "btnAgregarMarcas";
            this.btnAgregarMarcas.Size = new System.Drawing.Size(78, 25);
            this.btnAgregarMarcas.TabIndex = 0;
            this.btnAgregarMarcas.Text = "Agregar";
            this.btnAgregarMarcas.UseVisualStyleBackColor = true;
            this.btnAgregarMarcas.Click += new System.EventHandler(this.btnAgregarMarcas_Click);
            // 
            // btnModificarMarcas
            // 
            this.btnModificarMarcas.Location = new System.Drawing.Point(162, 273);
            this.btnModificarMarcas.Name = "btnModificarMarcas";
            this.btnModificarMarcas.Size = new System.Drawing.Size(78, 25);
            this.btnModificarMarcas.TabIndex = 1;
            this.btnModificarMarcas.Text = "Modificar";
            this.btnModificarMarcas.UseVisualStyleBackColor = true;
            this.btnModificarMarcas.Click += new System.EventHandler(this.btnModificarMarcas_Click);
            // 
            // btnEliminarMarcas
            // 
            this.btnEliminarMarcas.Location = new System.Drawing.Point(266, 273);
            this.btnEliminarMarcas.Name = "btnEliminarMarcas";
            this.btnEliminarMarcas.Size = new System.Drawing.Size(78, 25);
            this.btnEliminarMarcas.TabIndex = 2;
            this.btnEliminarMarcas.Text = "Eliminar";
            this.btnEliminarMarcas.UseVisualStyleBackColor = true;
            this.btnEliminarMarcas.Click += new System.EventHandler(this.btnEliminarMarcas_Click);
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMarcas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMarcas.Location = new System.Drawing.Point(96, 65);
            this.dgvMarcas.MultiSelect = false;
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.ReadOnly = true;
            this.dgvMarcas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMarcas.Size = new System.Drawing.Size(186, 191);
            this.dgvMarcas.TabIndex = 3;
            // 
            // frmMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 362);
            this.Controls.Add(this.dgvMarcas);
            this.Controls.Add(this.btnEliminarMarcas);
            this.Controls.Add(this.btnModificarMarcas);
            this.Controls.Add(this.btnAgregarMarcas);
            this.Name = "frmMarca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMarca";
            this.Load += new System.EventHandler(this.frmMarca_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarMarcas;
        private System.Windows.Forms.Button btnModificarMarcas;
        private System.Windows.Forms.Button btnEliminarMarcas;
        private System.Windows.Forms.DataGridView dgvMarcas;
    }
}