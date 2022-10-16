namespace Core.Services;

public interface IScholarityService
{
    Task<int> Create(Scholarity scholarity);
    Task Edit(Scholarity scholarity);
    Task Delete(int idScholarity);
    Task<Scholarity> Get(int idScholarity);
    Task<IEnumerable<Scholarity>> GetAll();
}
