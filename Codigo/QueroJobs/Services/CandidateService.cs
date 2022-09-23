using Core;
using Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class CandidateService : ICandidateService
{
    private readonly QueroJobsContext _queroJobsContext;
    public CandidateService(QueroJobsContext queroJobsContext)
    {
        _queroJobsContext = queroJobsContext;
    }

    public async Task<int> Create(Candidate candidate)
    {
        await _queroJobsContext.AddAsync(candidate);
        await _queroJobsContext.SaveChangesAsync();
        return candidate.Id;
    }

    public async Task Delete(int idCandidate)
    {
        var candidate = await _queroJobsContext.Candidates.
            FirstOrDefaultAsync(c => c.Id == idCandidate);

        if (candidate == null) return;

        _queroJobsContext.Remove(candidate);
        await _queroJobsContext.SaveChangesAsync();
    }

    public async Task Edit(Candidate candidate)
    {
        _queroJobsContext.Update(candidate);

        await _queroJobsContext.SaveChangesAsync();
    }

    public async Task<Candidate> Get(int idCandidate)
    {
        return await _queroJobsContext.Candidates.FirstOrDefaultAsync(c => c.Id == idCandidate);
    }

    public async Task<IEnumerable<Candidate>> GetAll()
    {
        return await _queroJobsContext.Candidates.Select(c => c).ToListAsync();
    }
}
