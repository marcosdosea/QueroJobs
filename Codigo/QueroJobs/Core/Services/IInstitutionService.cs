namespace Core.Services;

public interface IInstitutionService
{
    Task<int> Create(Institution institution);
    Task Edit(Institution institution);
    Task Delete(int idInstitution);
    Task<Institution> Get(int idInstitution);
    Task<IEnumerable<Institution>> GetAll();
}
