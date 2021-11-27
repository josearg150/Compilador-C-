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
    /// </Supuestos>
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
        private string IdAmbito;
        private string TipoAmbito;

        public string getIdAmbito()
        {
            return IdAmbito;
        }

        public string getTipoAmbito()
        {
            return TipoAmbito;
        }

        public void setTipoAmbito(string t_ambito)
        {
            this.TipoAmbito = t_ambito;
        }

        public void setIdAmbito(string id_ambito)
        {
            this.IdAmbito = id_ambito;
        }
    }
}
