using ChallengeJr.Application.DTOs.Requests;
using ChallengeJr.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeJr.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductUseCase _productUseCase;

    public ProductsController(IProductUseCase productUseCase)
    {
        _productUseCase = productUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequestDTO request)
    {
        var result = await _productUseCase.CreateAsync(request);
        
        if (!result.Success)
            return BadRequest(result);
        
        return CreatedAtAction(nameof(GetById), new { id = result.Data!.Id }, result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _productUseCase.GetByIdAsync(id);
        
        if (!result.Success)
            return NotFound(result);
        
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _productUseCase.GetAllAsync();
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductRequestDTO request)
    {
        var result = await _productUseCase.UpdateAsync(id, request);
        
        if (!result.Success)
            return BadRequest(result);
        
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _productUseCase.DeleteAsync(id);
        
        if (!result.Success)
            return NotFound(result);
        
        return Ok(result);
    }
}
