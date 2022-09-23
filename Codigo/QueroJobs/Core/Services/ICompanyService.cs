namespace Core.Services;

public interface ICompanyService
{
    Task<int> Create(Company company);
    Task Edit(Company company);
    Task Delete(int idCompany);
    Task<Company> Get(int idCompany);
    Task<IEnumerable<Company>> GetAll();
    Task<IEnumerable<Candidate>> GetAllInterestedsCandidates();
    Task UpdateCompanyNameById(int id, string corporateName);
}
