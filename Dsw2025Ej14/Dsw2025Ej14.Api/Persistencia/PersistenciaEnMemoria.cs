using System;
using System.Text.Json;

public class PersistenciaEnMemoria : IPersistencia
{
    private List<Product> _products;
    public PersistenciaEnMemoria()
    {
        LoadProducts();

    }
    

    public Product GetProduct(string sku)
    {
        return _products.FirstOrDefault(p => p.Sku == sku);

    }
    public IEnumerable<Product> GetProducts()
    {
        return _products.Where(p => p.IsActive).ToList();
    }

    private List<Product> LoadProducts()
    {
        var json = File.ReadAllText("C:\\Users\\moran\\OneDrive\\Desktop\\DSW2025\\Dsw2025Ej14\\Dsw2025Ej14\\Dsw2025Ej14.Api\\products.json");
        return _products = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

    }
}
