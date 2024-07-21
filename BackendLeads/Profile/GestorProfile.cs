using BackendLeads.DTO;
using AutoMapper;
using BackendLeads.Models;

namespace BackendLeads.Profiles
{
    public class GestorProfile : Profile
    {
        public GestorProfile()
        {
            CreateMap<Gestor, GestorDto>();
            CreateMap<Leads, LeadsDto>();
            CreateMap<LeadsAtualizarDto, Leads>();


        }
    }
}
