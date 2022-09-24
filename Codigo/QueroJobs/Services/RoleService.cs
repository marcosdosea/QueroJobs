using Core;
using Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class RoleService : IRoleService
{
    private readonly QueroJobsContext _queroJobsContext;

    public RoleService(QueroJobsContext queroJobsContext)
    {
        _queroJobsContext = queroJobsContext;
    }

    public async Task<int> Create(Role role)
    {
        await _queroJobsContext.AddAsync(role);
        await _queroJobsContext.SaveChangesAsync();
        return role.Id;
    }

    public async Task Delete(int idRole)
    {
        var role = await _queroJobsContext.Roles.FirstOrDefaultAsync(r => r.Id == idRole);

        if (role == null) return;

        _queroJobsContext.Remove(role);
        await _queroJobsContext.SaveChangesAsync();
    }

    public async Task Edit(Role role)
    {
        _queroJobsContext.Update(role);
        await _queroJobsContext.SaveChangesAsync();
    }

    public async Task<Role> Get(int idRole)
    {
        return await _queroJobsContext.Roles.FirstOrDefaultAsync(r => r.Id == idRole);
    }

    public async Task<IEnumerable<Role>> GetAll()
    {
        return await _queroJobsContext.Roles.ToListAsync();
    }
}
