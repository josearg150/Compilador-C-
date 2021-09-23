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
        private bool OperadoresShuntingInicializados = false;//operadores del algoritmo shunting 
        List<string> ExpresionRPNArreglo;//expresion que se usara para crear el arbol 
        ArrayList tokens;//tokens de la clase analisis lexico 
        ShuntingYard shunting;
        private readonly List<char> Numeros = new List<char>()
                    {
                        '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'
                    };
            //{ '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        #endregion

        //***************************************
        //Constructores   
        //***************************************
        #region Constructores
        public AnalizadorSintactico(ArrayList _tokens)
        {
            tokens = new ArrayList(_tokens);//se copian los tokens obtenidos 
            shunting = new ShuntingYard();
        }
        #endregion

        //***************************************
        //Metodos
        //***************************************
        #region Metodos
        public void analizar(String Expresion)
        {
            if (!OperadoresShuntingInicializados)         // Se inicializan los operadores permitidos con su precedencia
                shunting.InicializarOperadores();     // y asociatividad, tal como lo indica el algoritmo usado
            OperadoresShuntingInicializados = true; // (Shunting Yard)
            string ExpresionRPN = shunting.ConvertirInfijaAPosfija(Expresion); // Expresion en notación polaca revertida     
            //System.Windows.Forms.MessageBox.Show(ExpresionRPN);
            // Se convierte la cadena de la expresión en notación polaca revertida en un arreglo
            ExpresionRPNArreglo = new List<string>(ExpresionRPN.Split(' ').ToList());
            // Se elimina el objeto vacío sobrante al final del arreglo
            ExpresionRPNArreglo.RemoveAt(ExpresionRPNArreglo.Count - 1);
        }

        //metodo para identificar palabras reservadas 
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

        //metodo para quitar palabras reservadas 
        public void quitarReservadas()
        {
            for (int i = 0; i < ExpresionRPNArreglo.Count; i++)
            {
                bool encontrado = IdentificarReservada(ExpresionRPNArreglo.ElementAt(i));
                if (encontrado)
                {
                    ExpresionRPNArreglo.RemoveAt(i);//se quita el elemento detectado 
                }
            }
        }

        // metodo para quitar delimitadores
        public void quitarDelims()
        {
            for (int i = 0; i < ExpresionRPNArreglo.Count; i++)
            {
                if (ExpresionRPNArreglo[i].EndsWith(";"))
                {
                    ExpresionRPNArreglo[i] = ExpresionRPNArreglo[i].TrimEnd(';');
                }
            }
        }

        public System.Windows.Forms.Form crearFormulario()
        {
            //Se llama al metodo para eliminar las palabras reservadas
            quitarReservadas();
            quitarDelims();
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
            //ExpresionRPNArreglo.Reverse();
            int Id = 0;
            int i = 0;
            //bool primerNodo = true;
            foreach (string c in ExpresionRPNArreglo)
            {
                // Se incrementa el entero para identificar al siguiente nodo que se cree
                //System.Windows.Forms.MessageBox.Show(c);
                Id++;
                // Si es numero...
                try
                {
                    if (Numeros.Contains(char.Parse(c)))
                    {
                        var Nodo = Grafica.AddNode(Id.ToString());
                        Nodo.LabelText = "const";
                        var Nodo2 = Grafica.AddNode(Id + 1.ToString());
                        Nodo2.LabelText = c;
                        Grafica.AddEdge(Nodo.Id, "", Nodo2.Id);
                        // Se introduce el nodo creado a la pila
                        PilaGrafica.Push(Nodo);
                    }
                } catch
                {
                    
                }
                if (!shunting.OperadoresArr.Contains(c))
                {
                    var Nodo = Grafica.AddNode(Id.ToString());
                    Nodo.LabelText = "id";
                    var Nodo2 = Grafica.AddNode(Id + 1.ToString());
                    Nodo2.LabelText = c;
                    Grafica.AddEdge(Nodo.Id, "", Nodo2.Id);
                    PilaGrafica.Push(Nodo);
                } else if (shunting.OperadoresArr.Contains(c))
                {
                    var T1 = PilaGrafica.Pop();
                    var T2 = PilaGrafica.Pop();
                    // Se crea un nuevo nodo con el operador
                    var Nodo = Grafica.AddNode(Id.ToString());
                    Nodo.LabelText = c;
                    var Nodo2 = Grafica.AddNode(Id+1.ToString());
                    Nodo2.LabelText = "exp";
                    Grafica.AddEdge(Nodo2.Id, "", T1.Id);
                    // y se enlazan al nodo creado (operador)
                    Grafica.AddEdge(Nodo.Id, "", Nodo2.Id);
                    Grafica.AddEdge(Nodo.Id, "", T2.Id);
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
