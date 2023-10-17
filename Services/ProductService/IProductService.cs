namespace MicroService1.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProduct();

        Task<Product?> GetProduct(int id);

        Task<List<Product>> AddProduct(Product product);

        Task<List<Product>?> UpdateProduct(int id, Product request);

        Task<List<Product>?> DeleteProduct(int id);
    }
}
