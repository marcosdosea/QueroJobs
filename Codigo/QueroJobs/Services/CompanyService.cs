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
    public int Create(Company company)
    {
        _queroJobsContext.Add(company);
        _queroJobsContext.SaveChanges();
        return company.Id;
    }

    public void Delete(int idCompany)
    {
        throw new NotImplementedException();
    }

    public void Edit(Company company)
    {
        throw new NotImplementedException();
    }

    public Company Get(int idCompany)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Company> GetAll()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Candidate> GetAllInterestedsCandidates()
    {
        throw new NotImplementedException();
    }
}
