using AutoMapper;
using ChallengeJr.Application.DTOs.Requests;
using ChallengeJr.Application.DTOs.Responses;
using ChallengeJr.Application.DTOs.Shared;
using ChallengeJr.Application.Interfaces;
using ChallengeJr.Domain.Entities;
using ChallengeJr.Domain.Interfaces.Repositories;

namespace ChallengeJr.Application.UseCases;

public class ProductUseCase : IProductUseCase
{
    private readonly IBaseRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public ProductUseCase(IBaseRepository<Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ResponseDTO<ProductResponseDTO>> CreateAsync(CreateProductRequestDTO request)
    {
        try
        {
            var product = _mapper.Map<Product>(request);
            var createdProduct = await _productRepository.CreateAsync(product);
            var response = _mapper.Map<ProductResponseDTO>(createdProduct);
            
            return ResponseDTO<ProductResponseDTO>.CreateSuccess(response);
        }
        catch (Exception ex)
        {
            return ResponseDTO<ProductResponseDTO>.CreateFailure($"Erro ao criar produto: {ex.Message}");
        }
    }

    public async Task<ResponseDTO<ProductResponseDTO>> GetByIdAsync(Guid id)
    {
        try
        {
            var product = await _productRepository.GetByIdAsync(id);
            
            if (product == null)
                return ResponseDTO<ProductResponseDTO>.CreateFailure("Produto não encontrado");
            
            var response = _mapper.Map<ProductResponseDTO>(product);
            return ResponseDTO<ProductResponseDTO>.CreateSuccess(response);
        }
        catch (Exception ex)
        {
            return ResponseDTO<ProductResponseDTO>.CreateFailure($"Erro ao buscar produto: {ex.Message}");
        }
    }

    public async Task<ResponseDTO<List<ProductResponseDTO>>> GetAllAsync()
    {
        try
        {
            var products = await _productRepository.GetAllAsync();
            var response = _mapper.Map<List<ProductResponseDTO>>(products);
            
            return ResponseDTO<List<ProductResponseDTO>>.CreateSuccess(response);
        }
        catch (Exception ex)
        {
            return ResponseDTO<List<ProductResponseDTO>>.CreateFailure($"Erro ao listar produtos: {ex.Message}");
        }
    }

    public async Task<ResponseDTO<ProductResponseDTO>> UpdateAsync(Guid id, UpdateProductRequestDTO request)
    {
        try
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            
            if (existingProduct == null)
                return ResponseDTO<ProductResponseDTO>.CreateFailure("Produto não encontrado");
            
            _mapper.Map(request, existingProduct);
            var updatedProduct = await _productRepository.UpdateAsync(existingProduct);
            var response = _mapper.Map<ProductResponseDTO>(updatedProduct);
            
            return ResponseDTO<ProductResponseDTO>.CreateSuccess(response);
        }
        catch (Exception ex)
        {
            return ResponseDTO<ProductResponseDTO>.CreateFailure($"Erro ao atualizar produto: {ex.Message}");
        }
    }

    public async Task<ResponseDTO<bool>> DeleteAsync(Guid id)
    {
        try
        {
            var exists = await _productRepository.ExistsAsync(id);
            
            if (!exists)
                return ResponseDTO<bool>.CreateFailure("Produto não encontrado");
            
            await _productRepository.DeleteAsync(id);
            return ResponseDTO<bool>.CreateSuccess(true);
        }
        catch (Exception ex)
        {
            return ResponseDTO<bool>.CreateFailure($"Erro ao excluir produto: {ex.Message}");
        }
    }
}
