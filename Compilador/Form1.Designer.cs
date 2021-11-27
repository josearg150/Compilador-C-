
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
            this.grbLenguaje = new System.Windows.Forms.GroupBox();
            this.txtLenguaje = new System.Windows.Forms.RichTextBox();
            this.mspMenu = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecutarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLexico = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSintactico = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSemantico = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmListaErrores = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCodigoTresD = new System.Windows.Forms.ToolStripMenuItem();
            this.cuadrplosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbpCuadruplos = new System.Windows.Forms.TabPage();
            this.dgvCuadruplos = new System.Windows.Forms.DataGridView();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.op = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.argum1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.argum2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbpTriplos = new System.Windows.Forms.TabPage();
            this.dgvTriplos = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Arg1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Arg2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbpErrores = new System.Windows.Forms.TabPage();
            this.dgvErrores = new System.Windows.Forms.DataGridView();
            this.ColCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLexema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineaError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbpSemantico = new System.Windows.Forms.TabPage();
            this.dvgErrores = new System.Windows.Forms.DataGridView();
            this.colError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbpSintactico = new System.Windows.Forms.TabPage();
            this.tbpLexico = new System.Windows.Forms.TabPage();
            this.dgvSimbolos = new System.Windows.Forms.DataGridView();
            this.Lexema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scope = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbcInformacion = new System.Windows.Forms.TabControl();
            this.tbpCod3Dir = new System.Windows.Forms.TabPage();
            this.dgvCodigoTresD = new System.Windows.Forms.DataGridView();
            this.T = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expresion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbpEnsamblador = new System.Windows.Forms.TabPage();
            this.ensambladorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grbContenedorCodigoFuente.SuspendLayout();
            this.grbLenguaje.SuspendLayout();
            this.mspMenu.SuspendLayout();
            this.tbpCuadruplos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuadruplos)).BeginInit();
            this.tbpTriplos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTriplos)).BeginInit();
            this.tbpErrores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).BeginInit();
            this.tbpSemantico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgErrores)).BeginInit();
            this.tbpLexico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimbolos)).BeginInit();
            this.tbcInformacion.SuspendLayout();
            this.tbpCod3Dir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodigoTresD)).BeginInit();
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
            this.tsmLexico,
            this.tsmSintactico,
            this.tsmSemantico,
            this.tsmListaErrores,
            this.tsmCodigoTresD,
            this.cuadrplosToolStripMenuItem,
            this.ensambladorToolStripMenuItem});
            this.ejecutarToolStripMenuItem.Name = "ejecutarToolStripMenuItem";
            this.ejecutarToolStripMenuItem.Size = new System.Drawing.Size(116, 25);
            this.ejecutarToolStripMenuItem.Text = "Herramientas";
            this.ejecutarToolStripMenuItem.Click += new System.EventHandler(this.ejecutarToolStripMenuItem_Click);
            // 
            // tsmLexico
            // 
            this.tsmLexico.Name = "tsmLexico";
            this.tsmLexico.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.tsmLexico.Size = new System.Drawing.Size(323, 26);
            this.tsmLexico.Text = "Léxico";
            this.tsmLexico.Click += new System.EventHandler(this.léxicoToolStripMenuItem_Click);
            // 
            // tsmSintactico
            // 
            this.tsmSintactico.Name = "tsmSintactico";
            this.tsmSintactico.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmSintactico.Size = new System.Drawing.Size(323, 26);
            this.tsmSintactico.Text = "Sintáctico";
            this.tsmSintactico.Click += new System.EventHandler(this.sintácticoToolStripMenuItem_Click);
            // 
            // tsmSemantico
            // 
            this.tsmSemantico.Name = "tsmSemantico";
            this.tsmSemantico.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.tsmSemantico.Size = new System.Drawing.Size(323, 26);
            this.tsmSemantico.Text = "Semántico";
            this.tsmSemantico.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // tsmListaErrores
            // 
            this.tsmListaErrores.Name = "tsmListaErrores";
            this.tsmListaErrores.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.tsmListaErrores.Size = new System.Drawing.Size(323, 26);
            this.tsmListaErrores.Text = "Lista de Errores";
            this.tsmListaErrores.Click += new System.EventHandler(this.listaDeErroresToolStripMenuItem_Click);
            // 
            // tsmCodigoTresD
            // 
            this.tsmCodigoTresD.Name = "tsmCodigoTresD";
            this.tsmCodigoTresD.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.tsmCodigoTresD.Size = new System.Drawing.Size(323, 26);
            this.tsmCodigoTresD.Text = "Código de Tres Direcciones";
            this.tsmCodigoTresD.Click += new System.EventHandler(this.triplosToolStripMenuItem_Click);
            // 
            // cuadrplosToolStripMenuItem
            // 
            this.cuadrplosToolStripMenuItem.Name = "cuadrplosToolStripMenuItem";
            this.cuadrplosToolStripMenuItem.Size = new System.Drawing.Size(323, 26);
            this.cuadrplosToolStripMenuItem.Text = "Cuadruplos";
            this.cuadrplosToolStripMenuItem.Click += new System.EventHandler(this.cuadrplosToolStripMenuItem_Click);
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
            // tbpCuadruplos
            // 
            this.tbpCuadruplos.Controls.Add(this.dgvCuadruplos);
            this.tbpCuadruplos.Location = new System.Drawing.Point(4, 30);
            this.tbpCuadruplos.Name = "tbpCuadruplos";
            this.tbpCuadruplos.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCuadruplos.Size = new System.Drawing.Size(692, 560);
            this.tbpCuadruplos.TabIndex = 6;
            this.tbpCuadruplos.Text = "Cuádruplos";
            this.tbpCuadruplos.UseVisualStyleBackColor = true;
            // 
            // dgvCuadruplos
            // 
            this.dgvCuadruplos.AllowUserToAddRows = false;
            this.dgvCuadruplos.AllowUserToDeleteRows = false;
            this.dgvCuadruplos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCuadruplos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuadruplos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.op,
            this.argum1,
            this.argum2,
            this.result});
            this.dgvCuadruplos.Location = new System.Drawing.Point(6, 8);
            this.dgvCuadruplos.Name = "dgvCuadruplos";
            this.dgvCuadruplos.ReadOnly = true;
            this.dgvCuadruplos.RowTemplate.ReadOnly = true;
            this.dgvCuadruplos.Size = new System.Drawing.Size(680, 545);
            this.dgvCuadruplos.TabIndex = 1;
            // 
            // num
            // 
            this.num.HeaderText = "#";
            this.num.Name = "num";
            this.num.ReadOnly = true;
            this.num.Width = 60;
            // 
            // op
            // 
            this.op.HeaderText = "Operación";
            this.op.Name = "op";
            this.op.ReadOnly = true;
            // 
            // argum1
            // 
            this.argum1.HeaderText = "Argumento 1";
            this.argum1.Name = "argum1";
            this.argum1.ReadOnly = true;
            this.argum1.Width = 150;
            // 
            // argum2
            // 
            this.argum2.HeaderText = "Argumento 2";
            this.argum2.Name = "argum2";
            this.argum2.ReadOnly = true;
            this.argum2.Width = 150;
            // 
            // result
            // 
            this.result.HeaderText = "Resultado";
            this.result.Name = "result";
            this.result.ReadOnly = true;
            // 
            // tbpTriplos
            // 
            this.tbpTriplos.Controls.Add(this.dgvTriplos);
            this.tbpTriplos.Location = new System.Drawing.Point(4, 30);
            this.tbpTriplos.Name = "tbpTriplos";
            this.tbpTriplos.Padding = new System.Windows.Forms.Padding(3);
            this.tbpTriplos.Size = new System.Drawing.Size(692, 560);
            this.tbpTriplos.TabIndex = 5;
            this.tbpTriplos.Text = "Triplos";
            this.tbpTriplos.UseVisualStyleBackColor = true;
            // 
            // dgvTriplos
            // 
            this.dgvTriplos.AllowUserToAddRows = false;
            this.dgvTriplos.AllowUserToDeleteRows = false;
            this.dgvTriplos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvTriplos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTriplos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Operacion,
            this.Arg1,
            this.Arg2});
            this.dgvTriplos.Location = new System.Drawing.Point(6, 6);
            this.dgvTriplos.Name = "dgvTriplos";
            this.dgvTriplos.ReadOnly = true;
            this.dgvTriplos.RowTemplate.ReadOnly = true;
            this.dgvTriplos.Size = new System.Drawing.Size(680, 545);
            this.dgvTriplos.TabIndex = 0;
            // 
            // Numero
            // 
            this.Numero.HeaderText = "#";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 60;
            // 
            // Operacion
            // 
            this.Operacion.HeaderText = "Operación";
            this.Operacion.Name = "Operacion";
            this.Operacion.ReadOnly = true;
            // 
            // Arg1
            // 
            this.Arg1.HeaderText = "Argumento 1";
            this.Arg1.Name = "Arg1";
            this.Arg1.ReadOnly = true;
            this.Arg1.Width = 150;
            // 
            // Arg2
            // 
            this.Arg2.HeaderText = "Argumento 2";
            this.Arg2.Name = "Arg2";
            this.Arg2.ReadOnly = true;
            this.Arg2.Width = 150;
            // 
            // tbpErrores
            // 
            this.tbpErrores.Controls.Add(this.dgvErrores);
            this.tbpErrores.Location = new System.Drawing.Point(4, 30);
            this.tbpErrores.Name = "tbpErrores";
            this.tbpErrores.Padding = new System.Windows.Forms.Padding(3);
            this.tbpErrores.Size = new System.Drawing.Size(692, 560);
            this.tbpErrores.TabIndex = 3;
            this.tbpErrores.Text = "Errores";
            this.tbpErrores.UseVisualStyleBackColor = true;
            // 
            // dgvErrores
            // 
            this.dgvErrores.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCodigo,
            this.colTipo,
            this.colLexema,
            this.colLineaError});
            this.dgvErrores.Location = new System.Drawing.Point(0, 0);
            this.dgvErrores.Name = "dgvErrores";
            this.dgvErrores.Size = new System.Drawing.Size(692, 557);
            this.dgvErrores.TabIndex = 0;
            // 
            // ColCodigo
            // 
            this.ColCodigo.HeaderText = "Codigo";
            this.ColCodigo.Name = "ColCodigo";
            // 
            // colTipo
            // 
            this.colTipo.HeaderText = "Tipo de error";
            this.colTipo.Name = "colTipo";
            // 
            // colLexema
            // 
            this.colLexema.HeaderText = "Lexema";
            this.colLexema.Name = "colLexema";
            // 
            // colLineaError
            // 
            this.colLineaError.HeaderText = "Linea";
            this.colLineaError.Name = "colLineaError";
            // 
            // tbpSemantico
            // 
            this.tbpSemantico.Controls.Add(this.dvgErrores);
            this.tbpSemantico.Location = new System.Drawing.Point(4, 30);
            this.tbpSemantico.Name = "tbpSemantico";
            this.tbpSemantico.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSemantico.Size = new System.Drawing.Size(692, 560);
            this.tbpSemantico.TabIndex = 2;
            this.tbpSemantico.Text = "Pila Semántica";
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
            // tbcInformacion
            // 
            this.tbcInformacion.Controls.Add(this.tbpLexico);
            this.tbcInformacion.Controls.Add(this.tbpSintactico);
            this.tbcInformacion.Controls.Add(this.tbpSemantico);
            this.tbcInformacion.Controls.Add(this.tbpErrores);
            this.tbcInformacion.Controls.Add(this.tbpCod3Dir);
            this.tbcInformacion.Controls.Add(this.tbpTriplos);
            this.tbcInformacion.Controls.Add(this.tbpCuadruplos);
            this.tbcInformacion.Controls.Add(this.tbpEnsamblador);
            this.tbcInformacion.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcInformacion.Location = new System.Drawing.Point(460, 50);
            this.tbcInformacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbcInformacion.Name = "tbcInformacion";
            this.tbcInformacion.SelectedIndex = 0;
            this.tbcInformacion.Size = new System.Drawing.Size(700, 594);
            this.tbcInformacion.TabIndex = 3;
            // 
            // tbpCod3Dir
            // 
            this.tbpCod3Dir.Controls.Add(this.dgvCodigoTresD);
            this.tbpCod3Dir.Location = new System.Drawing.Point(4, 30);
            this.tbpCod3Dir.Name = "tbpCod3Dir";
            this.tbpCod3Dir.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCod3Dir.Size = new System.Drawing.Size(692, 560);
            this.tbpCod3Dir.TabIndex = 7;
            this.tbpCod3Dir.Text = "Código de Tres Direcciones";
            this.tbpCod3Dir.UseVisualStyleBackColor = true;
            // 
            // dgvCodigoTresD
            // 
            this.dgvCodigoTresD.AllowUserToAddRows = false;
            this.dgvCodigoTresD.AllowUserToDeleteRows = false;
            this.dgvCodigoTresD.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCodigoTresD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCodigoTresD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.T,
            this.Expresion});
            this.dgvCodigoTresD.Location = new System.Drawing.Point(6, 6);
            this.dgvCodigoTresD.Name = "dgvCodigoTresD";
            this.dgvCodigoTresD.Size = new System.Drawing.Size(680, 545);
            this.dgvCodigoTresD.TabIndex = 0;
            // 
            // T
            // 
            this.T.HeaderText = "T";
            this.T.Name = "T";
            this.T.Width = 60;
            // 
            // Expresion
            // 
            this.Expresion.HeaderText = "Expresión";
            this.Expresion.Name = "Expresion";
            this.Expresion.Width = 300;
            // 
            // tbpEnsamblador
            // 
            this.tbpEnsamblador.Location = new System.Drawing.Point(4, 30);
            this.tbpEnsamblador.Name = "tbpEnsamblador";
            this.tbpEnsamblador.Padding = new System.Windows.Forms.Padding(3);
            this.tbpEnsamblador.Size = new System.Drawing.Size(692, 560);
            this.tbpEnsamblador.TabIndex = 8;
            this.tbpEnsamblador.Text = "Ensamblador";
            this.tbpEnsamblador.UseVisualStyleBackColor = true;
            // 
            // ensambladorToolStripMenuItem
            // 
            this.ensambladorToolStripMenuItem.Name = "ensambladorToolStripMenuItem";
            this.ensambladorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.E)));
            this.ensambladorToolStripMenuItem.Size = new System.Drawing.Size(323, 26);
            this.ensambladorToolStripMenuItem.Text = "Ensamblador";
            this.ensambladorToolStripMenuItem.Click += new System.EventHandler(this.ensambladorToolStripMenuItem_Click);
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
            this.grbLenguaje.ResumeLayout(false);
            this.mspMenu.ResumeLayout(false);
            this.mspMenu.PerformLayout();
            this.tbpCuadruplos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuadruplos)).EndInit();
            this.tbpTriplos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTriplos)).EndInit();
            this.tbpErrores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).EndInit();
            this.tbpSemantico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgErrores)).EndInit();
            this.tbpLexico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSimbolos)).EndInit();
            this.tbcInformacion.ResumeLayout(false);
            this.tbpCod3Dir.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodigoTresD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbContenedorCodigoFuente;
        private System.Windows.Forms.RichTextBox txtCodigoFuente;
        private System.Windows.Forms.GroupBox grbLenguaje;
        private System.Windows.Forms.RichTextBox txtLenguaje;
        private System.Windows.Forms.MenuStrip mspMenu;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejecutarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmLexico;
        private System.Windows.Forms.ToolStripMenuItem tsmSintactico;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmSemantico;
        private System.Windows.Forms.ToolStripMenuItem tsmListaErrores;
        private System.Windows.Forms.TabPage tbpCuadruplos;
        private System.Windows.Forms.DataGridView dgvCuadruplos;
        private System.Windows.Forms.TabPage tbpTriplos;
        private System.Windows.Forms.DataGridView dgvTriplos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arg1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arg2;
        private System.Windows.Forms.TabPage tbpErrores;
        private System.Windows.Forms.DataGridView dgvErrores;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLexema;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineaError;
        private System.Windows.Forms.TabPage tbpSemantico;
        private System.Windows.Forms.DataGridView dvgErrores;
        private System.Windows.Forms.DataGridViewTextBoxColumn colError;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLinea;
        private System.Windows.Forms.TabPage tbpSintactico;
        private System.Windows.Forms.TabPage tbpLexico;
        private System.Windows.Forms.DataGridView dgvSimbolos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexema;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoToken;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linea;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDato;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scope;
        private System.Windows.Forms.TabControl tbcInformacion;
        private System.Windows.Forms.ToolStripMenuItem tsmCodigoTresD;
        private System.Windows.Forms.TabPage tbpCod3Dir;
        private System.Windows.Forms.DataGridView dgvCodigoTresD;
        private System.Windows.Forms.DataGridViewTextBoxColumn T;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expresion;
        private System.Windows.Forms.ToolStripMenuItem cuadrplosToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn op;
        private System.Windows.Forms.DataGridViewTextBoxColumn argum1;
        private System.Windows.Forms.DataGridViewTextBoxColumn argum2;
        private System.Windows.Forms.DataGridViewTextBoxColumn result;
        private System.Windows.Forms.ToolStripMenuItem ensambladorToolStripMenuItem;
        private System.Windows.Forms.TabPage tbpEnsamblador;
    }
}

