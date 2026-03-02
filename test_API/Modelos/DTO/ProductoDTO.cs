using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace test_API.Modelos.DTO
{
    public class ProductoDTO
    {
        [BsonId]
        public int Id { get; set; } 

        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }
    }
}