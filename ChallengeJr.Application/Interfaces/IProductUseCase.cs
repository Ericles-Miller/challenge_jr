using ChallengeJr.Application.DTOs.Requests;
using ChallengeJr.Application.DTOs.Responses;
using ChallengeJr.Application.DTOs.Shared;

namespace ChallengeJr.Application.Interfaces;

public interface IProductUseCase
{
    Task<ResponseDTO<ProductResponseDTO>> CreateAsync(CreateProductRequestDTO request);
    Task<ResponseDTO<ProductResponseDTO>> GetByIdAsync(Guid id);
    Task<ResponseDTO<List<ProductResponseDTO>>> GetAllAsync();
    Task<ResponseDTO<ProductResponseDTO>> UpdateAsync(Guid id, UpdateProductRequestDTO request);
    Task<ResponseDTO<bool>> DeleteAsync(Guid id);
}
