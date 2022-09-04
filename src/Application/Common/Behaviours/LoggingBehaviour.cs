﻿using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace MinimalApiArchitecture.Application.Common.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;

    public LoggingBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        _logger.LogInformation("Minimal API Request: {Name} {@Request}", requestName, request);

        return Task.CompletedTask;
    }
}

