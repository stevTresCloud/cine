namespace cine_presentacion_windows
{
    partial class FrmFacturas
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
            this.numFactura = new System.Windows.Forms.TextBox();
            this.lblNumFactura = new System.Windows.Forms.Label();
            this.fechaExpedicion = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.estadoPago = new System.Windows.Forms.ComboBox();
            this.lblEstadoPago = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvListadoEmpleados = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // numFactura
            // 
            this.numFactura.Location = new System.Drawing.Point(22, 32);
            this.numFactura.Name = "numFactura";
            this.numFactura.Size = new System.Drawing.Size(150, 20);
            this.numFactura.TabIndex = 0;
            // 
            // lblNumFactura
            // 
            this.lblNumFactura.AutoSize = true;
            this.lblNumFactura.Location = new System.Drawing.Point(19, 16);
            this.lblNumFactura.Name = "lblNumFactura";
            this.lblNumFactura.Size = new System.Drawing.Size(63, 13);
            this.lblNumFactura.TabIndex = 1;
            this.lblNumFactura.Text = "No Factura:";
            this.lblNumFactura.Click += new System.EventHandler(this.label1_Click);
            // 
            // fechaExpedicion
            // 
            this.fechaExpedicion.CustomFormat = "yyyy-MM-dd";
            this.fechaExpedicion.Location = new System.Drawing.Point(220, 32);
            this.fechaExpedicion.Name = "fechaExpedicion";
            this.fechaExpedicion.Size = new System.Drawing.Size(200, 20);
            this.fechaExpedicion.TabIndex = 2;
            this.fechaExpedicion.ValueChanged += new System.EventHandler(this.fechaExpedicion_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fecha Factura";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // estadoPago
            // 
            this.estadoPago.FormattingEnabled = true;
            this.estadoPago.Location = new System.Drawing.Point(463, 31);
            this.estadoPago.Name = "estadoPago";
            this.estadoPago.Size = new System.Drawing.Size(121, 21);
            this.estadoPago.TabIndex = 4;
            this.estadoPago.Text = "Estado";
            this.estadoPago.SelectedIndexChanged += new System.EventHandler(this.estadoPago_SelectedIndexChanged);
            // 
            // lblEstadoPago
            // 
            this.lblEstadoPago.AutoSize = true;
            this.lblEstadoPago.Location = new System.Drawing.Point(460, 16);
            this.lblEstadoPago.Name = "lblEstadoPago";
            this.lblEstadoPago.Size = new System.Drawing.Size(68, 13);
            this.lblEstadoPago.TabIndex = 5;
            this.lblEstadoPago.Text = "Estado Pago";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNumFactura);
            this.groupBox1.Controls.Add(this.lblEstadoPago);
            this.groupBox1.Controls.Add(this.numFactura);
            this.groupBox1.Controls.Add(this.estadoPago);
            this.groupBox1.Controls.Add(this.fechaExpedicion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 77);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Factura";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAbrir);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.btnEditar);
            this.groupBox2.Controls.Add(this.btnCrear);
            this.groupBox2.Location = new System.Drawing.Point(22, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(748, 51);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones";
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(484, 19);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(75, 23);
            this.btnAbrir.TabIndex = 3;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(376, 19);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(267, 19);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(161, 19);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCrear.TabIndex = 0;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvListadoEmpleados);
            this.groupBox3.Location = new System.Drawing.Point(22, 152);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(748, 286);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Listado de empleados";
            // 
            // dgvListadoEmpleados
            // 
            this.dgvListadoEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoEmpleados.Location = new System.Drawing.Point(6, 19);
            this.dgvListadoEmpleados.Name = "dgvListadoEmpleados";
            this.dgvListadoEmpleados.Size = new System.Drawing.Size(736, 261);
            this.dgvListadoEmpleados.TabIndex = 0;
            this.dgvListadoEmpleados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // FrmFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmFacturas";
            this.Text = "FrmFacturas";
            this.Load += new System.EventHandler(this.FrmFacturas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoEmpleados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox numFactura;
        private System.Windows.Forms.Label lblNumFactura;
        private System.Windows.Forms.DateTimePicker fechaExpedicion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox estadoPago;
        private System.Windows.Forms.Label lblEstadoPago;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvListadoEmpleados;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnAbrir;
    }
}