using Core;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class ScholarityService
{
    private readonly QueroJobsContext _queroJobsContext;

    public ScholarityService(QueroJobsContext queroJobsContext)
    {
        _queroJobsContext = queroJobsContext;
    }

    public async Task<int> Create(Scholarity scholarity)
    {
        await _queroJobsContext.AddAsync(scholarity);
        await _queroJobsContext.SaveChangesAsync();
        return scholarity.Id;
    }

    public async Task Delete(int idScholarity)
    {
        var scholarity = await _queroJobsContext.Scholarities.FirstOrDefaultAsync(r => r.Id == idScholarity);

        if (scholarity == null) return;

        _queroJobsContext.Remove(scholarity);
        await _queroJobsContext.SaveChangesAsync();
    }

    public async Task Edit(Scholarity scholarity)
    {
        _queroJobsContext.Update(scholarity);
        await _queroJobsContext.SaveChangesAsync();
    }

    public async Task<Scholarity> Get(int idScholarity)
    {
        return await _queroJobsContext.Scholarities.FirstOrDefaultAsync(r => r.Id == idScholarity);
    }

    public async Task<IEnumerable<Scholarity>> GetAll()
    {
        return await _queroJobsContext.Scholarities.ToListAsync();
    }
}
