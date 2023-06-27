using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoFinal2
{
    public class Menu
    {
        private int id;
        private string plato;
        private bool alergenos;
        private string descAlergeno;
        private string altAlergeno;
        private bool veggie;
        private double precio;
        private string ordenPlato;

        public int Id { get => id; set => id = value; }
        public string Plato { get => plato; set => plato = value; }
        public bool Alergenos { get => alergenos; set => alergenos = value; }
        public string DescAlergeno { get => descAlergeno; set => descAlergeno = value; }
        public string AltAlergeno { get => altAlergeno; set => altAlergeno = value; }
        public bool Veggie { get => veggie; set => veggie = value; }
        public double Precio { get => precio; set => precio = value; }
        public string OrdenPlato { get => ordenPlato; set => ordenPlato = value; }

        public Menu()
        {
            this.id = 0;
            this.plato = "";
            this.ordenPlato = "";
            this.alergenos = false;
            this.descAlergeno = "";
            this.altAlergeno = "";
            this.veggie = false;
            this.precio=0.0;
            
        }

        //CONSTRUCTOR NO ALÉRGENOS NO VEGGIE
        public Menu(int id, string plato, string ordenPlato, double precio)
        {
            this.id = id;
            this.plato = plato;
            this.ordenPlato = ordenPlato;
            this.alergenos = false;
            this.descAlergeno = "";
            this.altAlergeno = "";
            this.veggie = false;
            this.precio = precio;
        }
        //CONSTRUCTOR ALÉRGENOS Y VEGGIE
        public Menu(int id, string plato, string ordenPlato, bool alergenos, string descAlergeno, string altAlergeno, bool veggie, int precio)
        {
            this.id = id;
            this.plato = plato;
            this.ordenPlato = ordenPlato;
            this.alergenos = true;
            this.descAlergeno = descAlergeno;
            this.altAlergeno = altAlergeno;
            this.veggie = true;
            this.precio = precio;

        }

        //CONSTRUCTOR ALÉRGENOS NO VEGGIE
        public Menu(int id, string plato, string ordenPlato, bool alergenos, string descAlergeno, string altAlergeno, double precio)
        {
            this.id = id;
            this.plato = plato;
            this.ordenPlato = ordenPlato;
            this.alergenos = true;
            this.descAlergeno = descAlergeno;
            this.altAlergeno = altAlergeno;
            this.veggie = false;
            this.precio = precio;
        }
        //CONSTRUCTOR VEGGIE NO ALÉRGENOS
        public Menu (int id, string plato, string ordenPlato, bool veggie, double precio)
        {
            this.id = id;
            this.plato = plato;
            this.ordenPlato = ordenPlato;
            this.alergenos = false;
            this.descAlergeno = "";
            this.altAlergeno = "";
            this.veggie = true;
            this.precio = precio;
        }

        //CONEXIÓN CON BASE DE DATOS
        
        //VOLCAR BD EN ARRAY
        public void VolcarBD()
        {
            string ruta = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Talio tecnico\source\repos\menu.mdb";
            string consulta = "SELECT * FROM menuGeneral";

            int index = 0;

            Mesa TPlatos = new Mesa(100);//INSTANCIAMOS UN OBJETO DE TIPO ARRAY, QUE RECOGE COMANDA-S
            Comanda c = new Comanda();//INSTANCIAMOS OBJETO ATÓMICO (QUE SE GUARDA EN ARRAY)

            using (OleDbConnection conexion = new OleDbConnection(ruta))
            {
                OleDbCommand comando = new OleDbCommand(consulta, conexion);

                try
                {
                    conexion.Open();
                    using (OleDbDataReader miTabla = comando.ExecuteReader())
                    {
                        Console.WriteLine("---------------MENÚ---------------");
                        
                        while (miTabla.Read())
                        {                           
                            c.Id = miTabla.GetInt32(0); //ES LO MISMO QUE miTabla["Id"];
                            c.Plato = miTabla.GetString(1);
                            c.OrdenPlato = miTabla.GetString(2);
                            c.Precio = miTabla.GetDouble(3);
                            c.Alergenos = miTabla.GetBoolean(4);
                            c.DescAlergeno = miTabla.GetString(5);
                            c.AltAlergeno = miTabla.GetString(6);
                            c.NumMesa = 0;

                            TPlatos.AniadirPlato(c);
                            TPlatos.SumarCantPlatos();

                            //TPlatos(index) = c;
                            //index++;
                        }
                    }
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Se ha producido un error: " + ex.Message);
                }
            }
        }

        //INSERT
        public void AniadirPlatoBD()
        {
            string ruta = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Talio tecnico\source\repos\menu.mdb";
            string consulta = "INSERT INTO menuGeneral(plato, ordenPlato, precio, alergenos, descAlergeno, altAlergeno) VALUES ('" + plato + "','" + ordenPlato + "'," + precio + "," + alergenos + ",'" + descAlergeno + "','" + altAlergeno + "')";

            using (OleDbConnection conexion = new OleDbConnection(ruta))
            {
                OleDbCommand comando = new OleDbCommand(consulta, conexion);
                try
                {
                    conexion.Open();

                    using (OleDbDataReader miTabla = comando.ExecuteReader())

                    Console.WriteLine("Plato añadido correctamente");
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Se ha producido un error:" + ex.Message);
                }
                System.Console.ReadKey();
            }
        }

        //DELETE
        public void EliminarPlatoBD()
        {
            string ruta = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Talio tecnico\source\repos\menu.mdb";
            string consulta = "DELETE FROM menuGeneral WHERE Id=";
            int id;

            System.Console.WriteLine("Introduce el Id del Plato que quieres eliminar");
            id = int.Parse(System.Console.ReadLine());

            consulta = consulta + id;

            using (OleDbConnection conexion = new OleDbConnection(ruta))
            {
                OleDbCommand comando = new OleDbCommand(consulta, conexion);
                try
                {
                    conexion.Open();

                    using (OleDbDataReader miTabla = comando.ExecuteReader())

                    Console.WriteLine("Plato eliminado correctamente");
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Se ha producido un error:" + ex.Message);
                }
                System.Console.ReadKey();
            }
        }

        //SET
        public void ActualizarPlatoBD()
        {
            string ruta = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Talio tecnico\source\repos\menu.mdb";
            string consultaBase = "UPDATE menuGeneral SET";
            
            string consultaPlato="";
            string consultaOrdenPlato="";
            string consultaPrecio="";
            string consultaAlergenos="";
            string consultaDescAlergeno="";
            string consultaAltAlergeno="";

            int id;
            int opc;


            System.Console.WriteLine("Introduce el Id del Plato que quieres actualizar");
            id = int.Parse(System.Console.ReadLine());

            do
            {
                System.Console.WriteLine("Escoge una opción:\n (1) Modificar título del plato\n (2) Modificar orden del plato\n (3) Modificar precio\n (4) Modificar alérgenos\n (5) Modificar descripción de alérgenos\n (6) Modificar alternativa alérgenos\n (0) SALIR");
                opc = int.Parse(System.Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        System.Console.WriteLine("Añade el título del plato actualizado");
                        plato = (System.Console.ReadLine());
                        consultaPlato = consultaBase + "plato";
                        break;
                    case 2:
                        System.Console.WriteLine("Añade la orden del plato");
                        ordenPlato = (System.Console.ReadLine());
                        consultaOrdenPlato = consultaBase + "ordenPlato";
                        break;
                    case 3:
                        System.Console.WriteLine("Añade el precio");
                        precio = double.Parse(System.Console.ReadLine());
                        consultaPrecio = consultaBase + "precio";
                        break;
                    case 4:
                        System.Console.WriteLine("Indica si hay alérgenos");
                        alergenos = bool.Parse(System.Console.ReadLine());
                        consultaAlergenos = consultaBase + "alergenos";
                        break;
                    case 5:
                        System.Console.WriteLine("Describe el tipo de alérgeno");
                        descAlergeno = System.Console.ReadLine();
                        consultaDescAlergeno = consultaBase + "descAlergeno";
                        break;
                    case 6:
                        System.Console.WriteLine("Indica la alternativa al alérgeno");
                        altAlergeno = System.Console.ReadLine();
                        consultaAltAlergeno = consultaBase + "altAlergeno";
                        break;
                    case 0:
                        break;
                    default:
                        System.Console.WriteLine("Por favor, escoge una de las opciones de la lista");
                        break;
                }

            } while (opc != 0);

            System.Console.WriteLine("Tu consulta es: "+consultaBase+consultaPlato);

            using (OleDbConnection conexion = new OleDbConnection(ruta))
            {
                OleDbCommand comandoPlato = new OleDbCommand(consultaPlato, conexion);
                OleDbCommand comandoOrdenPlato = new OleDbCommand(consultaOrdenPlato, conexion);
                OleDbCommand comandoPrecio = new OleDbCommand(consultaPrecio, conexion);
                OleDbCommand comandoAlergenos = new OleDbCommand(consultaAlergenos, conexion);
                OleDbCommand comandoDescAlergeno = new OleDbCommand(consultaDescAlergeno, conexion);
                OleDbCommand comandoAltAlergeno = new OleDbCommand(consultaAltAlergeno, conexion);
           
                try
                {
                    conexion.Open();
                    if(consultaPlato!= "")
                    {
                        OleDbDataReader miTabla = comandoPlato.ExecuteReader();
                    }
                    if(consultaOrdenPlato!="")
                    {
                        OleDbDataReader miTabla = comandoOrdenPlato.ExecuteReader();
                    }
                    if (consultaPrecio != "")
                    {
                        OleDbDataReader miTabla = comandoPrecio.ExecuteReader();
                    }
                    if(consultaAlergenos!="")
                    {
                        OleDbDataReader miTabla = comandoAlergenos.ExecuteReader();
                    }
                    if (consultaDescAlergeno != "")
                    {
                        OleDbDataReader miTabla = comandoDescAlergeno.ExecuteReader();
                    }
                    if (consultaAltAlergeno != "")
                    {
                        OleDbDataReader miTabla = comandoAltAlergeno.ExecuteReader();
                    }

                    System.Console.WriteLine("Campos actualizados");
                    conexion.Close();
                }
                catch(Exception ex)
                {
                System.Console.WriteLine("Se produjo un problema: " + ex.Message);
                }
            }
            System.Console.ReadLine();
        }




    }
}
