﻿using AutoMapper;
using Vizitz.Entities;
using Vizitz.Models;

namespace Vizitz.Data
{
    public class MapInitializer : Profile
    {
        public MapInitializer()
        {
            CreateMap<User, AdminDTO>().ReverseMap();
            CreateMap<User, CreateAdminDTO>().ReverseMap();

            CreateMap<User, ProprietorDTO>().ReverseMap();
            CreateMap<User, UpdateProprietorDTO>().ReverseMap();

            CreateMap<User, VisitorDTO>().ReverseMap();
            CreateMap<User, UpdateVisitorDTO>().ReverseMap();

            CreateMap<Venue, VenueDTO>().ReverseMap();
            CreateMap<Venue, CreateVenueDTO>().ReverseMap();

            CreateMap<Schedule, ScheduleDTO>().ReverseMap();
            CreateMap<Schedule, CreateScheduleDTO>().ReverseMap();

            CreateMap<Visit, VisitDTO>().ReverseMap();
            CreateMap<Visit, CreateVisitDTO>().ReverseMap();
        }
    }
}
