using AutoMapper;
using Multishop.Catalog.DTOs.CategoryDtos;
using Multishop.Catalog.DTOs.ProductDetailDtos;
using Multishop.Catalog.DTOs.ProductImageDtos;
using Multishop.Catalog.Entities;

namespace Multishop.Catalog.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();


            CreateMap<Product, ResultProductDetailDto>().ReverseMap();
            CreateMap<Product,  CreateCategoryDto>().ReverseMap();
            CreateMap<Product, UpdateCategoryDto>().ReverseMap();
            CreateMap<Product, GetByIdCategoryDto>().ReverseMap();


            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();


            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();





        }
    }
}
