using Core;
using Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class CompanyService : ICompanyService
{
    private readonly QueroJobsContext _queroJobsContext;

    public CompanyService(QueroJobsContext queroJobsContext)
    {
        _queroJobsContext = queroJobsContext;
    }
    public async Task<int> Create(Company company)
    {
        await _queroJobsContext.AddAsync(company);
        await _queroJobsContext.SaveChangesAsync();
        return company.Id;
    }

    public async Task Delete(int idCompany)
    {
        var company = await _queroJobsContext.Companies.
            FirstOrDefaultAsync(c => c.Id == idCompany);

        if (company == null) return;

        _queroJobsContext.Remove(company);
        await _queroJobsContext.SaveChangesAsync();

    }

    public async Task Edit(Company company)
    {
        _queroJobsContext.Update(company);

        await _queroJobsContext.SaveChangesAsync();
    }

    public async Task<Company> Get(int idCompany)
    {
        return await _queroJobsContext.Companies.FirstOrDefaultAsync(c => c.Id == idCompany);
    }

    public async Task<IEnumerable<Company>> GetAll()
    {
        return await _queroJobsContext.Companies.ToListAsync();
    }

    public Task<IEnumerable<Candidate>> GetAllInterestedsCandidates()
    {
        throw new NotImplementedException(); //TODO Voltar para implementar esse método!
    }

    public async Task UpdateCompanyNameById(int id, string corporateName)
    {
        var company = await _queroJobsContext.Companies.FirstOrDefaultAsync(c => c.Id == id);

        if (company == null) return;

        company.CorporateName = corporateName;

        await _queroJobsContext.SaveChangesAsync();
    }
}
