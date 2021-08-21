using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        [HttpGet]
        public List<Persona> Get()
        {

            List<Persona> lst = null;

            using (Modelos.VueContext db = new Modelos.VueContext())
            {
                lst = (from p in db.Personas
                       select new Persona
                       {
                           Nombre = p.Nombre,
                           Edad = p.Edad
                       }).ToList();
            }

            return lst;
        }
    }

    public class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
}