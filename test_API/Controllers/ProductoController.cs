using test_API.Modelos.DTO;
using Microsoft.AspNetCore.Mvc;
using test_API.Services; // Añade esto

namespace test_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _productoService;

        public ProductoController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetProductos()
        {
            var productos = await _productoService.GetAsync();
            return Ok(productos);
        }

        [HttpGet("{id:int}", Name = "GetProducto")]
        public async Task<ActionResult<ProductoDTO>> GetProducto(int id)
        {
            if (id <= 0) return BadRequest();
            var producto = await _productoService.GetByIdAsync(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductoDTO>> CrearProducto([FromBody] ProductoDTO productoDTO)
        {
            if (productoDTO == null) return BadRequest();

            // Lógica para auto-incrementar ID (provisional para pruebas)
            var lista = await _productoService.GetAsync();
            productoDTO.Id = lista.Any() ? lista.Max(p => p.Id) + 1 : 1;

            await _productoService.CreateAsync(productoDTO);
            return CreatedAtRoute("GetProducto", new { id = productoDTO.Id }, productoDTO);
        }
    }
}