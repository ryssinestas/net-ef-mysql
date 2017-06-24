using AutoMapper;
using Project.Domain.Entities;
using Project.Presentation.Models;

namespace Project.Presentation.AutoMapper
{
    public class ModelToViewModelMappingProfile : Profile
    {
        public ModelToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}