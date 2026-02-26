using test_API.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace test_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Productos> GetProductos()
        {
            return new List<Productos>
            {
                   new Productos {Id=1, Nombre="Zapatos"},
                   new Productos {Id=2, Nombre="Camiseta"},
                   new Productos {Id=3, Nombre="Pantalones"}
            };

        } 
    }
}
