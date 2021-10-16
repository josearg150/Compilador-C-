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
        ArrayList Tokens; //Lista de palabras reservadas 
        int Estado;
        int Columna;
        int Fila;
        string Lexema;
        Char Caracter;
        public int EstadoToken;
        static private List<Token> ListaTokens;
        IdentificadorDeErrores ListaErrores;
        //Elementos graficos del form
        System.Windows.Forms.RichTextBox txtLenguaje; 
        System.Windows.Forms.DataGridView tabla_simbolos; 
        #endregion

        //***************************************
        //Constructores   
        //***************************************
        #region Constructores 
        //Constructor con parametros 
        public AnalizadorLexico(System.Windows.Forms.RichTextBox _lenguaje, System.Windows.Forms.DataGridView _tabla_simbolos,
                                IdentificadorDeErrores lista)
        {
            tabla_simbolos = _tabla_simbolos;
            txtLenguaje = _lenguaje;
            ListaTokens = new List<Token>();
            ListaErrores = lista;
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
            ListaTokens.Add(nuevo);
        }
        
        //Metodo para saber si es reservada o no
        public Boolean IdentificarReservada(String palabra)
        {
            Boolean encontrado = false;
            for (int i = 0; i < Tokens.Count; ++i)
            {
                if (palabra == Tokens[i].ToString())
                {
                    encontrado = true;
                    EstadoToken = i;
                    return encontrado;
                }
            }
            return encontrado;
        }

        //metodo para analizar el codigo fuente
        public void analizar(string _codigoFuente)
        {
            ListaTokens.Clear();
            //incializamos variables de estado e identificadores en tabla 
            //el estado en 0 es un error o espacio en blanco por lo cual volvera a analizar 
            Estado = 0;
            Columna = 0;
            Fila = 1;
            Lexema = "";
            _codigoFuente += " ";

            for (int i = 0; i < _codigoFuente.Length; i++)
            {
                Caracter = _codigoFuente[i]; //tomamos el caracter 
                Columna++; //aumentamos columna 

                switch (Estado)
                {
                    case 0:
                        if (Char.IsLetter(Caracter))//Comparamos si es una letra
                        {
                            Estado = 1;
                            Lexema += Caracter; //Agregamos el caracter al lexema
                        }
                        else if (Char.IsDigit(Caracter))//Comparamos si es numero
                        {
                            Estado = 2;
                            Lexema += Caracter;
                        }
                        //Comparaciones de comillas, comas, espacios en blancos etc.
                        else if (Caracter == '"') 
                        {
                            Estado = 4;
                            i--;
                            Columna--;
                        }
                        else if (Caracter == ',')
                        {
                            Estado = 6;
                            i--;
                            Columna--;
                        }
                        else if (Caracter == ' ')
                        {
                            Estado = 0;
                        }
                        else if (Caracter == '\n')
                        {
                            Columna = 0;
                            Fila++;
                            Estado = 0;
                        }
                        //Delimitadores
                        else if (Caracter == '{')
                        {
                            Lexema += Caracter;
                            agregarToken(Lexema, "llaveIzquierda", Fila, Columna, i - Lexema.Length);
                            Lexema = "";//se deja en blanco el lexema para seguir analizando 
                        }
                        else if (Caracter == '}')
                        {
                            Lexema += Caracter;
                            agregarToken(Lexema, "llaveDerecha", Fila, Columna, i - Lexema.Length);
                            Lexema = "";
                        }
                        else if (Caracter == '(')
                        {
                            Lexema += Caracter;
                            agregarToken(Lexema, "parentIzquierdo", Fila, Columna, i - Lexema.Length);
                            Lexema = "";
                        }
                        else if (Caracter == ')')
                        {
                            Lexema += Caracter;
                            agregarToken(Lexema, "parentDerecho", Fila, Columna, i - Lexema.Length);
                            Lexema = "";
                        }
                        else if (Caracter == '[')
                        {
                            Lexema += Caracter;
                            agregarToken(Lexema, "corcheteIzquierdo", Fila, Columna, i - Lexema.Length);
                            Lexema = "";
                        }
                        else if (Caracter == ']')
                        {
                            Lexema += Caracter;
                            agregarToken(Lexema, "corcheteDerecho", Fila, Columna, i - Lexema.Length);
                            Lexema = "";
                        }
                        else if (Caracter == ',')
                        {
                            Lexema += Caracter;
                            Lexema = "";
                        }

                        else if (Caracter == ';')
                        {
                            Lexema += Caracter;
                            agregarToken(Lexema, "Punto y Coma", Fila, Columna, i - Lexema.Length);
                            Lexema = "";
                        }
                        //Comparadores
                        else if (Caracter == '=')
                        {
                            Lexema += Caracter;
                            agregarToken(Lexema, "Asignacion", Fila, Columna, i - Lexema.Length);
                            Lexema = "";
                        }
                        else if (Caracter == '<')
                        {
                            Lexema += Caracter;
                            agregarToken(Lexema, "Menor que", Fila, Columna, i - Lexema.Length);
                            Lexema = "";
                        }
                        else if (Caracter == '>')
                        {
                            Lexema += Caracter;
                            agregarToken(Lexema, "Mayor que", Fila, Columna, i - Lexema.Length);
                            Lexema = "";
                        }

                        else if (Caracter == '.')
                        {
                            Lexema += Caracter;
                            agregarToken(Lexema, "Punto", Fila, Columna, i - Lexema.Length);
                            Lexema = "";
                        }
                        //Operadores
                        else if (Caracter == '+')
                        {
                            Lexema += Caracter;
                            agregarToken(Lexema, "Suma", Fila, Columna, i);
                            Lexema = "";
                        }
                        else if (Caracter == '-')
                        {
                            Lexema += Caracter;
                            agregarToken(Lexema, "Resta", Fila, Columna, i);
                            Lexema = "";
                        }
                        else if (Caracter == '*')
                        {
                            Lexema += Caracter;
                            agregarToken(Lexema, "Multiplicacion", Fila, Columna, i);
                            Lexema = "";
                        }
                        else if (Caracter == '/')
                        {
                            Lexema += Caracter;
                            agregarToken(Lexema, "Division", Fila, Columna, i);
                            Lexema = "";
                        }
                        else
                        {
                            //no es ninguno de los anteriores
                            Estado = -99;
                            i--;
                            Columna--;
                        }
                        break;

                    case 1:
                        //comparamos para saber si es un numero o una variable tipo _hola
                        if (Char.IsLetterOrDigit(Caracter) || Caracter == '_')
                        {
                            Lexema += Caracter;
                            Estado = 1;
                        }
                        else
                        {
                            //buscamos si es una palabra reservada o un identificador con el metodo de abajo
                            Boolean encontrado = false;
                            encontrado = IdentificarReservada(Lexema);
                            if (encontrado)
                            {
                                agregarToken(Lexema, "Reservada", Fila, Columna, i - Lexema.Length);
                            }
                            else
                            {
                                agregarToken(Lexema, "Identificador", Fila, Columna, i - Lexema.Length);
                            }
                            Lexema = "";
                            i--;
                            Columna--;
                            Estado = 0;
                        }
                        break;
                    case 2:
                        //analisis si es un numero 
                        if (Char.IsDigit(Caracter))
                        {
                            Lexema += Caracter;
                            Estado = 2;
                        }
                        else if (Caracter == '.')
                        {
                            Estado = 8;
                            Lexema += Caracter;
                        }
                        else
                        {
                            agregarToken(Lexema, "Digito", Fila, Columna, i - Lexema.Length);
                            Lexema = "";
                            i--;
                            Columna--;
                            Estado = 0;
                        }
                        break;
                    case 3:
                        if (Char.IsDigit(Caracter))
                        {
                            Lexema += Caracter;
                            Estado = 2;
                        }
                        else
                        {
                            Estado = -99;
                            i = i - 2;
                            Columna = Columna - 2;
                            Lexema = "";
                        }
                        break;
                    case 4:
                        //analisis para char y string 
                        if (Caracter == '"')
                        {
                            Lexema += Caracter;
                            Estado = 5;
                        }
                        break;
                    case 5:
                        if (Caracter != '"')
                        {
                            Lexema += Caracter;
                            Estado = 5;
                        }
                        else
                        {
                            Estado = 6;
                            i--;
                            Columna--;
                        }
                        break;
                    case 6:
                        if (Caracter == '"')
                        {
                            Lexema += Caracter;
                            agregarToken(Lexema, "Cadena", Fila, Columna, i - Lexema.Length);
                            Estado = 0;
                            Lexema = "";
                        }
                        else if (Caracter == ',')
                        {
                            Lexema += Caracter;
                            agregarToken(Lexema, "Coma", Fila, Columna, i - Lexema.Length);
                            Estado = 0;
                            Lexema = "";
                        }

                        break;

                    case 8:
                        if (Char.IsDigit(Caracter))
                        {
                            Estado = 9;
                            Lexema += Caracter;
                        }
                        else
                        {
                            ListaErrores.agregarErrores("Lexico",Lexema, "Se esperaba un digito [" + Lexema + "]", Fila, Columna);
                            Estado = 0;
                            Lexema = "";
                        }
                        break;
                    case 9:
                        if (Char.IsDigit(Caracter))
                        {
                            Estado = 9;
                            Lexema += Caracter;
                        }
                        else
                        {
                            agregarToken(Lexema, "Digito", Fila, Columna, i - Lexema.Length);
                            Lexema = "";
                            i--;
                            Columna--;
                            Estado = 0;
                        }

                        break;

                    case -99:
                        //es un posible error o espacio blanco por lo tanto el estado es 0 
                        Lexema += Caracter;
                        ListaErrores.agregarErrores("Lexico",Lexema, "Caracter Desconocido", Fila, Columna);
                        Estado = 0;
                        Lexema = "";
                        break;
                }
            }
        }

        //Metodo para mostrar en la tabla
        public void mostrar()
        {
            //Agregar tipos de datos si es identificador
            agregarTiposDeDato();
            extraerAmbitos();
            for (int i = 0; i < ListaTokens.Count; i++)
            {
                //Asignamos el token de la lista a un token auxiliar 
                Token token_actual = ListaTokens.ElementAt(i);
                i = tabla_simbolos.Rows.Add();//creamos una fila 
                //Asignamos datos a columnas
                tabla_simbolos.Rows[i].Cells["Lexema"].Value = token_actual.getLexema();
                tabla_simbolos.Rows[i].Cells["TipoToken"].Value = token_actual.getIdToken();
                tabla_simbolos.Rows[i].Cells["Linea"].Value = token_actual.getLinea();
                if (!(token_actual.getTipoDato().Equals("")))
                {
                    tabla_simbolos.Rows[i].Cells["TipoDato"].Value = ListaTokens.ElementAt(i-1).getLexema();
                }
                if (!(token_actual.getAmbito().Equals("")))
                {
                    tabla_simbolos.Rows[i].Cells["Scope"].Value = token_actual.getAmbito();
                }
            }
            /*
            for (int i = 0; i < ListaErrores.Count; i++) {
                Error token = ListaErrores.ElementAt(i);
                System.Windows.Forms.MessageBox.Show("Error: "+token.getLexema()+" en linea "+token.getLinea());
                ListaErrores.RemoveAt(i);
                }*/
                
        }

        //metodo para obtener los tokens identificados 
        public ArrayList getTokens()
        {
            return Tokens;
        }

        //metodo para obtener la lista de tokens 
        public List<Token> getListaTokens()
        {
            return ListaTokens;
        }

        public void agregarTiposDeDato()
        {
            int elemento_anterior;
            for(int i = 0; i < ListaTokens.Count; i++)
            {
                elemento_anterior = i - 1;
                //Comprobar si es menor a 0 para evitar errores y si el token anterior es reservado y si el actual es identificador
                if ((!(elemento_anterior < 0)) && ListaTokens.ElementAt(elemento_anterior).getIdToken().Equals("Reservada")
                    && ListaTokens.ElementAt(i).getIdToken().Equals("Identificador"))
                {
                    //Le asginamos al token actual el tipo de dato del anterior
                    ListaTokens.ElementAt(i).setTipoDato(ListaTokens.ElementAt(elemento_anterior).getIdToken());
                }
            }
        }

        public void extraerAmbitos()
        {
            List<Ambito> Ambitos = new List<Ambito>();
            for (int i = 0; i < ListaTokens.Count; i++)
            {
                Ambito ObjetoAmbito = new Ambito();
                Token token_actual = ListaTokens.ElementAt(i);
                if (token_actual.getLexema().Equals("package"))
                {
                    ObjetoAmbito.setIdAmbito(ListaTokens.ElementAt(i + 1).getLexema());
                    ObjetoAmbito.setTipoAmbito("paquete");
                    Ambitos.Add(ObjetoAmbito);
                    string CadenaAmbitos = "";
                    foreach (Ambito ambito in Ambitos)
                    {
                        CadenaAmbitos += ambito.getIdAmbito();
                        CadenaAmbitos += ": ";
                        CadenaAmbitos += ambito.getTipoAmbito();
                        CadenaAmbitos += ", ";
                    }
                    ListaTokens.ElementAt(i + 1).setAmbito(CadenaAmbitos);
                    continue;
                }
                if (token_actual.getLexema().Equals("class"))
                {
                    ObjetoAmbito.setIdAmbito(ListaTokens.ElementAt(i + 1).getLexema());
                    ObjetoAmbito.setTipoAmbito("clase");
                    Ambitos.Add(ObjetoAmbito);
                    string CadenaAmbitos = "";
                    foreach (Ambito ambito in Ambitos)
                    {
                        CadenaAmbitos += ambito.getIdAmbito();
                        CadenaAmbitos += ": ";
                        CadenaAmbitos += ambito.getTipoAmbito();
                        CadenaAmbitos += ", ";
                    }
                    ListaTokens.ElementAt(i + 1).setAmbito(CadenaAmbitos);
                    continue;
                }
                if ((token_actual.getLexema().Equals("int") ||
                     token_actual.getLexema().Equals("float") ||
                     token_actual.getLexema().Equals("char") ||
                     token_actual.getLexema().Equals("double") ||
                     token_actual.getLexema().Equals("string")))
                {
                    if (ListaTokens.ElementAt(i + 2).getIdToken().Equals("parentIzquierdo"))
                    {
                        ObjetoAmbito.setIdAmbito(ListaTokens.ElementAt(i + 1).getLexema());
                        ObjetoAmbito.setTipoAmbito("función");
                        Ambitos.Add(ObjetoAmbito);
                        string CadenaAmbitos = "";
                        foreach (Ambito ambito in Ambitos)
                        {
                            CadenaAmbitos += ambito.getIdAmbito();
                            CadenaAmbitos += ": ";
                            CadenaAmbitos += ambito.getTipoAmbito();
                            CadenaAmbitos += ", ";
                        }
                        ListaTokens.ElementAt(i + 1).setAmbito(CadenaAmbitos);
                        continue;
                    }
                    else
                    {
                        string CadenaAmbitos = "";
                        foreach (Ambito ambito in Ambitos)
                        {
                            CadenaAmbitos += ambito.getIdAmbito();
                            CadenaAmbitos += ": ";
                            CadenaAmbitos += ambito.getTipoAmbito();
                            CadenaAmbitos += ", ";
                        }
                        ListaTokens.ElementAt(i + 1).setAmbito(CadenaAmbitos);
                        continue;
                    }
                }
                if (token_actual.getLexema().Equals("if") ||
                    token_actual.getLexema().Equals("for") ||
                    token_actual.getLexema().Equals("while") ||
                    token_actual.getLexema().Equals("switch"))
                {
                    ObjetoAmbito.setIdAmbito(token_actual.getLexema());
                    ObjetoAmbito.setTipoAmbito("control de flujo");
                    Ambitos.Add(ObjetoAmbito);
                    string CadenaAmbitos = "";
                    foreach (Ambito ambito in Ambitos)
                    {
                        CadenaAmbitos += ambito.getIdAmbito();
                        CadenaAmbitos += ": ";
                        CadenaAmbitos += ambito.getTipoAmbito();
                        CadenaAmbitos += ", ";
                    }
                    token_actual.setAmbito(CadenaAmbitos);
                    continue;
                }
                if (token_actual.getLexema().Equals("("))
                {
                    while (!ListaTokens.ElementAt(i).getLexema().Equals(")"))
                    {
                        i++;
                    }
                    i++;
                    continue;
                }
            }
        }

        //Metodo para guardar las palabras reservadas del txt 
        public void guardarReservadas(string contenido)
        {
            string[] Lineas = contenido.Split(new[] { "\r\n", "\r", "\n" },StringSplitOptions.None);
            Tokens = new ArrayList(Lineas);
        }

        #endregion
    }
}
