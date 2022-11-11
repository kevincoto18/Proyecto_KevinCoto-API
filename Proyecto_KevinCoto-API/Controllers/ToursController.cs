using Microsoft.AspNetCore.Mvc;
using Proyecto_KevinCoto_API.Data;
using Proyecto_KevinCoto_API.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_KevinCoto_API.Controllers
{
    [Route("Datos/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private static ToursData data = new ToursData();
        // GET: api/<ToursController>
        [HttpGet]
        public List<Tour> Get()
        {
            List<Tour> list = new List<Tour>();
            list = data.ListarTour();
            return list;
        }

        // GET api/<ToursController>/5
        [HttpGet("{id}")]
        public Tour Get(string id)
        {
            Tour tour = data.BuscarTour(id);
            return tour;
        }

        // POST api/<ToursController>
        [HttpPost]
        public IActionResult Post([FromBody] Tour tour)
        {
            data.AgregarTour(tour);
            return Ok(tour);
        }

        // PUT api/<ToursController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Tour tour)
        {
            if (data.EditarTour(tour))
                return Ok(tour);
            else
                return BadRequest();
        }

        // DELETE api/<ToursController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            data.EliminarTour(id);
            return Ok();
        }
    }
}
