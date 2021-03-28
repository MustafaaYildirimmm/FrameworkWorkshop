using AutoMapper;
using FrameworkWorkShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkWorkShop.Business.Mappings.AutoMapper.Profiles
{
    public class BusinessProfile :Profile
    {
        public BusinessProfile()
        {
            CreateMap<Product, Product>();
        }
    }
}
