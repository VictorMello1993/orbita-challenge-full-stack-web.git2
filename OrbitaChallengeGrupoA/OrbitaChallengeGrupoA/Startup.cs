using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OrbitaChallengeGrupoA.Application.Commands.CreateUser;
using OrbitaChallengeGrupoA.Domain.Repositories;
using OrbitaChallengeGrupoA.Filters;
using OrbitaChallengeGrupoA.Infrastructure.Persistence;
using OrbitaChallengeGrupoA.Infrastructure.Persistence.Repositories;

namespace OrbitaChallengeGrupoA
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

            services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommand>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrbitaChallengeGrupoA", Version = "v1" });
            });

            var connectionString = Configuration.GetConnectionString("OrbitaChallengeGrupoAConnection");

            services.AddDbContext<OrbitaChallengeGrupoADbContext>(options => options.UseMySQL(connectionString));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddMediatR(typeof(CreateUserCommand));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error");
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrbitaChallengeGrupoA v1"));                
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
