namespace GestionBiblioteca
{
    partial class Pantalla_Admin
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
            btnInicio = new Button();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            tpReportes = new TabPage();
            dgvSesion = new DataGridView();
            tpUsuarios = new TabPage();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            txtNombreCompleto = new TextBox();
            dgvUsuarios = new DataGridView();
            btnActualizarUsuario = new Button();
            btnCrearUsuario = new Button();
            chkActivo = new CheckBox();
            cmbRol = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabControl1 = new TabControl();
            tpReportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSesion).BeginInit();
            tpUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // btnInicio
            // 
            btnInicio.Location = new Point(646, 409);
            btnInicio.Margin = new Padding(3, 4, 3, 4);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(151, 31);
            btnInicio.TabIndex = 1;
            btnInicio.Text = "Cerrar Sesión";
            btnInicio.UseVisualStyleBackColor = true;
            btnInicio.Click += btnInicio_Click_1;
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // tpReportes
            // 
            tpReportes.Controls.Add(dgvSesion);
            tpReportes.Location = new Point(4, 29);
            tpReportes.Margin = new Padding(3, 4, 3, 4);
            tpReportes.Name = "tpReportes";
            tpReportes.Padding = new Padding(3, 4, 3, 4);
            tpReportes.Size = new Size(792, 367);
            tpReportes.TabIndex = 1;
            tpReportes.Text = "Ver Sesiones ";
            tpReportes.UseVisualStyleBackColor = true;
            // 
            // dgvSesion
            // 
            dgvSesion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSesion.Location = new Point(6, 8);
            dgvSesion.Margin = new Padding(3, 4, 3, 4);
            dgvSesion.Name = "dgvSesion";
            dgvSesion.RowHeadersWidth = 51;
            dgvSesion.Size = new Size(777, 331);
            dgvSesion.TabIndex = 7;
            // 
            // tpUsuarios
            // 
            tpUsuarios.Controls.Add(txtPassword);
            tpUsuarios.Controls.Add(txtUsername);
            tpUsuarios.Controls.Add(txtNombreCompleto);
            tpUsuarios.Controls.Add(dgvUsuarios);
            tpUsuarios.Controls.Add(btnActualizarUsuario);
            tpUsuarios.Controls.Add(btnCrearUsuario);
            tpUsuarios.Controls.Add(chkActivo);
            tpUsuarios.Controls.Add(cmbRol);
            tpUsuarios.Controls.Add(label4);
            tpUsuarios.Controls.Add(label3);
            tpUsuarios.Controls.Add(label2);
            tpUsuarios.Controls.Add(label1);
            tpUsuarios.Location = new Point(4, 29);
            tpUsuarios.Margin = new Padding(3, 4, 3, 4);
            tpUsuarios.Name = "tpUsuarios";
            tpUsuarios.Padding = new Padding(3, 4, 3, 4);
            tpUsuarios.Size = new Size(792, 367);
            tpUsuarios.TabIndex = 0;
            tpUsuarios.Text = "Crear y gestionar usuarios";
            tpUsuarios.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(153, 91);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(173, 27);
            txtPassword.TabIndex = 14;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(153, 52);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(173, 27);
            txtUsername.TabIndex = 13;
            // 
            // txtNombreCompleto
            // 
            txtNombreCompleto.Location = new Point(153, 13);
            txtNombreCompleto.Margin = new Padding(3, 4, 3, 4);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.Size = new Size(173, 27);
            txtNombreCompleto.TabIndex = 5;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.BackgroundColor = Color.FromArgb(255, 224, 192);
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(3, 129);
            dgvUsuarios.Margin = new Padding(3, 4, 3, 4);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.Size = new Size(781, 200);
            dgvUsuarios.TabIndex = 12;
            // 
            // btnActualizarUsuario
            // 
            btnActualizarUsuario.Location = new Point(589, 56);
            btnActualizarUsuario.Margin = new Padding(3, 4, 3, 4);
            btnActualizarUsuario.Name = "btnActualizarUsuario";
            btnActualizarUsuario.Size = new Size(110, 31);
            btnActualizarUsuario.TabIndex = 11;
            btnActualizarUsuario.Text = "ACTUALIZAR";
            btnActualizarUsuario.UseVisualStyleBackColor = true;
            btnActualizarUsuario.Click += btnActualizarUsuario_Click_1;
            // 
            // btnCrearUsuario
            // 
            btnCrearUsuario.Location = new Point(589, 17);
            btnCrearUsuario.Margin = new Padding(3, 4, 3, 4);
            btnCrearUsuario.Name = "btnCrearUsuario";
            btnCrearUsuario.Size = new Size(110, 31);
            btnCrearUsuario.TabIndex = 10;
            btnCrearUsuario.Text = "CREAR";
            btnCrearUsuario.UseVisualStyleBackColor = true;
            btnCrearUsuario.Click += btnCrearUsuario_Click;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(366, 96);
            chkActivo.Margin = new Padding(3, 4, 3, 4);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(82, 24);
            chkActivo.TabIndex = 9;
            chkActivo.Text = "ACTIVO";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(366, 45);
            cmbRol.Margin = new Padding(3, 4, 3, 4);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(138, 28);
            cmbRol.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(366, 17);
            label4.Name = "label4";
            label4.Size = new Size(31, 20);
            label4.TabIndex = 3;
            label4.Text = "Rol";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 95);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 2;
            label3.Text = "Contraseña";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 56);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 17);
            label1.Name = "label1";
            label1.Size = new Size(134, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre Completo";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpUsuarios);
            tabControl1.Controls.Add(tpReportes);
            tabControl1.Location = new Point(1, 1);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 400);
            tabControl1.TabIndex = 0;
            // 
            // Pantalla_Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(800, 451);
            Controls.Add(btnInicio);
            Controls.Add(tabControl1);
            Name = "Pantalla_Admin";
            Text = "Pantalla_Admin";
            tpReportes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSesion).EndInit();
            tpUsuarios.ResumeLayout(false);
            tpUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnInicio;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private TabPage tpReportes;
        private DataGridView dgvSesion;
        private TabPage tpUsuarios;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private TextBox txtNombreCompleto;
        private DataGridView dgvUsuarios;
        private Button btnActualizarUsuario;
        private Button btnCrearUsuario;
        private CheckBox chkActivo;
        private ComboBox cmbRol;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TabControl tabControl1;
    }
}