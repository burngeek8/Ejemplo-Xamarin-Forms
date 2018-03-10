
using System.Collections.Generic; 
using MantenimientoContactos.Datos.Modelo;

namespace MantenimientoContactos.Datos
{
    public class BaseDeDatos
    {
        public List<Categoria> Categorias { get; set; }
        public List<Contacto> Contactos { get; set; }

        public BaseDeDatos()
        {
            Categorias = new List<Categoria>();
            Contactos= new List<Contacto>();

            var cliente = new Categoria
            {
                Id=1,
                Nombre = "Clientes"
            };
            var proveedor = new Categoria
            {
                Id=1,
                Nombre = "Proveedores"
            };
            Categorias.Add(cliente);
            Categorias.Add(proveedor);

            Contactos.Add(new Contacto
            {
                Id = 1,
                Nombre = "Juan Perez",
                Telefono = "921329922",
                Categoria = cliente
            });

            Contactos.Add(new Contacto
            {
                Id = 2,
                Nombre = "Julio Diaz",
                Telefono = "921329888",
                Categoria = cliente
            });

            Contactos.Add(new Contacto
            {
                Id = 3,
                Nombre = "Luis Gomez",
                Telefono = "54257776",
                Categoria = proveedor
            });

            Contactos.Add(new Contacto
            {
                Id = 4,
                Nombre = "Juana Diaz",
                Telefono = "958335333",
                Categoria = proveedor
            });

        }
    }
}
