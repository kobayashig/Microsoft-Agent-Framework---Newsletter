namespace Newsletter.Core.Services.Abstractions;

public interface INewsletterService
{
    Task SendAsync(
        CancellationToken cancellationToken);
}