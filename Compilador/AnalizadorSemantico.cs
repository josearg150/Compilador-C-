using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    /// <summary>
    ///     Clase Analizador semantico
    ///     Contiene los metodos para analizar errores en el codigo fuente 
    /// </summary>
    /// 
    /// <Para>
    ///     Con esta clase se puede analizar el codigo fuente en busca de errores semanticos
    /// </Para>
    /// 
    /// <Supuestos>
    ///     La clase se instanciará desde el form de la aplicación.
    /// </Supuestos>
    /// 
    /// <Autor>
    ///     Jose angel rocha garcia 
    ///     Jose luis carreon reyes
    /// </Autor>
    /// 
    /// <FechaCreacion >
    ///     27/09/2021
    /// </FechaCreacion>
    class AnalizadorSemantico
    {
        //***************************************
        //Variables locales                     
        //***************************************
        #region Variables
        static private List<Token> ListaTokens;
        System.Windows.Forms.DataGridView tabla;
        Stack<String> PilaOperandos = new Stack<String>(); 
        Stack<String> PilaOperadores = new Stack<String>();
        IdentificadorDeErrores ListaErrores;
        #endregion

        //***************************************
        //Constructores   
        //***************************************
        #region Constructores 
        public AnalizadorSemantico(List<Token> lista, System.Windows.Forms.DataGridView _tabla_simbolos, IdentificadorDeErrores Lista)
        {
            ListaTokens = lista;
            tabla = _tabla_simbolos;
            ListaErrores = Lista;
        }
        #endregion

        //***************************************
        //Metodos
        //***************************************
        #region Metodos
        /// <summary>
        ///     Analisis semantico principal
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void analizar()
        {
            tabla.Rows.Clear();
            //metemos los parentesis, corchetes o llaves en una pila 
            Stack<Token> llaves = new Stack<Token>();
            Stack<Token> parentesis = new Stack<Token>();
            Stack<Token> corchetes = new Stack<Token>();
            //Metemos las aperturas a su pila correspondiente
            for (int i = 0; i < ListaTokens.Count; i++)
            {
                Token token = (ListaTokens.ElementAt(i));
                if (token.getIdToken().Equals("llaveIzquierda")){
                    llaves.Push(token);
                }
                else if(token.getIdToken().Equals("parentIzquierdo"))
                {
                    parentesis.Push(token);
                }
                else if (token.getIdToken().Equals("corcheteIzquierdo"))
                {
                    corchetes.Push(token);
                 }
            }
            //Analizamos los cierres y sacamos elementos de sus respectivas pilas
            for (int i = 0; i < ListaTokens.Count; i++)
            {              
                if(ListaTokens.ElementAt(i).getIdToken().Equals("llaveDerecha"))
                {
                    if(llaves.Count == 0)
                    {
                        continue;
                    }
                    llaves.Pop();
                }
                else if (ListaTokens.ElementAt(i).getIdToken().Equals("parentDerecho"))
                {
                    if (parentesis.Count == 0)
                    {
                        continue;
                    }
                    parentesis.Pop();
                }
                else if (ListaTokens.ElementAt(i).getIdToken().Equals("corcheteDerecho"))
                {
                    if (corchetes.Count == 0)
                    {
                        continue;
                    }
                    corchetes.Pop();
                }
            }
            //Revisar operandos y operadores
            guardarOperadores_OperandosEnPila();
            //Pilas vacias no hay errores de cierre o apertura
            if (llaves.Count == 0 && parentesis.Count == 0 && corchetes.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("No se detectaron errores de apertura y cierre");
            }
            else
            {
                //Existen errores, se identifican las correspondendicas faltantes y se agregan a la tabla
                int renglon = 0;
                System.Windows.Forms.MessageBox.Show("Se detectaron errores");
                for(int i = 0; i < llaves.Count; i++)
                {
                    Token token = llaves.Pop();
                    string error = "Falta cierre de llave izquierda";
                    ListaErrores.agregarErrores("03", "Sintactico", token.getLexema(), error, token.getLinea(), token.getColumna());
                    renglon = tabla.Rows.Add();
                    tabla.Rows[renglon].Cells["colError"].Value = error;
                    tabla.Rows[renglon].Cells["colLinea"].Value = token.getLinea();
                    renglon++;
                }
                for (int i = 0; i < parentesis.Count; i++)
                {
                    Token token = parentesis.Pop();
                    string error = "Falta cierre de parentesis izquierdo";
                    ListaErrores.agregarErrores("03", "Sintactico", token.getLexema(), error, token.getLinea(), token.getColumna());
                    renglon = tabla.Rows.Add();
                    tabla.Rows[renglon].Cells["colError"].Value = error;
                    tabla.Rows[renglon].Cells["colLinea"].Value = token.getLinea();
                    renglon++;
                }
                for (int i = 0; i < corchetes.Count; i++)
                {
                    Token token = corchetes.Pop();
                    string error = "Falta cierre de corchete izquierdo";
                    ListaErrores.agregarErrores("03", "Sintactico", token.getLexema(), error, token.getLinea(), token.getColumna());
                    renglon = tabla.Rows.Add();
                    tabla.Rows[renglon].Cells["colError"].Value = error;
                    tabla.Rows[renglon].Cells["colLinea"].Value = token.getLinea();
                    renglon++;
                }                              
            }
        }

        /// <summary>
        ///     Categorizar los tokens según su operador
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void guardarOperadores_OperandosEnPila() {
            for (int i = 0; i < ListaTokens.Count; i++)
            {
                //Extraer lexema ingresado por el usuario
                String lexema = ListaTokens.ElementAt(i).getLexema();
                //Identificar si es operador u operando
                if (lexema.Equals("+") || lexema.Equals("-") || lexema.Equals("*") || lexema.Equals("/") || lexema.Equals("^"))
                {
                    PilaOperadores.Push(lexema);
                }
                else if (lexema.All(char.IsDigit))
                {
                    PilaOperandos.Push(lexema);
                }
                
            }
            Stack<String> pilaOperadoresInvertida = invertirPila(PilaOperadores);
            Stack<String> pilaOperandosInvertida = invertirPila(PilaOperandos);
            realizarOperaciones(pilaOperadoresInvertida, pilaOperandosInvertida);
        }

        /// <summary>
        ///     Operaciones en la pila semantica
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void realizarOperaciones(Stack<String> pilaOperadores, Stack<String> pilaOperandos)
        {
            Stack<String> pilaOperaciones = new Stack<String>();
            //Ingresamos dos operandos para realizar operaciones
            if(pilaOperadores.Count >= 2)
            {
                pilaOperaciones.Push(pilaOperandos.Pop());
                pilaOperaciones.Push(pilaOperandos.Pop());
            }
            //Contador para while
            int i = pilaOperadores.Count + pilaOperandos.Count;
            //meter los operadores y operandos restantes
            while (i > 0)
            {
                if(pilaOperadores.Count > 0)
                {
                    pilaOperaciones.Push(pilaOperadores.Pop());
                }
                if(pilaOperandos.Count > 0)
                {
                    pilaOperaciones.Push(pilaOperandos.Pop());
                }
                i--;
            }
            Stack<String> pilaOperacionesInvertida = invertirPila(pilaOperaciones);
            //Realizar operaciones 
            Stack<String> pilaAux = new Stack<String>();
            String operadores = "+-*^^";
            String operadorAnterior = "";
            bool continuar = true;
            bool finalizoCorrecto = true;
            while (pilaOperacionesInvertida.Count > 0)
            {
                String elem = pilaOperacionesInvertida.Pop();

                if (elem.All(char.IsDigit))
                {   
                    pilaAux.Push(elem);
                    continuar = true;
                }
                else if (operadorAnterior.Contains(elem))
                {
                    System.Windows.Forms.MessageBox.Show("Error en correspondencia de operadores, revise el codigo fuente");
                    ListaErrores.agregarErrores("05", "Sintactico", elem+operadorAnterior, "Error en correspondencia de operadores", 0, 0);
                    continuar = false;
                    finalizoCorrecto = false;
                    break;
                }
                else if(operadores.Contains(elem) && pilaAux.Count >= 2 && continuar)
                {
                    finalizoCorrecto = true;
                    switch (elem)
                    {
                        case "+": 
                            int suma = int.Parse(pilaAux.Pop()) + int.Parse(pilaAux.Pop());
                            pilaAux.Push(suma.ToString());
                            operadorAnterior = "+";
                             break;
                        case "-":
                            int resta = int.Parse(pilaAux.Pop()) - int.Parse(pilaAux.Pop());
                            pilaAux.Push(resta.ToString());
                            operadorAnterior = "-";
                            break;       
                        case "*":
                            int mult = int.Parse(pilaAux.Pop()) * int.Parse(pilaAux.Pop());
                            pilaAux.Push(mult.ToString());
                            operadorAnterior = "*";
                            break;
                        case "/":
                            int division = int.Parse(pilaAux.Pop()) / int.Parse(pilaAux.Pop());
                            pilaAux.Push(division.ToString());
                            operadorAnterior = "/";
                            break;                          
                        case "^":
                            Double pot = Math.Pow(int.Parse(pilaAux.Pop()), int.Parse(pilaAux.Pop()));  
                            pilaAux.Push(pot.ToString());
                            operadorAnterior = "^";
                            break;
                    }
                }
            } 
            
            while (pilaAux.Count == 1 && finalizoCorrecto)
            {
                pilaAux.Pop();
                System.Windows.Forms.MessageBox.Show("Existe correspondencia de operandos y operadores");
            }
        }

        /// <summary>
        ///     Invierte la pila semantica
        /// </summary>
        /// <param></param>
        /// <returns>La pila invertida</returns>
        private Stack<String> invertirPila(Stack<String> pilaR)
        {
            Stack<String> PilaFinal = new Stack<string>();
            while(pilaR.Count > 0)
            {
               PilaFinal.Push(pilaR.Pop());
            }
            return PilaFinal;
        }
        #endregion
    }
}
