using Gym.BLL.IRepositories;
using Gym.BLL.IServices;
using Gym.BLL_EF.Repositories;
using Gym.BLL_EF.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Security.Claims;

namespace Gym.BLL_EF
{
    public static class BLLServices
    {
        public static IServiceCollection AddBLL(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ClaimsPrincipal>(s => s.GetService<IHttpContextAccessor>().HttpContext.User);

            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IClubRepository, ClubRepository>();
            services.AddScoped<IClubTicketTypeRepository, ClubTicketTypeRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
            services.AddScoped<IUserPaymentRepository, UserPaymentRepository>();


            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IClubService, ClubService>();
            services.AddScoped<IClubTicketTypeService, ClubTicketTypeService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ITicketTypeService, TicketTypeService>();
            services.AddScoped<IUserPaymentService, UserPaymentService>();
            services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(assembly);

            return services;
        }
    }
}
