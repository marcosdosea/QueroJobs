using Core;
using Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class CompetenceService : ICompetenceService
{
    private readonly QueroJobsContext _queroJobsContext;

    public CompetenceService(QueroJobsContext queroJobsContext)
    {
        _queroJobsContext = queroJobsContext;
    }

    public async Task<int> Create(Competence competence)
    {
        await _queroJobsContext.AddAsync(competence);
        await _queroJobsContext.SaveChangesAsync();
        return competence.Id;
    }

    public async Task Delete(int idCompetence)
    {
        var competence = await _queroJobsContext.Roles.FirstOrDefaultAsync(c => c.Id == idCompetence);

        if (competence == null) return;

        _queroJobsContext.Remove(competence);
        await _queroJobsContext.SaveChangesAsync();
    }

    public async Task Edit(Competence competence)
    {
        _queroJobsContext.Update(competence);
        await _queroJobsContext.SaveChangesAsync();
    }

    public async Task<Competence> Get(int idCompetence)
    {
        return await _queroJobsContext.Competences.FirstOrDefaultAsync(c => c.Id == idCompetence);
    }

    public async Task<IEnumerable<Competence>> GetAll()
    {
        return await _queroJobsContext.Competences.ToListAsync();
    }
}
