using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SystemCore.Application.ViewModels.Product;
using SystemCore.Data.Entities;

namespace SystemCore.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
        }
    }
}
