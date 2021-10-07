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
        //metodos get de los atributos
        public int getIndice()
        {
            return Indice;
        }
        public String getLexema()
        {
            return Lexema;
        }
        public String getIdToken()
        {
            return TipoToken;
        }
        public String getTipoDato()
        {
            return tipoDato;
        }
        public void setTipoDato(String _tipoDato)
        {
            tipoDato = _tipoDato;
        }
        public int getLinea()
        {
            return Linea;
        }
        public int getColumna()
        {
            return Columna;
        }
        #endregion
    }
}
