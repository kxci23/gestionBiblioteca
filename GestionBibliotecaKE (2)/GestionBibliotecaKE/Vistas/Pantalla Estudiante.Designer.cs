namespace GestionBiblioteca
{
    partial class Pantalla_Estudiante
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
            tpHistorial = new TabPage();
            dgvHistorial = new DataGridView();
            tpBuscarLibros = new TabPage();
            btnInicio = new Button();
            txtAdquisicion = new TextBox();
            txtBuscar = new TextBox();
            label4 = new Label();
            btnAdquirir = new Button();
            dgvLibros = new DataGridView();
            btnBuscar = new Button();
            label1 = new Label();
            ol = new TabControl();
            tabPage1 = new TabPage();
            dgvDevolucion = new DataGridView();
            btnDevolucion = new Button();
            tpHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            tpBuscarLibros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            ol.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDevolucion).BeginInit();
            SuspendLayout();
            // 
            // tpHistorial
            // 
            tpHistorial.Controls.Add(dgvHistorial);
            tpHistorial.Location = new Point(4, 29);
            tpHistorial.Margin = new Padding(3, 4, 3, 4);
            tpHistorial.Name = "tpHistorial";
            tpHistorial.Padding = new Padding(3, 4, 3, 4);
            tpHistorial.Size = new Size(975, 471);
            tpHistorial.TabIndex = 2;
            tpHistorial.Text = "Historial de Préstamo";
            tpHistorial.UseVisualStyleBackColor = true;
            tpHistorial.Click += tpHistorial_Click;
            // 
            // dgvHistorial
            // 
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Location = new Point(6, 4);
            dgvHistorial.Margin = new Padding(3, 4, 3, 4);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.RowHeadersWidth = 51;
            dgvHistorial.Size = new Size(805, 400);
            dgvHistorial.TabIndex = 0;
            dgvHistorial.CellContentClick += dgvHistorial_CellContentClick;
            // 
            // tpBuscarLibros
            // 
            tpBuscarLibros.Controls.Add(txtAdquisicion);
            tpBuscarLibros.Controls.Add(txtBuscar);
            tpBuscarLibros.Controls.Add(label4);
            tpBuscarLibros.Controls.Add(btnAdquirir);
            tpBuscarLibros.Controls.Add(dgvLibros);
            tpBuscarLibros.Controls.Add(btnBuscar);
            tpBuscarLibros.Controls.Add(label1);
            tpBuscarLibros.Location = new Point(4, 29);
            tpBuscarLibros.Margin = new Padding(3, 4, 3, 4);
            tpBuscarLibros.Name = "tpBuscarLibros";
            tpBuscarLibros.Padding = new Padding(3, 4, 3, 4);
            tpBuscarLibros.Size = new Size(975, 471);
            tpBuscarLibros.TabIndex = 0;
            tpBuscarLibros.Text = "Buscar Libro";
            tpBuscarLibros.UseVisualStyleBackColor = true;
            // 
            // btnInicio
            // 
            btnInicio.Location = new Point(809, 512);
            btnInicio.Margin = new Padding(3, 4, 3, 4);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(175, 66);
            btnInicio.TabIndex = 1;
            btnInicio.Text = "Cerrar Sesión";
            btnInicio.UseVisualStyleBackColor = true;
            btnInicio.UseWaitCursor = true;
            btnInicio.Click += btnInicio_Click;
            // 
            // txtAdquisicion
            // 
            txtAdquisicion.Location = new Point(480, 31);
            txtAdquisicion.Name = "txtAdquisicion";
            txtAdquisicion.Size = new Size(382, 27);
            txtAdquisicion.TabIndex = 8;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(6, 32);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(303, 27);
            txtBuscar.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(504, 4);
            label4.Name = "label4";
            label4.Size = new Size(327, 20);
            label4.TabIndex = 7;
            label4.Text = "Aplaste en la tabla el libro que quiera adquirir\r\n";
            // 
            // btnAdquirir
            // 
            btnAdquirir.BackColor = Color.FromArgb(128, 255, 128);
            btnAdquirir.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdquirir.Location = new Point(869, 29);
            btnAdquirir.Name = "btnAdquirir";
            btnAdquirir.Size = new Size(118, 29);
            btnAdquirir.TabIndex = 6;
            btnAdquirir.Text = "Adquirir";
            btnAdquirir.UseVisualStyleBackColor = false;
            btnAdquirir.Click += btnAdquirir_Click_1;
            // 
            // dgvLibros
            // 
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibros.Location = new Point(8, 69);
            dgvLibros.Margin = new Padding(3, 4, 3, 4);
            dgvLibros.Name = "dgvLibros";
            dgvLibros.RowHeadersWidth = 51;
            dgvLibros.Size = new Size(978, 324);
            dgvLibros.TabIndex = 3;
            dgvLibros.CellContentClick += dgvLibros_CellContentClick;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(331, 29);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(86, 31);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "BUSCAR";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 4);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 0;
            label1.Text = "BUSCAR LIBRO";
            // 
            // ol
            // 
            ol.AccessibleName = "";
            ol.Controls.Add(tpBuscarLibros);
            ol.Controls.Add(tpHistorial);
            ol.Controls.Add(tabPage1);
            ol.Font = new Font("Segoe UI Symbol", 9F);
            ol.Location = new Point(-7, 0);
            ol.Margin = new Padding(3, 4, 3, 4);
            ol.Name = "ol";
            ol.SelectedIndex = 0;
            ol.Size = new Size(983, 504);
            ol.TabIndex = 0;
            ol.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvDevolucion);
            tabPage1.Controls.Add(btnDevolucion);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(975, 471);
            tabPage1.TabIndex = 3;
            tabPage1.Text = "Devolver Libro ";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvDevolucion
            // 
            dgvDevolucion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDevolucion.Location = new Point(16, 8);
            dgvDevolucion.Margin = new Padding(3, 4, 3, 4);
            dgvDevolucion.Name = "dgvDevolucion";
            dgvDevolucion.RowHeadersWidth = 51;
            dgvDevolucion.Size = new Size(443, 335);
            dgvDevolucion.TabIndex = 1;
            dgvDevolucion.CellContentClick += dgvDevolucion_CellContentClick;
            // 
            // btnDevolucion
            // 
            btnDevolucion.Location = new Point(554, 110);
            btnDevolucion.Margin = new Padding(3, 4, 3, 4);
            btnDevolucion.Name = "btnDevolucion";
            btnDevolucion.Size = new Size(330, 147);
            btnDevolucion.TabIndex = 0;
            btnDevolucion.Text = "Devolucion";
            btnDevolucion.UseVisualStyleBackColor = true;
            btnDevolucion.Click += button1_Click;
            // 
            // Pantalla_Estudiante
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 128);
            ClientSize = new Size(1005, 600);
            Controls.Add(btnInicio);
            Controls.Add(ol);
            Name = "Pantalla_Estudiante";
            Text = "Pantalla_Estudiante";
            Load += Pantalla_Estudiante_Load;
            tpHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            tpBuscarLibros.ResumeLayout(false);
            tpBuscarLibros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            ol.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDevolucion).EndInit();
            ResumeLayout(false);
        }
        // Add the missing event handler method for dgvDevolucion_CellContentClick
        private void dgvDevolucion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Implement the logic for handling the CellContentClick event here.
            // For now, you can leave it empty or add a placeholder comment.
        }
        #endregion

        private TabPage tpHistorial;
        private DataGridView dgvHistorial;
        private TabPage tpBuscarLibros;
        private Button btnInicio;
        private TextBox txtAdquisicion;
        private TextBox txtBuscar;
        private Label label4;
        private Button btnAdquirir;
        private DataGridView dgvLibros;
        private Button btnBuscar;
        private Label label1;
        private TabControl ol;
        private TabPage tabPage1;
        private DataGridView dgvDevolucion;
        private Button btnDevolucion;
    }
}