using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using ManagerAuthorBooks.Domain.Commands.AuthorCommands;
using ManagerAuthorBooks.Domain.Entities;
using ManagerAuthorBooks.Domain.Commands.BooksCommands;
using ManagerAuthorBooks.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using ManagerAuthorBooks.Domain.Repositories;
using ManagerAuthorBooks.Infra.Repositories;
using ManagerAuthorBooks.Domain.Handlers;
using ManagerAuthorBooks.API.Configurations;
using ManagerAuthorBooks.Domain.Handlers.Contracts;
using ManagerAuthorBooks.Infra.Services;
using ManagerAuthorBooks.Domain.Queries.Contracts;
using ManagerAuthorBooks.Domain.Queries;

namespace ManagerAuthorBooks.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("connectionString")));

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BooksRepository>();

            services.AddScoped<AuthorHandler, AuthorHandler>();
            //services.AddScoped<BooksHandler, BooksHandler>();

            services.AddScoped<IMediatorHandler, RabbitMQueue>();
            services.AddScoped<IAuthorQueries, AuthorQueries>();

           //var mappingConfig = new MapperConfiguration(mc =>
           // {
           //     mc.AddProfile(new MappingProfile());
           // });
 

           //  IMapper mapper = mappingConfig.CreateMapper();
           // services.AddSingleton(mapper);

            //Setup para Swagger
            SwaggerSetup.AddSwaggerSetup(services);

            //Setup para AutoMapper
            AutoMapperSetup.AddAutoMapperSetup(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogInformation("######################################################################################");
            logger.LogInformation("#### Executando o método Configure() ####" + DateTime.Now.ToLongDateString());
            logger.LogInformation("######################################################################################");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            SwaggerSetup.UseSwaggerSetup(app);
        }
    }
}
