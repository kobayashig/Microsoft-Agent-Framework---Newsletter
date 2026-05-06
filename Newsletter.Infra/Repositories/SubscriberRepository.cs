using Newsletter.Core.Models;
using Newsletter.Core.Repositories.Abstractions;

namespace Newsletter.Infra.Repositories;

public class SubscriberRepository : ISubscriberRepository
{
    public async Task<IEnumerable<Subscriber>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        await Task.Delay(100, cancellationToken);

        return
        [
            new Subscriber("Andre Baltieri", "hello@balta.io"),
            new Subscriber("Gemini AI", "gemini@example.com"),
            new Subscriber("DotNet User", "user@dotnet.com"),
            new Subscriber("Software Architect", "arch@dev.com"),
            new Subscriber("Clean Code Fan", "bob@uncle.com")
        ];
    }
}