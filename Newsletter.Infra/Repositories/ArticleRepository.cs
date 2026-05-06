using Newsletter.Core.Models;
using Newsletter.Core.Repositories.Abstractions;

namespace Newsletter.Infra.Repositories;

public class ArticleRepository : IArticleRepository
{
    public async Task<IEnumerable<Article>> GetFromLastWeekAsync(
        CancellationToken cancellationToken)
    {
        await Task.Delay(150, cancellationToken);

        return
        [
            new Article(
                "Dapper: Mapeando consultas complexas",
                "https://blog.balta.io/dapper-mapeando-consultas-complexas/",
                "Learn how to map complex queries using Dapper in .NET...",
                DateTime.Now.AddDays(-1)
            ),
            new Article(
                "FluentValidation: Validando seus domínios",
                "https://blog.balta.io/fluent-validation/",
                "A deep dive into domain validation with FluentValidation...",
                DateTime.Now.AddDays(-2)
            ),
            new Article(
                "Entity Framework: Performance com AsNoTracking",
                "https://blog.balta.io/ef-performance/",
                "Boost your EF Core performance using the AsNoTracking method...",
                DateTime.Now.AddDays(-3)
            ),
            new Article(
                "Minimal APIs: Quando utilizar?",
                "https://blog.balta.io/minimal-apis-quando-utilizar/",
                "Discover the best scenarios to implement Minimal APIs in .NET 8...",
                DateTime.Now.AddDays(-4)
            ),
            new Article(
                "C# 12: Novidades do Collection Expressions",
                "https://blog.balta.io/csharp-12-collection-expressions/",
                "The new way to initialize collections in C# 12 is here...",
                DateTime.Now.AddDays(-5)
            )
        ];
    }
}