using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApi.BookStore.Business.Common;
using WebApi.BookStore.Business.Operations.BookOperations.Commands;
using WebApi.BookStore.Business.Operations.GenreOperations.Commands;
using WebApi.BookStore.Business.Operations.GenreOperations.Queries;
using WebApi.BookStore.Business.Operations.Validators.GenreValidator.Commands;
using WebApi.BookStore.Business.Operations.Validators.GenreValidator.Queries;
using WebApi.BookStore.Business.Services;
using WebApi.BookStore.Business.Validators.BookValidator.Commands;
using WebApi.BookStore.Data.Context;

namespace pa_product_api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi.BookStore API", Version = "v1" });
            });
            
            services.AddDbContext<BookStoreDbContext>(options => options.UseInMemoryDatabase(databaseName: "BookStoreDB"));
            services.AddScoped<IBookStoreDbContext>(provider => provider.GetService<BookStoreDbContext>());
            services.AddSingleton<ILoggerService, ConsoleLogger>();
            services.AddAutoMapper(typeof(MappingProfile));
            
            //CreateBookCommand Fluent Validation
            /*services.AddScoped<IValidator<CreateBookCommand>, CreateBookCommandValidator>();
            services.AddScoped<IValidator<GetGenreDetailQuery>, GetGenreDetailQueryValidator>();
            services.AddScoped<IValidator<CreateGenreCommand>, CreateGenreCommandValidator>();*/
            services.AddValidatorsFromAssemblyContaining<CreateGenreCommandValidator>();

            

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "pa-product-api API v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}