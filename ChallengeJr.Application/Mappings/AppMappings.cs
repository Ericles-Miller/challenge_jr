using AutoMapper;
using ChallengeJr.Application.DTOs.Requests;
using ChallengeJr.Application.DTOs.Responses;
using ChallengeJr.Domain.Entities;

namespace ChallengeJr.Application.Mappings;

public class AppMappings : Profile
{
    public AppMappings()
    {
        // Product mappings
        CreateMap<CreateProductRequestDTO, Product>();
        CreateMap<UpdateProductRequestDTO, Product>();
        CreateMap<Product, ProductResponseDTO>();
    }
}
