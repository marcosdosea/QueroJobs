using Core;
using Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class InstitutionService : IInstitutionService
{
    private readonly QueroJobsContext _queroJobsContext;

    public InstitutionService(QueroJobsContext queroJobsContext)
    {
        _queroJobsContext = queroJobsContext;
    }

    public async Task<int> Create(Institution institution)
    {
        await _queroJobsContext.AddAsync(institution);
        await _queroJobsContext.SaveChangesAsync();
        return institution.Id;
    }

    public async Task Delete(int idInstitution)
    {
        var institution = await _queroJobsContext.Institutions.FirstOrDefaultAsync(i => i.Id == idInstitution);

        if (institution == null) return;

        _queroJobsContext.Remove(institution);
        await _queroJobsContext.SaveChangesAsync();

    }

    public async Task Edit(Institution institution)
    {
        _queroJobsContext.Update(institution);
        await _queroJobsContext.SaveChangesAsync();
    }

    public async Task<Institution> Get(int idInstitution)
    {
        return await _queroJobsContext.Institutions.FirstOrDefaultAsync(i => i.Id == idInstitution);
    }

    public async Task<IEnumerable<Institution>> GetAll()
    {
        return await _queroJobsContext.Institutions.ToListAsync();
    }
}
