using System;

public class PersistenciaEnMemoria : IPersistencia
{
	public PersistenciaEnMemoria()
	{
		LoadProducts();
		
	}
    private List<Product> _products = [];

    public Product GetProduct(string sku) 
    {
        _products.FirstOrDefault(p => p.Sku == sku);   
    
    }
    public IEnumerable<Product> GetProducts()
    {
        return _products.Where(p => p.IsActive);
    }
    
    private void LoadProducts()
    {
        var json = File.ReadAllText("Data:\\products.json");
        var _products = JsonSerializer.Deserialize<List<Product>>(json);

    }
}
