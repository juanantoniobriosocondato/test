using System.ComponentModel.DataAnnotations;

namespace test_API.Modelos
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; } 
        public DateTime FechaCreacion { get; set; }
    }
}
