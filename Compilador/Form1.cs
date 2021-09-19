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
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("");
        }

        private void léxicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbcInformacion.SelectTab(tabPage1);
            txtLenguaje.Clear();
            dgvSimbolos.Rows.Clear();
            analizador_lexico = new AnalizadorLexico(txtLenguaje, dgvSimbolos);
            string codigoFuente = txtCodigoFuente.Text;
            analizador_lexico.analizar(codigoFuente);
        }

        private void sintácticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtLenguaje.Clear();
            dgvSimbolos.Rows.Clear();
            tbcInformacion.SelectTab(tabPage2);
        }
    }
}
