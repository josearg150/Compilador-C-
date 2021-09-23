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
        AnalizadorLexico AnalizadorLexico;
        AnalizadorSintactico AnalizadorSintactico;

        public Compilador()
        {
            InitializeComponent();
            AnalizadorLexico = new AnalizadorLexico(txtLenguaje, dgvSimbolos);
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
                tbcInformacion.SelectTab(tbpLexico);     
                dgvSimbolos.Rows.Clear();
                dgvSimbolos.Refresh();
                AnalizadorLexico.analizar(txtCodigoFuente.Text);
                AnalizadorLexico.mostrar();
            }
        }

        private void sintácticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                String Linea = txtCodigoFuente.SelectedText;
                if (Linea.Contains("\n"))
                {
                    System.Windows.Forms.MessageBox.Show("Por favor seleccione sólo una línea.");
                }
                else
                {
                    if (AnalizadorLexico.getListaTokens().Count == 0)
                    {
                        AnalizadorLexico.analizar(txtCodigoFuente.Text);
                        tbcInformacion.SelectTab(tbpSintactico);
                        AnalizadorSintactico = new AnalizadorSintactico(AnalizadorLexico.getTokens());
                        AnalizadorSintactico.analizar(Linea);
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
                AnalizadorLexico.guardarReservadas(ContenidoArchivo);
            } else
            {
                System.Windows.Forms.MessageBox.Show("Error al abrir el archivo.");
            }
        }
    }
}
