using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoFinal2
{
    public class Mesa
    {
        private Comanda[] arrayPlatos;   //Array que recibe COMANDA-s
        private int limite;
        private int numPlatos;
        private int id;
        private string status = "PENDING";

        public int Limite { get => limite; set => limite = value; }
        public int NumPlatos { get => numPlatos; set => numPlatos = value; }
        public int Id { get => id; set => id = value; }
        public string Status { get => status; set => status = value; }

        //CONSTRUCTOR DEL ARRAY PASANDO EL LÍMITE
        public Mesa(int limite)
        {
            this.arrayPlatos = new Comanda[limite];
            this.limite = limite;
            this.numPlatos = numPlatos;
            this.status = "PENDING";
        }

        

        public void MostrarMesa()
        {
            for (int i = 0; i < arrayPlatos.Length; i++)
            {
                System.Console.WriteLine(arrayPlatos[i]);
            }
        }

        public void VaciarMesa()
        {
            this.arrayPlatos = new Comanda[limite];
            numPlatos = 0;
        }

        public void EliminarPlato(Comanda c)
        {
            if (c != null && numPlatos != 0)
            {
                int pos = -1;

                for (int i = 0; i < arrayPlatos.Length; i++)//Menor que, porque mi posición debe ser el total -1 (índice)
                {
                    if (c.Id == arrayPlatos[i].Id)
                    {
                        pos = i;
                    }
                    if (pos == -1)
                    {
                        System.Console.WriteLine("Plato no encontrado, prueba con otro ID por favor");
                    }
                    else
                    {
                        arrayPlatos[pos] = null;

                        for (int index = 0; index < numPlatos; index++)
                        {
                            arrayPlatos[index] = arrayPlatos[index + 1];
                        }

                        arrayPlatos[numPlatos] = null;
                        numPlatos--;
                    }
                }
            }
        }
        public void AniadirPlato(Comanda c)
        {
            if (c != null && numPlatos < arrayPlatos.Length)
            {
                arrayPlatos[numPlatos] = c;
                numPlatos++;
            }
        }

        public Comanda BuscarPlato(int id)
        {
            if (numPlatos != 0)
            {
                int pos = -1;

                for (int i = 0; i < numPlatos; i++)
                {
                    if (id == arrayPlatos[i].Id)
                    {
                        pos = i;
                    }
                }

                if (pos == -1)
                {
                    System.Console.WriteLine("Plato no encontrado, prueba con otro ID por favor");
                    return null;
                }
                else
                {
                    return (arrayPlatos[pos]);
                }

            }
            else
            {
                return null;
            }
        }

        //ACTUALIZA EL NÚMERO DE PLATOS CUANDO AÑADIMOS 1
        public void SumarCantPlatos()
        {
            //Actualizamos el pramétro de la clase, no es necesario devolver nada
            numPlatos++;
        }
        //ACTUALIZA EL NÚMERO DE PLATOS CUANDO RESTAMOS 1
        public void RestarCantPlatos()
        {
            numPlatos--;
        }
    }
}
