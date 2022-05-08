using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer.Model;
using OrderSystem.Model;

namespace OrderSystem.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => new Size(src.Length, src.Width, src.Height)));

            CreateMap<ProductModel, Product>()
                .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Size.Length))
                .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.Size.Width))
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Size.Height))
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.StockItems, opt => opt.Ignore())
                .ForMember(dest => dest.OrderItems, opt => opt.Ignore());
        }
    }
}
