namespace Core.Services;

public interface ICandidateService
{
    Task<int> Create(Candidate candidate);
    Task Edit(Candidate candidate);
    Task Delete(int idCandidate);
    Task<Candidate> Get(int idCandidate);
    Task<IEnumerable<Candidate>> GetAll();
}
