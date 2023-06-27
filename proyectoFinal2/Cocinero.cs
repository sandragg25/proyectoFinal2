using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoFinal2
{
    public class Cocinero:TipoEmpleado
    {

        public Cocinero()
        {
            this.NumEmpleado = 0;
        }

        public Cocinero(int numEmpleado)
        {
            this.NumEmpleado = numEmpleado;
        }

        public void MarcharMesa(Mesa orderMesa)
        {           
            orderMesa.Status = "EN CURSO";
         
        }
    }
}
