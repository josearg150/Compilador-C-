using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    /// <summary>
    ///     Clase Ámbito, la cual almacena el scope de cada entidad del código introducido por el usuario.
    /// </summary>
    /// 
    /// <Para>
    ///     Asignar a cada entidad del código introducido su scope correspondiente.
    /// </Para>
    /// 
    /// <Supuestos>
    ///     La clase se usará en conjunto con la clase Token.
    /// </Supuestos>
    /// 
    /// 
    /// <Autor>
    ///     Jose angel rocha garcia 
    ///     Jose luis carreon reyes
    /// </Autor>
    /// 
    /// <FechaCreacion >
    ///     27/11/2021
    /// </FechaCreacion>
    class Ambito
    {
        //***************************************
        //Variables locales                     
        //***************************************
        #region Variables locales
        private string IdAmbito;
        private string TipoAmbito;
        #endregion

        //***************************************
        //Metodos
        //***************************************
        #region Metodos
        /// <summary>
        ///     get IdAmbito
        /// </summary>
        /// <param></param>
        /// <returns>El campo privado IdAmbito.</returns>
        public string getIdAmbito()
        {
            return IdAmbito;
        }

        /// <summary>
        ///     get TipoAmbito
        /// </summary>
        /// <param></param>
        /// <returns>El campo privado TipoAmbito.</returns>
        public string getTipoAmbito()
        {
            return TipoAmbito;
        }

        /// <summary>
        ///     set setTipoAmbito
        /// </summary>
        /// <param>string t_ambito</param>
        /// <returns></returns>
        public void setTipoAmbito(string t_ambito)
        {
            this.TipoAmbito = t_ambito;
        }

        /// <summary>
        ///     set TipoAmbito
        /// </summary>
        /// <param>string id_ambito</param>
        /// <returns></returns>
        public void setIdAmbito(string id_ambito)
        {
            this.IdAmbito = id_ambito;
        }
        #endregion
    }
}
