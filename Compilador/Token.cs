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
        private String Lexema;
        private String TipoToken;
        private String tipoDato="";
        private String Ambito = "";
        private int Linea;
        private int Columna;
        private int Indice;
        #endregion

        //***************************************
        //Constructores   
        //***************************************
        #region Constructores
        //Constructor con parametros 
        public Token(String Lexema, String TipoToken, int Linea, int Columna, int Indice)
        {

            this.Lexema = Lexema;
            this.TipoToken = TipoToken;
            this.Linea = Linea;
            this.Columna = Columna;
            this.Indice = Indice;
        }
        #endregion

        //***************************************
        //Metodos
        //***************************************
        #region Metodos
        /// <summary>
        ///     get Indice
        /// </summary>
        /// <param></param>
        /// <returns>El campo privado Indice</returns>
        public int getIndice()
        {
            return Indice;
        }

        /// <summary>
        ///     get Lexema
        /// </summary>
        /// <param></param>
        /// <returns>El campo privado Lexema</returns>
        public String getLexema()
        {
            return Lexema;
        }

        /// <summary>
        ///     get Indice
        /// </summary>
        /// <param></param>
        /// <returns>El campo privado Indice</returns>
        public String getIdToken()
        {
            return TipoToken;
        }

        /// <summary>
        ///     get TipoDato
        /// </summary>
        /// <param></param>
        /// <returns>El campo privado TipoDato</returns>
        public String getTipoDato()
        {
            return tipoDato;
        }

        /// <summary>
        ///     get TipoDato
        /// </summary>
        /// <param>El valor del campo privado TipoDato</param>
        /// <returns></returns>
        public void setTipoDato(String _tipoDato)
        {
            tipoDato = _tipoDato;
        }

        /// <summary>
        ///     get Ambito
        /// </summary>
        /// <param></param>
        /// <returns>El campo privado Ambito</returns>
        public String getAmbito()
        {
            return Ambito;
        }

        /// <summary>
        ///     set Ambito
        /// </summary>
        /// <param>El valor del campo privado Ambito</param>
        /// <returns></returns>
        public void setAmbito(String _ambito)
        {
            Ambito = _ambito;
        }

        /// <summary>
        ///     get Linea
        /// </summary>
        /// <param></param>
        /// <returns>El campo privado Linea</returns>
        public int getLinea()
        {
            return Linea;
        }

        /// <summary>
        ///     get Columna
        /// </summary>
        /// <param></param>
        /// <returns>El campo privado Columna</returns>
        public int getColumna()
        {
            return Columna;
        }
        #endregion
    }
}
