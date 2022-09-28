using AutoMapper;
using Core;
using QueroJobsWEB.Models;

namespace QueroJobsWEB.Mappers;

public class CandidateProfile : Profile
{
    public CandidateProfile()
    {
        CreateMap<CandidateModel, Candidate>().ReverseMap();
    }
}
