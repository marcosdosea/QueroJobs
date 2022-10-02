using AutoMapper;
using Core;
using QueroJobsWEB.Models;

namespace QueroJobsWEB.Mappers;
public class CompetenceProfile : Profile
{
    public CompetenceProfile()
    {
        CreateMap<CompetenceModel, Competence>().ReverseMap();
    }
}
