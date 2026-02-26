using test_API.Modelos;
using test_API.Modelos.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_API.Datos;


namespace test_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ProductoDTO>> GetProductos()
        {
            return Ok(ProductoTienda.productoList);
        } 

        [HttpGet("id:int", Name="GetProducto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProductoDTO> GetProducto(int id)
        {
            if (id == 0) 
            {
                return BadRequest();
            }

            var producto = ProductoTienda.productoList.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ProductoDTO> CrearProducto([FromBody] ProductoDTO productoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(productoDTO == null) 
            {
                return BadRequest(productoDTO);
            }
            if (productoDTO.Id > 0) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            productoDTO.Id = ProductoTienda.productoList.OrderByDescending(p => p.Id).FirstOrDefault().Id + 1;
            ProductoTienda.productoList.Add(productoDTO);
            return CreatedAtRoute("GetProducto", new {id=productoDTO.Id}, productoDTO);
        }
    }
}
