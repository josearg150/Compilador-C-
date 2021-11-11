using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    class Cuadruplo
    {
        static private List<Token> ListaTokens;
        ArrayList nombres_funciones;
        System.Windows.Forms.DataGridView tabla;
        int i;
        int num_proceso;
        public Cuadruplo(List<Token> Lista, System.Windows.Forms.DataGridView tabla_)
        {
            ListaTokens = Lista;
            tabla = tabla_;
            nombres_funciones = new ArrayList();
        }
        private void borrarTodo()
        {
            tabla.Rows.Clear();
            nombres_funciones.Clear();
        }
        public void realizarCuadruplo()
        {
            borrarTodo();
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
        private void poner_parteBaja(string nombre_funcion)
        {
            i = tabla.Rows.Add();//creamos una fila 
            tabla.Rows[i].Cells["num"].Value = i.ToString();
            tabla.Rows[i].Cells["op"].Value = "nom_"+nombre_funcion;
            descripcion_funcion();
            i++;
            i = tabla.Rows.Add();//creamos una fila 
            tabla.Rows[i].Cells["num"].Value = i.ToString();
            tabla.Rows[i].Cells["result"].Value = "fin_llamada_proc" + num_proceso;
        }
        private void descripcion_funcion()
        {
            i = tabla.Rows.Add();//creamos una fila 
            tabla.Rows[i].Cells["num"].Value = i.ToString();
            tabla.Rows[i].Cells["op"].Value = "pendiente";
            tabla.Rows[i].Cells["argum1"].Value = "pendiente";
            tabla.Rows[i].Cells["argum2"].Value = "pendiente";
            tabla.Rows[i].Cells["result"].Value = "pendiente";
        }
        private void guardarNombreFunciones()
        {  
           for (int i = 0; i < ListaTokens.Count - 1; i++)
              {
                if (ListaTokens.ElementAt(i).getIdToken().Equals("Identificador")
                   && ListaTokens.ElementAt(i + 1).getIdToken().Equals("parentIzquierdo"))
                   {
                     
                     nombres_funciones.Add(ListaTokens.ElementAt(i).getLexema());
                     
                    }
                                
                }
              
        }
    }
}
