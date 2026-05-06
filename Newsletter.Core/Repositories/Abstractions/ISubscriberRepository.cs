using Newsletter.Core.Models;

namespace Newsletter.Core.Repositories.Abstractions;

public interface ISubscriberRepository
{
    Task<IEnumerable<Subscriber>> GetAllAsync(
        CancellationToken cancellationToken);
}