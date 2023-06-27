using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoFinal2
{
    public class Comanda:Menu
    {
        private int numMesa;
        private string status;

        public int NumMesa { get => numMesa; set => numMesa = value; }
        public string Status { get => status; set => status = value; }

        public Comanda()
        {
            this.Id = 0;
            this.Plato = "";
            this.OrdenPlato = "";
            this.Alergenos = false;
            this.DescAlergeno = "";
            this.AltAlergeno = "";
            this.Veggie = false;
            this.Precio = 0.0;
            this.numMesa = 0;
        }
        public Comanda(int numMesa)
        {
            this.Id = 0;
            this.Plato = "";
            this.OrdenPlato = "";
            this.Alergenos = false;
            this.DescAlergeno = "";
            this.AltAlergeno = "";
            this.Veggie = false;
            this.Precio = 0.0;      
        }

        //CONSTRUCTOR SIN MESA (NO ALÉRGENOS, NO VEGGIE)
        public Comanda(int id, string plato, string ordenPlato, double precio)
        {
            this.Id = id;
            this.Plato = plato;
            this.OrdenPlato = ordenPlato;
            this.Alergenos = false;
            this.DescAlergeno = "";
            this.AltAlergeno = "";
            this.Veggie = false;
            this.Precio = precio;
            this.numMesa = 0;
        }

        //CONSTRUCTOR NO ALÉRGENOS NO VEGGIE
        public Comanda(int id, string plato, string ordenPlato, double precio, int numMesa)
        {
            this.Id = id;
            this.Plato = plato;
            this.OrdenPlato = ordenPlato;
            this.Alergenos = false;
            this.DescAlergeno = "";
            this.AltAlergeno = "";
            this.Veggie = false;
            this.Precio = precio;
            this.numMesa = numMesa;
        }
        //CONSTRUCTOR ALÉRGENOS Y VEGGIE
        public Comanda(int id, string plato, string ordenPlato, bool alergenos, string descAlergeno, string altAlergeno, bool veggie, int precio, int numMesa)
        {
            this.Id = id;
            this.Plato = plato;
            this.OrdenPlato = ordenPlato;
            this.Alergenos = true;
            this.DescAlergeno = descAlergeno;
            this.AltAlergeno = altAlergeno;
            this.Veggie = true;
            this.Precio = precio;
            this.numMesa = numMesa;

        }

        //CONSTRUCTOR ALÉRGENOS NO VEGGIE
        public Comanda(int id, string plato, string ordenPlato, bool alergenos, string descAlergeno, string altAlergeno, double precio, int numMesa)
        {
            this.Id = id;
            this.Plato = plato;
            this.OrdenPlato = ordenPlato;
            this.Alergenos = true;
            this.DescAlergeno = descAlergeno;
            this.AltAlergeno = altAlergeno;
            this.Veggie = false;
            this.Precio = precio;
            this.numMesa = numMesa;
        }
        //CONSTRUCTOR VEGGIE NO ALÉRGENOS
        public Comanda(int id, string plato, string ordenPlato, bool veggie, double precio, int numMesa)
        {
            this.Id = id;
            this.Plato = plato;
            this.OrdenPlato = ordenPlato;
            this.Alergenos = false;
            this.DescAlergeno = "";
            this.AltAlergeno = "";
            this.Veggie = true;
            this.Precio = precio;
            this.numMesa = numMesa;
        }

    }
}
