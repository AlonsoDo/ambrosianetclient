using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ambrosia
{
    class FuncionesAuxiliares
    {
        public string GenerarIdCliente()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }
    }

    /*int j = 0;                   
    for (var i = 0; i <= tvOrden.Nodes.Count; i++)
    {
        InfoNodo prueba = new InfoNodo();
        prueba = (InfoNodo)tvOrden.Nodes[i].Tag;
        
        if (prueba.IdNodo == ContNodos)
        {            
            tvOrden.Nodes[i].BackColor = Color.Pink;
            j = 1;
        }
    }
    if (j == 0)
        MessageBox.Show("not found");
    */
}