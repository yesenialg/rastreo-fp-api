using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RastreoFirplak.Application.Contracts.Infrastructure;
using RastreoFirplak.Application.Contracts.Persistence;
using RastreoFirplak.Application.Models;
using RastreoFirplak.Infrastructure.Email;
using RastreoFirplak.Infrastructure.Persistence;
using RastreoFirplak.Infrastructure.Repositories;

namespace RastreoFirplak.Infrastructure
{
    public static class InfrastructureServiceRegistratiob
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EnviosDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IGuiaRepository, GuiaRepository>();

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
