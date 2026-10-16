using System;
using System.Collections.Generic;
using System.Text;


using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Notifications;

public class EmailNotifier : INotificationService
{
    public void Send(string recipient, string message)
    {
        Console.WriteLine(
            $"[EMAIL] To: {recipient} | Message: {message}");
    }
}
