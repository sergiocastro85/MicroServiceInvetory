﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
    }
}
