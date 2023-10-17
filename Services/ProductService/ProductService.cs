using MicroService1.Data;

namespace MicroService1.Services.ProductService
{
    public class ProductService : IProductService
    {

        private readonly DataContext _context;
        private static readonly List<Product> products = new List<Product>()
            {
                new Product{ Id = 1, Name = "Stylo", Description = "Bic"},
                new Product{ Id = 2, Name = "Cahier", Description = "Selecta"}
            };


        public ProductService(DataContext context)
        {
            _context= context;
        }

        public async Task<List<Product>> AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();  

            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>?> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is null)
                return null;
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return products;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product?> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product;
        }

        public async Task<List<Product>> UpdateProduct(int id, Product request)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is null)
                return null;

            product.Name = request.Name;
            product.Description = request.Description;

            await _context.SaveChangesAsync();

            return products;
        }
    }
}
