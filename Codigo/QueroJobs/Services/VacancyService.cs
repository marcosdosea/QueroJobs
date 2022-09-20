using Core;
using Core.Services;

namespace Services;

public class VacancyService : IVacancyService
{
    private readonly QueroJobsContext _queroJobsContext;
    public VacancyService(QueroJobsContext queroJobsContext)
    {
        _queroJobsContext = queroJobsContext;
    }
    /// <summary>
    /// Cria uma vaga
    /// </summary>
    /// <param name="vacancy"></param>
    /// <returns></returns>
    public int Create(Vacancy vacancy)
    {
        _queroJobsContext.Add(vacancy);
        _queroJobsContext.SaveChanges();
        return vacancy.Id;
    }

    public void Delete(int idVacancy)
    {
        throw new NotImplementedException();
    }

    public void Edit(Vacancy vacancy)
    {
        throw new NotImplementedException();
    }

    public Vacancy Get(int idVacancy)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Vacancy> GetAll()
    {
        throw new NotImplementedException();
    }
}
