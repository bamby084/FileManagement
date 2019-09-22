using System;
using System.Text;
using System.Threading.Tasks;
using FileManagement.DataAccess;
using FileManagement.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FileManagement.Infrastructure
{
    public static class IoC
    {
        public static void AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:SqlServerConnectionString"]);
            });

            services.Configure<AppSettings>(options => configuration.GetSection("AppSettings").Bind(options));
            string secretKey = configuration.GetSection("AppSettings")["Secret"];
            byte[] key = Encoding.ASCII.GetBytes(secretKey);

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                });

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<DbContext, DatabaseContext>();
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
