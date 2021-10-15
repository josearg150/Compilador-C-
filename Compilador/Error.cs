using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    /// <summary>
    ///     Clase Error
    ///     Contiene los metodos para ver los errores del codigo
    /// </summary>
    /// 
    /// <Para>
    ///     Con esta clase se puede analizar el codigo fuente y podemos ver los errores
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
    ///     14/10/2021
    /// </FechaCreacion>
    class Error
    {
        //***************************************
        //Variables locales                     
        //***************************************
        #region Variables
        private String lexema;
        private String idToken;
        private int linea;
        private int columna;
        #endregion
        //***************************************
        //Constructores   
        //***************************************
        #region Constructores 
        public Error(String lexema, String idToken, int linea, int columna)
        {

            this.lexema = lexema;
            this.idToken = idToken;
            this.linea = linea;
            this.columna = columna;
        }
        #endregion 
        //***************************************
        //Metodos
        //***************************************
        #region Metodos
        public String getLexema()
        {
            return this.lexema;
        }
        public String getIdToken()
        {
            return this.idToken;
        }
        public int getLinea()
        {
            return this.linea;
        }
        public int getColumna()
        {
            return this.columna;
        }
        #endregion
    }
}
    

