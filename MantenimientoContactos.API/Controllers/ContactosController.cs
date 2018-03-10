using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MantenimientoContactos.API.DTO;
using MantenimientoContactos.Datos.Modelo;
using MantenimientoContactos.API.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace MantenimientoContactos.API.Controllers
{

    //  http://localhost/api/Contactos
    [Route("api/[controller]")]
    public class ContactosController : Controller
    {
        private readonly ServicioContactos _srvContactos;
        public ContactosController(ServicioContactos srvContactos)
        {
            _srvContactos = srvContactos;
        }

        // GET api/values
         [HttpGet]
        public List<ContactosListView> Get()
        {
            return _srvContactos.ObtenerContactos().Select(c=> new ContactosListView
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Categoria = c.Categoria.Nombre
            }).ToList();
        }      
 

        // GET api/values/5
        [HttpGet("{id}")]
        public Contacto Get(int id)
        {
            return _srvContactos.ObtenerContactoPorId(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
