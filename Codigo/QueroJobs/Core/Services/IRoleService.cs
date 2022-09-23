namespace Core.Services;
public interface IRoleService
{
    Task<int> Create(Role role);
    Task Edit(Role role);
    Task Delete(int idRole);
    Task<Role> Get(int idRole);
    Task<IEnumerable<Role>> GetAll();
}
