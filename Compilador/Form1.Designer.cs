
namespace Compilador
{
    partial class Compilador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compilador));
            this.grbContenedorCodigoFuente = new System.Windows.Forms.GroupBox();
            this.txtCodigoFuente = new System.Windows.Forms.RichTextBox();
            this.tbcInformacion = new System.Windows.Forms.TabControl();
            this.tbpLexico = new System.Windows.Forms.TabPage();
            this.dgvSimbolos = new System.Windows.Forms.DataGridView();
            this.tbpSintactico = new System.Windows.Forms.TabPage();
            this.tbpSemantico = new System.Windows.Forms.TabPage();
            this.dvgErrores = new System.Windows.Forms.DataGridView();
            this.colError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbLenguaje = new System.Windows.Forms.GroupBox();
            this.txtLenguaje = new System.Windows.Forms.RichTextBox();
            this.mspMenu = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecutarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.léxicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sintácticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Lexema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scope = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbContenedorCodigoFuente.SuspendLayout();
            this.tbcInformacion.SuspendLayout();
            this.tbpLexico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimbolos)).BeginInit();
            this.tbpSemantico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgErrores)).BeginInit();
            this.grbLenguaje.SuspendLayout();
            this.mspMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbContenedorCodigoFuente
            // 
            this.grbContenedorCodigoFuente.Controls.Add(this.txtCodigoFuente);
            this.grbContenedorCodigoFuente.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbContenedorCodigoFuente.Location = new System.Drawing.Point(18, 349);
            this.grbContenedorCodigoFuente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbContenedorCodigoFuente.Name = "grbContenedorCodigoFuente";
            this.grbContenedorCodigoFuente.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbContenedorCodigoFuente.Size = new System.Drawing.Size(420, 295);
            this.grbContenedorCodigoFuente.TabIndex = 1;
            this.grbContenedorCodigoFuente.TabStop = false;
            this.grbContenedorCodigoFuente.Text = "Código fuente";
            // 
            // txtCodigoFuente
            // 
            this.txtCodigoFuente.Location = new System.Drawing.Point(10, 32);
            this.txtCodigoFuente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCodigoFuente.Name = "txtCodigoFuente";
            this.txtCodigoFuente.Size = new System.Drawing.Size(400, 250);
            this.txtCodigoFuente.TabIndex = 0;
            this.txtCodigoFuente.Text = "";
            // 
            // tbcInformacion
            // 
            this.tbcInformacion.Controls.Add(this.tbpLexico);
            this.tbcInformacion.Controls.Add(this.tbpSintactico);
            this.tbcInformacion.Controls.Add(this.tbpSemantico);
            this.tbcInformacion.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcInformacion.Location = new System.Drawing.Point(460, 50);
            this.tbcInformacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbcInformacion.Name = "tbcInformacion";
            this.tbcInformacion.SelectedIndex = 0;
            this.tbcInformacion.Size = new System.Drawing.Size(700, 594);
            this.tbcInformacion.TabIndex = 3;
            // 
            // tbpLexico
            // 
            this.tbpLexico.Controls.Add(this.dgvSimbolos);
            this.tbpLexico.Location = new System.Drawing.Point(4, 30);
            this.tbpLexico.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbpLexico.Name = "tbpLexico";
            this.tbpLexico.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbpLexico.Size = new System.Drawing.Size(692, 560);
            this.tbpLexico.TabIndex = 0;
            this.tbpLexico.Text = "Tabla de Símbolos";
            this.tbpLexico.UseVisualStyleBackColor = true;
            // 
            // dgvSimbolos
            // 
            this.dgvSimbolos.AllowUserToAddRows = false;
            this.dgvSimbolos.AllowUserToDeleteRows = false;
            this.dgvSimbolos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSimbolos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSimbolos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lexema,
            this.TipoToken,
            this.Linea,
            this.TipoDato,
            this.Scope});
            this.dgvSimbolos.Location = new System.Drawing.Point(9, 10);
            this.dgvSimbolos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvSimbolos.Name = "dgvSimbolos";
            this.dgvSimbolos.ReadOnly = true;
            this.dgvSimbolos.RowHeadersWidth = 50;
            this.dgvSimbolos.RowTemplate.Height = 25;
            this.dgvSimbolos.Size = new System.Drawing.Size(675, 541);
            this.dgvSimbolos.TabIndex = 0;
            // 
            // tbpSintactico
            // 
            this.tbpSintactico.Location = new System.Drawing.Point(4, 30);
            this.tbpSintactico.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbpSintactico.Name = "tbpSintactico";
            this.tbpSintactico.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbpSintactico.Size = new System.Drawing.Size(692, 560);
            this.tbpSintactico.TabIndex = 1;
            this.tbpSintactico.Text = "Árbol Sintáctico";
            this.tbpSintactico.UseVisualStyleBackColor = true;
            // 
            // tbpSemantico
            // 
            this.tbpSemantico.Controls.Add(this.dvgErrores);
            this.tbpSemantico.Location = new System.Drawing.Point(4, 30);
            this.tbpSemantico.Name = "tbpSemantico";
            this.tbpSemantico.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSemantico.Size = new System.Drawing.Size(692, 560);
            this.tbpSemantico.TabIndex = 2;
            this.tbpSemantico.Text = "Errores";
            this.tbpSemantico.UseVisualStyleBackColor = true;
            // 
            // dvgErrores
            // 
            this.dvgErrores.AllowUserToAddRows = false;
            this.dvgErrores.AllowUserToDeleteRows = false;
            this.dvgErrores.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dvgErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgErrores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colError,
            this.colLinea});
            this.dvgErrores.Location = new System.Drawing.Point(0, 0);
            this.dvgErrores.Name = "dvgErrores";
            this.dvgErrores.Size = new System.Drawing.Size(692, 557);
            this.dvgErrores.TabIndex = 0;
            // 
            // colError
            // 
            this.colError.HeaderText = "Error";
            this.colError.Name = "colError";
            // 
            // colLinea
            // 
            this.colLinea.HeaderText = "Linea";
            this.colLinea.Name = "colLinea";
            // 
            // grbLenguaje
            // 
            this.grbLenguaje.Controls.Add(this.txtLenguaje);
            this.grbLenguaje.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbLenguaje.Location = new System.Drawing.Point(19, 40);
            this.grbLenguaje.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbLenguaje.Name = "grbLenguaje";
            this.grbLenguaje.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbLenguaje.Size = new System.Drawing.Size(420, 295);
            this.grbLenguaje.TabIndex = 4;
            this.grbLenguaje.TabStop = false;
            this.grbLenguaje.Text = "Lenguaje";
            // 
            // txtLenguaje
            // 
            this.txtLenguaje.Location = new System.Drawing.Point(10, 32);
            this.txtLenguaje.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLenguaje.Name = "txtLenguaje";
            this.txtLenguaje.ReadOnly = true;
            this.txtLenguaje.Size = new System.Drawing.Size(400, 250);
            this.txtLenguaje.TabIndex = 0;
            this.txtLenguaje.Text = "";
            // 
            // mspMenu
            // 
            this.mspMenu.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mspMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ejecutarToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.mspMenu.Location = new System.Drawing.Point(0, 0);
            this.mspMenu.Name = "mspMenu";
            this.mspMenu.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.mspMenu.Size = new System.Drawing.Size(1174, 31);
            this.mspMenu.TabIndex = 6;
            this.mspMenu.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(75, 25);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // ejecutarToolStripMenuItem
            // 
            this.ejecutarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.léxicoToolStripMenuItem,
            this.sintácticoToolStripMenuItem,
            this.toolStripMenuItem1});
            this.ejecutarToolStripMenuItem.Name = "ejecutarToolStripMenuItem";
            this.ejecutarToolStripMenuItem.Size = new System.Drawing.Size(116, 25);
            this.ejecutarToolStripMenuItem.Text = "Herramientas";
            this.ejecutarToolStripMenuItem.Click += new System.EventHandler(this.ejecutarToolStripMenuItem_Click);
            // 
            // léxicoToolStripMenuItem
            // 
            this.léxicoToolStripMenuItem.Name = "léxicoToolStripMenuItem";
            this.léxicoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.léxicoToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.léxicoToolStripMenuItem.Text = "Léxico";
            this.léxicoToolStripMenuItem.Click += new System.EventHandler(this.léxicoToolStripMenuItem_Click);
            // 
            // sintácticoToolStripMenuItem
            // 
            this.sintácticoToolStripMenuItem.Name = "sintácticoToolStripMenuItem";
            this.sintácticoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.sintácticoToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
            this.sintácticoToolStripMenuItem.Text = "Sintáctico";
            this.sintácticoToolStripMenuItem.Click += new System.EventHandler(this.sintácticoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItem1.Size = new System.Drawing.Size(238, 26);
            this.toolStripMenuItem1.Text = "Semantico";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(66, 25);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // Lexema
            // 
            this.Lexema.HeaderText = "Lexema";
            this.Lexema.Name = "Lexema";
            this.Lexema.ReadOnly = true;
            // 
            // TipoToken
            // 
            this.TipoToken.HeaderText = "Token";
            this.TipoToken.Name = "TipoToken";
            this.TipoToken.ReadOnly = true;
            this.TipoToken.Width = 170;
            // 
            // Linea
            // 
            this.Linea.HeaderText = "Línea";
            this.Linea.Name = "Linea";
            this.Linea.ReadOnly = true;
            this.Linea.Width = 55;
            // 
            // TipoDato
            // 
            this.TipoDato.HeaderText = "TipoDato";
            this.TipoDato.Name = "TipoDato";
            this.TipoDato.ReadOnly = true;
            // 
            // Scope
            // 
            this.Scope.HeaderText = "Ámbito (Scope)";
            this.Scope.Name = "Scope";
            this.Scope.ReadOnly = true;
            this.Scope.Width = 900;
            // 
            // Compilador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 661);
            this.Controls.Add(this.grbLenguaje);
            this.Controls.Add(this.tbcInformacion);
            this.Controls.Add(this.grbContenedorCodigoFuente);
            this.Controls.Add(this.mspMenu);
            this.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mspMenu;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Compilador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compilador";
            this.grbContenedorCodigoFuente.ResumeLayout(false);
            this.tbcInformacion.ResumeLayout(false);
            this.tbpLexico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimbolos)).EndInit();
            this.tbpSemantico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgErrores)).EndInit();
            this.grbLenguaje.ResumeLayout(false);
            this.mspMenu.ResumeLayout(false);
            this.mspMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbContenedorCodigoFuente;
        private System.Windows.Forms.RichTextBox txtCodigoFuente;
        private System.Windows.Forms.TabControl tbcInformacion;
        private System.Windows.Forms.TabPage tbpLexico;
        private System.Windows.Forms.TabPage tbpSintactico;
        private System.Windows.Forms.GroupBox grbLenguaje;
        private System.Windows.Forms.RichTextBox txtLenguaje;
        private System.Windows.Forms.DataGridView dgvSimbolos;
        private System.Windows.Forms.MenuStrip mspMenu;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejecutarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem léxicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sintácticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TabPage tbpSemantico;
        private System.Windows.Forms.DataGridView dvgErrores;
        private System.Windows.Forms.DataGridViewTextBoxColumn colError;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexema;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoToken;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linea;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDato;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scope;
    }
}

