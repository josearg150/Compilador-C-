using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{  /// <summary>
   ///  
   /// </summary>
   /// 
   /// <Para>
   ///     
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
   ///     15/10/2021
   /// </FechaCreacion>
    class IdentificadorDeErrores
    {
        //***************************************
        //Variables locales                     
        //***************************************
        #region Variables
        static private List<Error> ListaErrores;
        System.Windows.Forms.DataGridView tabla_errores;

        #endregion
        //***************************************
        //Constructores   
        //***************************************
        #region Constructores 
        public IdentificadorDeErrores(System.Windows.Forms.DataGridView tabla)
        {
            ListaErrores = new List<Error>();
            tabla_errores = tabla;
        }

        #endregion
        //***************************************
        //Metodos
        //***************************************
        #region Metodos
        public List<Error> getListaDeErrores()
        {
            return ListaErrores;
        }
        public void agregarErrores(String tipo,String lexema, String idToken, int linea, int columna)
        {
            Error errtok = new Error(tipo,lexema, idToken, linea, columna);
            ListaErrores.Add(errtok);
        }
        public void mostrar()
        {
            for (int i = 0; i < ListaErrores.Count; i++)
            {
                //Asignamos el token de la lista a un token auxiliar 
                Error Error_actual = ListaErrores.ElementAt(i);
                i = tabla_errores.Rows.Add();//creamos una fila 
                //Asignamos datos a columnas
                tabla_errores.Rows[i].Cells["ColCodigo"].Value = "NOID";
                tabla_errores.Rows[i].Cells["colTipo"].Value = Error_actual.getTipo();
                tabla_errores.Rows[i].Cells["colLexema"].Value = Error_actual.getLexema();
                tabla_errores.Rows[i].Cells["colLineaError"].Value = Error_actual.getLinea(); 

            }
        }
        #endregion
    }
}
