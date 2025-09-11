using Consume_API_in_MVC_App.Models;

namespace Consume_API_in_MVC_App.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //https://localhost:7043/api/products
        public async Task<List<Product>> GetAllProducts() =>
            await _httpClient.GetFromJsonAsync<List<Product>>("products") ?? new List<Product>();

        public async Task<Product?> GetProductById(int id) =>
            await _httpClient.GetFromJsonAsync<Product>($"products/{id}");
        //public async Task<List<Product>> GetProductsAsync(string token)
        //{
        //    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        //    var response = await _httpClient.GetAsync("products");
        //    response.EnsureSuccessStatusCode();
        //    var products = await response.Content.ReadFromJsonAsync<List<Models.Product>>();
        //    return products ?? new List<Models.Product>();
        //}
    }
}
