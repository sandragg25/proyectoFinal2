using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoFinal2
{
    public class TipoEmpleado
    {
        private int numEmpleado;
        private int sector;

        public int NumEmpleado { get => numEmpleado; set => numEmpleado = value; }
        public int Sector { get => sector; set => sector = value; }

        public TipoEmpleado() 
        {
            this.numEmpleado = 0;
        }
        public TipoEmpleado(int numEmpleado, int sector)
        {
            this.numEmpleado = numEmpleado;
            this.sector = sector;
        }

        public TipoEmpleado IdentificaEmpleado(int sector)
        {
            System.Console.WriteLine("Introduce el sector");
            sector = int.Parse(System.Console.ReadLine());

            if(sector==1)
            {
                Camarero camarero1 = new Camarero();
                return camarero1;
            }
            if(sector==2)
            {
                Cocinero coci1 = new Cocinero();
                return coci1;
            }
            else
            {
                return null;
            }
        }
    }
}
