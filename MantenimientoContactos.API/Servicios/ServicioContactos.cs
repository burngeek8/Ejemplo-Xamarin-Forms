using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MantenimientoContactos.Datos;
using  MantenimientoContactos.Datos.Modelo;

namespace MantenimientoContactos.API.Servicios
{
    public class ServicioContactos
    {
        private readonly BaseDeDatos _db;
        public ServicioContactos(BaseDeDatos db)
        {
            _db = db;
        }

        public List<Contacto> ObtenerContactos()
        {
            return _db.Contactos;
        }

        public int AgregarContacto(Contacto item)
        {
            if (string.IsNullOrEmpty(item.Nombre))
            {
                return -1;
            }

            var catContacto = item.Categoria;
            if (!_db.Categorias.Any(y => y.Id == catContacto.Id))
            {
                _db.Categorias.Add(catContacto);
            }
            _db.Contactos.Add(item);
            return 1;
        }

        public Contacto ObtenerContactoPorId(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return _db.Contactos.FirstOrDefault(c => c.Id == id);
        }

        public List<Contacto> BuscarPorNombre(string filtro)
        {
            return _db.Contactos
                    .Where(c => c.Nombre.ToLower().Contains(filtro.ToLower())) 
                    .OrderBy(x=>x.Categoria)
                    .ToList();
        }
    }
}
