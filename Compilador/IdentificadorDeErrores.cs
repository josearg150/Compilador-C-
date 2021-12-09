using System;
using System.Collections;
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
        System.Windows.Forms.RichTextBox codigo;

        #endregion

        //***************************************
        //Constructores   
        //***************************************
        #region Constructores 
        public IdentificadorDeErrores(System.Windows.Forms.DataGridView tabla)
        {
            ListaErrores = new List<Error>();
            tabla_errores = tabla;
            codigo = new System.Windows.Forms.RichTextBox();
            
        }

        #endregion

        //***************************************
        //Metodos
        //***************************************
        #region Metodos
        /// <summary>
        ///     get ListaDeErrores
        /// </summary>
        /// <param></param>
        /// <returns>Campo privado: ListaDeErrores</returns>
        public List<Error> getListaDeErrores()
        {
            return ListaErrores;
        }

        /// <summary>
        ///     Añade los errores al arreglo principal por token.
        /// </summary>
        /// <param>Datos del token: String codigo,String tipo,String lexema, String idToken, int linea, int columna</param>
        /// <returns></returns>
        public void agregarErrores(String codigo,String tipo,String lexema, String idToken, int linea, int columna)
        {
            Error errtok = new Error(codigo,tipo,lexema, idToken, linea, columna);
            ListaErrores.Add(errtok);
        }

        /// <summary>
        ///     Muestra los errores en la tabla del form.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void mostrar()
        {
            for (int i = 0; i < ListaErrores.Count; i++)
            {
                //Asignamos el token de la lista a un token auxiliar 
                Error Error_actual = ListaErrores.ElementAt(i);
                i = tabla_errores.Rows.Add();//creamos una fila 
                //Asignamos datos a columnas
                tabla_errores.Rows[i].Cells["ColCodigo"].Value =Error_actual.getCodigo();
                tabla_errores.Rows[i].Cells["colTipo"].Value = Error_actual.getTipo();
                tabla_errores.Rows[i].Cells["colLexema"].Value = Error_actual.getLexema()+"->"+Error_actual.getIdToken();
                tabla_errores.Rows[i].Cells["colLineaError"].Value = Error_actual.getLinea(); 

            }
        }

        /// <summary>
        ///     set Codigo
        /// </summary>
        /// <param>Texto del TextBox del form</param>
        /// <returns></returns>
        public void setCodigo(System.Windows.Forms.RichTextBox _codigo)
        {
            codigo.Text = _codigo.Text;
            AnalizarLineas();
        }
        //Revisar si las lineas terminan con ;

        /// <summary>
        ///     Análisis de errores principal.
        /// </summary>
        /// <param></param>
        /// <returns>Campo privado: codigo</returns>
        private void AnalizarLineas()
        {

            for(int i = 0; i < codigo.Lines.Length; i++)
            {
                analizarTiposDeDato(codigo.Lines[i], i);
                //Aperturas de llaves, parentesis, corchetes ,no son errores
                if (codigo.Lines[i].EndsWith("{") || codigo.Lines[i].EndsWith("(") || codigo.Lines[i].EndsWith("["))
                {
                    continue;
                }
                //La linea no termina en ;
                else if (!(codigo.Lines[i].EndsWith(";")))
                {
                    agregarErrores("04", "Semantico", codigo.Lines[i].Last().ToString(), "Se esperaba ;", i+1, 0);
                }
                
            }
        }

        /// <summary>
        ///     Análisis para la validación de operaciones con tipos de dato correctos.
        /// </summary>
        /// <param>Lineas del codigo a comprobar</param>
        /// <returns></returns>
        private void analizarTiposDeDato(String linea, int numLinea)
        {
            ///  0  1 2 3
            /// int a = 1;
            /// 
            String[] word1 = linea.Split(' ');
            String palabraInicio = word1[0].ToLower();
            
            if(palabraInicio.Equals("int") || palabraInicio.Equals("float") || palabraInicio.Equals("char") || palabraInicio.Equals("string"))
            {
                if (word1[1].All(char.IsDigit))
                {
                    agregarErrores("06", "Semantico", word1[1], "Nombre de variable invalido", numLinea + 1, 0);
                }

            }
        }
        #endregion
    }
}
