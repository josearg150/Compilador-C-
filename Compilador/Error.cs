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
        private String codigo;
        private String tipo;
        private String lexema;
        private String idToken;
        private int linea;
        private int columna;
        #endregion

        //***************************************
        //Constructores   
        //***************************************
        #region Constructores 
        public Error(String codigo,String tipo,String lexema, String idToken, int linea, int columna)
        {
            this.codigo = codigo;
            this.tipo = tipo;
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
        /// <summary>
        ///     get Codigo
        /// </summary>
        /// <param></param>
        /// <returns>Campo privado: codigo</returns>
        public String getCodigo()
        {
            return this.codigo;
        }

        /// <summary>
        ///     get Codigo
        /// </summary>
        /// <param></param>
        /// <returns>Campo privado: codigo</returns>
        public String getTipo()
        {
            return this.tipo;
        }

        /// <summary>
        ///     get Lexema
        /// </summary>
        /// <param></param>
        /// <returns>Campo privado: Lexema</returns>
        public String getLexema()
        {
            return this.lexema;
        }

        /// <summary>
        ///     get IdToken
        /// </summary>
        /// <param></param>
        /// <returns>Campo privado: IdToken</returns>
        public String getIdToken()
        {
            return this.idToken;
        }

        /// <summary>
        ///     get Linea
        /// </summary>
        /// <param></param>
        /// <returns>Campo privado: Linea</returns>
        public int getLinea()
        {
            return this.linea;
        }

        /// <summary>
        ///     get Columna
        /// </summary>
        /// <param></param>
        /// <returns>Campo privado: Columna</returns>
        public int getColumna()
        {
            return this.columna;
        }

        #endregion
    }
}
    

