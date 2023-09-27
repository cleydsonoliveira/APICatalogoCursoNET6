﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace APICatalogoCursoNET6.Filters
{
    public class ApiLoggingFilter : IActionFilter
    {
        private readonly ILogger<ApiLoggingFilter> _logger;
        public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
        {

            _logger = logger;

        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("##Executando -> OnActionExecuting");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _logger.LogInformation($"ModelState: {context.ModelState.IsValid}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("##Executando -> OnActionExecuted");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
        }

    }
}