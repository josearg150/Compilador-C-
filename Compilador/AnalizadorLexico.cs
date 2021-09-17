using System;
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
        int token1 = 0;   //Contador para simbolos 
        int token2 = 0;  //Contador para errores
        int nerror = 0; //numero de error 
        System.Windows.Forms.RichTextBox txtLenguaje; //txt para mostrar la salida del lenguaje 
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
        }
        #endregion

        //***************************************
        //Metodos
        //***************************************
        #region Metodos
        public void analizar(string codigoFuente)
        {
            int estado_de_inicio;            
            int estado_principal = 0;        
            char cadena;         
            string token = "";            

            for (estado_de_inicio = 0; estado_de_inicio < codigoFuente.Length; estado_de_inicio++)
            {
                cadena = codigoFuente[estado_de_inicio];

                switch (estado_principal)
                {
                    case 0:
                        switch (cadena)
                        {
                            case ' ':
                            case '\r':
                            case '\t':
                            case '\n':
                            case '\b':
                            case '\f':
                                estado_principal = 0; //Espacios son estado en 0
                                break;

                            case 'p':
                                token += cadena;  
                                estado_principal = 1;        
                                break;

                            case 'P':
                                token += cadena; 
                                estado_principal = 1;     
                                break;

                            case 'c':
                                token += cadena;  
                                estado_principal = 3;       
                                break;

                            case 'C':
                                token += cadena;  
                                estado_principal = 6;       
                                break;
                            case '{':
                                token += cadena;
                                estado_principal = 9;
                                estado_de_inicio = estado_de_inicio - 1;
                                break;

                            case '}':
                                token += cadena;
                                estado_principal = 9;
                                estado_de_inicio = estado_de_inicio - 1;
                                break;

                            case ';':
                                token += cadena;
                                estado_principal = 9;
                                estado_de_inicio = estado_de_inicio - 1;
                                break;

                            case ',':
                                token += cadena;
                                estado_principal = 9;
                                estado_de_inicio = estado_de_inicio - 1;
                                break;

                            case 'i':
                                token += cadena;
                                estado_principal = 10;
                                break;

                            case 'b':
                                token += cadena;
                                estado_principal = 14;
                                break;

                            case 's':
                                token += cadena;
                                estado_principal = 17;
                                break;

                            default:
                                token += cadena;
                                break;
                        }
                        break;

                    case 1:
                        if (cadena == 'p' || cadena == 'P')
                        {
                            token += cadena;
                            estado_principal = 1;
                        }
                        else if (cadena.Equals('u'))
                        {
                            token += cadena;  
                            estado_principal = 1;       
                        }
                        else if (cadena.Equals('b'))
                        {
                            token += cadena;
                            estado_principal = 1;
                        }
                        else if (cadena.Equals('l'))
                        {
                            token += cadena;
                            estado_principal = 1;
                        }
                        else if (cadena.Equals('i'))
                        {
                            token += cadena;
                            estado_principal = 1;
                        }
                        else if (cadena.Equals('c'))
                        {
                            token += cadena;
                            estado_principal = 2;               
                            estado_de_inicio = estado_de_inicio - 1; ;  
                        }
                        else if (cadena.Equals('r'))
                        {
                            token += cadena;
                            estado_principal = 12;
                        }
                        break;

                    case 2:
                        mostrarReservadas(token);
                        mostrarTokensEnTabla(token);
                        token = "";                            
                        estado_principal = 0;                 
                        break;

                    case 3:
                        if (cadena == 'c')
                        {
                            token += cadena;
                            estado_principal = 3;
                        }
                        else if (cadena.Equals('l'))
                        {
                            token += cadena;
                            estado_principal = 3;
                        }
                        else if (cadena.Equals('a'))
                        {
                            token += cadena;
                            estado_principal = 3;
                        }
                        else if (cadena == 's')
                        {
                            token += cadena;
                            estado_principal = 4;
                        }
                        break;

                    case 4:
                        if (cadena == 's')
                        {
                            token += cadena;
                            estado_principal = 5;
                            estado_de_inicio = estado_de_inicio - 1;
                        }
                        break;


                    case 5:
                        mostrarReservadas(token);
                        mostrarTokensEnTabla(token);
                        token = "";
                        estado_principal = 0;
                        break;


                    case 6:
                        if (cadena == 'C')
                        {
                            token += cadena;
                            estado_principal = 6;
                        }
                        else if (cadena.Equals('a'))
                        {
                            token += cadena;
                            estado_principal = 6;
                        }
                        else if (cadena.Equals('s'))
                        {
                            token += cadena;
                            estado_principal = 6;
                        }
                        else if (cadena == 'i')
                        {
                            token += cadena;
                            estado_principal = 6;

                        }
                        else if (cadena.Equals('l'))
                        {
                            token += cadena;
                            estado_principal = 7;
                        }
                        break;

                    case 7:
                        if (cadena.Equals('l'))
                        {
                            token += cadena;
                            estado_principal = 7;
                        }
                        else if (cadena == 'a')
                        {
                            token += cadena;
                            estado_principal = 8;
                            estado_de_inicio = estado_de_inicio - 1;
                        }
                        break;

                    case 8:
                        mostrarReservadas(token);
                        mostrarTokensEnTabla(token);
                        token = "";
                        estado_principal = 0;
                        break;

                    case 9:
                        mostrarReservadas(token);
                        mostrarTokensEnTabla(token);
                        token = "";
                        estado_principal = 0;
                        break;


                    case 10:
                        if (cadena == 'i')
                        {
                            token += cadena;
                            estado_principal = 10;
                        }
                        else if (cadena.Equals('n'))
                        {
                            token += cadena;
                            estado_principal = 10;
                        }
                        else if (cadena.Equals('t'))
                        {
                            token += cadena;
                            estado_principal = 11;
                            estado_de_inicio = estado_de_inicio - 1;
                        }
                        break;

                    case 11:
                        mostrarReservadas(token);
                        mostrarTokensEnTabla(token);
                        token = "";
                        estado_principal = 0;
                        break;

                    case 12:
                        if (cadena.Equals('r'))
                        {
                            token += cadena;
                            estado_principal = 12;
                        }
                        else if (cadena.Equals('o'))
                        {
                            token += cadena;
                            estado_principal = 12;
                        }
                        else if (cadena.Equals('t'))
                        {
                            token += cadena;
                            estado_principal = 12;
                        }
                        else if (cadena.Equals('e'))
                        {
                            token += cadena;
                            estado_principal = 12;
                        }
                        else if (cadena.Equals('c'))
                        {
                            token += cadena;
                            estado_principal = 12;
                        }
                        else if (cadena.Equals('t'))
                        {
                            token += cadena;
                            estado_principal = 12;
                        }
                        else if (cadena.Equals('e'))
                        {
                            token += cadena;
                            estado_principal = 12;
                        }
                        else if (cadena.Equals('d'))
                        {
                            token += cadena;
                            estado_principal = 13;
                            estado_de_inicio = estado_de_inicio - 1;
                        }
                        break;

                    case 13:
                        mostrarReservadas(token);
                        mostrarTokensEnTabla(token);
                        token = "";
                        estado_principal = 0;
                        break;

                    case 14:
                        if (cadena.Equals('b'))
                        {
                            token += cadena;
                            estado_principal = 14;
                        }
                        else if (cadena.Equals('o'))
                        {
                            token += cadena;
                            estado_principal = 15;
                        }
                        break;

                    case 15:
                        if (cadena.Equals('o'))
                        {
                            token += cadena;
                            estado_principal = 15;
                        }
                        else if (cadena.Equals('l'))
                        {
                            token += cadena;
                            estado_principal = 15;
                        }
                        else if (cadena.Equals('e'))
                        {
                            token += cadena;
                            estado_principal = 15;
                        }
                        else if (cadena.Equals('a'))
                        {
                            token += cadena;
                            estado_principal = 15;
                        }
                        else if (cadena.Equals('n'))
                        {
                            token += cadena;
                            estado_principal = 16;
                            estado_de_inicio = estado_de_inicio - 1;
                        }
                        break;

                    case 16:
                        mostrarReservadas(token);
                        mostrarTokensEnTabla(token);
                        token = "";
                        estado_principal = 0;
                        break;


                    case 17:
                        if (cadena.Equals('s'))
                        {
                            token += cadena;
                            estado_principal = 17;
                        }
                        else if (cadena.Equals('t'))
                        {
                            token += cadena;
                            estado_principal = 17;
                        }
                        else if (cadena.Equals('r'))
                        {
                            token += cadena;
                            estado_principal = 17;
                        }
                        else if (cadena.Equals('i'))
                        {
                            token += cadena;
                            estado_principal = 17;
                        }
                        else if (cadena.Equals('n'))
                        {
                            token += cadena;
                            estado_principal = 17;
                        }
                        else if (cadena.Equals('g'))
                        {
                            token += cadena;
                            estado_principal = 18;
                            estado_de_inicio = estado_de_inicio - 1;
                        }
                        break;

                    case 18:
                        mostrarReservadas(token);
                        mostrarTokensEnTabla(token);
                        token = "";
                        estado_principal = 0;
                        break;
                }
            }
        }
        public void mostrarReservadas(string tokeniguala)
        {
            switch (tokeniguala.ToLower())
            {
                case "public":
                    txtLenguaje.Text = txtLenguaje.Text + "public \n";
                    break;
                case "protected":
                    txtLenguaje.Text = txtLenguaje.Text + "protected \n";
                    break;
                case "class":
                    txtLenguaje.Text = txtLenguaje.Text + "Class \n";
                    break;
                case "Casilla":
                    txtLenguaje.Text = txtLenguaje.Text + "Casilla" + " " + "Nombre Clase\n";
                    break;
                case "{":
                    txtLenguaje.Text = txtLenguaje.Text + "{ \n";
                    break;
                case "}":
                    txtLenguaje.Text = txtLenguaje.Text + "} \n";
                    break;
                case ",":
                    txtLenguaje.Text = txtLenguaje.Text + ", \n";
                    break;
                case ";":
                    txtLenguaje.Text = txtLenguaje.Text + "; \n";
                    break;
                case "int":
                    txtLenguaje.Text = txtLenguaje.Text + "int \n";
                    break;          
                case "boolean":
                    txtLenguaje.Text = txtLenguaje.Text + "boolean \n";
                    break;
                case "string":
                    txtLenguaje.Text = txtLenguaje.Text + "string \n";
                    break;
            }
        }
        private void mostrarTokensEnTabla(string lexema)
        {
            
             token1 = tabla_simbolos.Rows.Add();
             switch (lexema.ToLower())
             {
                 case "public":
                 case "protected":
                 case "class":
                 case "Casilla":
                 case "boolean":
                 case "string":
                 case "int":
                    tabla_simbolos.Rows[token1].Cells["Token"].Value = lexema;
                     tabla_simbolos.Rows[token1].Cells["Tipo"].Value = "Palabra Reservada";
                     break;
                 case "{":
                 case "}":
                 case ";":
                 case ",":
                    tabla_simbolos.Rows[token1].Cells["Token"].Value = lexema;
                     tabla_simbolos.Rows[token1].Cells["Tipo"].Value = "Signo Reservado";
                     break;    
                 default:
                     //errores(lexema);    //error en el texto
                     nerror += 1;      //numero de error
                     break;

             }
        }
        #endregion
    }
}
