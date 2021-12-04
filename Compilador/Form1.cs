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
        // Arreglos de referencia para establecer los caracteres que están permitidos en la expresión.
        private readonly char[] Operadores = { '+', '-', '*', '/', '^', '√' };
        private readonly char[] Numeros = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        AnalizadorLexico AnalizadorLexico;
        AnalizadorSintactico AnalizadorSintactico;
        AnalizadorSemantico AnalizadorSemantico;
        IdentificadorDeErrores ListaErrores;
        IDictionary<string, StringBuilder> Terminos = new Dictionary<string, StringBuilder>();
        Stack<string> PilaTerminos = new Stack<string>();
        int Tx = 1;
        #endregion

        //***************************************
        //Constructores   
        //***************************************
        #region Constructores 
        public Compilador()
        {
            InitializeComponent();
            ListaErrores = new IdentificadorDeErrores(dgvErrores);
            AnalizadorLexico = new AnalizadorLexico(txtLenguaje, dgvSimbolos, ListaErrores);
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
            }
            else if (txtLenguaje.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("No se cargó ningún archivo.");
            }
            else
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
            }
            else if (txtLenguaje.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("No se cargó ningún archivo.");
            }
            else if (txtCodigoFuente.SelectedText.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Por favor seleccione una línea.");
            }
            else
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
                    }
                    else
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
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Error al abrir el archivo.");
            }
        }

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
            ListaErrores.setCodigo(txtCodigoFuente);
            ListaErrores.mostrar();
        }
        #endregion

        /// <summary>
        ///     Valida el input dado por el usuario.
        /// </summary>
        /// <param name="expresion">Cadena con la expresión a validar.</param>
        /// <returns>La expresión validada en forma de cadena, o una cadena vacía en caso de error.</returns>
        private string ValidarInput(string expresion)
        {
            if (expresion.Equals(""))
            {
                // Se retorna una cadena vacía cuando haya error de validación.
                return "";
            }
            else
            {
                // Cadena que lleva cuenta del tipo de caracter en cada iteración (si es operador, número)
                string AuxChar = "";
                // Lista genérica de cadenas usada para ir armando la expresión validada.
                List<string> ExpresionValidada = new List<string>();

                int i = 0;
                // Por cada caracter en la expresión dada...
                foreach (char c in expresion)
                {
                    // Se ignoran los espacios
                    if (c.Equals(' '))
                    {
                        i++;
                        continue;
                    }
                    // Operadores que no sean operadores o números no se aceptan
                    if (!Operadores.Contains(c) && !Numeros.Contains(c))
                    {
                        return "";
                    }
                    // La expresión no puede comenzar con un operador
                    if (i == 0 && Operadores.Contains(c) && c != '√')
                    {
                        return "";
                    }
                    // A menos que sea una raíz cuadrada
                    else if (i == 0 && c == '√')
                    {
                        AuxChar = "op";
                    }
                    // La expresión no puede terminar con un operador
                    else if (i == expresion.Length - 1 && Operadores.Contains(c))
                    {
                        return "";
                    }
                    // Dos operadores no pueden estar uno al lado del otro, excepto por la raíz cuadrada (el 2 es implícito)
                    if (AuxChar.Equals("op") && Operadores.Contains(c))
                    {
                        if (c == '√')
                        {
                            ExpresionValidada.Add("2");
                        }
                        else
                        {
                            return "";
                        }
                    }

                    // Como la iteración se lleva a cabo caracter por caracter, si se encuentra un número y el caracter
                    // anterior también fue un número, ambos se unen para formar un número de x dígitos
                    if (AuxChar == "num" && Numeros.Contains(c))
                    {
                        ExpresionValidada.Insert(ExpresionValidada.Count - 1, ExpresionValidada.ElementAt(ExpresionValidada.Count - 1) + c.ToString());
                        ExpresionValidada.RemoveAt(ExpresionValidada.Count - 1);
                        i++;
                        AuxChar = "num";
                        continue;
                    }

                    // Se lleva cuenta de si el caracter de la iteración anterior es número u operador
                    if (Numeros.Contains(c))
                    {
                        AuxChar = "num";
                    }
                    else if (Operadores.Contains(c))
                    {
                        AuxChar = "op";
                    }

                    // Se inserta el término evaluado en el arreglo que se retornará como cadena al final
                    ExpresionValidada.Add(c.ToString());
                    i++;
                }
                // Se retorna la cadena con la expresión validada con un espacio para dividir cada término,
                // puesto que el algoritmo Shunting Yard así lo requiere.
                return string.Join(" ", ExpresionValidada);
            }
        }

        /// <summary>
        ///     Convierte la expresión validada en notación polaca revertida a un árbol. (No se usa, solo se
        ///     implementó para un potencial uso futuro con otros analizadores.)
        /// </summary>
        /// <param name="ExpresionPosfija">La expresión validada en notación polaca revertida a evaluar en forma de una lista genérica de cadenas.</param>
        /// <returns>Un árbol binario de expresiones.</returns>
        private Nodo ConvertirRPNAArbol(List<string> ExpresionPosfija)
        {
            // Se sigue exactamente el mismo algoritmo descrito en el método Graficar().
            // Sólo cambian los objetos utilizados para las operaciones.
            Stack<Nodo> PilaArbol = new Stack<Nodo>();
            foreach (string c in ExpresionPosfija)
            {
                if (Numeros.Contains(c[0]))
                {
                    Nodo Nodo = new Nodo(c);
                    PilaArbol.Push(Nodo);
                }
                else if (Operadores.Contains(c[0]))
                {
                    Nodo T1 = PilaArbol.Pop();
                    Nodo T2 = PilaArbol.Pop();
                    Nodo Nodo = new Nodo(c);
                    Nodo.Izquierda = T1;
                    Nodo.Derecha = T2;
                    PilaArbol.Push(Nodo);
                }
            }
            return PilaArbol.Pop();
        }

        // Postorden
        /// <summary>
        ///     Recorre el árbol dado en postorden.
        /// </summary>
        /// <param name="Nodo">El nodo raíz del árbol a recorrer.</param>
        /// <returns>N/A</returns>
        private void RecorrerArbol(Nodo Nodo)
        {
            if (Nodo != null)
            {
                RecorrerArbol(Nodo.Izquierda);
                RecorrerArbol(Nodo.Derecha);
                try
                {
                    if (Operadores.ToList().Contains(char.Parse(Nodo.Valor)))
                    {
                        string Termino = Nodo.Izquierda.Valor + Nodo.Valor + Nodo.Derecha.Valor;
                        try
                        {
                            if (Operadores.ToList().Contains(char.Parse(Nodo.Izquierda.Valor)) && !Operadores.ToList().Contains(char.Parse(Nodo.Derecha.Valor)))
                            {
                                Termino = PilaTerminos.Pop() + Nodo.Valor + Nodo.Derecha.Valor;

                            }
                            else if (!Operadores.ToList().Contains(char.Parse(Nodo.Izquierda.Valor)) && Operadores.ToList().Contains(char.Parse(Nodo.Derecha.Valor)))
                            {
                                Termino = Nodo.Izquierda.Valor + Nodo.Valor + PilaTerminos.Pop();

                            }
                            else if (Operadores.ToList().Contains(char.Parse(Nodo.Izquierda.Valor)) && Operadores.ToList().Contains(char.Parse(Nodo.Derecha.Valor)))
                            {
                                string Termino1 = PilaTerminos.Pop();
                                string Termino2 = PilaTerminos.Pop();
                                Termino = Termino2 + Nodo.Valor + Termino1;
                            }
                        }
                        catch
                        {

                        }
                        dgvCodigoTresD.Rows.Add();
                        dgvCodigoTresD.Rows[Tx].Cells["T"].Value = Tx.ToString();
                        dgvCodigoTresD.Rows[Tx].Cells["Expresion"].Value = Termino;
                        PilaTerminos.Push("T" + Tx.ToString());
                        Tx++;
                    }
                }
                catch
                {

                }
            }
        }

        /// <summary>
        ///     Invierte los nodos del árbol binario dado.
        /// </summary>
        /// <param name="Nodo">El nodo raíz del árbol a invertir.</param>
        /// <returns>El nodo raíz del árbol ya invertido.</returns>
        private Nodo InvertirArbol(Nodo Nodo)
        {
            if (Nodo == null) return null;

            var left = Nodo.Izquierda;
            var right = Nodo.Derecha;
            Nodo.Derecha = this.InvertirArbol(left);
            Nodo.Izquierda = this.InvertirArbol(right);

            return Nodo;
        }

        /// <summary>
        ///     Genera los triplos correspondientes del código de tres direcciones previamente generado.
        /// </summary>
        /// <returns>N/A</returns>
        private void triplosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigoFuente.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("El input no puede estar vacío.");
            }
            else if (txtLenguaje.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("No se cargó ningún archivo.");
            }
            else if (txtCodigoFuente.SelectedText.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Por favor seleccione una línea.");
            }
            else
            {
                // Solo se debe seleccionar una sola linea
                String Linea = txtCodigoFuente.SelectedText;
                if (Linea.Contains("\n"))
                {
                    System.Windows.Forms.MessageBox.Show("Por favor seleccione sólo una línea.");
                }
                else
                {
                    string Expresion = ValidarInput(Linea); // La expresión validada
                    if (Expresion.Equals("")) // Se muestra un popup avisando que la validación no fue exitosa.
                    {
                        System.Windows.Forms.MessageBox.Show("Input inválido. Intente de nuevo.");
                    }
                    else
                    {
                        ShuntingYard shuntingYard = new ShuntingYard();
                        shuntingYard.InicializarOperadores();
                        string ExpresionRPN = shuntingYard.ConvertirInfijaAPosfija(Expresion); // Expresion en notación polaca revertida
                        // System.Windows.Forms.MessageBox.Show(ExpresionRPN);
                        // Se convierte la cadena de la expresión en notación polaca revertida en un arreglo
                        List<string> ExpresionRPNArreglo = new List<string>(ExpresionRPN.Split(' ').ToList());
                        // Se elimina el objeto vacío sobrante al final del arreglo
                        ExpresionRPNArreglo.RemoveAt(ExpresionRPNArreglo.Count - 1);

                        Nodo NodoRaiz = ConvertirRPNAArbol(ExpresionRPNArreglo);

                        tbcInformacion.SelectTab(tbpCod3Dir);
                        dgvCodigoTresD.Rows.Clear();
                        dgvCodigoTresD.Refresh();
                        dgvCodigoTresD.Rows.Add();
                        Nodo NodoInvertido = InvertirArbol(NodoRaiz);
                        RecorrerArbol(NodoInvertido);
                        dgvCodigoTresD.Rows.RemoveAt(0);
                    }
                }
            }
        }

        private void cuadrplosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigoFuente.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("El input no puede estar vacío.");
            }
            else if (txtLenguaje.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("No se cargó ningún archivo.");
            }
            else
            {
                //Aqui va lo que va hacer el codigo 
                tbcInformacion.SelectTab(tbpCuadruplos);
                dgvCuadruplos.Rows.Clear();
                dgvCuadruplos.Refresh();
                Cuadruplo cuadr = new Cuadruplo(AnalizadorLexico.getListaTokens(), dgvCuadruplos);
                cuadr.realizarCuadruplo();
            }
        }

        /// <summary>
        ///     Genera el código ensamblador correspondiente a los cuádruplos previamente generados.
        /// </summary>
        /// <returns>N/A</returns>
        private void ensambladorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbcInformacion.SelectTab(tbpEnsamblador);
            rtbEnsamblador.Text = "";
            String NombreFuncion = "";
            String NombreVariable = "";
            String MnemOperacion = "";
            String Ensamblaje = "";
            String OperandoUno = "";
            String OperandoDos = "";

            String OperacionAritmetica = "";
            List<Token> ListaDeTokens = AnalizadorLexico.getListaTokens();
            for (int i = 0; i < ListaDeTokens.Count; i++)
            {
                Token token_actual = ListaDeTokens.ElementAt(i);
                if (token_actual.getLexema().Equals("void"))
                {
                    if (ListaDeTokens.ElementAt(i + 2).getIdToken().Equals("parentIzquierdo"))
                    {
                        NombreFuncion = ListaDeTokens.ElementAt(i + 1).getLexema();
                        OperacionAritmetica = ListaDeTokens.ElementAt(i + 9).getLexema();
                        OperandoUno = ListaDeTokens.ElementAt(i + 8).getLexema();
                        OperandoDos = ListaDeTokens.ElementAt(i + 10).getLexema();
                        if (OperacionAritmetica.Equals("+"))
                        {
                            NombreVariable = "suma";
                            MnemOperacion = "ADD";
                        } else if (OperacionAritmetica.Equals("-"))
                        {
                            NombreVariable = "resta";
                            MnemOperacion = "SUB";
                        } else if (OperacionAritmetica.Equals("*"))
                        {
                            NombreVariable = "multiplicacion";
                            MnemOperacion = "MUL";
                        } else if (OperacionAritmetica.Equals("/"))
                        {
                            NombreVariable = "division";
                            MnemOperacion = "DIV";
                        }
                    }
                }
            }
            Ensamblaje = "lbl" + NombreFuncion + "Llamada:\n" +
                         "CALL lbl" + NombreFuncion + "\n" +
                         "JMP lbl" + NombreFuncion + "Salida\n" +
                         "\n" +
                         "lbl" + NombreFuncion + ":\n" +
                         NombreVariable + " db 0" + "\n" +
                         "PUSH AX\n" +
                         "MOV AX, " + OperandoUno + "\n" +
                         MnemOperacion + " AX, " + OperandoDos + "\n" +
                         "MOV " + "[" + NombreVariable + "]" + ", AX\n" +
                         "POP AX\n" +
                         "RET\n" +
                         "\n" +
                         "lbl" + NombreFuncion + "Salida:\n";
            rtbEnsamblador.Text = Ensamblaje;
        }
    }
}
