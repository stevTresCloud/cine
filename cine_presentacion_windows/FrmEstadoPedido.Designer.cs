namespace cine_presentacion_windows
{
    partial class FrmEstadoPedido
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTipoEstadoPedido = new System.Windows.Forms.TextBox();
            this.txtIdEstadoPedido = new System.Windows.Forms.TextBox();
            this.chkActivoEstadoPedido = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvEstadosPedido = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadosPedido)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkActivoEstadoPedido);
            this.groupBox1.Controls.Add(this.txtIdEstadoPedido);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTipoEstadoPedido);
            this.groupBox1.Location = new System.Drawing.Point(23, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estado Pedido";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tipo de Estado";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtTipoEstadoPedido
            // 
            this.txtTipoEstadoPedido.Location = new System.Drawing.Point(124, 19);
            this.txtTipoEstadoPedido.Name = "txtTipoEstadoPedido";
            this.txtTipoEstadoPedido.Size = new System.Drawing.Size(244, 20);
            this.txtTipoEstadoPedido.TabIndex = 2;
            // 
            // txtIdEstadoPedido
            // 
            this.txtIdEstadoPedido.Location = new System.Drawing.Point(124, 51);
            this.txtIdEstadoPedido.Name = "txtIdEstadoPedido";
            this.txtIdEstadoPedido.Size = new System.Drawing.Size(100, 20);
            this.txtIdEstadoPedido.TabIndex = 4;
            this.txtIdEstadoPedido.Visible = false;
            // 
            // chkActivoEstadoPedido
            // 
            this.chkActivoEstadoPedido.AutoSize = true;
            this.chkActivoEstadoPedido.Location = new System.Drawing.Point(24, 54);
            this.chkActivoEstadoPedido.Name = "chkActivoEstadoPedido";
            this.chkActivoEstadoPedido.Size = new System.Drawing.Size(65, 17);
            this.chkActivoEstadoPedido.TabIndex = 5;
            this.chkActivoEstadoPedido.Text = "Activo ?";
            this.chkActivoEstadoPedido.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAbrir);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.btnEditar);
            this.groupBox2.Controls.Add(this.btnCrear);
            this.groupBox2.Location = new System.Drawing.Point(23, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 67);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones";
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(280, 28);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(75, 23);
            this.btnAbrir.TabIndex = 3;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(188, 28);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(95, 28);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(14, 28);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCrear.TabIndex = 0;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvEstadosPedido);
            this.groupBox3.Location = new System.Drawing.Point(23, 190);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(390, 296);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Listado Estado Pedido";
            // 
            // dgvEstadosPedido
            // 
            this.dgvEstadosPedido.AllowUserToAddRows = false;
            this.dgvEstadosPedido.AllowUserToDeleteRows = false;
            this.dgvEstadosPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstadosPedido.Location = new System.Drawing.Point(6, 19);
            this.dgvEstadosPedido.Name = "dgvEstadosPedido";
            this.dgvEstadosPedido.Size = new System.Drawing.Size(378, 271);
            this.dgvEstadosPedido.TabIndex = 0;
            this.dgvEstadosPedido.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEstadosPedido_CellContentClick_1);
            // 
            // FrmEstadoPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 507);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmEstadoPedido";
            this.Text = "FrmEstadoPedido";
            this.Load += new System.EventHandler(this.FrmEstadoPedido_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadosPedido)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTipoEstadoPedido;
        private System.Windows.Forms.TextBox txtIdEstadoPedido;
        private System.Windows.Forms.CheckBox chkActivoEstadoPedido;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvEstadosPedido;
    }
}