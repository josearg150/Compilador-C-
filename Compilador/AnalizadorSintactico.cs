using System;
using System.Collections;
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
        List<string> ExpresionRPNArreglo;
        ArrayList tokens;
        #endregion
        //***************************************
        //Constructores   
        //***************************************
        #region Constructores
        public AnalizadorSintactico(ArrayList _tokens)
        {
            tokens = new ArrayList(_tokens);
        }
        #endregion
        //***************************************
        //Metodos
        //***************************************
        #region Metodos
        public void analizar(String Expresion)
        {
            ShuntingYard shunting = new ShuntingYard();
            if (!OperadoresShuntingInicializados)         // Se inicializan los operadores permitidos con su precedencia
                shunting.InicializarOperadores();     // y asociatividad, tal como lo indica el algoritmo usado
            OperadoresShuntingInicializados = true; // (Shunting Yard)
            string ExpresionRPN = shunting.ConvertirInfijaAPosfija(Expresion); // Expresion en notación polaca revertida     
            System.Windows.Forms.MessageBox.Show(ExpresionRPN);
            // Se convierte la cadena de la expresión en notación polaca revertida en un arreglo
            ExpresionRPNArreglo = new List<string>(ExpresionRPN.Split(' ').ToList());
            // Se elimina el objeto vacío sobrante al final del arreglo
            ExpresionRPNArreglo.RemoveAt(ExpresionRPNArreglo.Count - 1);
        
        }
        public Boolean IdentificarReservada(String palabra)
        {
            for (int i = 0; i < tokens.Count; ++i)
            {
                if (palabra == tokens[i].ToString())
                {
                    return true;
                }
            }
            return false;
        }
        public void quitarReservadas()
        {
            for (int i = 0; i < ExpresionRPNArreglo.Count; i++)
            {
                bool encontrado = IdentificarReservada(ExpresionRPNArreglo.ElementAt(i));
              /*  for (int j = 0; j < tokens.Count; j++)
                {
                    
                }*/
               
                if (encontrado)
                {
                    ExpresionRPNArreglo.RemoveAt(i);
                }
            }
        }
        public System.Windows.Forms.Form crearFormulario()
        {
            quitarReservadas();
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
            // Pila de nodos de la librería Microsoft.Msagl
            Stack<Microsoft.Msagl.Drawing.Node> PilaGrafica = new Stack<Microsoft.Msagl.Drawing.Node>();
            // ...
            ExpresionRPNArreglo.Reverse();
            int Id = 0;
            int i = 0;
            bool primerNodo = true;
            foreach (string c in ExpresionRPNArreglo)
            {
                bool result = int.TryParse(c, out i);//swaber si es numero 
                // Se incrementa el entero para identificar al siguiente nodo que se cree
                System.Windows.Forms.MessageBox.Show(c);
                Id++;
                if (primerNodo)
                {
                    var Nodo = Grafica.AddNode(Id.ToString());
                    Nodo.LabelText = c;
                    // Se introduce el nodo creado a la pila
                    PilaGrafica.Push(Nodo);
                    primerNodo = false;
                }
                else if (result)
                {
                    var T1 = PilaGrafica.Pop();
                    // Se crea un nuevo nodo con el operador
                    var Nodo = Grafica.AddNode(Id.ToString());
                    Nodo.LabelText = c;
                    // y se enlazan al nodo creado (operador)
                    Grafica.AddEdge(Nodo.Id, "", T1.Id);
                    // Se introduce el nodo creado a la pila
                    PilaGrafica.Push(Nodo);
                }
                
            }

            // Se asocia el visor al formulario creado al principio del método
            Visor.Graph = Grafica;
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
