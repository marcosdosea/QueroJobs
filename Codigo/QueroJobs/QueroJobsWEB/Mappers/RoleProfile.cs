using AutoMapper;
using Core;
using QueroJobsWEB.Models;

namespace QueroJobsWEB.Mappers;
public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<RoleModel, Role>().ReverseMap();
    }
}