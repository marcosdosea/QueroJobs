namespace Core.Services;

public interface ICompetenceService
{
    Task<int> Create(Competence competence);
    Task Edit(Competence competence);
    Task Delete(int idCompetence);
    Task<Competence> Get(int idCompetence);
    Task<IEnumerable<Competence>> GetAll();
}
