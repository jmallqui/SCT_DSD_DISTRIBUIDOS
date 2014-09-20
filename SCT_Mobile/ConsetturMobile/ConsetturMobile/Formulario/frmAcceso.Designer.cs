namespace ConsetturMobile
{
    partial class frmAcceso
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAcceso));
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlAcceso = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblEstadoAcceso = new System.Windows.Forms.Label();
            this.pnlCentros = new System.Windows.Forms.Panel();
            this.lbCentros = new System.Windows.Forms.ListBox();
            this.lblEstadoCentros = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnCancelarCentro = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblEstadoMenu = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnConsultas = new System.Windows.Forms.Button();
            this.lblUsuarioMenu = new System.Windows.Forms.Label();
            this.btnControlTicket = new System.Windows.Forms.Button();
            this.lblCentroMenu = new System.Windows.Forms.Label();
            this.btnSincronizar = new System.Windows.Forms.Button();
            this.teclado = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.btnteclado = new System.Windows.Forms.Button();
            this.btnSalirServicio = new System.Windows.Forms.Button();
            this.pnlAcceso.SuspendLayout();
            this.pnlCentros.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(240, 71);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.DoubleClick += new System.EventHandler(this.pbLogo_DoubleClick);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(93, 113);
            this.txtUsuario.MaxLength = 15;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(134, 21);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.GotFocus += new System.EventHandler(this.txtUsuario_GotFocus);
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            this.txtUsuario.LostFocus += new System.EventHandler(this.txtUsuario_LostFocus);
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(93, 140);
            this.txtContrasena.MaxLength = 15;
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.Size = new System.Drawing.Size(134, 21);
            this.txtContrasena.TabIndex = 2;
            this.txtContrasena.GotFocus += new System.EventHandler(this.txtContrasena_GotFocus);
            this.txtContrasena.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContrasena_KeyPress);
            this.txtContrasena.LostFocus += new System.EventHandler(this.txtContrasena_LostFocus);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(122, 194);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(105, 41);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(11, 194);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 41);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(11, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(11, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.Text = "Contraseña:";
            // 
            // pnlAcceso
            // 
            this.pnlAcceso.BackColor = System.Drawing.Color.White;
            this.pnlAcceso.Controls.Add(this.label7);
            this.pnlAcceso.Controls.Add(this.lblEstadoAcceso);
            this.pnlAcceso.Controls.Add(this.txtUsuario);
            this.pnlAcceso.Controls.Add(this.txtContrasena);
            this.pnlAcceso.Controls.Add(this.pbLogo);
            this.pnlAcceso.Controls.Add(this.btnCancelar);
            this.pnlAcceso.Controls.Add(this.label2);
            this.pnlAcceso.Controls.Add(this.btnAceptar);
            this.pnlAcceso.Controls.Add(this.label1);
            this.pnlAcceso.Location = new System.Drawing.Point(0, 0);
            this.pnlAcceso.Name = "pnlAcceso";
            this.pnlAcceso.Size = new System.Drawing.Size(240, 268);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(11, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 18);
            this.label7.Text = "v.3.A";
            // 
            // lblEstadoAcceso
            // 
            this.lblEstadoAcceso.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblEstadoAcceso.ForeColor = System.Drawing.Color.Black;
            this.lblEstadoAcceso.Location = new System.Drawing.Point(112, 82);
            this.lblEstadoAcceso.Name = "lblEstadoAcceso";
            this.lblEstadoAcceso.Size = new System.Drawing.Size(115, 20);
            this.lblEstadoAcceso.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlCentros
            // 
            this.pnlCentros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlCentros.Controls.Add(this.lbCentros);
            this.pnlCentros.Controls.Add(this.lblEstadoCentros);
            this.pnlCentros.Controls.Add(this.label4);
            this.pnlCentros.Controls.Add(this.lblUsuario);
            this.pnlCentros.Controls.Add(this.btnCancelarCentro);
            this.pnlCentros.Controls.Add(this.btnContinuar);
            this.pnlCentros.Controls.Add(this.label3);
            this.pnlCentros.Location = new System.Drawing.Point(246, 76);
            this.pnlCentros.Name = "pnlCentros";
            this.pnlCentros.Size = new System.Drawing.Size(240, 192);
            // 
            // lbCentros
            // 
            this.lbCentros.Location = new System.Drawing.Point(10, 24);
            this.lbCentros.Name = "lbCentros";
            this.lbCentros.Size = new System.Drawing.Size(220, 100);
            this.lbCentros.TabIndex = 0;
            // 
            // lblEstadoCentros
            // 
            this.lblEstadoCentros.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblEstadoCentros.ForeColor = System.Drawing.Color.Black;
            this.lblEstadoCentros.Location = new System.Drawing.Point(115, 5);
            this.lblEstadoCentros.Name = "lblEstadoCentros";
            this.lblEstadoCentros.Size = new System.Drawing.Size(115, 20);
            this.lblEstadoCentros.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.Text = "Usuario:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.Crimson;
            this.lblUsuario.Location = new System.Drawing.Point(61, 127);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(169, 25);
            // 
            // btnCancelarCentro
            // 
            this.btnCancelarCentro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnCancelarCentro.Location = new System.Drawing.Point(10, 156);
            this.btnCancelarCentro.Name = "btnCancelarCentro";
            this.btnCancelarCentro.Size = new System.Drawing.Size(105, 30);
            this.btnCancelarCentro.TabIndex = 10;
            this.btnCancelarCentro.Text = "Salir";
            this.btnCancelarCentro.Click += new System.EventHandler(this.btnCancelarCentro_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnContinuar.Location = new System.Drawing.Point(125, 156);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(105, 30);
            this.btnContinuar.TabIndex = 9;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(10, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.Text = "Centros:";
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMenu.Controls.Add(this.lblEstadoMenu);
            this.pnlMenu.Controls.Add(this.label6);
            this.pnlMenu.Controls.Add(this.label5);
            this.pnlMenu.Controls.Add(this.btnSalir);
            this.pnlMenu.Controls.Add(this.btnConsultas);
            this.pnlMenu.Controls.Add(this.lblUsuarioMenu);
            this.pnlMenu.Controls.Add(this.btnControlTicket);
            this.pnlMenu.Controls.Add(this.lblCentroMenu);
            this.pnlMenu.Controls.Add(this.btnSincronizar);
            this.pnlMenu.Location = new System.Drawing.Point(492, 76);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(240, 192);
            // 
            // lblEstadoMenu
            // 
            this.lblEstadoMenu.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblEstadoMenu.ForeColor = System.Drawing.Color.Black;
            this.lblEstadoMenu.Location = new System.Drawing.Point(113, 5);
            this.lblEstadoMenu.Name = "lblEstadoMenu";
            this.lblEstadoMenu.Size = new System.Drawing.Size(115, 20);
            this.lblEstadoMenu.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.Text = "Centro:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 25);
            this.label5.Text = "Usuario:";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(123, 82);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(105, 50);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnConsultas
            // 
            this.btnConsultas.Location = new System.Drawing.Point(123, 25);
            this.btnConsultas.Name = "btnConsultas";
            this.btnConsultas.Size = new System.Drawing.Size(105, 50);
            this.btnConsultas.TabIndex = 6;
            this.btnConsultas.Text = "Consultas";
            this.btnConsultas.Click += new System.EventHandler(this.btnConsultas_Click);
            // 
            // lblUsuarioMenu
            // 
            this.lblUsuarioMenu.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioMenu.ForeColor = System.Drawing.Color.Crimson;
            this.lblUsuarioMenu.Location = new System.Drawing.Point(66, 139);
            this.lblUsuarioMenu.Name = "lblUsuarioMenu";
            this.lblUsuarioMenu.Size = new System.Drawing.Size(162, 25);
            // 
            // btnControlTicket
            // 
            this.btnControlTicket.Location = new System.Drawing.Point(12, 25);
            this.btnControlTicket.Name = "btnControlTicket";
            this.btnControlTicket.Size = new System.Drawing.Size(105, 50);
            this.btnControlTicket.TabIndex = 5;
            this.btnControlTicket.Text = "Tickets";
            this.btnControlTicket.Click += new System.EventHandler(this.btnControlTicket_Click);
            // 
            // lblCentroMenu
            // 
            this.lblCentroMenu.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblCentroMenu.ForeColor = System.Drawing.Color.Crimson;
            this.lblCentroMenu.Location = new System.Drawing.Point(66, 169);
            this.lblCentroMenu.Name = "lblCentroMenu";
            this.lblCentroMenu.Size = new System.Drawing.Size(164, 16);
            // 
            // btnSincronizar
            // 
            this.btnSincronizar.Location = new System.Drawing.Point(153, 139);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(84, 46);
            this.btnSincronizar.TabIndex = 8;
            this.btnSincronizar.Text = "Sincronizar";
            this.btnSincronizar.Visible = false;
            
            // 
            // btnteclado
            // 
            this.btnteclado.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnteclado.Location = new System.Drawing.Point(11, 272);
            this.btnteclado.Name = "btnteclado";
            this.btnteclado.Size = new System.Drawing.Size(70, 21);
            this.btnteclado.TabIndex = 44;
            this.btnteclado.Text = "Teclado";
            this.btnteclado.Click += new System.EventHandler(this.btnteclado_Click);
            // 
            // btnSalirServicio
            // 
            this.btnSalirServicio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSalirServicio.Location = new System.Drawing.Point(157, 272);
            this.btnSalirServicio.Name = "btnSalirServicio";
            this.btnSalirServicio.Size = new System.Drawing.Size(70, 21);
            this.btnSalirServicio.TabIndex = 48;
            this.btnSalirServicio.Text = "Salir";
            this.btnSalirServicio.Visible = false;
            this.btnSalirServicio.Click += new System.EventHandler(this.btnSalirServicio_Click);
            // 
            // frmAcceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1370, 294);
            this.ControlBox = false;
            this.Controls.Add(this.btnSalirServicio);
            this.Controls.Add(this.btnteclado);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlCentros);
            this.Controls.Add(this.pnlAcceso);
            this.Name = "frmAcceso";
            this.Text = "Acceso";
            this.Load += new System.EventHandler(this.frmAcceso_Load);
            this.Activated += new System.EventHandler(this.frmAcceso_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmAcceso_Closing);
            this.pnlAcceso.ResumeLayout(false);
            this.pnlCentros.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlAcceso;
        private System.Windows.Forms.Panel pnlCentros;
        private System.Windows.Forms.ListBox lbCentros;
        private System.Windows.Forms.Button btnCancelarCentro;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnConsultas;
        private System.Windows.Forms.Button btnControlTicket;
        private System.Windows.Forms.Label lblUsuarioMenu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCentroMenu;
        private System.Windows.Forms.Button btnSincronizar;
        private Microsoft.WindowsCE.Forms.InputPanel teclado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEstadoAcceso;
        private System.Windows.Forms.Label lblEstadoCentros;
        private System.Windows.Forms.Label lblEstadoMenu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnteclado;
        private System.Windows.Forms.Button btnSalirServicio;
    }
}

