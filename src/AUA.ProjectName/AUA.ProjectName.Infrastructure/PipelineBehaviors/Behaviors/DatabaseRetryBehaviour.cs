using AUA.ProjectName.Infrastructure.PipelineBehaviors.Attributes;
using MediatR;

namespace AUA.ProjectName.Infrastructure.PipelineBehaviors.Behaviors
{
    public class DatabaseRetryBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {

        private readonly IRequestHandler<TRequest, TResponse> _requestHandler;
        public DatabaseRetryBehaviour(IRequestHandler<TRequest, TResponse> requestHandler)
        {
            _requestHandler = requestHandler;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            var attributes1 = _requestHandler.GetType().GetCustomAttributes(false);

            if (!attributes1.Any(p => p is DatabaseRetryAttribute))
                return await next();

            for (int i = 0; ; i++)
            {
                try
                {
                    var result = await _requestHandler.Handle(request, cancellationToken);
                    return result;
                }
                catch (Exception ex)
                {
                    // _config.NumberOfDatabaseRetries
                    if (i >=3 || !IsDatabaseException(ex))
                        throw;
                }
            }

            var attributes = request.GetType().GetCustomAttributes(false);


            var response = await next();


            return response;
        }
        private static bool IsDatabaseException(Exception exception)
        {
            var message = exception.InnerException?.Message;

            if (message == null)
                return false;

            return message.Contains("The connection is broken and recovery is not possible")
                || message.Contains("error occurred while establishing a connection");
        }
    }
}
