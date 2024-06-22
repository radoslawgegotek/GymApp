using Gym.DAL.Context;
using Gym.Model.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Gym.DAL
{
    public static class DALServices
    {
        public static IServiceCollection AddDAL(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<GymDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddAuthorization();
            services.AddAuthentication(IdentityConstants.ApplicationScheme)
                .AddBearerToken(IdentityConstants.BearerScheme);
            services.AddAuthorizationBuilder();

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                //Identity config
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.Lockout.AllowedForNewUsers = false;

                //Passwords config
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<GymDbContext>()
            .AddDefaultTokenProviders()
            .AddApiEndpoints();

            return services;
        }
    }
}
