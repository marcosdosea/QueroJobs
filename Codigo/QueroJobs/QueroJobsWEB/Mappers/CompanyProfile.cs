using AutoMapper;
using Core;
using QueroJobsWEB.Models;

namespace QueroJobsWEB.Mappers;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<CompanyModel, Company>().ReverseMap();
    }
}
