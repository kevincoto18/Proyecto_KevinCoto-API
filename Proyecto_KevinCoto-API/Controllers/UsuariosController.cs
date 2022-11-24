using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ApiDBContext context;
        public UsuariosController(ApiDBContext context)
        {
            this.context = context;
        }
        #region metodoGetLista
        // GET: api/<UsuariosController>
        //[HttpGet]
        //public List<Usuario> Get()
        //{
        //    //List<Usuario> list = new List<Usuario>();
        //    //list = data.ListarUsuarios();
        //    //return list;
        //}
        #endregion
        [HttpGet]
        public List<Usuario> Get()
        {
            List<Usuario> lista = context.Usuario.ToList();
            return lista;

        }
        #region metodogetbuscar
        //// GET api/<UsuariosController>/5
        //[HttpGet("{cedula}")]
        //public Usuario Get(string cedula)
        //{
        //    Usuario user = data.BuscarUsuario(cedula);
        //    return user;
        //}
        #endregion
        [HttpGet("{cedula}")]
        public Usuario Get(string cedula)
        {
            Usuario lista = context.Usuario.Find(cedula);
            return lista;
        }
        #region metodoPost

        // POST api/<UsuariosController>
        //[HttpPost]
        //public IActionResult Post([FromBody] Usuario user)
        //{
        //    var resultado = data.AgregarUsuario(user);
        //    if (resultado)
        //        return Ok(user);
        //    else
        //        return BadRequest();
        //}
        #endregion
        // POST api/<UsuariosController>
        [HttpPost]
        public IActionResult Post([FromBody] Usuario user)
        {
            context.Usuario.Add(user);
            context.SaveChanges();
            return Ok(user);
        }
        // PUT api/<UsuariosController>/5
        #region metodoPut
        //[HttpPut]
        //public IActionResult Put([FromBody] Usuario user)
        //{
        //    if (data.EditarUsuario(user))
        //        return Ok(user);
        //    else
        //        return BadRequest();

        //}
        #endregion
        [HttpPut]
        public IActionResult Put([FromBody] Usuario user)
        {
            context.Entry(user).State = EntityState.Modified;
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;

            }
            return NoContent();

        }
        // DELETE api/<UsuariosController>/5
        [HttpDelete("{cedula}")]
        #region metodoDelete
        //public IActionResult Delete(string cedula)
        //{
        //    if (data.EliminarUsuario(cedula))
        //        return Ok();
        //    else
        //        return BadRequest();
        //}
        #endregion

        public IActionResult Delete(string cedula)
        {
            if (context.Usuario == null)
            {
                return NotFound();
            }
            Usuario user = context.Usuario.Find(cedula);
            if (user == null)
            {
                return NotFound();
            }
            context.Usuario.Remove(user);
            context.SaveChanges();
            return Ok();
        }
    }
}
