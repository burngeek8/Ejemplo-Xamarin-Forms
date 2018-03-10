using System;
using System.Collections.Generic;
using System.Text;

namespace MantenimientoContactos.Datos.Modelo
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public Categoria Categoria { get;set; }
    }
}
