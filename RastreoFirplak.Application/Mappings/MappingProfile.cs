using AutoMapper;
using RastreoFirplak.Application.Features.Guias.Commands.UpdateGuia;
using RastreoFirplak.Application.Features.Guias.Queries;
using RastreoFirplak.Domain;

namespace RastreoFirplak.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Guia, GuiaModel>();
            CreateMap<UpdateGuiaCommand, Guia> ();
        }
    }
}
