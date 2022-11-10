using Microsoft.AspNetCore.Mvc;
using Proyecto_KevinCoto_API.Data;
using Proyecto_KevinCoto_API.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_KevinCoto_API.Controllers
{
    [Route("Datos/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private static UsuariosData data = new UsuariosData();
        // GET: api/<UsuariosController>
        [HttpGet]
        public List<Usuario> Get()
        {
            List<Usuario> list = new List<Usuario>();
            list = data.ListarUsuarios();
            return list;
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{cedula}")]
        public Usuario Get(string cedula)
        {
            Usuario user = data.BuscarUsuario(cedula);
            return user ;
        }

     

        // POST api/<UsuariosController>
        [HttpPost]
        public IActionResult Post([FromBody] Usuario user)
        {
            var resultado = data.AgregarUsuario(user);
            if(resultado)
            return Ok(user);
            else
                return BadRequest();
        }

        // PUT api/<UsuariosController>/5
        [HttpPut]
        public IActionResult Put( [FromBody] Usuario user)
        {
            if (data.EditarUsuario(user))
                return Ok(user);
            else
                return BadRequest();

        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{cedula}")]
        public IActionResult Delete(string cedula)
        {
            if (data.EliminarUsuario(cedula))
                return Ok();
            else
                return BadRequest();
        }
    }
}
