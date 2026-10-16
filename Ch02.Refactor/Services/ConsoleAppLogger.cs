using System;
using System.Collections.Generic;
using System.Text;


using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Services;

public class ConsoleAppLogger : IAppLogger
{
    public void LogInfo(string message)
    {
        Console.WriteLine($"[INFO] {message}");
    }

    public void LogError(string message)
    {
        Console.WriteLine($"[ERROR] {message}");
    }
}
