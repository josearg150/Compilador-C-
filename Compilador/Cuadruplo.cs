using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    /// <summary>
    ///     Clase Cuadruplo para generar los cuádruplos a partir del código de tres direcciones.
    /// </summary>
    /// 
    /// <Para>
    ///     Almacenar, organizar y mostrar los cuádruplos en su tabla correspondiente.
    /// </Para>
    /// 
    /// <Supuestos>
    ///                 
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
    class Cuadruplo
    {
        //***************************************
        //Variables locales                     
        //***************************************
        #region Variables locales
        static private List<Token> ListaTokens;
        static private List<Token> Tokens_operaciones;
        ArrayList nombres_funciones;
        ArrayList lista_operaciones;
        System.Windows.Forms.DataGridView tabla;
        int i;
        int num_proceso;
        int contador_expresion = 0;
        #endregion

        //***************************************
        //Constructores   
        //***************************************
        #region Constructores
        public Cuadruplo(List<Token> Lista, System.Windows.Forms.DataGridView tabla_)
        {
            ListaTokens = Lista;
            tabla = tabla_;
            nombres_funciones = new ArrayList();
            lista_operaciones = new ArrayList();
            Tokens_operaciones = new List<Token>();
        }
        #endregion Constructores

        //***************************************
        //Metodos
        //***************************************
        #region Metodos
        /// <summary>
        ///     Limpia la tabla principal de los cuadruplos.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void borrarTodo()
        {
            tabla.Rows.Clear();
            nombres_funciones.Clear();
        }

        /// <summary>
        ///     Calcula el cuadruplo correspondiente para mostrarlo en la i fila.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void realizarCuadruplo()
        {
            //Proceso para primer renglon Proc
            guardarNombreFunciones();
            i = 0; //contador para renglones
            num_proceso = 1; //contador de procesos
            //Parte de arriba
            for(int j = 0; j < nombres_funciones.Count; j++)
            {
                poner_nombres_funciones(nombres_funciones[j].ToString());
                num_proceso++;
            }
            num_proceso = 1; // reseteamos el numero de proceso
            //creamos una fila de color para separar parte de arriba y abajo
            i++;
            i = tabla.Rows.Add();
            tabla.Rows[i].Cells["num"].Value = i.ToString();
            tabla.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
            //////////////////////////////////////////////////////////////////
            //Parte de abajo
            for (int j = 0; j < nombres_funciones.Count; j++)
            {
                poner_parteBaja(nombres_funciones[j].ToString());
                num_proceso++;
            }
        }

        /// <summary>
        ///     Asignar nombres a las funciones.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void poner_nombres_funciones(string nombre_funcion)
        {
            i = tabla.Rows.Add();//creamos una fila 
            tabla.Rows[i].Cells["num"].Value = i.ToString();
            tabla.Rows[i].Cells["op"].Value = "proc" + num_proceso + ":";
            i++;
            i = tabla.Rows.Add();//creamos una fila 
            //Proceso para agregar nombre de funcion
            tabla.Rows[i].Cells["num"].Value = i.ToString();
            tabla.Rows[i].Cells["op"].Value = nombre_funcion;//esFuncion();
            tabla.Rows[i].Cells["result"].Value = "goto nom_" + nombre_funcion.ToLower();
            i++;
            i = tabla.Rows.Add();//creamos una fila 
            //Proceso para finalizar funcion
            tabla.Rows[i].Cells["num"].Value = i.ToString();
            tabla.Rows[i].Cells["op"].Value = "fin_llamada_proc" + num_proceso;
        }

        /// <summary>
        ///     Crear la parte inferior de la tabla de cuadruplos.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void poner_parteBaja(string nombre_funcion)
        {
            i = tabla.Rows.Add();//creamos una fila 
            tabla.Rows[i].Cells["num"].Value = i.ToString();
            tabla.Rows[i].Cells["op"].Value = "nom_"+nombre_funcion;
           // int contador_expresion = 0;
            descripcion_funcion();
            i++;
            i = tabla.Rows.Add();//creamos una fila 
            tabla.Rows[i].Cells["num"].Value = i.ToString();
            tabla.Rows[i].Cells["result"].Value = "fin_llamada_proc" + num_proceso;
        }

        /// <summary>
        ///     Asignar descripciones a las funciones.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void descripcion_funcion()
        {
            i = tabla.Rows.Add();//creamos una fila
            tabla.Rows[i].Cells["num"].Value = i.ToString();
            obtenerExpresionOperacion();
            int contadorDeT = 1;
            bool ponerEnArgum1 = false;
            Tokens_operaciones.Reverse();
                for (int j = 0; j < Tokens_operaciones.Count; j++) {
                
                string idToken = Tokens_operaciones.ElementAt(j).getIdToken();
                if (idToken.Equals("Suma") || idToken.Equals("Resta") || idToken.Equals("Division") || idToken.Equals("Multiplicacion"))
                {
                    tabla.Rows[i].Cells["op"].Value = Tokens_operaciones.ElementAt(j).getLexema();
                    contador_expresion++;
                    //lista_operaciones.Add(ListaTokens.ElementAt(i).getLexema());
                }
                else if (idToken.Equals("Asignacion")) { 
                    tabla.Rows[i].Cells["op"].Value = Tokens_operaciones.ElementAt(j).getLexema();
                    contador_expresion++;
                    tabla.Rows[i].Cells["argum1"].Value = "T"+(contadorDeT-1);
                }
                else if (idToken.Equals("Identificador"))
                {
                    tabla.Rows[i].Cells["result"].Value = Tokens_operaciones.ElementAt(j).getLexema();
                    contador_expresion++;
                }
                else if (idToken.Equals("Digito"))
                {
                    if (ponerEnArgum1)
                    {
                        tabla.Rows[i].Cells["argum1"].Value = Tokens_operaciones.ElementAt(j).getLexema();
                        contador_expresion++;
                        tabla.Rows[i].Cells["result"].Value = "T" + contadorDeT;
                        contadorDeT++;
                        i++;
                        i = tabla.Rows.Add();//creamos una fila
                    }
                    else
                    {
                        tabla.Rows[i].Cells["argum2"].Value = Tokens_operaciones.ElementAt(j).getLexema();
                        contador_expresion++;
                        ponerEnArgum1 = true;
                    }

                }
                
                
            }
        }

        /// <summary>
        ///     Devuelve el token según si identificador.
        /// </summary>
        /// <param></param>
        /// <returns>token</returns>
        private void obtenerExpresionOperacion()
        {
            for(int i = 0; i < ListaTokens.Count; i++){
                string idToken = ListaTokens.ElementAt(i).getIdToken();
                
                 if (idToken.Equals("Identificador") )
                {
                    Tokens_operaciones.Add(ListaTokens.ElementAt(i));
                    lista_operaciones.Add(ListaTokens.ElementAt(i).getLexema());
                }
                else if (idToken.Equals("Asignacion"))
                {
                    Tokens_operaciones.Add(ListaTokens.ElementAt(i));
                }
                else if (idToken.Equals("Suma") || idToken.Equals("Resta") || idToken.Equals("Division") || idToken.Equals("Multiplicacion"))
                {
                    Tokens_operaciones.Add(ListaTokens.ElementAt(i));
                }
                else if (idToken.Equals("Digito"))
                {
                    Tokens_operaciones.Add(ListaTokens.ElementAt(i));
                }
            }
        }

        /// <summary>
        ///     Función no pura; modifica el campp privado ListaTokens según los identificadors de los tokens que se contengan en ese arreglo.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void guardarNombreFunciones()
        {  
           for (int j = 0; j < ListaTokens.Count - 1; j++)
              {
                if (ListaTokens.ElementAt(j).getIdToken().Equals("Identificador")
                   && ListaTokens.ElementAt(j + 1).getIdToken().Equals("parentIzquierdo"))
                   {
                     
                    nombres_funciones.Add(ListaTokens.ElementAt(j).getLexema());
                    ListaTokens.RemoveAt(j);
                   }
                                
              }
        }
        #endregion Metodos
    }
}
