using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    /// <summary>
    ///     Clase Analizador lexico
    ///     Contiene los metodos para analizar el codigo fuente 
    /// </summary>
    /// 
    /// <Para>
    ///     Con esta clase se puede analizar el codigo fuente y mostrar sus errores y simbolos 
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
    ///     14/09/2021
    /// </FechaCreacion>
    class AnalizadorLexico
    {
        //***************************************
        //Variables locales                     
        //***************************************
        #region Variables
        //Variables que se usaran en el analiador lexico, como atributos de tokens, caracter 
        ArrayList tokens;//Lista de palabras reservadas 
        int estado;
        int columna;
        int fila;
        string lexema;
        Char caracter;
        public int estado_token;
        static private List<Token> listaDeTokens;
        //Elementos graficos del form
        System.Windows.Forms.RichTextBox txtLenguaje; 
        System.Windows.Forms.DataGridView tabla_simbolos; 
        #endregion

        //***************************************
        //Constructores   
        //***************************************
        #region Constructores 
        //Constructor con parametros 
        public AnalizadorLexico(System.Windows.Forms.RichTextBox _lenguaje, System.Windows.Forms.DataGridView _tabla_simbolos)
        {
            tabla_simbolos = _tabla_simbolos;
            txtLenguaje = _lenguaje;
            listaDeTokens = new List<Token>();
            tokens = new ArrayList();
            //Lista de palabras reservadas
            tokens.Add("inicio");  
            tokens.Add("prueba"); 
            tokens.Add("reservada"); 
        }
        #endregion

        //***************************************
        //Metodos
        //***************************************
        #region Metodos
        //metodo para agregar tokens a la lista 
        public void agregarToken(String lexema, String idToken, int linea, int columna, int indice)
        {
            Token nuevo = new Token(lexema, idToken, linea, columna, indice);
            listaDeTokens.Add(nuevo);
        }
        //Metodo para saber si es reservada o no
        public Boolean IdentificarReservada(String palabra)
        {
            Boolean encontrado = false;
            for (int i = 0; i < tokens.Count; ++i)
            {
                if (palabra == tokens[i].ToString())
                {
                    encontrado = true;
                    estado_token = i;
                    return encontrado;
                }
                else { 
                    encontrado = false; 
                }

            }
            return encontrado;
        }

        //metodo para analizar el codigo fuente
        public void analizar(string _codigoFuente)
        {
            //incializamos variables de estado e identificadores en tabla 
            //el estado en 0 es un error o espacio en blanco por lo cual volvera a analizar 
            estado = 0;
            columna = 0;
            fila = 1;
            lexema = "";
            _codigoFuente = _codigoFuente + " ";

            for (int i = 0; i < _codigoFuente.Length; i++)
            {
                caracter = _codigoFuente[i];//tomamos el caracter 
                columna++;//aumentamos columna 

                switch (estado)
                {
                    case 0:
                        if (Char.IsLetter(caracter))//Comparamos si es una letra
                        {
                            estado = 1;
                            lexema += caracter; //Agregamos el caracter al lexema
                        }
                        else if (Char.IsDigit(caracter))//Comparamos si es numero
                        {
                            estado = 2;
                            lexema += caracter;
                        }
                        //Comparaciones de comillas, comas, espacios en blancos etc.
                        else if (caracter == '"') 
                        {
                            estado = 4;
                            i--;
                            columna--;
                        }
                        else if (caracter == ',')
                        {
                            estado = 6;
                            i--;
                            columna--;
                        }
                        else if (caracter == ' ')
                        {
                            estado = 0;
                        }
                        else if (caracter == '\n')
                        {
                            columna = 0;
                            fila++;
                            estado = 0;
                        }
                        //Delimitadores
                        else if (caracter == '{')
                        {
                            lexema += caracter;
                            agregarToken(lexema, "llaveIzquierda", fila, columna, i - lexema.Length);
                            lexema = "";//se deja en blanco el lexema para seguir analizando 
                        }
                        else if (caracter == '}')
                        {
                            lexema += caracter;
                            agregarToken(lexema, "llaveDerecha", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (caracter == '(')
                        {
                            lexema += caracter;
                            agregarToken(lexema, "parentIzquierdo", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (caracter == ')')
                        {
                            lexema += caracter;
                            agregarToken(lexema, "parentDerecho", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (caracter == ',')
                        {
                            lexema += caracter;
                            lexema = "";
                        }

                        else if (caracter == ';')
                        {
                            lexema += caracter;
                            agregarToken(lexema, "Punto y Coma", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        //Comparadores
                        else if (caracter == '=')
                        {
                            lexema += caracter;
                            agregarToken(lexema, "Asignacion", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (caracter == '<')
                        {
                            lexema += caracter;
                            agregarToken(lexema, "Menor que", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (caracter == '>')
                        {
                            lexema += caracter;
                            agregarToken(lexema, "Mayor que", fila, columna, i - lexema.Length);
                            lexema = "";
                        }

                        else if (caracter == '.')
                        {
                            lexema += caracter;
                            agregarToken(lexema, "Punto", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        //Operadores
                        else if (caracter == '+')
                        {
                            lexema += caracter;
                            agregarToken(lexema, "Suma", fila, columna, i);
                            lexema = "";
                        }
                        else if (caracter == '-')
                        {
                            lexema += caracter;
                            agregarToken(lexema, "Resta", fila, columna, i);
                            lexema = "";
                        }
                        else if (caracter == '*')
                        {
                            lexema += caracter;
                            agregarToken(lexema, "Multiplicacion", fila, columna, i);
                            lexema = "";
                        }
                        else if (caracter == '/')
                        {
                            lexema += caracter;
                            agregarToken(lexema, "Division", fila, columna, i);
                            lexema = "";
                        }
                        else
                        {
                            //no es ninguno de los anteriores
                            estado = -99;
                            i--;
                            columna--;
                        }
                        break;

                    case 1:
                        //comparamos para saber si es un numero o una variable tipo _hola
                        if (Char.IsLetterOrDigit(caracter) || caracter == '_')
                        {
                            lexema += caracter;
                            estado = 1;
                        }
                        else
                        {
                            //buscamos si es una palabra reservada o un identificador con el metodo de abajo
                            Boolean encontrado = false;
                            encontrado = IdentificarReservada(lexema);
                            if (encontrado)
                            {
                                agregarToken(lexema, "Reservada", fila, columna, i - lexema.Length);
                            }
                            else
                            {
                                agregarToken(lexema, "Identificador", fila, columna, i - lexema.Length);
                            }
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }
                        break;
                    case 2:
                        //analisis si es un numero 
                        if (Char.IsDigit(caracter))
                        {
                            lexema += caracter;
                            estado = 2;
                        }
                        else if (caracter == '.')
                        {
                            estado = 8;
                            lexema += caracter;
                        }
                        else
                        {
                            agregarToken(lexema, "Digito", fila, columna, i - lexema.Length);
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }
                        break;
                    case 3:
                        if (Char.IsDigit(caracter))
                        {
                            lexema += caracter;
                            estado = 2;
                        }
                        else
                        {
                            estado = -99;
                            i = i - 2;
                            columna = columna - 2;
                            lexema = "";
                        }
                        break;
                    case 4:
                        //analisis para char y string 
                        if (caracter == '"')
                        {
                            lexema += caracter;
                            estado = 5;
                        }
                        break;
                    case 5:
                        if (caracter != '"')
                        {
                            lexema += caracter;
                            estado = 5;
                        }
                        else
                        {
                            estado = 6;
                            i--;
                            columna--;
                        }
                        break;
                    case 6:
                        if (caracter == '"')
                        {
                            lexema += caracter;
                            agregarToken(lexema, "Cadena", fila, columna, i - lexema.Length);
                            estado = 0;
                            lexema = "";
                        }
                        else if (caracter == ',')
                        {
                            lexema += caracter;
                            agregarToken(lexema, "Coma", fila, columna, i - lexema.Length);
                            estado = 0;
                            lexema = "";
                        }

                        break;

                    case 8:
                        if (Char.IsDigit(caracter))
                        {
                            estado = 9;
                            lexema += caracter;
                        }
                        else
                        {
                            estado = 0;
                            lexema = "";
                        }
                        break;
                    case 9:
                        if (Char.IsDigit(caracter))
                        {
                            estado = 9;
                            lexema += caracter;
                        }
                        else
                        {
                            agregarToken(lexema, "Digito", fila, columna, i - lexema.Length);
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }

                        break;

                    case -99:
                        //es un posible error o espacio blanco por lo tanto el estado es 0 
                        lexema += caracter;
                        estado = 0;
                        lexema = "";
                        break;
                }
            }
        }

        //Metodo para mostrar en la tabla
        public void mostrar()
        {
            for (int i = 0; i < listaDeTokens.Count; i++)
            {
                //Asignamos el token de la lista a un token auxiliar 
                Token token_actual = listaDeTokens.ElementAt(i);
                i = tabla_simbolos.Rows.Add();//creamos una fila 
                //Asignamos datos a columnas
                tabla_simbolos.Rows[i].Cells["Lexema"].Value = token_actual.getLexema();
                tabla_simbolos.Rows[i].Cells["TipoToken"].Value = token_actual.getIdToken();
                tabla_simbolos.Rows[i].Cells["Linea"].Value = token_actual.getLinea();
            }

            for (int i = 0; i < tokens.Count; i++)
            {
                txtLenguaje.Text = txtLenguaje.Text + "\n" + tokens[i];
            }
        }



        #endregion
    }
}
