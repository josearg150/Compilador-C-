using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
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
