using AutoMapper;
using Kai.Core.Product;
using Kai.Core.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kai.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, ProductModel>();
            CreateMap<UserDto, UserModel>().ReverseMap();
        }
    }
}
