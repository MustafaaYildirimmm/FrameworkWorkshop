using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkWorkShop.Core.Utilities.Mapping
{
    public class AutoMapperHelper
    {
        public static List<T> MapToSameTypeList<T>(List<T> list)
        {
            var config = new MapperConfiguration(c => c.CreateMap<T, T>());
            var mapper = config.CreateMapper();

            return mapper.Map<List<T>,List<T>>(list);
        }

        public static T MapToSameType<T>(T obj)
        {
            var config = new MapperConfiguration(c => c.CreateMap<T, T>());
            var mapper = config.CreateMapper();

            return mapper.Map<T,T>(obj);
        }
    }
}
