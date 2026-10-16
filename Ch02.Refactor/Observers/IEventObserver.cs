using System;
using System.Collections.Generic;
using System.Text;

using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Observers;

public interface IEventObserver
{
    void OnEventCreated(Event ev);
}
