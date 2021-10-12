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
        Stack<String> PilaIDR = new Stack<String>();
        #endregion
        //***************************************
        //Constructores   
        //***************************************
        #region Constructores 
        public AnalizadorSemantico(List<Token> lista, System.Windows.Forms.DataGridView _tabla_simbolos)
        {
            ListaTokens = lista;
            tabla = _tabla_simbolos;
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

            if(tokens.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("No se detectaron errores");
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
                    }
                    else if (lexema.Equals("{"))
                    {
                        error = "Falta cierre de llave izquierda";
                    }
                    else if (lexema.Equals("["))
                    {
                        error = "Falta cierre de corchete izquierdo";
                    }
                    i = tabla.Rows.Add();
                    tabla.Rows[i].Cells["colError"].Value = error;
                    tabla.Rows[i].Cells["colLinea"].Value = token.getLinea();
                }
            }
        }

        private void guardarOperadores_OperandosEnPila() {
            for (int i = 0; i <= ListaTokens.Count; i++)
            {
                //Extraer lexema ingresado por el usuario
                String lexema = ListaTokens.ElementAt(i).getLexema();
                //Identificar si es operador u operando
                if (lexema.Equals("+") || lexema.Equals("-") || lexema.Equals("*") || lexema.Equals("/") || lexema.Equals("^") 
                    || lexema.All(char.IsDigit))
                {
                    PilaIDR.Push(lexema);
                }
                
            }
        }
        #endregion
    }
}
