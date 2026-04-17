using AutoMapper;
using Siemns.DotNet.PmsApp.APIs.Models.DTOs;
using Siemns.DotNet.PmsApp.APIs.Models.Entities;

namespace Siemns.DotNet.PmsApp.APIs.Mapper
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            this
                .CreateMap<ProductDTO, Product>()
                .ForMember<int>(p => p.ProductId, (expression) => expression.MapFrom(dto => dto.ProductId))
                .ForMember<string>(p => p.ProductName, (expression) => expression.MapFrom(dto => dto.ProductName))
                .ForMember<decimal?>(p=>p.Price, (expression)=>expression.MapFrom(dto=>dto.Price))
                .ForMember<string?>(p => p.Description, (expression) => expression.MapFrom(dto => dto.Description))
                .ForMember<int?>(p => p.CategoryId, (expression) => expression.MapFrom(dto => dto.CategoryId))
                .ForMember<Category?>(p => p.Category, (expression) => expression.MapFrom(dto => dto.Category))
                .ReverseMap();

            this.CreateMap<CategoryDTO, Category>()
                .ReverseMap();
        }
    }
}
