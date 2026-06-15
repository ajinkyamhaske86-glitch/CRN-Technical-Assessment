using CRNAssessment.API.Data;
using CRNAssessment.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CRNAssessment.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _context.Products.ToListAsync();
        return Ok(products);
    }
    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        Log.Information("Product Created Successfully");

        product.CreatedOn = DateTime.Now;

        _context.Products.Add(product);

        await _context.SaveChangesAsync();

        return Ok(product);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Product product)
    {
        var existingProduct = await _context.Products.FindAsync(id);

        if (existingProduct == null)
            return NotFound();

        existingProduct.ProductName = product.ProductName;
        existingProduct.ModifiedBy = product.ModifiedBy;
        existingProduct.ModifiedOn = DateTime.Now;

        await _context.SaveChangesAsync();

        return Ok(existingProduct);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
            return NotFound();

        _context.Products.Remove(product);

        await _context.SaveChangesAsync();

        return Ok("Product Deleted Successfully");
    }
}