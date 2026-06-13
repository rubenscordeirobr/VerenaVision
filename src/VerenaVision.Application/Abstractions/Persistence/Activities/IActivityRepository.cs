using VerenaVision.Domain.Entities.Activities;

namespace VerenaVision.Application.Abstractions.Persistence.Activities;
public interface IActivityRepository
{
    Task<IEnumerable<ActivityBase>> GetAllAsync();
    Task<ActivityBase?> GetByIdAsync(string id);
    Task AddAsync(ActivityBase activity);
    Task DeleteAsync(string id);
}
