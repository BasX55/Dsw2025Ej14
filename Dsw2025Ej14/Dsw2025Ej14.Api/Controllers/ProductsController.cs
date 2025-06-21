using Microsoft.AspNetCore.Mvc;
using System;



[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IPersistencia _persistencia;
    public ProductsController(IPersistencia persistencia)
    {
        _persistencia = persistencia ?? throw new ArgumentNullException(nameof(persistencia));
    }


    [HttpGet("api/products/{sku}")]
    public IActionResult GetProduct(string sku)
    {
        var product = _persistencia.GetProduct(sku);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }



    [HttpGet("api/products")]
    public IActionResult GetProductos()
    {
        var productos = _persistencia.GetProducts();
        if (productos == null || !productos.Any())
        {
            return NotFound();
        }
        return Ok(productos);

    }
}
