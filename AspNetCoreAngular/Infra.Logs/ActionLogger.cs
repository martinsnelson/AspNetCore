using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace AspNetCoreAngular.Infra.Logs
{
    public class ActionLogger : IActionFilter
    {
        private readonly ILogger<ActionLogger> _logger;

        public ActionLogger(ILogger<ActionLogger> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var data = new
            {
                Version = "0.0.1",
                //User = context.HttpContext.User.Identity.Name,
                IP = context.HttpContext.Connection.RemoteIpAddress.ToString(),
                Hostname = context.HttpContext.Request.Host.ToString(),
                AreaAccessed = context.HttpContext.Request.GetDisplayUrl(),
                Action = context.ActionDescriptor.DisplayName,
                TimeStamp = DateTime.Now

            };

            _logger.LogInformation(1, data.ToString());
            _logger.LogTrace("OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
