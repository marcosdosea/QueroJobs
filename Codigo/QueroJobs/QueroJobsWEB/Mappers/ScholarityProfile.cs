using AutoMapper;
using Core;
using QueroJobsWEB.Models;

namespace QueroJobsWEB.Mappers;

public class ScholarityProfile : Profile
{
    public ScholarityProfile()
    {
        CreateMap<ScholarityModel, Scholarity>().ReverseMap();
    }
}
