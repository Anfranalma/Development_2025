using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
using System.Data;

namespace Layer_Business
{
    public class NCategoria
    {
        //Metdos insertar que llae al metodo insertar de la clase DCatergoria
        //de la capa datos
        public static string Insertar(string nombre, string descripcion)
        {
            DCategoria Obj = new DCategoria();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;

            return Obj.Insertar(Obj);
        }

        //metodo editar qeu llaa la metodo editar de la clase DCategoria
        //de la capa de datos

        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            DCategoria Obj = new DCategoria();
            Obj.IdCategoria = idcategoria;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Editar(Obj);
        }

        //Metodo eliminar qeu llama al metodo eliminar de la case DCategoria
        //de la capa de datos

        public static string Eliminar(int idcategoria)
        {
            DCategoria Obj = new DCategoria();
            Obj.IdCategoria = idcategoria;
            return Obj.Eliminar(Obj);
        }

        //MEtodo mostrar que llama al metodo mostrar de la clase DCategoria
        //de la capa de datos
        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();
        }

        public static DataTable BuscarNombre(string textobuscar)
        {
            DCategoria Obj = new DCategoria();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
