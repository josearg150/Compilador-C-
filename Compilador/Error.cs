using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    public enum tipoError
    {
        Lexico,
        Sintactico,
        Semantico,
        CodigoIntermedio,
        Ejecucion
    }

    class Error
    {
        private int Codigo;
        private string MensajeError;
        private tipoError Tipo;
        private int Linea;

        public int getCodigo()
        {
            return Codigo;
        }

        public string getMensajeError()
        {
            return MensajeError;
        }

        public tipoError getTipo()
        {
            return Tipo;
        }

        public int getLinea()
        {
            return Linea;
        }

        public void setCodigo(int Codigo)
        {
            this.Codigo = Codigo;
        }

        public void setMensajeError(string Mensaje)
        {
            this.MensajeError = Mensaje;
        }

        public void setTipo(tipoError Tipo)
        {
            this.Tipo = Tipo;
        }

        public void setLinea(int Linea)
        {
            this.Linea = Linea;
        }
    }
}
