using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoFinal2
{
    public class Camarero: TipoEmpleado
    {

        public Camarero()
        {
            this.NumEmpleado = 0;
        }
        
        public Camarero(int numEmpleado)
        {
            this.NumEmpleado = numEmpleado;
        }

        public void AbrirMesa(int NumMesa)
        {
            Comanda c = new Comanda();

            System.Console.WriteLine("Programa iniciado\n Indica un número de mesa para empezar:");
            c.NumMesa = int.Parse(System.Console.ReadLine());

            Mesa orderMesa = new Mesa(0);

            System.Console.WriteLine("¿Cuántos platos van a pedir?");
            orderMesa.Limite = int.Parse(System.Console.ReadLine());

            for (int i = 0; i < orderMesa.Limite; i++)
            {
                orderMesa.AniadirPlato(c);
            }
        }

        public void CerrarMesa(Mesa orderMesa)
        {
            Comanda c = new Comanda();
            double Precio = 0.00;

            for (int i = 0; i < orderMesa.Limite; i++)
            {
                Precio = Precio + c.Precio;
            }
            System.Console.WriteLine("TOTAL------------------------- " + Precio);
        }

        public void ModificarMesa()
        {
            Comanda c = new Comanda();
            Mesa orderMesa = new Mesa(100);

            int opc = -1;
            do
            {
                System.Console.WriteLine("¿Qué quieres hacer?\n (1) AÑADIR PLATO\n (2) ELIMINAR PLATO\n (3) VACIAR MESA\n (4) CERRAR MESA\n (0) SALIR");
                
                switch(opc)
                {
                    case 1:
                        orderMesa.AniadirPlato(c);
                        break;
                    case 2:
                        orderMesa.EliminarPlato(c);
                        break;
                    case 3:
                        orderMesa.VaciarMesa();
                        break;
                    case 4:
                        CerrarMesa(orderMesa);
                        break;
                    case 0:
                        System.Console.WriteLine("SESIÓN CERRADA");
                        break;
                    default:
                        System.Console.WriteLine("Elige una opción del menú");
                        break;
                }          
            }
            while (opc != 0);
            
            
        }
        


        

}
}
