using AUA.ProjectName.DataLayer.AppContext.EntityFrameworkContext;
using AUA.ProjectName.Infrastructure.PipelineBehaviors.Attributes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace AUA.ProjectName.Infrastructure.PipelineBehaviors.Behaviors
{
    public class TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {

        private readonly IRequestHandler<TRequest, TResponse> _requestHandler;
        private readonly DatabaseFacade? _databaseFacade;

        public TransactionBehaviour(IRequestHandler<TRequest, TResponse> requestHandler, IUnitOfWork unitOfWork)
        {
            _requestHandler = requestHandler;
            _databaseFacade = unitOfWork.DatabaseFacade();
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            return HasTransactionAttribute() ?
                   await RunWithTransactionAsync(next, cancellationToken) :
                   await next();
        }

        public async Task<TResponse> RunWithTransactionAsync(RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            return await Strategy.ExecuteAsync(async () =>
                   await TransactionBodyAsync(next, cancellationToken));
        }

        public async Task<TResponse> TransactionBodyAsync(RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            await BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken);

            var result = await next();

            await CommitTransactionAsync(cancellationToken);

            return result;
        }

        private bool HasTransactionAttribute()
        {
            var attributes = _requestHandler.GetType().GetCustomAttributes(false);


            return attributes.Any(p => p is TransactionAttribute);
        }
        public IDbContextTransaction BeginTransaction()
        {
            return _databaseFacade!.BeginTransaction();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return await _databaseFacade!.BeginTransactionAsync(cancellationToken);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken = default)
        {
            return await _databaseFacade!.BeginTransactionAsync(isolationLevel, cancellationToken);
        }
        
        public void CommitTransaction()
        {
            _databaseFacade!.CommitTransaction();
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _databaseFacade!.CommitTransactionAsync(cancellationToken);
        }

        public IExecutionStrategy Strategy => _databaseFacade!.CreateExecutionStrategy();



    }
}
