using AutoMapper;
using Core;
using QueroJobsWEB.Models;

namespace QueroJobsWEB.Mappers
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseModel, Course>().ReverseMap();
        }


    }
}
