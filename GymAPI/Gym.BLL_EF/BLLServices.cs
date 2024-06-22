using Gym.BLL.IRepositories;
using Gym.BLL.IServices;
using Gym.BLL_EF.Repositories;
using Gym.BLL_EF.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Gym.BLL_EF
{
    public static class BLLServices
    {
        public static IServiceCollection AddBLL(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

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

            services.AddAutoMapper(assembly);

            return services;
        }
    }
}
