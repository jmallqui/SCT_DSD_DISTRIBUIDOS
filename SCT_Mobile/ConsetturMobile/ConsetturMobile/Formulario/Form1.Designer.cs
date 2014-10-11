namespace ConsetturMobile.Formulario
{
    partial class Form1
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.txtTarifa = new System.Windows.Forms.TextBox();
            this.txtMensajes = new System.Windows.Forms.TextBox();
            this.txtCodbarra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTarifa
            // 
            this.txtTarifa.Font = new System.Drawing.Font("Courier New", 14F, System.Drawing.FontStyle.Bold);
            this.txtTarifa.Location = new System.Drawing.Point(1, 50);
            this.txtTarifa.Multiline = true;
            this.txtTarifa.Name = "txtTarifa";
            this.txtTarifa.ReadOnly = true;
            this.txtTarifa.Size = new System.Drawing.Size(237, 94);
            this.txtTarifa.TabIndex = 1;
            // 
            // txtMensajes
            // 
            this.txtMensajes.Font = new System.Drawing.Font("Courier New", 14F, System.Drawing.FontStyle.Bold);
            this.txtMensajes.Location = new System.Drawing.Point(0, 150);
            this.txtMensajes.Multiline = true;
            this.txtMensajes.Name = "txtMensajes";
            this.txtMensajes.ReadOnly = true;
            this.txtMensajes.Size = new System.Drawing.Size(237, 115);
            this.txtMensajes.TabIndex = 2;
            // 
            // txtCodbarra
            // 
            this.txtCodbarra.Location = new System.Drawing.Point(4, 23);
            this.txtCodbarra.Name = "txtCodbarra";
            this.txtCodbarra.Size = new System.Drawing.Size(233, 21);
            this.txtCodbarra.TabIndex = 0;
            this.txtCodbarra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodbarra_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 20);
            this.label1.Text = "Nro. Ticket/Codigo de barras:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.txtCodbarra);
            this.Controls.Add(this.txtMensajes);
            this.Controls.Add(this.txtTarifa);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Control de Tickets";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTarifa;
        private System.Windows.Forms.TextBox txtMensajes;
        private System.Windows.Forms.TextBox txtCodbarra;
        private System.Windows.Forms.Label label1;
    }
}