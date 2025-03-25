using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Command.User;
using Application.UseCases.DTOs;
using AutoMapper;
using Domain.Entities;
 

namespace Application.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
           CreateMap<ProductDto, Product>();
           CreateMap<Product, ProductDto>();

           CreateMap<SupplierDto, Supplier>();
           CreateMap<Supplier, SupplierDto>();

            CreateMap<AddUserCommand, User>()
                 .ForMember(dest => dest.CreatedAt,opt=>opt.MapFrom(src=>DateTime.UtcNow))
                 .ForMember(dest => dest.Status,opt=>opt.MapFrom(src=> "Activo"));

            CreateMap<User, UserDto>();
        }
    }
}
