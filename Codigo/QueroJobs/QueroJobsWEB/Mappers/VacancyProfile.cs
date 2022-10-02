using QueroJobsWEB.Models;
using Core;
using AutoMapper;

namespace QueroJobsWEB.Mappers;

public class VacancyProfile : Profile
{
    public VacancyProfile()
    {
        CreateMap<VacancyModel, Vacancy>().ReverseMap();
    }
}
