using System;
using System.Text.Json;

public interface IPersistencia
{
    public Product GetProduct(string sku);
    public IEnumerable<Product> GetProducts();
}
