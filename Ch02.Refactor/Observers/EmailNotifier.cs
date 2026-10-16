using System;
using System.Collections.Generic;
using System.Text;

using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Observers;

public class EmailNotifier : IEventObserver
{
    public void OnEventCreated(Event ev)
    {
        Console.WriteLine(
            $"[EVENT EMAIL] New event: {ev.Title} on {ev.Date:dd/MM/yyyy}");
    }
}
