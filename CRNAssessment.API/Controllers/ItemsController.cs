using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRNAssessment.API.Data;
using CRNAssessment.API.Models;

namespace CRNAssessment.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ItemsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Items.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();
        return Ok(item);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _context.Items.FindAsync(id);

        if (item == null)
            return NotFound();

        return Ok(item);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Item item)
    {
        var existingItem = await _context.Items.FindAsync(id);

        if (existingItem == null)
            return NotFound();

        existingItem.Quantity = item.Quantity;

        await _context.SaveChangesAsync();

        return Ok(existingItem);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _context.Items.FindAsync(id);

        if (item == null)
            return NotFound();

        _context.Items.Remove(item);

        await _context.SaveChangesAsync();

        return Ok("Item Deleted Successfully");
    }
}