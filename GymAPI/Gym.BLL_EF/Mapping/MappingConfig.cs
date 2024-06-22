using AutoMapper;
using Gym.BLL.Dto.Classes;
using Gym.BLL.Dto.Club;
using Gym.BLL.Dto.ClubTicketType;
using Gym.BLL.Dto.Reservation;
using Gym.BLL.Dto.Ticket;
using Gym.BLL.Dto.TicketType;
using Gym.BLL.Dto.UserPayment;
using Gym.Model.Models;

namespace Gym.BLL_EF.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ClassResponseDto, Class>().ReverseMap();
            CreateMap<ClassRequestDto, Class>().ReverseMap();

            CreateMap<ClubResponseDto, Club>().ReverseMap();
            CreateMap<ClubRequestDto, Club>().ReverseMap();

            CreateMap<ClubTicketTypeResponseDto, ClubTicketType>().ReverseMap();
            CreateMap<ClubTicketTypeRequestDto, ClubTicketType>().ReverseMap();

            CreateMap<ReservationResponseDto, Reservation>().ReverseMap();
            CreateMap<ReservationRequestDto, Reservation>().ReverseMap();

            CreateMap<TicketResponseDto, Ticket>().ReverseMap();
            CreateMap<TicketRequestDto, Ticket>().ReverseMap();

            CreateMap<TicketTypeResponseDto, TicketType>().ReverseMap();
            CreateMap<TicketTypeRequestDto, TicketType>().ReverseMap();

            CreateMap<UserPaymentResponseDto, UserPayment>().ReverseMap();
            CreateMap<UserPaymentRequestDto, UserPayment>().ReverseMap();
        }
    }
}
