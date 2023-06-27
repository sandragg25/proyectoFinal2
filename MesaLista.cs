using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoFinal2
{
    public class MesaLista
    {
        private List<Comanda> ListaComanda;
        
        private int id;
        private string status;

        public int Id { get => id; set => id = value; }
        public string Status { get => status; set => status = value; }

        //CONSTRUCTOR DE LA LISTA CON STATUS = "PENDING" DE BASE
        public MesaLista()
        {
            this.ListaComanda = new List<Comanda>();
            this.id = 0;
            this.status = "PENDING";
        }

        public void AniadirComanda(Comanda c)
        {
            if(c!=null && ListaComanda.Count > 0)
            {
                ListaComanda.Add(c);
            }
        }

        public void OrdenarListaId()
        {
            ListaComanda.Sort();
        }

        public void EliminarComanda(Comanda c)
        {
            if(c!=null && ListaComanda.Count != 0)
            {
                ListaComanda.Remove(c);
            }
            else
            {
                System.Console.WriteLine("Por favor, introduce la comanda que deseas eliminar");
            }
        }

        public void EliminarMesa()
        {
            ListaComanda.Clear();
            //this.ListaComanda = new List <Comanda>();
        }

        //NO ESTÁ ACABADA!!!!!!!!!
        public void EliminarPlatosComanda(Comanda c)
        {
            string query = "";
            System.Console.WriteLine("Indica el plato que quieres eliminar de la comanda");
            query = System.Console.ReadLine();

            // ListaComanda.RemoveAll(c.Plato == query);
            //ListaComanda.OrderBy(c => c.Plato == query);
        }


    }
}
