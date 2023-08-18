using DepartamentosAPI.Data;
using EvoSystems.Domain.Repositories;
using EvoSystems.Infra.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DepartamentosAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddDbContext<Contexto>(opcoes => opcoes.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            var domainAssembly = AppDomain.CurrentDomain.Load("EvoSystems.Domain");
            var infraAssembly = AppDomain.CurrentDomain.Load("EvoSystems.Infra");
            
            services.AddMediatR(domainAssembly,infraAssembly);

            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();

            services.AddEndpointsApiExplorer();

            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", builder =>
                {
                    builder.WithOrigins("https://localhost:4200", "http://localhost:4200");
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                    builder.AllowCredentials();
                });
            });

            services.AddSwaggerGen();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("MyPolicy");

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
