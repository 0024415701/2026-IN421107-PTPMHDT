using System;
using System.Collections.Generic;
using System.Text;


using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Notifications;

public class ConsoleNotifier : INotificationService
{
    public void Send(string recipient, string message)
    {
        Console.WriteLine(
            $"[CONSOLE] To: {recipient} | Message: {message}");
    }
}
