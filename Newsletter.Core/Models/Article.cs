namespace Newsletter.Core.Models;

public sealed record Article(
    string Title,
    string Url,
    string Content,
    DateTime PublishDate
);