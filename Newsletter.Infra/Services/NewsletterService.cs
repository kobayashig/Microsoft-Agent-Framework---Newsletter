using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newsletter.Core.Agents.Abstractions;
using Newsletter.Core.Enums;
using Newsletter.Core.Models;
using Newsletter.Core.Repositories.Abstractions;
using Newsletter.Core.Services.Abstractions;
using Newsletter.Infra.Repositories;

namespace Newsletter.Infra.Services;

public class NewsletterService(
    ILogger<NewsletterService> logger,
    IArticleRepository articleRepository,
    
    [FromKeyedServices(AgentType.TitleGenerator)]
    IAgent<IEnumerable<Article>, string> titleGeneratorAgent,
    
    [FromKeyedServices(AgentType.NewsletterGenerator)]
    IAgent<IEnumerable<Article>, string> newsletterGerenatorAgent) : INewsletterService
{
    public async Task SendAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Recuperando os post da semana...");
        var posts = await articleRepository.GetFromLastWeekAsync(cancellationToken);
        if (!posts.Any())
            return;
        
        logger.LogInformation("Gerando titulo da newsletter...");
        var subject = await titleGeneratorAgent.RunAsync(posts, cancellationToken);

        logger.LogInformation("Gerando o conteúdo da newsletter...");
        var body = await newsletterGerenatorAgent.RunAsync(posts, cancellationToken);
        
        
    }
}