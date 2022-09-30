namespace Core.Services;

public interface IVacancyService
{
    Task<int> Create(Vacancy vacancy);
    Task Edit(Vacancy vacancy);
    Task Delete(int idVacancy);
    Task<Vacancy> Get(int idVacancy);
    Task<IEnumerable<Vacancy>> GetAll();
}
