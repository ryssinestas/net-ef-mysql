using AutoMapper;
using Project.Domain.Entities;
using Project.Presentation.Models;

namespace Project.Presentation.AutoMapper
{
    public class ViewModelToModelMappingProfile : Profile
    {
        public ViewModelToModelMappingProfile()
        {
            CreateMap<ProductViewModel, Product>();
        }
    }
}