using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    /// <summary>
    ///     Clase Token
    ///     Contiene los atributos de un token 
    /// </summary>
    /// 
    /// <Para>
    ///   Esta clase se usa en el analisis lexico para guardar los tokens detectados
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
    ///     18/09/2021
    /// </FechaCreacion>
    class Token
    {
        //***************************************
        //Variables locales                     
        //***************************************
        #region Variables locales 
        //Atributos de un token 
        private String lexema;
        private String tipoToken;
        private int linea;
        private int columna;
        private int indice;
        #endregion
        //***************************************
        //Constructores   
        //***************************************
        #region Constructores
        //Constructor con parametros 
        public Token(String lexema, String tipoToken, int linea, int columna, int indice)
        {

            this.lexema = lexema;
            this.tipoToken = tipoToken;
            this.linea = linea;
            this.columna = columna;
            this.indice = indice;
        }
        #endregion
        //***************************************
        //Metodos
        //***************************************
        #region Metodos
        //metodos get de los atributos
        public int getIndice()
        {
            return indice;
        }
        public String getLexema()
        {
            return lexema;
        }
        public String getIdToken()
        {
            return tipoToken;
        }
        public int getLinea()
        {
            return linea;
        }
        public int getColumna()
        {
            return columna;
        }
        #endregion
    }
}
