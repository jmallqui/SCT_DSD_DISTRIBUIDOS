namespace ConsetturMobile
{
    partial class frmConsulta
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
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cboCentros = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnListar = new System.Windows.Forms.Button();
            this.lvDetalle = new System.Windows.Forms.ListView();
            this.colContador = new System.Windows.Forms.ColumnHeader();
            this.colIdTx = new System.Windows.Forms.ColumnHeader();
            this.colFecha = new System.Windows.Forms.ColumnHeader();
            this.colHoraInicio = new System.Windows.Forms.ColumnHeader();
            this.colHoraFin = new System.Windows.Forms.ColumnHeader();
            this.colTiempo = new System.Windows.Forms.ColumnHeader();
            this.colCantidad = new System.Windows.Forms.ColumnHeader();
            this.colPax = new System.Windows.Forms.ColumnHeader();
            this.colTotal = new System.Windows.Forms.ColumnHeader();
            this.colNumBus = new System.Windows.Forms.ColumnHeader();
            this.colPlaca = new System.Windows.Forms.ColumnHeader();
            this.colConductor = new System.Windows.Forms.ColumnHeader();
            this.colUsuario = new System.Windows.Forms.ColumnHeader();
            this.colEstado = new System.Windows.Forms.ColumnHeader();
            this.txtViajes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblEstadoConsulta = new System.Windows.Forms.Label();
            this.txtTotalTickets = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalPax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalPasajeros = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(60, 23);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(76, 20);
            this.dtpFecha.TabIndex = 0;
            this.dtpFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFecha_KeyPress);
            // 
            // cboCentros
            // 
            this.cboCentros.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cboCentros.Location = new System.Drawing.Point(60, 1);
            this.cboCentros.Name = "cboCentros";
            this.cboCentros.Size = new System.Drawing.Size(176, 20);
            this.cboCentros.TabIndex = 11;
            this.cboCentros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCentros_KeyPress);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(4, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 18);
            this.label6.Text = "Centros:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.Text = "Fecha:";
            // 
            // btnListar
            // 
            this.btnListar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnListar.Location = new System.Drawing.Point(155, 23);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(81, 21);
            this.btnListar.TabIndex = 23;
            this.btnListar.Text = "Listar";
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // lvDetalle
            // 
            this.lvDetalle.Columns.Add(this.colContador);
            this.lvDetalle.Columns.Add(this.colIdTx);
            this.lvDetalle.Columns.Add(this.colFecha);
            this.lvDetalle.Columns.Add(this.colHoraInicio);
            this.lvDetalle.Columns.Add(this.colHoraFin);
            this.lvDetalle.Columns.Add(this.colTiempo);
            this.lvDetalle.Columns.Add(this.colCantidad);
            this.lvDetalle.Columns.Add(this.colPax);
            this.lvDetalle.Columns.Add(this.colTotal);
            this.lvDetalle.Columns.Add(this.colNumBus);
            this.lvDetalle.Columns.Add(this.colPlaca);
            this.lvDetalle.Columns.Add(this.colConductor);
            this.lvDetalle.Columns.Add(this.colUsuario);
            this.lvDetalle.Columns.Add(this.colEstado);
            this.lvDetalle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lvDetalle.FullRowSelect = true;
            this.lvDetalle.Location = new System.Drawing.Point(4, 45);
            this.lvDetalle.Name = "lvDetalle";
            this.lvDetalle.Size = new System.Drawing.Size(232, 173);
            this.lvDetalle.TabIndex = 24;
            this.lvDetalle.View = System.Windows.Forms.View.Details;
            // 
            // colContador
            // 
            this.colContador.Text = "N°";
            this.colContador.Width = 50;
            // 
            // colIdTx
            // 
            this.colIdTx.Text = " N° Control";
            this.colIdTx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colIdTx.Width = 91;
            // 
            // colFecha
            // 
            this.colFecha.Text = "Fecha";
            this.colFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colFecha.Width = 135;
            // 
            // colHoraInicio
            // 
            this.colHoraInicio.Text = "H. Inicio";
            this.colHoraInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHoraInicio.Width = 70;
            // 
            // colHoraFin
            // 
            this.colHoraFin.Text = "H. Fin";
            this.colHoraFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHoraFin.Width = 70;
            // 
            // colTiempo
            // 
            this.colTiempo.Text = "Tiempo";
            this.colTiempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colTiempo.Width = 50;
            // 
            // colCantidad
            // 
            this.colCantidad.Text = "Psjero";
            this.colCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCantidad.Width = 60;
            // 
            // colPax
            // 
            this.colPax.Text = "Free";
            this.colPax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colPax.Width = 60;
            // 
            // colTotal
            // 
            this.colTotal.Text = "Pax";
            this.colTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTotal.Width = 60;
            // 
            // colNumBus
            // 
            this.colNumBus.Text = "N° Bus";
            this.colNumBus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colNumBus.Width = 50;
            // 
            // colPlaca
            // 
            this.colPlaca.Text = "Placa";
            this.colPlaca.Width = 70;
            // 
            // colConductor
            // 
            this.colConductor.Text = "Conductor";
            this.colConductor.Width = 100;
            // 
            // colUsuario
            // 
            this.colUsuario.Text = "Usuario";
            this.colUsuario.Width = 100;
            // 
            // colEstado
            // 
            this.colEstado.Text = "Estado";
            this.colEstado.Width = 100;
            // 
            // txtViajes
            // 
            this.txtViajes.BackColor = System.Drawing.SystemColors.Control;
            this.txtViajes.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtViajes.ForeColor = System.Drawing.Color.Black;
            this.txtViajes.Location = new System.Drawing.Point(61, 241);
            this.txtViajes.MaxLength = 20;
            this.txtViajes.Name = "txtViajes";
            this.txtViajes.ReadOnly = true;
            this.txtViajes.Size = new System.Drawing.Size(56, 19);
            this.txtViajes.TabIndex = 26;
            this.txtViajes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotal_KeyPress);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(0, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 15);
            this.label8.Text = "N° Viajes:";
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSalir.Location = new System.Drawing.Point(3, 262);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(114, 30);
            this.btnSalir.TabIndex = 28;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblEstadoConsulta
            // 
            this.lblEstadoConsulta.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblEstadoConsulta.ForeColor = System.Drawing.Color.Green;
            this.lblEstadoConsulta.Location = new System.Drawing.Point(87, 137);
            this.lblEstadoConsulta.Name = "lblEstadoConsulta";
            this.lblEstadoConsulta.Size = new System.Drawing.Size(115, 20);
            this.lblEstadoConsulta.Text = "Online";
            this.lblEstadoConsulta.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTotalTickets
            // 
            this.txtTotalTickets.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalTickets.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtTotalTickets.Location = new System.Drawing.Point(61, 220);
            this.txtTotalTickets.MaxLength = 20;
            this.txtTotalTickets.Name = "txtTotalTickets";
            this.txtTotalTickets.ReadOnly = true;
            this.txtTotalTickets.Size = new System.Drawing.Size(56, 19);
            this.txtTotalTickets.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(0, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.Text = "T. Psjeros:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(117, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 15);
            this.label3.Text = "T. Pax:";
            // 
            // txtTotalPax
            // 
            this.txtTotalPax.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalPax.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtTotalPax.Location = new System.Drawing.Point(179, 220);
            this.txtTotalPax.MaxLength = 20;
            this.txtTotalPax.Name = "txtTotalPax";
            this.txtTotalPax.ReadOnly = true;
            this.txtTotalPax.Size = new System.Drawing.Size(57, 19);
            this.txtTotalPax.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(118, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 15);
            this.label4.Text = "T. Free:";
            // 
            // txtTotalPasajeros
            // 
            this.txtTotalPasajeros.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalPasajeros.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtTotalPasajeros.ForeColor = System.Drawing.Color.Black;
            this.txtTotalPasajeros.Location = new System.Drawing.Point(179, 241);
            this.txtTotalPasajeros.MaxLength = 20;
            this.txtTotalPasajeros.Name = "txtTotalPasajeros";
            this.txtTotalPasajeros.ReadOnly = true;
            this.txtTotalPasajeros.Size = new System.Drawing.Size(57, 19);
            this.txtTotalPasajeros.TabIndex = 45;
            // 
            // frmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.txtViajes);
            this.Controls.Add(this.txtTotalPasajeros);
            this.Controls.Add(this.txtTotalPax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotalTickets);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvDetalle);
            this.Controls.Add(this.cboCentros);
            this.Controls.Add(this.lblEstadoConsulta);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Name = "frmConsulta";
            this.Text = "Consulta";
            this.Load += new System.EventHandler(this.frmConsulta_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmConsulta_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cboCentros;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.ListView lvDetalle;
        private System.Windows.Forms.ColumnHeader colContador;
        private System.Windows.Forms.ColumnHeader colFecha;
        private System.Windows.Forms.ColumnHeader colIdTx;
        private System.Windows.Forms.ColumnHeader colPlaca;
        private System.Windows.Forms.ColumnHeader colConductor;
        private System.Windows.Forms.TextBox txtViajes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ColumnHeader colHoraInicio;
        private System.Windows.Forms.ColumnHeader colHoraFin;
        private System.Windows.Forms.ColumnHeader colTiempo;
        private System.Windows.Forms.ColumnHeader colCantidad;
        private System.Windows.Forms.ColumnHeader colPax;
        private System.Windows.Forms.ColumnHeader colUsuario;
        private System.Windows.Forms.ColumnHeader colEstado;
        private System.Windows.Forms.Label lblEstadoConsulta;
        private System.Windows.Forms.TextBox txtTotalTickets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader colTotal;
        private System.Windows.Forms.ColumnHeader colNumBus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalPax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalPasajeros;
    }
}