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
    public partial class Form1 : Form
    {
        AnalizadorLexico analizador_lexico;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            txtLenguaje.Clear();
            analizador_lexico = new AnalizadorLexico(txtLenguaje);
            string codigoFuente = txtCodigoFuente.Text;
            analizador_lexico.Analizar(codigoFuente);
        }
    }
}
