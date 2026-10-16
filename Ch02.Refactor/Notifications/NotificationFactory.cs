using System;
using System.Collections.Generic;
using System.Text;

using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Notifications;

public enum NotificationChannel
{
    Email,
    Console
}

public static class NotificationFactory
{
    public static INotificationService Create(
        NotificationChannel channel)
    {
        return channel switch
        {
            NotificationChannel.Email => new EmailNotifier(),
            NotificationChannel.Console => new ConsoleNotifier(),
            _ => throw new ArgumentOutOfRangeException(
                nameof(channel),
                channel,
                "Unsupported notification channel")
        };
    }
}
