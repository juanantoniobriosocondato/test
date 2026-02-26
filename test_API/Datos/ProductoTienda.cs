using test_API.Modelos.DTO;

namespace test_API.Datos
{
    public static class ProductoTienda
    {
        public static List<ProductoDTO> productoList = new List<ProductoDTO>()
        {
            new ProductoDTO() {Id=1, Nombre="Zapatos" },
            new ProductoDTO() {Id=2, Nombre="Camiseta"},
            new ProductoDTO() {Id=3, Nombre="Pantalones"}
        };
    }
}
