namespace PersonasApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblNombre = new Label();
            lblEdad = new Label();
            txtNombre = new TextBox();
            txtEdad = new TextBox();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            dgvPersonas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPersonas).BeginInit();
            SuspendLayout();
            // lblNombre
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(25, 40);
            lblNombre.Name = "lblNombre";
            lblNombre.Text = "Nombre :";
            // lblEdad
            lblEdad.AutoSize = true;
            lblEdad.Location = new Point(25, 85);
            lblEdad.Name = "lblEdad";
            lblEdad.Text = "Edad :";
            // txtNombre
            txtNombre.Location = new Point(95, 36);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(250, 23);
            txtNombre.MaxLength = 100;
            txtNombre.TabIndex = 0;
            // txtEdad
            txtEdad.Location = new Point(95, 82);
            txtEdad.Name = "txtEdad";
            txtEdad.Size = new Size(95, 23);
            txtEdad.MaxLength = 3;
            txtEdad.TabIndex = 1;
            txtEdad.KeyPress += txtEdad_KeyPress;
            // btnGuardar
            btnGuardar.Location = new Point(385, 28);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(85, 58);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // btnLimpiar
            btnLimpiar.Location = new Point(490, 28);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(85, 58);
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // btnEliminar
            btnEliminar.Location = new Point(595, 28);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(85, 58);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // dgvPersonas
            dgvPersonas.AllowUserToAddRows = false;
            dgvPersonas.AllowUserToDeleteRows = false;
            dgvPersonas.ReadOnly = true;
            dgvPersonas.MultiSelect = false;
            dgvPersonas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPersonas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPersonas.Location = new Point(25, 130);
            dgvPersonas.Name = "dgvPersonas";
            dgvPersonas.Size = new Size(655, 270);
            dgvPersonas.TabIndex = 5;
            dgvPersonas.CellClick += dgvPersonas_CellClick;
            dgvPersonas.KeyDown += dgvPersonas_KeyDown;
            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 430);
            Controls.Add(lblNombre);
            Controls.Add(lblEdad);
            Controls.Add(txtNombre);
            Controls.Add(txtEdad);
            Controls.Add(btnGuardar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(dgvPersonas);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvPersonas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblNombre;
        private Label lblEdad;
        private TextBox txtNombre;
        private TextBox txtEdad;
        private Button btnGuardar;
        private Button btnLimpiar;
        private Button btnEliminar;
        private DataGridView dgvPersonas;
    }
}
