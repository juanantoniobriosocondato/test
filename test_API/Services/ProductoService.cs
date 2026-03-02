using MongoDB.Driver;
using test_API.Modelos.DTO;

namespace test_API.Services
{
    public class ProductoService
    {
        private readonly IMongoCollection<ProductoDTO> _productos;

        public ProductoService(IConfiguration config)
        {
            var cliente = new MongoClient(config.GetValue<string>("MongoDB:ConnectionString"));
            var baseDatos = cliente.GetDatabase(config.GetValue<string>("MongoDB:DatabaseName"));
            _productos = baseDatos.GetCollection<ProductoDTO>(config.GetValue<string>("MongoDB:CollectionName"));
        }

        public async Task<List<ProductoDTO>> GetAsync() =>
            await _productos.Find(_ => true).ToListAsync();

        public async Task<ProductoDTO> GetByIdAsync(int id) =>
            await _productos.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(ProductoDTO producto) =>
            await _productos.InsertOneAsync(producto);
    }
}