namespace Core.Services;

public interface ICompanyService
{
    int Create(Company company);
    void Edit(Company company);
    void Delete(int idCompany);
    Company Get(int idCompany);
    IEnumerable<Company> GetAll();
    IEnumerable<Candidate> GetAllInterestedsCandidates();
}
