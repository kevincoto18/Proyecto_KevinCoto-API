using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_KevinCoto_API.Data;
using Proyecto_KevinCoto_API.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_KevinCoto_API.Controllers
{
    [Route("Datos/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ApiDBContext context;
        public ProductosController(ApiDBContext context)
        {
            this.context = context;
        }
        private static ProductosData data = new ProductosData();
        // GET: api/<ProductosController>
        #region MetodoGet
        //[HttpGet]
        //public List<Producto> Get()
        //{
        //    List<Producto> list = new List<Producto>();
        //    list = data.ListarProductos();
        //    return list;
        //}
        #endregion
        [HttpGet]
        public List<Producto> Get()
        {
            List<Producto> list = context.Producto.ToList();

            return list;
        }
        // GET api/<ProductosController>/5
        #region MetodoGetporID
        //[HttpGet("{id}")]
        //public Producto Get(string id)
        //{
        //    Producto product = data.BuscarProducto(id);
        //    return product;
        //}
        #endregion
        [HttpGet("{id}")]
        public Producto Get(string id)
        {
            Producto product = context.Producto.Find(id);
            return product;
        }
        // POST api/<ProductosController>
        #region metodopost
        //[HttpPost]
        //public IActionResult Post([FromBody] Producto product)
        //{
        //    data.AgregarProducto(product);
        //    return Ok(product);
        //}
        #endregion
        [HttpPost]
        public IActionResult Post([FromBody] Producto product)
        {
            context.Producto.Add(product);
            context.SaveChanges();
            return Ok(product);
        }
        // PUT api/<ProductosController>/5
        #region MetodoPut
        //[HttpPut]
        //public IActionResult Put([FromBody] Producto product)
        //{
        //    if (data.EditarProducto(product))
        //        return Ok(product);
        //    else
        //        return BadRequest();
        //}
        #endregion
        [HttpPut]
        public IActionResult Put([FromBody] Producto product)
        {
            context.Entry(product).State = EntityState.Modified;
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;

            }
            return Ok();
        }

        // DELETE api/<ProductosController>/5
        #region MetodoDelete
        //[HttpDelete("{id}")]
        //public IActionResult Delete(string id)
        //{
        //    data.EliminarProducto(id);
        //    return Ok();
        //}
        #endregion
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (context.Producto == null)
            {
                return BadRequest();
            }
            Producto product = context.Producto.Find(id);
            if (product == null)
            {
                return BadRequest();
            }
            context.Producto.Remove(product);
            context.SaveChanges();
            return Ok();
        }
    }
}
