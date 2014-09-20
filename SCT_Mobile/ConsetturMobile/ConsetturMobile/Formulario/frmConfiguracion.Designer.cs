namespace ConsetturMobile
{
    partial class frmConfiguracion
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracion));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.pnlClave = new System.Windows.Forms.Panel();
            this.lbltitulo = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCancelarAcceso = new System.Windows.Forms.Button();
            this.btnAceptarAcceso = new System.Windows.Forms.Button();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.pnlParametros = new System.Windows.Forms.Panel();
            this.txtNuevaContrasenia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTiempo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWebService = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelarParametros = new System.Windows.Forms.Button();
            this.btnGrabarParametros = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer();
            this.pnlClave.SuspendLayout();
            this.pnlParametros.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlClave
            // 
            this.pnlClave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlClave.Controls.Add(this.lbltitulo);
            this.pnlClave.Controls.Add(this.PictureBox1);
            this.pnlClave.Controls.Add(this.btnCancelarAcceso);
            this.pnlClave.Controls.Add(this.btnAceptarAcceso);
            this.pnlClave.Controls.Add(this.txtContraseña);
            this.pnlClave.Controls.Add(this.Label2);
            this.pnlClave.Location = new System.Drawing.Point(0, 0);
            this.pnlClave.Name = "pnlClave";
            this.pnlClave.Size = new System.Drawing.Size(240, 268);
            // 
            // lbltitulo
            // 
            this.lbltitulo.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lbltitulo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbltitulo.Location = new System.Drawing.Point(78, 11);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(143, 54);
            this.lbltitulo.Text = "Panel de Configuración";
            this.lbltitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(20, 11);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(52, 54);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // btnCancelarAcceso
            // 
            this.btnCancelarAcceso.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnCancelarAcceso.Location = new System.Drawing.Point(124, 174);
            this.btnCancelarAcceso.Name = "btnCancelarAcceso";
            this.btnCancelarAcceso.Size = new System.Drawing.Size(97, 45);
            this.btnCancelarAcceso.TabIndex = 59;
            this.btnCancelarAcceso.Text = "Salir";
            this.btnCancelarAcceso.Click += new System.EventHandler(this.btnCancelarAcceso_Click);
            // 
            // btnAceptarAcceso
            // 
            this.btnAceptarAcceso.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnAceptarAcceso.Location = new System.Drawing.Point(20, 174);
            this.btnAceptarAcceso.Name = "btnAceptarAcceso";
            this.btnAceptarAcceso.Size = new System.Drawing.Size(97, 45);
            this.btnAceptarAcceso.TabIndex = 58;
            this.btnAceptarAcceso.Text = "Aceptar";
            this.btnAceptarAcceso.Click += new System.EventHandler(this.btnAceptarAcceso_Click);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtContraseña.Location = new System.Drawing.Point(20, 128);
            this.txtContraseña.MaxLength = 50;
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(201, 19);
            this.txtContraseña.TabIndex = 21;
            this.txtContraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContraseña_KeyPress);
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Label2.Location = new System.Drawing.Point(20, 110);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(105, 20);
            this.Label2.Text = "Contraseña:";
            // 
            // pnlParametros
            // 
            this.pnlParametros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlParametros.Controls.Add(this.txtNuevaContrasenia);
            this.pnlParametros.Controls.Add(this.label4);
            this.pnlParametros.Controls.Add(this.txtTiempo);
            this.pnlParametros.Controls.Add(this.label3);
            this.pnlParametros.Controls.Add(this.txtWebService);
            this.pnlParametros.Controls.Add(this.label8);
            this.pnlParametros.Controls.Add(this.label1);
            this.pnlParametros.Controls.Add(this.btnCancelarParametros);
            this.pnlParametros.Controls.Add(this.btnGrabarParametros);
            this.pnlParametros.Location = new System.Drawing.Point(250, 0);
            this.pnlParametros.Name = "pnlParametros";
            this.pnlParametros.Size = new System.Drawing.Size(240, 268);
            // 
            // txtNuevaContrasenia
            // 
            this.txtNuevaContrasenia.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtNuevaContrasenia.Location = new System.Drawing.Point(11, 176);
            this.txtNuevaContrasenia.MaxLength = 50;
            this.txtNuevaContrasenia.Name = "txtNuevaContrasenia";
            this.txtNuevaContrasenia.PasswordChar = '*';
            this.txtNuevaContrasenia.Size = new System.Drawing.Size(218, 19);
            this.txtNuevaContrasenia.TabIndex = 56;
            this.txtNuevaContrasenia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNuevaContrasenia_KeyPress);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(11, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 20);
            this.label4.Text = "Nueva Contraseña:";
            // 
            // txtTiempo
            // 
            this.txtTiempo.Location = new System.Drawing.Point(11, 134);
            this.txtTiempo.MaxLength = 50;
            this.txtTiempo.Name = "txtTiempo";
            this.txtTiempo.Size = new System.Drawing.Size(218, 21);
            this.txtTiempo.TabIndex = 83;
            this.txtTiempo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTiempo_KeyPress);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(11, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 20);
            this.label3.Text = "Tiempo de sincronización (Segundos)";
            // 
            // txtWebService
            // 
            this.txtWebService.Location = new System.Drawing.Point(11, 79);
            this.txtWebService.MaxLength = 250;
            this.txtWebService.Multiline = true;
            this.txtWebService.Name = "txtWebService";
            this.txtWebService.Size = new System.Drawing.Size(218, 37);
            this.txtWebService.TabIndex = 80;
            this.txtWebService.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWebService_KeyPress);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(11, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 20);
            this.label8.Text = "Link web service:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(20, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 54);
            this.label1.Text = "Configuración de Parámetros";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCancelarParametros
            // 
            this.btnCancelarParametros.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnCancelarParametros.Location = new System.Drawing.Point(129, 211);
            this.btnCancelarParametros.Name = "btnCancelarParametros";
            this.btnCancelarParametros.Size = new System.Drawing.Size(100, 45);
            this.btnCancelarParametros.TabIndex = 59;
            this.btnCancelarParametros.Text = "Cancelar";
            this.btnCancelarParametros.Click += new System.EventHandler(this.btnCancelarParametros_Click);
            // 
            // btnGrabarParametros
            // 
            this.btnGrabarParametros.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnGrabarParametros.Location = new System.Drawing.Point(11, 211);
            this.btnGrabarParametros.Name = "btnGrabarParametros";
            this.btnGrabarParametros.Size = new System.Drawing.Size(100, 45);
            this.btnGrabarParametros.TabIndex = 58;
            this.btnGrabarParametros.Text = "Grabar";
            this.btnGrabarParametros.Click += new System.EventHandler(this.btnGrabarParametros_Click);
            // 
            // frmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1386, 268);
            this.ControlBox = false;
            this.Controls.Add(this.pnlParametros);
            this.Controls.Add(this.pnlClave);
            this.Menu = this.mainMenu1;
            this.Name = "frmConfiguracion";
            this.Load += new System.EventHandler(this.frmConfiguracion_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmConfiguracion_Closing);
            this.pnlClave.ResumeLayout(false);
            this.pnlParametros.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnlClave;
        internal System.Windows.Forms.Label lbltitulo;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.TextBox txtContraseña;
        internal System.Windows.Forms.Button btnCancelarAcceso;
        internal System.Windows.Forms.Button btnAceptarAcceso;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel pnlParametros;
        internal System.Windows.Forms.TextBox txtWebService;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button btnCancelarParametros;
        internal System.Windows.Forms.Button btnGrabarParametros;
        internal System.Windows.Forms.TextBox txtTiempo;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtNuevaContrasenia;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
    }
}