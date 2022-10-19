using AutoMapper;
using Core;
using QueroJobsWEB.Models;

namespace QueroJobsWEB.Mappers;

public class InstitutionProfile : Profile
{
    public InstitutionProfile()
    {
        CreateMap<InstitutionModel, Institution>().ReverseMap();
    }
}
