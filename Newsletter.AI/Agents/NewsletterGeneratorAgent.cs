using System.Text.Json;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newsletter.AI.Models;
using Newsletter.AI.Providers.Abstractions;
using Newsletter.Core;
using Newsletter.Core.Agents.Abstractions;
using Newsletter.Core.Enums;
using Newsletter.Core.Models;
using OpenAI.Chat;

namespace Newsletter.AI.Agents;

public class NewsletterGeneratorAgent(
    ILogger<NewsletterGeneratorAgent> logger,
    [FromKeyedServices(PromptProvider.File)]
    IPromptProvider promptProvider) : IAgent<IEnumerable<Article>, string>
{
    private const string AgentName = "NewsletterGeneratorAgent";
    private const string Prompt = "Gere um conteúdo para newsletter com base neste JSON: ";
    private const float Temperature = 0.7f;
    
    public async Task<string> RunAsync(
        IEnumerable<Article> data, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Gerando o conteúdo da newsletter...");

        var client = new OpenAI.OpenAIClient(Configuration.OpenAi.ApiKey);
        var instructions = await promptProvider
            .GetPromptAsync(AgentName, cancellationToken);

        var agent = client
            .GetChatClient(AIModels.Gpt4OMini)
            .AsAIAgent(new ChatClientAgentOptions
            {
                Name = AgentName,
                Description = "Agente especialista em gerar conteúdo para newsletter via e-mail",
                ChatOptions = new ChatOptions
                {
                    ModelId = AIModels.Gpt4OMini,
                    Temperature = Temperature,
                    Instructions = instructions
                }
            });

        var prompt = $"{Prompt} {JsonSerializer.Serialize(data)}";
        var response = await agent.RunAsync<string>(prompt, cancellationToken: cancellationToken);
        
        logger.LogInformation("Newsletter gerada...");
        logger.LogInformation(response.Result);
        
        return response.Result;
    }
}