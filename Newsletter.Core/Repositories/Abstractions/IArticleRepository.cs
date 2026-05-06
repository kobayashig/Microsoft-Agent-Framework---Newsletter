using Newsletter.Core.Models;

namespace Newsletter.Core.Repositories.Abstractions;

public interface IArticleRepository
{
    Task<IEnumerable<Article>> GetFromLastWeekAsync(
        CancellationToken cancellationToken);
}