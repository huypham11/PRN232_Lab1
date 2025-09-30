using AutoMapper;
using BusinessObjects;
using BusinessObjects.ViewModel;

namespace ProductWebAPI.Mapper;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<ProductViewModel, Product>();
        CreateMap<Product, ProductViewModel>();
        // Create your mapping configurations here
    }

}