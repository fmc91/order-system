using AutoMapper;
using OrderSystem.Model;
using DataLayer.Model;

namespace OrderSystem.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryModel>();

            CreateMap<CategoryModel, Category>()
                .ForMember(dest => dest.Products, opt => opt.Ignore());
        }
    }
}
