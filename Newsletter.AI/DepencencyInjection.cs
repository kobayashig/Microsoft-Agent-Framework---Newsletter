using Microsoft.Extensions.DependencyInjection;
using Newsletter.AI.Agents;
using Newsletter.AI.Providers;
using Newsletter.AI.Providers.Abstractions;
using Newsletter.Core.Agents.Abstractions;
using Newsletter.Core.Enums;
using Newsletter.Core.Models;

namespace Newsletter.AI;

public static class DepencencyInjection
{
    public static IServiceCollection AddAgents(this IServiceCollection services)
    {
        services.AddKeyedTransient<IAgent<IEnumerable<Article>, string>, TitleGeneratorAgent>(AgentType.TitleGenerator);
        services.AddKeyedTransient<IAgent<IEnumerable<Article>, string>, NewsletterGeneratorAgent>(AgentType.NewsletterGenerator);

        services.AddKeyedTransient<IPromptProvider, FilePromptProvider>(PromptProvider.File);
        
        return services;
    }
}