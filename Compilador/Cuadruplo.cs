﻿using System;
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
        public Cuadruplo(string linea, List<Token> Lista)
        {
            codigo = linea;
            ListaTokens = Lista;
        }

        private void realizarCuadruplo()
        {

        }
    }
}
