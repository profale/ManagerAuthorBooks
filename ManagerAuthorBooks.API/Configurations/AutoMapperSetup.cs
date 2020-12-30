using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ManagerAuthorBooks.API.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace ManagerAuthorBooks.API.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(Startup));
            ////services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            ////.AddAutoMapper(typeof(ManagerAuthorBooks.API), typeof(ManagerAuthorBooks.Domain));
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });


            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
