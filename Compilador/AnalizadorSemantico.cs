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
        public void analizar()
        { 
            //metemos los parentesis, corchetes o llaves en una pila 
            Stack<Token> tokens = new Stack<Token>();
            for (int i = 0; i < ListaTokens.Count; i++)
            {
                Token token = (ListaTokens.ElementAt(i));
                if (token.getIdToken().Equals("llaveIzquierda")
                    || token.getIdToken().Equals("parentIzquierdo")
                    || token.getIdToken().Equals("corcheteIzquierdo"))
                {
                    tokens.Push(token);
                }
            }
          
            for (int i = 0; i < ListaTokens.Count; i++)
            {   if(tokens.Count == 0)
                {
                    break;
                }
                Token token = tokens.Peek();
                if (token.getIdToken().Equals("llaveIzquierda") && ListaTokens.ElementAt(i).getIdToken().Equals("llaveDerecha"))
                {
                    tokens.Pop();
                }
                else if (token.getIdToken().Equals("parentIzquierdo") && ListaTokens.ElementAt(i).getIdToken().Equals("parentDerecho"))
                {
                    
                    tokens.Pop();
                }
                else if(token.getIdToken().Equals("corcheteIzquierdo") && ListaTokens.ElementAt(i).getIdToken().Equals("corcheteDerecho"))
                {
                    tokens.Pop();
                }
            }
            guardarOperadores_OperandosEnPila();
            if (tokens.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("No se detectaron errores de apertura y cierre");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Se detectaron errores");
                for(int i = 0; i <= tokens.Count; i++)
                {
                    Token token = tokens.Pop();
                    
                    string error = " ";
                    string lexema = token.getLexema();
                    if (lexema.Equals("("))
                    {
                        error = "Falta cierre de parentesis izquierdo";
                        ListaErrores.agregarErrores("03", "Sintactico", token.getLexema(), error, token.getLinea(), token.getColumna());
                    }
                    else if (lexema.Equals("{"))
                    {
                        error = "Falta cierre de llave izquierda";
                        ListaErrores.agregarErrores("03", "Sintactico", token.getLexema(), error, token.getLinea(), token.getColumna());
                    }
                    else if (lexema.Equals("["))
                    {
                        error = "Falta cierre de corchete izquierdo";
                        ListaErrores.agregarErrores("03", "Siintactico", token.getLexema(), error, token.getLinea(), token.getColumna());
                    }
                    i = tabla.Rows.Add();
                    tabla.Rows[i].Cells["colError"].Value = error;
                    tabla.Rows[i].Cells["colLinea"].Value = token.getLinea();
                    //Guardamos los operadores y operandos en la pila 
                    
                }
            }
        }

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
                    System.Windows.Forms.MessageBox.Show("Error en correspondencia");
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
