using Core;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CourseService : ICourseService
    {
        private readonly QueroJobsContext _queroJobsContext;

        public CourseService(QueroJobsContext queroJobsContext)
        {
            _queroJobsContext = queroJobsContext;
        }

        public async Task<int> Create(Course course)
        {
            await _queroJobsContext.AddAsync(course);
            await _queroJobsContext.SaveChangesAsync();
            return course.Id;
        }

        public async Task Delete(int idCourse)
        {
            var course = await _queroJobsContext.Companies.FirstOrDefaultAsync(c => c.Id == idCourse);

            if (course == null) return;

            _queroJobsContext.Remove(course);
            await _queroJobsContext.SaveChangesAsync();

        }

        public async Task Edit(Course course)
        {
            _queroJobsContext.Update(course);

            await _queroJobsContext.SaveChangesAsync();
        }

        public async Task<Course> Get(int idCourse)
        {
            return await _queroJobsContext.Courses.FirstOrDefaultAsync(c => c.Id == idCourse);
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _queroJobsContext.Courses.ToListAsync();
        }

        public async Task UpdateCourseNameById(int id, string courseName)
        {
            var course = await _queroJobsContext.Courses.FirstOrDefaultAsync(c => c.Id == id);

            if (course == null) return;

            course.CourseName = courseName;

            await _queroJobsContext.SaveChangesAsync();
        }
    }
}
