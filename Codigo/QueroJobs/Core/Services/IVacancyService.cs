namespace Core.Services;

public interface IVacancyService
{
    int Create(Vacancy vacancy);
    void Edit(Vacancy vacancy);
    void Delete(int idVacancy);
    Vacancy Get(int idVacancy);
    IEnumerable<Vacancy> GetAll();
}
