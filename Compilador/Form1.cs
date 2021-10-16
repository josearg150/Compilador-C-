using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador
{
    /// <summary>
    ///     Formulario principal para la interfaz de la aplicación.
    /// </summary>
    /// <Para>
    ///     Invocar al formulario y sus componentes (botones, menús, etc.)
    /// </Para>
    /// <Supuestos>
    ///     Para que aparezca la interfaz, es necesario no remover las llamadas pertinentes en main().
    /// </Supuestos>
    /// <Autor>
    ///     José Luis Carreón Reyes
    ///     José Ángel Rocha García
    /// </Autor>
    /// <FechaCreacion>
    ///     14/09/2021
    /// </FechaCreacion>
    public partial class Compilador : Form
    {
        //***************************************
        //Variables locales                     
        //***************************************
        #region Variables
        AnalizadorLexico AnalizadorLexico;
        AnalizadorSintactico AnalizadorSintactico;
        AnalizadorSemantico AnalizadorSemantico;
        IdentificadorDeErrores ListaErrores;
        #endregion

        //***************************************
        //Constructores   
        //***************************************
        #region Constructores 
        public Compilador()
        {
            InitializeComponent();
            ListaErrores = new IdentificadorDeErrores(dgvErrores);
            AnalizadorLexico = new AnalizadorLexico(txtLenguaje, dgvSimbolos,ListaErrores);
            
        }
        #endregion

        //***************************************
        //Eventos
        //***************************************
        #region Eventos
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Proyecto de compilador.\n" +
                                                 "Fase léxica y sintáctica.\n" +
                                                 "José Luis Carreón Reyes\n" +
                                                 "José Ángel Rocha García");
        }

        // Dispara la ejecución del analizador léxico
        private void léxicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Validacion de input
            if (txtCodigoFuente.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("El input no puede estar vacío.");
            } else if (txtLenguaje.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("No se cargó ningún archivo.");
            } else
            {
                tbcInformacion.SelectTab(tbpLexico);     
                dgvSimbolos.Rows.Clear();
                dgvSimbolos.Refresh();
                // Se toma el código fuente escrito y se le pasa al constructor del
                // objeto del analizador léxico
                AnalizadorLexico.analizar(txtCodigoFuente.Text);
                // Añade los tokens generados a la tabla
                AnalizadorLexico.mostrar();
            }
        }

        // Dispara la ejecución del analizador sintáctico
        private void sintácticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Validación de input
            if (txtCodigoFuente.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("El input no puede estar vacío.");
            } else if (txtLenguaje.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("No se cargó ningún archivo.");
            } else if (txtCodigoFuente.SelectedText.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Por favor seleccione una línea.");
            } else
            {
                // Solo se debe seleccionar una sola linea
                String Linea = txtCodigoFuente.SelectedText;
                if (Linea.Contains("\n"))
                {
                    System.Windows.Forms.MessageBox.Show("Por favor seleccione sólo una línea.");
                }
                else
                {
                    // Si se ejecuta directamente el analizador sintáctico antes del
                    // léxico
                    if (AnalizadorLexico.getListaTokens().Count == 0)
                    {
                        AnalizadorLexico.analizar(txtCodigoFuente.Text);
                        tbcInformacion.SelectTab(tbpSintactico);
                        // El analizador sintáctico recibe los tokens generados
                        AnalizadorSintactico = new AnalizadorSintactico(AnalizadorLexico.getTokens());
                        AnalizadorSintactico.analizar(Linea);
                        // Muestra la gráfica
                        tbcInformacion.TabPages[1].Controls.Add(AnalizadorSintactico.crearFormulario());
                    } else
                    {
                        tbcInformacion.SelectTab(tbpSintactico);
                        AnalizadorSintactico = new AnalizadorSintactico(AnalizadorLexico.getTokens());
                        AnalizadorSintactico.analizar(Linea);
                        tbcInformacion.TabPages[1].Controls.Clear();
                        tbcInformacion.TabPages[1].Controls.Add(AnalizadorSintactico.crearFormulario());
                    }
                }
            }
        }

        // Método para cargar el archivo con el lenguaje
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtLenguaje.Clear();
            OpenFileDialog DialogoArchivo = new OpenFileDialog();
            DialogoArchivo.Title = "Buscar archivos de texto";
            DialogoArchivo.DefaultExt = "txt";
            DialogoArchivo.Filter = "Archivos de texto (*.txt)|*.txt";
            DialogoArchivo.CheckFileExists = true;
            DialogoArchivo.CheckPathExists = true;
            DialogoArchivo.RestoreDirectory = true;
            if (DialogoArchivo.ShowDialog() == DialogResult.OK)
            {
                String RutaArchivo = DialogoArchivo.FileName;
                String ContenidoArchivo = System.IO.File.ReadAllText(RutaArchivo);
                txtLenguaje.Text = ContenidoArchivo;
                // Se cargan las palabras reservadas del lenguaje al analizador léxico
                AnalizadorLexico.guardarReservadas(ContenidoArchivo);
            } else
            {
                System.Windows.Forms.MessageBox.Show("Error al abrir el archivo.");
            }
        }
        #endregion

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tbcInformacion.SelectTab(tbpSemantico);
            AnalizadorSemantico = new AnalizadorSemantico(AnalizadorLexico.getListaTokens(), dvgErrores, ListaErrores);
            AnalizadorSemantico.analizar();
        }

        private void ejecutarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listaDeErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbcInformacion.SelectTab(tbpErrores);
            ListaErrores.mostrar();
        }
    }
}
