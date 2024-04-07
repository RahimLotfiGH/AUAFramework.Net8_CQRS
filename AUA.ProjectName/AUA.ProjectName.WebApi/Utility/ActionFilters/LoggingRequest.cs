using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Models.DomainEvents.General;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Channels;
using AUA.Infrastructure.Utilities.ServiceUtilities;
using AUA.ProjectName.Common.Extensions;
using AUA.ProjectName.Models.DomainEvents.Base;
using Microsoft.AspNetCore.Mvc;

namespace AUA.ProjectName.WebApi.Utility.ActionFilters
{
    public class LoggingRequest : Attribute, IAsyncActionFilter
    {
        private readonly Channel<IDomainEvent> _commandDomainEventBus;

        public LoggingRequest()
        {
            _commandDomainEventBus = AppServiceFactory.GetService<Channel<IDomainEvent>>(); ;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var model = GetModel(context);

            await PublishActionDomainEventAsync(model, context.HttpContext);

            await next();
        }

        private static object GetModel(ActionExecutingContext context)
        {
            var httpMethod = GetHttpMethod(context);

            return HttpQueryStringMethodType.Contains(httpMethod) ?
                    context.ActionArguments.FirstOrDefault() :
                    context.ActionArguments.FirstOrDefault().Value;
        }

      

        private static IEnumerable<string> HttpQueryStringMethodType => new[]
            {
                HttpMethodTypeConsts.Get,
                HttpMethodTypeConsts.Delete
            };

        protected async Task PublishActionDomainEventAsync(object model, HttpContext context)
        {
            var domainEvent = CreateActionDomainEvent(model, context);

            await _commandDomainEventBus.Writer
                                        .WriteAsync(domainEvent);
        }

        private static ActionDomainEvent CreateActionDomainEvent(object actionInput, HttpContext context)
        {
            var parameters = actionInput.ClearParameters();

            return new ActionDomainEvent
            {
                UserId = GetUserId(context),
                ActionName = context.Request.Path,
                IssueTime = DateTime.UtcNow,
                Params = parameters,
                UserName = GetUserName(parameters)
            };
        }

      
        private static long? GetUserId(HttpContext context)
        {
            var model = ApplicationHelper.GetCurrentUserDataVm(context);

            return model?.UserId ?? DefaultValueConsts.SystemUserId;
        }

        private static string GetUserName(Dictionary<string, object> dictionary)
        {
            if (dictionary.Count == 0)
                return string.Empty;

            var result = dictionary.Keys.Where(k => k.ToLower().Contains(FiledNameConsts.Password))
                                        .ToList();
            return result.Any() ?
                   dictionary[result.First()].ToString() :
                   string.Empty;
        }

        private static string GetHttpMethod(ActionContext context) => context.HttpContext
            .Request
            .Method
            .ToLower();
    }
}
