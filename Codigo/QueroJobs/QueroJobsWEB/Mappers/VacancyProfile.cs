using AutoMapper;
using Core;
using QueroJobsWEB.Models;

namespace QueroJobsWEB.Mappers;

public class VacancyProfile : Profile
{
    public VacancyProfile()
    {
        CreateMap<VacancyModel, Vacancy>().ReverseMap();
    }
}
