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
    public partial class Compilador : Form
    {
        AnalizadorLexico analizador_lexico;
        public Compilador()
        {
            InitializeComponent();
            analizador_lexico = new AnalizadorLexico(txtLenguaje, dgvSimbolos);
        }

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

        private void léxicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigoFuente.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("El input no puede estar vacío.");
            } else if (txtLenguaje.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("No se cargó ningún archivo.");
            } else
            {
                string codigoFuente = txtCodigoFuente.Text;
                tbcInformacion.SelectTab(tbpLexico);     
                dgvSimbolos.Rows.Clear();
                analizador_lexico.analizar(codigoFuente);
                analizador_lexico.mostrar();
            }
        }

        private void sintácticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigoFuente.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("El input no puede estar vacío.");
            } else if (txtCodigoFuente.SelectedText.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Por favor seleccione una línea.");
            } else
            {
                String linea = txtCodigoFuente.SelectedText;
                if (linea.Contains("\n"))
                {
                    System.Windows.Forms.MessageBox.Show("Por favor seleccione sólo una línea.");
                }
                else
                {
                    //txtLenguaje.Clear();
                    //dgvSimbolos.Rows.Clear();
                    tbcInformacion.SelectTab(tbpSintactico);
                    /* Se crea un formulario (requerido por la librería Microsoft.Msagl)
                    System.Windows.Forms.Form Formulario = new System.Windows.Forms.Form();
                    // Se ajusta el tamaño del formulario
                    Formulario.Size = new Size(800, 600);
                    
                    // Objeto para visualizar los elementos (nodos, líneas) que se vayan creando.
                    Microsoft.Msagl.GraphViewerGdi.GViewer Visor = new Microsoft.Msagl.GraphViewerGdi.GViewer();
                    // Se crea el objeto gráfica, al cual se irán añadiendo elementos visuales.
                    Microsoft.Msagl.Drawing.Graph Grafica = new Microsoft.Msagl.Drawing.Graph("Grafica");
                    // ...
                    Visor.Graph = Grafica;
                    // Se asocia el visor al formulario creado al principio del método
                    Formulario.SuspendLayout();
                    Formulario.TopLevel = false;
                    Formulario.Visible = true;
                    Formulario.FormBorderStyle = FormBorderStyle.None;
                    Visor.Dock = System.Windows.Forms.DockStyle.Fill;
                    Formulario.Controls.Add(Visor);
                    Formulario.ResumeLayout();
                    // Muestra el formulario (la gráfica)*/
                    // analizador_sintactico.crearFormulario();
                    //tbcInformacion.TabPages[1].Controls.Add(Formulario);
                    //Creando objeto analizador_sintactico 
                    AnalizadorSintactico analizador_sintactico = new AnalizadorSintactico(analizador_lexico.getListaTokens());
                    analizador_sintactico.analizar(linea);
                    tbcInformacion.TabPages[1].Controls.Add(analizador_sintactico.crearFormulario());
                }
            }
        }

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
                analizador_lexico.guardarReservadas(ContenidoArchivo);
            } else
            {
                System.Windows.Forms.MessageBox.Show("Error al abrir el archivo.");
            }
        }

    }
}
