using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    class Cuadruplo
    {
        private string codigo;
        static private List<Token> ListaTokens; 
        System.Windows.Forms.DataGridView tabla;
        public Cuadruplo(string linea, List<Token> Lista, System.Windows.Forms.DataGridView tabla_)
        {
            codigo = linea;
            ListaTokens = Lista;
            tabla = tabla_;
        }

        public void realizarCuadruplo()
        {
            //Proceso para primer renglon Proc
            int i = 0;
            i = tabla.Rows.Add();//creamos una fila 
            tabla.Rows[i].Cells["num"].Value = i.ToString();
            tabla.Rows[i].Cells["op"].Value = "proc" + i +":";
            tabla.Rows[i].Cells["argum1"].Value = " ";
            tabla.Rows[i].Cells["argum2"].Value = " ";
            tabla.Rows[i].Cells["result"].Value = " ";

            i++;
            i = tabla.Rows.Add();//creamos una fila 
            //Proceso para agregar nombre de funcion
            tabla.Rows[i].Cells["num"].Value = i.ToString();
            tabla.Rows[i].Cells["op"].Value = esFuncion();
            tabla.Rows[i].Cells["argum1"].Value = " ";
            tabla.Rows[i].Cells["argum2"].Value = " ";
            tabla.Rows[i].Cells["result"].Value = "goto nombreFuncion";

            i++;
            i = tabla.Rows.Add();//creamos una fila 
            //Proceso para finalizar funcion
            tabla.Rows[i].Cells["num"].Value = i.ToString();
            tabla.Rows[i].Cells["op"].Value = "fin llamada";
            tabla.Rows[i].Cells["argum1"].Value = " ";
            tabla.Rows[i].Cells["argum2"].Value = " ";
            tabla.Rows[i].Cells["result"].Value = "";

        }

        private string esFuncion()
        {  
           for (int i = 0; i < ListaTokens.Count - 1; i++)
              {
                if (ListaTokens.ElementAt(i).getIdToken().Equals("Identificador")
                   && ListaTokens.ElementAt(i + 1).getIdToken().Equals("parentIzquierdo"))
                {
                  string nombre_funcion = ListaTokens.ElementAt(i).getLexema();
                  return nombre_funcion;
                }
               }
                
            return "N/A";
        }
    }
}
