namespace Newsletter.Core.Agents.Abstractions;

public interface IAgent<in TData, TResponse>
    where TData : class
    where TResponse : class
{
    Task<TResponse> RunAsync(
        TData data,
        CancellationToken cancellationToken);
}