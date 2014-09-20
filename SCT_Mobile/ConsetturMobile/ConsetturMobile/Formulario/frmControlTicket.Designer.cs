namespace ConsetturMobile
{
    partial class frmControlTicket
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
            this.txtNumControl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVehiculo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChofer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreChofer = new System.Windows.Forms.TextBox();
            this.txtCentro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.txtNumVehiculo = new System.Windows.Forms.Label();
            this.btnBusVacio = new System.Windows.Forms.Button();
            this.lblEstadoCabecera = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEscanear = new System.Windows.Forms.Button();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.lblNumBus = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTarifa = new System.Windows.Forms.TextBox();
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.btnCerrarControlTicket = new System.Windows.Forms.Button();
            this.txtNroPasajeros = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblEstadoDetalle = new System.Windows.Forms.Label();
            this.btnOtros = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblMensajesAsientos = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lvDetalle = new System.Windows.Forms.ListView();
            this.colNumLectura = new System.Windows.Forms.ColumnHeader();
            this.colCodBarras = new System.Windows.Forms.ColumnHeader();
            this.colNumControl = new System.Windows.Forms.ColumnHeader();
            this.pnlError = new System.Windows.Forms.Panel();
            this.btnCerrarError = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.pnlEliminar = new System.Windows.Forms.Panel();
            this.lblEstadoEliminar = new System.Windows.Forms.Label();
            this.btnAceptarEliminar = new System.Windows.Forms.Button();
            this.btnCancelarEliminar = new System.Windows.Forms.Button();
            this.txtCodTicketEliminar = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.teclado = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.btnteclado = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer();
            this.lblNombreServicio = new System.Windows.Forms.Label();
            this.pnlCabecera.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            this.pnlError.SuspendLayout();
            this.pnlEliminar.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNumControl
            // 
            this.txtNumControl.BackColor = System.Drawing.SystemColors.Control;
            this.txtNumControl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtNumControl.Location = new System.Drawing.Point(78, 47);
            this.txtNumControl.MaxLength = 15;
            this.txtNumControl.Name = "txtNumControl";
            this.txtNumControl.ReadOnly = true;
            this.txtNumControl.Size = new System.Drawing.Size(151, 19);
            this.txtNumControl.TabIndex = 3;
            this.txtNumControl.TextChanged += new System.EventHandler(this.txtNumControl_TextChanged);
            this.txtNumControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumControl_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(7, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.Text = "N° Control:";
            // 
            // txtVehiculo
            // 
            this.txtVehiculo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtVehiculo.Location = new System.Drawing.Point(78, 22);
            this.txtVehiculo.MaxLength = 14;
            this.txtVehiculo.Name = "txtVehiculo";
            this.txtVehiculo.Size = new System.Drawing.Size(101, 19);
            this.txtVehiculo.TabIndex = 6;
            this.txtVehiculo.TextChanged += new System.EventHandler(this.txtVehiculo_TextChanged);
            this.txtVehiculo.GotFocus += new System.EventHandler(this.txtVehiculo_GotFocus);
            this.txtVehiculo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVehiculo_KeyPress);
            this.txtVehiculo.LostFocus += new System.EventHandler(this.txtVehiculo_LostFocus);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.Text = "Vehículo:";
            // 
            // txtChofer
            // 
            this.txtChofer.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtChofer.Location = new System.Drawing.Point(78, 70);
            this.txtChofer.MaxLength = 14;
            this.txtChofer.Name = "txtChofer";
            this.txtChofer.ReadOnly = true;
            this.txtChofer.Size = new System.Drawing.Size(151, 19);
            this.txtChofer.TabIndex = 9;
           
            this.txtChofer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChofer_KeyPress);
            
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(7, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.Text = "Chofer:";
            // 
            // txtNombreChofer
            // 
            this.txtNombreChofer.BackColor = System.Drawing.SystemColors.Control;
            this.txtNombreChofer.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtNombreChofer.Location = new System.Drawing.Point(7, 94);
            this.txtNombreChofer.MaxLength = 15;
            this.txtNombreChofer.Name = "txtNombreChofer";
            this.txtNombreChofer.ReadOnly = true;
            this.txtNombreChofer.Size = new System.Drawing.Size(222, 19);
            this.txtNombreChofer.TabIndex = 11;
            this.txtNombreChofer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreChofer_KeyPress);
            // 
            // txtCentro
            // 
            this.txtCentro.BackColor = System.Drawing.SystemColors.Control;
            this.txtCentro.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtCentro.Location = new System.Drawing.Point(78, 117);
            this.txtCentro.MaxLength = 15;
            this.txtCentro.Name = "txtCentro";
            this.txtCentro.ReadOnly = true;
            this.txtCentro.Size = new System.Drawing.Size(151, 19);
            this.txtCentro.TabIndex = 13;
            this.txtCentro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCentro_KeyPress);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(7, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 18);
            this.label4.Text = "Centro:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.SystemColors.Control;
            this.txtUsuario.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtUsuario.Location = new System.Drawing.Point(78, 140);
            this.txtUsuario.MaxLength = 15;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(151, 19);
            this.txtUsuario.TabIndex = 16;
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(7, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 18);
            this.label5.Text = "Usuario:";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Enabled = false;
            this.btnCerrar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.Location = new System.Drawing.Point(9, 201);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(107, 30);
            this.btnCerrar.TabIndex = 19;
            this.btnCerrar.Text = "Cerrar Control";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.Location = new System.Drawing.Point(122, 201);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 30);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar Control";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlCabecera.Controls.Add(this.txtNumVehiculo);
            this.pnlCabecera.Controls.Add(this.btnBusVacio);
            this.pnlCabecera.Controls.Add(this.txtNumControl);
            this.pnlCabecera.Controls.Add(this.txtVehiculo);
            this.pnlCabecera.Controls.Add(this.lblEstadoCabecera);
            this.pnlCabecera.Controls.Add(this.btnLimpiar);
            this.pnlCabecera.Controls.Add(this.btnSalir);
            this.pnlCabecera.Controls.Add(this.btnEscanear);
            this.pnlCabecera.Controls.Add(this.label1);
            this.pnlCabecera.Controls.Add(this.txtChofer);
            this.pnlCabecera.Controls.Add(this.txtCentro);
            this.pnlCabecera.Controls.Add(this.btnCerrar);
            this.pnlCabecera.Controls.Add(this.btnCancelar);
            this.pnlCabecera.Controls.Add(this.txtUsuario);
            this.pnlCabecera.Controls.Add(this.label2);
            this.pnlCabecera.Controls.Add(this.label5);
            this.pnlCabecera.Controls.Add(this.label3);
            this.pnlCabecera.Controls.Add(this.label4);
            this.pnlCabecera.Controls.Add(this.txtNombreChofer);
            this.pnlCabecera.Location = new System.Drawing.Point(0, 0);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(240, 268);
            // 
            // txtNumVehiculo
            // 
            this.txtNumVehiculo.BackColor = System.Drawing.SystemColors.Control;
            this.txtNumVehiculo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtNumVehiculo.Location = new System.Drawing.Point(183, 22);
            this.txtNumVehiculo.Name = "txtNumVehiculo";
            this.txtNumVehiculo.Size = new System.Drawing.Size(46, 19);
            this.txtNumVehiculo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnBusVacio
            // 
            this.btnBusVacio.Enabled = false;
            this.btnBusVacio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnBusVacio.Location = new System.Drawing.Point(9, 235);
            this.btnBusVacio.Name = "btnBusVacio";
            this.btnBusVacio.Size = new System.Drawing.Size(107, 30);
            this.btnBusVacio.TabIndex = 43;
            this.btnBusVacio.Text = "Bus Vacío";
         
            // 
            // lblEstadoCabecera
            // 
            this.lblEstadoCabecera.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblEstadoCabecera.ForeColor = System.Drawing.Color.Green;
            this.lblEstadoCabecera.Location = new System.Drawing.Point(114, 3);
            this.lblEstadoCabecera.Name = "lblEstadoCabecera";
            this.lblEstadoCabecera.Size = new System.Drawing.Size(115, 20);
            this.lblEstadoCabecera.Text = "Online";
            this.lblEstadoCabecera.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.Location = new System.Drawing.Point(9, 166);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(107, 30);
            this.btnLimpiar.TabIndex = 37;
            this.btnLimpiar.Text = "Nuevo Control";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSalir.Location = new System.Drawing.Point(122, 235);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(107, 30);
            this.btnSalir.TabIndex = 31;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEscanear
            // 
            this.btnEscanear.Enabled = false;
            this.btnEscanear.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnEscanear.Location = new System.Drawing.Point(122, 166);
            this.btnEscanear.Name = "btnEscanear";
            this.btnEscanear.Size = new System.Drawing.Size(107, 30);
            this.btnEscanear.TabIndex = 25;
            this.btnEscanear.Text = "Leer Ticket";
            this.btnEscanear.Click += new System.EventHandler(this.btnEscanear_Click);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BackColor = System.Drawing.Color.Yellow;
            this.pnlDetalle.Controls.Add(this.lblNumBus);
            this.pnlDetalle.Controls.Add(this.label11);
            this.pnlDetalle.Controls.Add(this.txtTarifa);
            this.pnlDetalle.Controls.Add(this.txtCodigoBarras);
            this.pnlDetalle.Controls.Add(this.btnCerrarControlTicket);
            this.pnlDetalle.Controls.Add(this.txtNroPasajeros);
            this.pnlDetalle.Controls.Add(this.label10);
            this.pnlDetalle.Controls.Add(this.lblEstadoDetalle);
            this.pnlDetalle.Controls.Add(this.btnOtros);
            this.pnlDetalle.Controls.Add(this.btnRegresar);
            this.pnlDetalle.Controls.Add(this.txtTotal);
            this.pnlDetalle.Controls.Add(this.lblMensajesAsientos);
            this.pnlDetalle.Controls.Add(this.label8);
            this.pnlDetalle.Controls.Add(this.btnEliminar);
            this.pnlDetalle.Controls.Add(this.label6);
            this.pnlDetalle.Controls.Add(this.lvDetalle);
            this.pnlDetalle.Location = new System.Drawing.Point(247, 0);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(240, 268);
            // 
            // lblNumBus
            // 
            this.lblNumBus.BackColor = System.Drawing.SystemColors.Control;
            this.lblNumBus.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblNumBus.Location = new System.Drawing.Point(185, 2);
            this.lblNumBus.Name = "lblNumBus";
            this.lblNumBus.Size = new System.Drawing.Size(46, 15);
            this.lblNumBus.Text = "01";
            this.lblNumBus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(138, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 14);
            this.label11.Text = "N° Bus:";
            // 
            // txtTarifa
            // 
            this.txtTarifa.BackColor = System.Drawing.SystemColors.Control;
            this.txtTarifa.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.txtTarifa.Location = new System.Drawing.Point(6, 46);
            this.txtTarifa.MaxLength = 15;
            this.txtTarifa.Multiline = true;
            this.txtTarifa.Name = "txtTarifa";
            this.txtTarifa.ReadOnly = true;
            this.txtTarifa.Size = new System.Drawing.Size(225, 59);
            this.txtTarifa.TabIndex = 8;
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtCodigoBarras.Location = new System.Drawing.Point(6, 18);
            this.txtCodigoBarras.MaxLength = 20;
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(225, 26);
            this.txtCodigoBarras.TabIndex = 5;
            this.txtCodigoBarras.TextChanged += new System.EventHandler(this.txtCodigoBarras_TextChanged);
            this.txtCodigoBarras.GotFocus += new System.EventHandler(this.txtCodigoBarras_GotFocus);
            this.txtCodigoBarras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoBarras_KeyPress);
            this.txtCodigoBarras.LostFocus += new System.EventHandler(this.txtCodigoBarras_LostFocus);
            // 
            // btnCerrarControlTicket
            // 
            this.btnCerrarControlTicket.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnCerrarControlTicket.Location = new System.Drawing.Point(6, 203);
            this.btnCerrarControlTicket.Name = "btnCerrarControlTicket";
            this.btnCerrarControlTicket.Size = new System.Drawing.Size(107, 28);
            this.btnCerrarControlTicket.TabIndex = 32;
            this.btnCerrarControlTicket.Text = "Cerrar Control";
            this.btnCerrarControlTicket.Click += new System.EventHandler(this.btnCerrarControlTicket_Click);
            // 
            // txtNroPasajeros
            // 
            this.txtNroPasajeros.BackColor = System.Drawing.SystemColors.Control;
            this.txtNroPasajeros.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.txtNroPasajeros.Location = new System.Drawing.Point(152, 139);
            this.txtNroPasajeros.MaxLength = 20;
            this.txtNroPasajeros.Name = "txtNroPasajeros";
            this.txtNroPasajeros.ReadOnly = true;
            this.txtNroPasajeros.Size = new System.Drawing.Size(79, 29);
            this.txtNroPasajeros.TabIndex = 26;
            this.txtNroPasajeros.Text = "29";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(6, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 15);
            this.label10.Text = "Total Tickets Leidos:";
            // 
            // lblEstadoDetalle
            // 
            this.lblEstadoDetalle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblEstadoDetalle.ForeColor = System.Drawing.Color.Green;
            this.lblEstadoDetalle.Location = new System.Drawing.Point(100, 51);
            this.lblEstadoDetalle.Name = "lblEstadoDetalle";
            this.lblEstadoDetalle.Size = new System.Drawing.Size(22, 20);
            this.lblEstadoDetalle.Text = "Online";
            this.lblEstadoDetalle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnOtros
            // 
            this.btnOtros.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnOtros.Location = new System.Drawing.Point(124, 235);
            this.btnOtros.Name = "btnOtros";
            this.btnOtros.Size = new System.Drawing.Size(107, 28);
            this.btnOtros.TabIndex = 22;
            this.btnOtros.Text = "Otros";
          
            // 
            // btnRegresar
            // 
            this.btnRegresar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnRegresar.Location = new System.Drawing.Point(6, 235);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(107, 28);
            this.btnRegresar.TabIndex = 21;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotal.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.txtTotal.Location = new System.Drawing.Point(152, 107);
            this.txtTotal.MaxLength = 20;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(79, 29);
            this.txtTotal.TabIndex = 7;
            this.txtTotal.Text = "4";
            // 
            // lblMensajesAsientos
            // 
            this.lblMensajesAsientos.BackColor = System.Drawing.Color.Red;
            this.lblMensajesAsientos.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.lblMensajesAsientos.ForeColor = System.Drawing.Color.White;
            this.lblMensajesAsientos.Location = new System.Drawing.Point(6, 171);
            this.lblMensajesAsientos.Name = "lblMensajesAsientos";
            this.lblMensajesAsientos.Size = new System.Drawing.Size(225, 27);
            this.lblMensajesAsientos.Text = "QUEDAN 25 ASIENTOS";
            this.lblMensajesAsientos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(6, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 15);
            this.label8.Text = "Capacidad del Bus:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.Location = new System.Drawing.Point(124, 203);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(107, 28);
            this.btnEliminar.TabIndex = 20;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(8, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 14);
            this.label6.Text = "Codigo Barras:";
            // 
            // lvDetalle
            // 
            this.lvDetalle.Columns.Add(this.colNumLectura);
            this.lvDetalle.Columns.Add(this.colCodBarras);
            this.lvDetalle.Columns.Add(this.colNumControl);
            this.lvDetalle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lvDetalle.Location = new System.Drawing.Point(8, 174);
            this.lvDetalle.Name = "lvDetalle";
            this.lvDetalle.Size = new System.Drawing.Size(69, 21);
            this.lvDetalle.TabIndex = 0;
            this.lvDetalle.View = System.Windows.Forms.View.Details;
            this.lvDetalle.Visible = false;
            // 
            // colNumLectura
            // 
            this.colNumLectura.Text = "N°";
            this.colNumLectura.Width = 55;
            // 
            // colCodBarras
            // 
            this.colCodBarras.Text = "Cod. Barras";
            this.colCodBarras.Width = 121;
            // 
            // colNumControl
            // 
            this.colNumControl.Text = "N° Control";
            this.colNumControl.Width = 91;
            // 
            // pnlError
            // 
            this.pnlError.BackColor = System.Drawing.Color.Crimson;
            this.pnlError.Controls.Add(this.btnCerrarError);
            this.pnlError.Controls.Add(this.lblMensaje);
            this.pnlError.Location = new System.Drawing.Point(739, 47);
            this.pnlError.Name = "pnlError";
            this.pnlError.Size = new System.Drawing.Size(234, 247);
            // 
            // btnCerrarError
            // 
            this.btnCerrarError.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnCerrarError.Location = new System.Drawing.Point(161, 220);
            this.btnCerrarError.Name = "btnCerrarError";
            this.btnCerrarError.Size = new System.Drawing.Size(70, 25);
            this.btnCerrarError.TabIndex = 20;
            this.btnCerrarError.Text = "Cerrar (X)";
            this.btnCerrarError.Click += new System.EventHandler(this.btnCerrarError_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblMensaje.ForeColor = System.Drawing.Color.White;
            this.lblMensaje.Location = new System.Drawing.Point(3, 4);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(228, 213);
            this.lblMensaje.Text = "Mensaje";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlEliminar
            // 
            this.pnlEliminar.BackColor = System.Drawing.Color.GreenYellow;
            this.pnlEliminar.Controls.Add(this.lblEstadoEliminar);
            this.pnlEliminar.Controls.Add(this.btnAceptarEliminar);
            this.pnlEliminar.Controls.Add(this.btnCancelarEliminar);
            this.pnlEliminar.Controls.Add(this.txtCodTicketEliminar);
            this.pnlEliminar.Controls.Add(this.label9);
            this.pnlEliminar.Location = new System.Drawing.Point(494, 0);
            this.pnlEliminar.Name = "pnlEliminar";
            this.pnlEliminar.Size = new System.Drawing.Size(240, 268);
            // 
            // lblEstadoEliminar
            // 
            this.lblEstadoEliminar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblEstadoEliminar.ForeColor = System.Drawing.Color.Green;
            this.lblEstadoEliminar.Location = new System.Drawing.Point(114, 3);
            this.lblEstadoEliminar.Name = "lblEstadoEliminar";
            this.lblEstadoEliminar.Size = new System.Drawing.Size(115, 20);
            this.lblEstadoEliminar.Text = "Online";
            this.lblEstadoEliminar.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnAceptarEliminar
            // 
            this.btnAceptarEliminar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnAceptarEliminar.Location = new System.Drawing.Point(9, 157);
            this.btnAceptarEliminar.Name = "btnAceptarEliminar";
            this.btnAceptarEliminar.Size = new System.Drawing.Size(107, 30);
            this.btnAceptarEliminar.TabIndex = 39;
            this.btnAceptarEliminar.Text = "Aceptar";
          
            // 
            // btnCancelarEliminar
            // 
            this.btnCancelarEliminar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnCancelarEliminar.Location = new System.Drawing.Point(122, 157);
            this.btnCancelarEliminar.Name = "btnCancelarEliminar";
            this.btnCancelarEliminar.Size = new System.Drawing.Size(107, 30);
            this.btnCancelarEliminar.TabIndex = 38;
            this.btnCancelarEliminar.Text = "Cancelar";
           
            // 
            // txtCodTicketEliminar
            // 
            this.txtCodTicketEliminar.Location = new System.Drawing.Point(9, 104);
            this.txtCodTicketEliminar.MaxLength = 20;
            this.txtCodTicketEliminar.Name = "txtCodTicketEliminar";
            this.txtCodTicketEliminar.Size = new System.Drawing.Size(220, 21);
            this.txtCodTicketEliminar.TabIndex = 7;
          
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(9, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 18);
            this.label9.Text = "Cod. Ticket:";
            // 
            // btnteclado
            // 
            this.btnteclado.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnteclado.Location = new System.Drawing.Point(9, 271);
            this.btnteclado.Name = "btnteclado";
            this.btnteclado.Size = new System.Drawing.Size(70, 21);
            this.btnteclado.TabIndex = 43;
            this.btnteclado.Text = "Teclado";
            this.btnteclado.Click += new System.EventHandler(this.btnteclado_Click);
            // 
            // lblNombreServicio
            // 
            this.lblNombreServicio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblNombreServicio.ForeColor = System.Drawing.Color.Green;
            this.lblNombreServicio.Location = new System.Drawing.Point(97, 271);
            this.lblNombreServicio.Name = "lblNombreServicio";
            this.lblNombreServicio.Size = new System.Drawing.Size(132, 20);
            this.lblNombreServicio.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmControlTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1370, 294);
            this.ControlBox = false;
            this.Controls.Add(this.lblNombreServicio);
            this.Controls.Add(this.btnteclado);
            this.Controls.Add(this.pnlError);
            this.Controls.Add(this.pnlEliminar);
            this.Controls.Add(this.pnlDetalle);
            this.Controls.Add(this.pnlCabecera);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Name = "frmControlTicket";
            this.Text = "Control Ticket";
            this.Load += new System.EventHandler(this.frmControlTicket_Load);
            this.pnlCabecera.ResumeLayout(false);
            this.pnlDetalle.ResumeLayout(false);
            this.pnlError.ResumeLayout(false);
            this.pnlEliminar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVehiculo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChofer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreChofer;
        private System.Windows.Forms.TextBox txtCentro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.ListView lvDetalle;
        private System.Windows.Forms.TextBox txtTarifa;
        private System.Windows.Forms.Label lblMensajesAsientos;
        private System.Windows.Forms.TextBox txtCodigoBarras;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader colCodBarras;
        private System.Windows.Forms.ColumnHeader colNumControl;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEscanear;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnOtros;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Panel pnlError;
        private System.Windows.Forms.Button btnCerrarError;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColumnHeader colNumLectura;
        private System.Windows.Forms.Panel pnlEliminar;
        private System.Windows.Forms.TextBox txtCodTicketEliminar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAceptarEliminar;
        private System.Windows.Forms.Button btnCancelarEliminar;
        private System.Windows.Forms.Label lblEstadoCabecera;
        private System.Windows.Forms.Label lblEstadoEliminar;
        private System.Windows.Forms.Label lblEstadoDetalle;
        private System.Windows.Forms.TextBox txtNroPasajeros;
        private System.Windows.Forms.Label label10;
        private Microsoft.WindowsCE.Forms.InputPanel teclado;
        private System.Windows.Forms.Button btnteclado;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnBusVacio;
        private System.Windows.Forms.Button btnCerrarControlTicket;
        private System.Windows.Forms.Label txtNumVehiculo;
        private System.Windows.Forms.Label lblNumBus;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblNombreServicio;
    }
}