using BackendLeads.DTO;
using AutoMapper;
using BackendLeads.Models;

namespace BackendLeads.Profiles
{
    public class GestorProfile : Profile
    {
        public GestorProfile()
        {
            CreateMap<GestorDto,Gestor >();
            CreateMap<Leads, LeadsDto>();
            CreateMap<LeadsAtualizarDto, Leads>();


        }
    }
}
