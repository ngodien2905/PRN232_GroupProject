using Application.Interfaces;
using Application.Interfaces.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Config
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration cfg)
        {
            var authConn = cfg.GetConnectionString("AuthDatabase") ?? throw new System.Exception("AuthDatabase missing");
            var contentConn = cfg.GetConnectionString("ContentDatabase") ?? throw new System.Exception("ContentDatabase missing");
            var examConn = cfg.GetConnectionString("ExamDatabase") ?? throw new System.Exception("ExamDatabase missing");
            var aiConn = cfg.GetConnectionString("AiDatabase") ?? throw new System.Exception("AiDatabase missing");

            services.AddDbContext<AuthDbContext>(o =>
                o.UseSqlServer(authConn, sql => sql.EnableRetryOnFailure())
            );
            services.AddDbContext<ContentDbContext>(o =>
                o.UseSqlServer(contentConn, sql => sql.EnableRetryOnFailure())
            );
            services.AddDbContext<ExamDbContext>(o =>
                o.UseSqlServer(examConn, sql => sql.EnableRetryOnFailure())
            );
            services.AddDbContext<AiDbContext>(o =>
                o.UseSqlServer(aiConn, sql => sql.EnableRetryOnFailure())
            );

            services.AddScoped<IAuthUnitOfWork, AuthUnitOfWork>();
            services.AddScoped<IContentUnitOfWork, ContentUnitOfWork>();
            services.AddScoped<IExamUnitOfWork, ExamUnitOfWork>();
            services.AddScoped<IAiUnitOfWork, AiUnitOfWork>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStudentService, StudentService>();

            services.AddHttpClient();

            return services;
        }
    }
}
