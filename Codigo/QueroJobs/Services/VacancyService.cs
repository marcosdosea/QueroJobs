using Core;
using Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class VacancyService : IVacancyService
{
    private readonly QueroJobsContext _queroJobsContext;
    public VacancyService(QueroJobsContext queroJobsContext)
    {
        _queroJobsContext = queroJobsContext;
    }
    public async Task<int> Create(Vacancy vacancy)
    {
        await _queroJobsContext.AddAsync(vacancy);
        await _queroJobsContext.SaveChangesAsync();
        return vacancy.Id;
    }
    public async Task Delete(int idVacancy)
    {
        var vacancy = await _queroJobsContext.Vacancies.
            FirstOrDefaultAsync(v => v.Id == idVacancy);

        if (vacancy == null) return;

        _queroJobsContext.Remove(vacancy);
        await _queroJobsContext.SaveChangesAsync();
    }

    public async Task Edit(Vacancy vacancy)
    {
        _queroJobsContext.Update(vacancy);

        await _queroJobsContext.SaveChangesAsync();
    }

    public async Task<Vacancy> Get(int idVacancy)
    {
        return await _queroJobsContext.Vacancies.FirstOrDefaultAsync(v => v.Id == idVacancy);
    }

    public async Task<IEnumerable<Vacancy>> GetAll()
    {
        return await _queroJobsContext.Vacancies.Select(v => v).ToListAsync();
    }

    public Task<IEnumerable<Candidate>> GetAllInterestedsCandidates()
    {
        throw new NotImplementedException(); //TODO Voltar para implementar esse método!
    }
}
