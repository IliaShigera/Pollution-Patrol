namespace PollutionPatrol.Modules.Reporting.Application.Contracts;

public interface IReportingModule
{
    Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);

    Task ExecuteCommandAsync(ICommand command, CancellationToken cancellationToken = default);

    Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}