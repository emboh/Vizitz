using AutoMapper;
using Vizitz.Entities;
using Vizitz.Models;
using Vizitz.Models.Account;

namespace Vizitz.Data
{
    public class MapInitializer : Profile
    {
        public MapInitializer()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<UserRole, UserRoleDTO>().ReverseMap();

            CreateMap<User, RegisterDTO>().ReverseMap();

            CreateMap<User, AdminDTO>().ReverseMap();
            CreateMap<User, CreateAdminDTO>().ReverseMap();

            CreateMap<User, ProprietorDTO>().ReverseMap();
            CreateMap<User, CreateProprietorDTO>().ReverseMap();
            CreateMap<User, UpdateProprietorDTO>().ReverseMap();

            CreateMap<User, VisitorDTO>().ReverseMap();
            CreateMap<User, CreateVisitorDTO>().ReverseMap();
            CreateMap<User, UpdateVisitorDTO>().ReverseMap();

            CreateMap<Venue, VenueDTO>().ReverseMap();
            CreateMap<Venue, CreateVenueDTO>().ReverseMap();
            CreateMap<Venue, UpdateVenueDTO>().ReverseMap();

            CreateMap<Schedule, ScheduleDTO>().ReverseMap();
            CreateMap<Schedule, CreateScheduleDTO>().ReverseMap();

            CreateMap<Visit, VisitDTO>().ReverseMap();
            CreateMap<Visit, CreateVisitDTO>().ReverseMap();
        }
    }
}
