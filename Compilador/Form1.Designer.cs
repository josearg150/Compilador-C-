
namespace Compilador
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.grbContenedorCodigoFuente = new System.Windows.Forms.GroupBox();
            this.txtCodigoFuente = new System.Windows.Forms.RichTextBox();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.tbcInformacion = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grbLenguaje = new System.Windows.Forms.GroupBox();
            this.txtLenguaje = new System.Windows.Forms.RichTextBox();
            this.dgvSimbolos = new System.Windows.Forms.DataGridView();
            this.Token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbContenedorCodigoFuente.SuspendLayout();
            this.tbcInformacion.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grbLenguaje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimbolos)).BeginInit();
            this.SuspendLayout();
            // 
            // grbContenedorCodigoFuente
            // 
            this.grbContenedorCodigoFuente.Controls.Add(this.txtCodigoFuente);
            this.grbContenedorCodigoFuente.Location = new System.Drawing.Point(24, 288);
            this.grbContenedorCodigoFuente.Name = "grbContenedorCodigoFuente";
            this.grbContenedorCodigoFuente.Size = new System.Drawing.Size(384, 368);
            this.grbContenedorCodigoFuente.TabIndex = 1;
            this.grbContenedorCodigoFuente.TabStop = false;
            this.grbContenedorCodigoFuente.Text = "Código fuente";
            // 
            // txtCodigoFuente
            // 
            this.txtCodigoFuente.Location = new System.Drawing.Point(7, 20);
            this.txtCodigoFuente.Name = "txtCodigoFuente";
            this.txtCodigoFuente.Size = new System.Drawing.Size(371, 342);
            this.txtCodigoFuente.TabIndex = 0;
            this.txtCodigoFuente.Text = "";
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Location = new System.Drawing.Point(24, 12);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(125, 23);
            this.btnAnalizar.TabIndex = 2;
            this.btnAnalizar.Text = "Analisis lexico";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // tbcInformacion
            // 
            this.tbcInformacion.Controls.Add(this.tabPage1);
            this.tbcInformacion.Controls.Add(this.tabPage2);
            this.tbcInformacion.Controls.Add(this.tabPage3);
            this.tbcInformacion.Location = new System.Drawing.Point(427, 32);
            this.tbcInformacion.Name = "tbcInformacion";
            this.tbcInformacion.SelectedIndex = 0;
            this.tbcInformacion.Size = new System.Drawing.Size(688, 624);
            this.tbcInformacion.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvSimbolos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(680, 598);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Simbolos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(680, 598);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Arbol sintactico";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(680, 598);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Errores";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // grbLenguaje
            // 
            this.grbLenguaje.Controls.Add(this.txtLenguaje);
            this.grbLenguaje.Location = new System.Drawing.Point(24, 54);
            this.grbLenguaje.Name = "grbLenguaje";
            this.grbLenguaje.Size = new System.Drawing.Size(384, 228);
            this.grbLenguaje.TabIndex = 4;
            this.grbLenguaje.TabStop = false;
            this.grbLenguaje.Text = "Lenguaje";
            // 
            // txtLenguaje
            // 
            this.txtLenguaje.Location = new System.Drawing.Point(7, 20);
            this.txtLenguaje.Name = "txtLenguaje";
            this.txtLenguaje.Size = new System.Drawing.Size(371, 202);
            this.txtLenguaje.TabIndex = 0;
            this.txtLenguaje.Text = "";
            // 
            // dgvSimbolos
            // 
            this.dgvSimbolos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSimbolos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Token,
            this.Tipo});
            this.dgvSimbolos.Location = new System.Drawing.Point(6, 6);
            this.dgvSimbolos.Name = "dgvSimbolos";
            this.dgvSimbolos.Size = new System.Drawing.Size(667, 586);
            this.dgvSimbolos.TabIndex = 0;
            // 
            // Token
            // 
            this.Token.HeaderText = "Token";
            this.Token.Name = "Token";
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 668);
            this.Controls.Add(this.grbLenguaje);
            this.Controls.Add(this.tbcInformacion);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.grbContenedorCodigoFuente);
            this.Name = "Form1";
            this.Text = "Form1";
            this.grbContenedorCodigoFuente.ResumeLayout(false);
            this.tbcInformacion.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grbLenguaje.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimbolos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbContenedorCodigoFuente;
        private System.Windows.Forms.RichTextBox txtCodigoFuente;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.TabControl tbcInformacion;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox grbLenguaje;
        private System.Windows.Forms.RichTextBox txtLenguaje;
        private System.Windows.Forms.DataGridView dgvSimbolos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Token;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
    }
}

