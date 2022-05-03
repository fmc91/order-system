using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.ProductModel;
using EntityModel = DataLayer.Model;

namespace DomainLayer.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<EntityModel.Product, Product>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Product, EntityModel.Product>()
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.StockItems, opt => opt.Ignore())
                .ForMember(dest => dest.OrderItems, opt => opt.Ignore());

            CreateMap<EntityModel.Category, Category>();

            CreateMap<Category, EntityModel.Category>()
                .ForMember(dest => dest.Products, opt => opt.Ignore());
        }
    }
}
