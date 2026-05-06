namespace Newsletter.Core.Services.Abstractions;

public interface IEmailService
{
    Task SendAsync(
        string toName,
        string toEmail,
        string subject,
        string body,
        CancellationToken cancellationToken
    );
}