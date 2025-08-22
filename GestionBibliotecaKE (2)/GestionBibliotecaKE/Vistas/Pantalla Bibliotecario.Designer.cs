namespace GestionBiblioteca
{
    partial class Pantalla_Bibliotecario
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
            tabControl1 = new TabControl();
            tpGestionLibros = new TabPage();
            label9 = new Label();
            btnInicio = new Button();
            cmbEstadoLibro = new ComboBox();
            dgvLibros = new DataGridView();
            btnActualizarLibro = new Button();
            btnRegistrarLibro = new Button();
            cmbCategoria = new ComboBox();
            nudStock = new NumericUpDown();
            nudPaginas = new NumericUpDown();
            txtISBN = new TextBox();
            txtAutor = new TextBox();
            txtTitulo = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tpAprobarSolicitudes = new TabPage();
            dgvSolicitudes = new DataGridView();
            label12 = new Label();
            label11 = new Label();
            dtpFechaDevolucion = new DateTimePicker();
            dtpFechaPrestamo = new DateTimePicker();
            label10 = new Label();
            btnRechazar = new Button();
            btnAprobar = new Button();
            dataGridView1 = new DataGridView();
            tpRegistrarDevoluciones = new TabPage();
            label13 = new Label();
            btnRegistrarDevolucion = new Button();
            label8 = new Label();
            label7 = new Label();
            txtObservaciones = new TextBox();
            txtCondicion = new TextBox();
            dgvPrestamosActivos = new DataGridView();
            tabControl1.SuspendLayout();
            tpGestionLibros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPaginas).BeginInit();
            tpAprobarSolicitudes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSolicitudes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tpRegistrarDevoluciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamosActivos).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpGestionLibros);
            tabControl1.Controls.Add(tpAprobarSolicitudes);
            tabControl1.Controls.Add(tpRegistrarDevoluciones);
            tabControl1.Location = new Point(-1, 5);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1213, 650);
            tabControl1.TabIndex = 0;
            // 
            // tpGestionLibros
            // 
            tpGestionLibros.BackColor = Color.FromArgb(255, 255, 192);
            tpGestionLibros.Controls.Add(label9);
            tpGestionLibros.Controls.Add(cmbEstadoLibro);
            tpGestionLibros.Controls.Add(dgvLibros);
            tpGestionLibros.Controls.Add(btnActualizarLibro);
            tpGestionLibros.Controls.Add(btnRegistrarLibro);
            tpGestionLibros.Controls.Add(cmbCategoria);
            tpGestionLibros.Controls.Add(nudStock);
            tpGestionLibros.Controls.Add(nudPaginas);
            tpGestionLibros.Controls.Add(txtISBN);
            tpGestionLibros.Controls.Add(txtAutor);
            tpGestionLibros.Controls.Add(txtTitulo);
            tpGestionLibros.Controls.Add(label6);
            tpGestionLibros.Controls.Add(label5);
            tpGestionLibros.Controls.Add(label4);
            tpGestionLibros.Controls.Add(label3);
            tpGestionLibros.Controls.Add(label2);
            tpGestionLibros.Controls.Add(label1);
            tpGestionLibros.Location = new Point(4, 29);
            tpGestionLibros.Margin = new Padding(3, 4, 3, 4);
            tpGestionLibros.Name = "tpGestionLibros";
            tpGestionLibros.Padding = new Padding(3, 4, 3, 4);
            tpGestionLibros.Size = new Size(1205, 617);
            tpGestionLibros.TabIndex = 0;
            tpGestionLibros.Text = "Registrar y actualizar libros";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(719, 76);
            label9.Name = "label9";
            label9.Size = new Size(114, 20);
            label9.TabIndex = 17;
            label9.Text = "Estado del libro";
            // 
            // btnInicio
            // 
            btnInicio.Location = new Point(1218, 34);
            btnInicio.Margin = new Padding(3, 4, 3, 4);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(113, 35);
            btnInicio.TabIndex = 1;
            btnInicio.Text = "Cerrar Sesión";
            btnInicio.UseVisualStyleBackColor = true;
            btnInicio.Click += btnInicio_Click;
            // 
            // cmbEstadoLibro
            // 
            cmbEstadoLibro.FormattingEnabled = true;
            cmbEstadoLibro.Location = new Point(708, 100);
            cmbEstadoLibro.Name = "cmbEstadoLibro";
            cmbEstadoLibro.Size = new Size(159, 28);
            cmbEstadoLibro.TabIndex = 16;
            // 
            // dgvLibros
            // 
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibros.Location = new Point(161, 249);
            dgvLibros.Margin = new Padding(3, 4, 3, 4);
            dgvLibros.Name = "dgvLibros";
            dgvLibros.RowHeadersWidth = 51;
            dgvLibros.Size = new Size(911, 289);
            dgvLibros.TabIndex = 14;
            // 
            // btnActualizarLibro
            // 
            btnActualizarLibro.Location = new Point(879, 125);
            btnActualizarLibro.Margin = new Padding(3, 4, 3, 4);
            btnActualizarLibro.Name = "btnActualizarLibro";
            btnActualizarLibro.Size = new Size(136, 35);
            btnActualizarLibro.TabIndex = 13;
            btnActualizarLibro.Text = "ACTUALIZAR";
            btnActualizarLibro.UseVisualStyleBackColor = true;
            btnActualizarLibro.Click += btnActualizarLibro_Click;
            // 
            // btnRegistrarLibro
            // 
            btnRegistrarLibro.Location = new Point(879, 86);
            btnRegistrarLibro.Margin = new Padding(3, 4, 3, 4);
            btnRegistrarLibro.Name = "btnRegistrarLibro";
            btnRegistrarLibro.Size = new Size(136, 35);
            btnRegistrarLibro.TabIndex = 12;
            btnRegistrarLibro.Text = "REGISTRAR LIBRO";
            btnRegistrarLibro.UseVisualStyleBackColor = true;
            btnRegistrarLibro.Click += btnRegistrarLibro_Click;
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(546, 142);
            cmbCategoria.Margin = new Padding(3, 4, 3, 4);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(146, 28);
            cmbCategoria.TabIndex = 11;
            // 
            // nudStock
            // 
            nudStock.Location = new Point(546, 104);
            nudStock.Margin = new Padding(3, 4, 3, 4);
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(145, 27);
            nudStock.TabIndex = 10;
            // 
            // nudPaginas
            // 
            nudPaginas.Location = new Point(546, 65);
            nudPaginas.Margin = new Padding(3, 4, 3, 4);
            nudPaginas.Name = "nudPaginas";
            nudPaginas.Size = new Size(145, 27);
            nudPaginas.TabIndex = 9;
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(242, 142);
            txtISBN.Margin = new Padding(3, 4, 3, 4);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(182, 27);
            txtISBN.TabIndex = 8;
            // 
            // txtAutor
            // 
            txtAutor.Location = new Point(242, 104);
            txtAutor.Margin = new Padding(3, 4, 3, 4);
            txtAutor.Name = "txtAutor";
            txtAutor.Size = new Size(182, 27);
            txtAutor.TabIndex = 7;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(242, 65);
            txtTitulo.Margin = new Padding(3, 4, 3, 4);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(182, 27);
            txtTitulo.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(459, 146);
            label6.Name = "label6";
            label6.Size = new Size(87, 20);
            label6.TabIndex = 5;
            label6.Text = "CATEGORIA";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(459, 108);
            label5.Name = "label5";
            label5.Size = new Size(53, 20);
            label5.TabIndex = 4;
            label5.Text = "STOCK";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(459, 69);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 3;
            label4.Text = "N. PÁGINAS";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(183, 146);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 2;
            label3.Text = "ISBN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(183, 108);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 1;
            label2.Text = "AUTOR";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(183, 69);
            label1.Name = "label1";
            label1.Size = new Size(56, 20);
            label1.TabIndex = 0;
            label1.Text = "TITULO";
            // 
            // tpAprobarSolicitudes
            // 
            tpAprobarSolicitudes.BackColor = Color.FromArgb(255, 255, 192);
            tpAprobarSolicitudes.Controls.Add(dgvSolicitudes);
            tpAprobarSolicitudes.Controls.Add(label12);
            tpAprobarSolicitudes.Controls.Add(label11);
            tpAprobarSolicitudes.Controls.Add(dtpFechaDevolucion);
            tpAprobarSolicitudes.Controls.Add(dtpFechaPrestamo);
            tpAprobarSolicitudes.Controls.Add(label10);
            tpAprobarSolicitudes.Controls.Add(btnRechazar);
            tpAprobarSolicitudes.Controls.Add(btnAprobar);
            tpAprobarSolicitudes.Controls.Add(dataGridView1);
            tpAprobarSolicitudes.Location = new Point(4, 29);
            tpAprobarSolicitudes.Margin = new Padding(3, 4, 3, 4);
            tpAprobarSolicitudes.Name = "tpAprobarSolicitudes";
            tpAprobarSolicitudes.Padding = new Padding(3, 4, 3, 4);
            tpAprobarSolicitudes.Size = new Size(1205, 617);
            tpAprobarSolicitudes.TabIndex = 1;
            tpAprobarSolicitudes.Text = "Aprobar solicitudes de préstamo";
            // 
            // dgvSolicitudes
            // 
            dgvSolicitudes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSolicitudes.Location = new Point(9, 51);
            dgvSolicitudes.Name = "dgvSolicitudes";
            dgvSolicitudes.RowHeadersWidth = 51;
            dgvSolicitudes.Size = new Size(864, 284);
            dgvSolicitudes.TabIndex = 9;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline);
            label12.Location = new Point(903, 112);
            label12.Name = "label12";
            label12.Size = new Size(270, 28);
            label12.TabIndex = 8;
            label12.Text = "Fecha Devolucion Esperada";
            label12.Click += label12_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label11.Location = new Point(899, 51);
            label11.Name = "label11";
            label11.Size = new Size(161, 28);
            label11.TabIndex = 7;
            label11.Text = "Fecha Prestamo";
            // 
            // dtpFechaDevolucion
            // 
            dtpFechaDevolucion.Location = new Point(903, 152);
            dtpFechaDevolucion.Name = "dtpFechaDevolucion";
            dtpFechaDevolucion.Size = new Size(297, 27);
            dtpFechaDevolucion.TabIndex = 6;
            // 
            // dtpFechaPrestamo
            // 
            dtpFechaPrestamo.Location = new Point(903, 82);
            dtpFechaPrestamo.Name = "dtpFechaPrestamo";
            dtpFechaPrestamo.Size = new Size(293, 27);
            dtpFechaPrestamo.TabIndex = 5;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(48, 4);
            label10.Name = "label10";
            label10.Size = new Size(730, 25);
            label10.TabIndex = 4;
            label10.Text = "El Bibliotecario debe seleccionar las fechas de prestamo y de devolucion \r\n";
            // 
            // btnRechazar
            // 
            btnRechazar.BackColor = Color.FromArgb(255, 128, 128);
            btnRechazar.Location = new Point(927, 186);
            btnRechazar.Margin = new Padding(3, 4, 3, 4);
            btnRechazar.Name = "btnRechazar";
            btnRechazar.Size = new Size(223, 99);
            btnRechazar.TabIndex = 2;
            btnRechazar.Text = "RECHAZAR";
            btnRechazar.UseVisualStyleBackColor = false;
            btnRechazar.Click += btnRechazar_Click;
            // 
            // btnAprobar
            // 
            btnAprobar.BackColor = Color.Lime;
            btnAprobar.Location = new Point(927, 292);
            btnAprobar.Margin = new Padding(3, 4, 3, 4);
            btnAprobar.Name = "btnAprobar";
            btnAprobar.Size = new Size(223, 101);
            btnAprobar.TabIndex = 1;
            btnAprobar.Text = "APROBAR";
            btnAprobar.UseVisualStyleBackColor = false;
            btnAprobar.Click += btnAprobar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(9, 364);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(864, 260);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // tpRegistrarDevoluciones
            // 
            tpRegistrarDevoluciones.BackColor = Color.FromArgb(255, 255, 192);
            tpRegistrarDevoluciones.Controls.Add(label13);
            tpRegistrarDevoluciones.Controls.Add(btnRegistrarDevolucion);
            tpRegistrarDevoluciones.Controls.Add(label8);
            tpRegistrarDevoluciones.Controls.Add(label7);
            tpRegistrarDevoluciones.Controls.Add(txtObservaciones);
            tpRegistrarDevoluciones.Controls.Add(txtCondicion);
            tpRegistrarDevoluciones.Controls.Add(dgvPrestamosActivos);
            tpRegistrarDevoluciones.Location = new Point(4, 29);
            tpRegistrarDevoluciones.Margin = new Padding(3, 4, 3, 4);
            tpRegistrarDevoluciones.Name = "tpRegistrarDevoluciones";
            tpRegistrarDevoluciones.Padding = new Padding(3, 4, 3, 4);
            tpRegistrarDevoluciones.Size = new Size(1205, 617);
            tpRegistrarDevoluciones.TabIndex = 2;
            tpRegistrarDevoluciones.Text = "Registrar devoluciones";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Verdana", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(343, 33);
            label13.Name = "label13";
            label13.Size = new Size(396, 28);
            label13.TabIndex = 6;
            label13.Text = "Seleccione el id para registrar";
            label13.Click += label13_Click;
            // 
            // btnRegistrarDevolucion
            // 
            btnRegistrarDevolucion.Location = new Point(593, 375);
            btnRegistrarDevolucion.Margin = new Padding(3, 4, 3, 4);
            btnRegistrarDevolucion.Name = "btnRegistrarDevolucion";
            btnRegistrarDevolucion.Size = new Size(250, 63);
            btnRegistrarDevolucion.TabIndex = 5;
            btnRegistrarDevolucion.Text = "REGISTRAR DEVOLUCIÓN";
            btnRegistrarDevolucion.UseVisualStyleBackColor = true;
            btnRegistrarDevolucion.Click += btnRegistrarDevolucion_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(179, 425);
            label8.Name = "label8";
            label8.Size = new Size(123, 20);
            label8.TabIndex = 4;
            label8.Text = "OBSERVACIONES";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(188, 375);
            label7.Name = "label7";
            label7.Size = new Size(90, 20);
            label7.TabIndex = 3;
            label7.Text = "CONDICIÓN";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(309, 423);
            txtObservaciones.Margin = new Padding(3, 4, 3, 4);
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(161, 27);
            txtObservaciones.TabIndex = 2;
            // 
            // txtCondicion
            // 
            txtCondicion.Location = new Point(309, 372);
            txtCondicion.Margin = new Padding(3, 4, 3, 4);
            txtCondicion.Name = "txtCondicion";
            txtCondicion.Size = new Size(161, 27);
            txtCondicion.TabIndex = 1;
            txtCondicion.TextChanged += txtCondicion_TextChanged;
            // 
            // dgvPrestamosActivos
            // 
            dgvPrestamosActivos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrestamosActivos.Location = new Point(131, 97);
            dgvPrestamosActivos.Margin = new Padding(3, 4, 3, 4);
            dgvPrestamosActivos.Name = "dgvPrestamosActivos";
            dgvPrestamosActivos.RowHeadersWidth = 51;
            dgvPrestamosActivos.Size = new Size(870, 200);
            dgvPrestamosActivos.TabIndex = 0;
            // 
            // Pantalla_Bibliotecario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 192);
            ClientSize = new Size(1373, 702);
            Controls.Add(tabControl1);
            Controls.Add(btnInicio);
            Name = "Pantalla_Bibliotecario";
            Text = "Pantalla_Bibliotecario";
            tabControl1.ResumeLayout(false);
            tpGestionLibros.ResumeLayout(false);
            tpGestionLibros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPaginas).EndInit();
            tpAprobarSolicitudes.ResumeLayout(false);
            tpAprobarSolicitudes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSolicitudes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tpRegistrarDevoluciones.ResumeLayout(false);
            tpRegistrarDevoluciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamosActivos).EndInit();
            ResumeLayout(false);
        }
        // Add the missing event handler method for dataGridView1_CellContentClick
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Implement the logic for handling the CellContentClick event here.
            // For now, this can be left empty or include a placeholder comment.
        }
        #endregion

        private TabControl tabControl1;
        private TabPage tpGestionLibros;
        private TabPage tpAprobarSolicitudes;
        private Button btnInicio;
        private TabPage tpRegistrarDevoluciones;
        private ComboBox cmbCategoria;
        private NumericUpDown nudStock;
        private NumericUpDown nudPaginas;
        private TextBox txtISBN;
        private TextBox txtAutor;
        private TextBox txtTitulo;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dgvLibros;
        private Button btnActualizarLibro;
        private Button btnRegistrarLibro;
        private Button btnRechazar;
        private Button btnAprobar;
        private DataGridView dataGridView1;
        private Button btnRegistrarDevolucion;
        private Label label8;
        private Label label7;
        private TextBox txtObservaciones;
        private TextBox txtCondicion;
        private DataGridView dgvPrestamosActivos;
        private Label label9;
        private ComboBox cmbEstadoLibro;
        private Label label10;
        private DateTimePicker dtpFechaDevolucion;
        private DateTimePicker dtpFechaPrestamo;
        private Label label12;
        private Label label11;
        private DataGridView dgvSolicitudes;
        private Label label13;
    }
}