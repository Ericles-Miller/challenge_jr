using System.ComponentModel.DataAnnotations;

namespace ChallengeJr.Application.DTOs.Requests;

public class CreateProductRequestDTO
{
    [Required(ErrorMessage = "O nome do produto é obrigatório")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "O preço é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "A categoria é obrigatória")]
    [StringLength(50, ErrorMessage = "A categoria deve ter no máximo 50 caracteres")]
    public string Category { get; set; } = string.Empty;

    [Range(0, int.MaxValue, ErrorMessage = "A quantidade em estoque não pode ser negativa")]
    public int Stock { get; set; }

    public bool IsActive { get; set; } = true;
}
