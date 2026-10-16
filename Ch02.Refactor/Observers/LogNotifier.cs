using System;
using System.Collections.Generic;
using System.Text;

using EduHub.Ch02.Domain;
using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Observers;

public class LogNotifier : IEventObserver
{
    private readonly IAppLogger _logger;

    public LogNotifier(IAppLogger logger)
    {
        _logger = logger
                  ?? throw new ArgumentNullException(nameof(logger));
    }

    public void OnEventCreated(Event ev)
    {
        _logger.LogInfo(
            $"Observer: Event '{ev.Title}' was created.");
    }
}
