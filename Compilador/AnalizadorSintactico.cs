using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador
{
    /// <summary>
    ///     Clase Analizador sintactico
    ///     Contiene los metodos para analizar el codigo fuente 
    /// </summary>
    /// 
    /// <Para>
    ///   
    /// </Para>
    /// 
    /// <Supuestos>
    /// </Supuestos>
    /// 
    /// <Autor>
    ///     Jose angel rocha garcia 
    ///     Jose luis carreon reyes
    /// </Autor>
    /// 
    /// <FechaCreacion >
    ///     17/09/2021
    /// </FechaCreacion>
    class AnalizadorSintactico
    {
        //***************************************
        //Variables locales                     
        //***************************************
        #region Variables
        private bool OperadoresShuntingInicializados = false;
        #endregion
        //***************************************
        //Constructores   
        //***************************************
        #region Constructores
        public AnalizadorSintactico()
        {

        }
        #endregion
        //***************************************
        //Metodos
        //***************************************
        #region Metodos
        public void analizar(String Expresion )
        {
            if (!OperadoresShuntingInicializados)       // Se inicializan los operadores permitidos con su precedencia
                ShuntingYard.InicializarOperadores();     // y asociatividad, tal como lo indica el algoritmo usado
            OperadoresShuntingInicializados = true; // (Shunting Yard)
            string ExpresionRPN = ShuntingYard.ConvertirInfijaAPosfija(Expresion); // Expresion en notación polaca revertida
            System.Windows.Forms.MessageBox.Show(ExpresionRPN);
            // Se convierte la cadena de la expresión en notación polaca revertida en un arreglo
            List<string> ExpresionRPNArreglo = new List<string>(ExpresionRPN.Split(' ').ToList());
            // Se elimina el objeto vacío sobrante al final del arreglo
            ExpresionRPNArreglo.RemoveAt(ExpresionRPNArreglo.Count - 1);
            //Graficar(ExpresionRPNArreglo);
        }
        private void Graficar(List<string> ExpresionPosfija)
        {
           

        }
        public System.Windows.Forms.Form crearFormulario()
        {
            // Se crea un formulario (requerido por la librería Microsoft.Msagl)
            System.Windows.Forms.Form Formulario = new System.Windows.Forms.Form();
            // Se ajusta el tamaño del formulario
            Formulario.Size = new Size(800, 600);
            //Creando objeto analizador_sintactico 
            //AnalizadorSintactico analizador_sintactico = new AnalizadorSintactico();
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
            return Formulario;
        }
        #endregion
    }
}
