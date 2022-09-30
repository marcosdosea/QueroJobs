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
    /// <param ///name="vacancy"></param>
    /// <returns></returns>
    public int Create(Vacancy vacancy)
    {
        _queroJobsContext.Add(vacancy);
        _queroJobsContext.SaveChanges();
        return vacancy.Id;
    }

    public void Delete(int idVacancy)
    {
        var vacancy = await _queroJobsContext.Vacancy.
            FirstOrDefaultAsync(c => c.Id == idVacancy);

        if (vacancy == null) return;

        _queroJobsContext.Remove(vacancy);
        await _queroJobsContext.SaveChangesAsync();
    }

    public void Edit(Vacancy vacancy)
    {
        _queroJobsContext.Update(vacancy);

        await _queroJobsContext.SaveChangesAsync();
    }

    public Vacancy Get(int idVacancy)
    {
        return await _queroJobsContext.Vacancies.FirstOrDefaultAsync(c => c.Id == idVacancy);
    }

    public IEnumerable<Vacancy> GetAll()
    {
        return await _queroJobsContext.Vacancies .Select(c => c).ToListAsync();
    }
}
