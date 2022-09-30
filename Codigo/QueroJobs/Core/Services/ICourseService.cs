namespace Core.Services;

public interface ICourseService
{
    Task<int> Create(Course course);
    Task Edit(Course course);
    Task Delete(int idCourse);
    Task<Course> Get(int idCourse);
    Task<IEnumerable<Course>> GetAll();
    Task UpdateCourseNameById(int id, string courseName);
}
