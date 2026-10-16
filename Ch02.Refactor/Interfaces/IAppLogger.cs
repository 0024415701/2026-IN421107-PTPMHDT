using System;
using System.Collections.Generic;
using System.Text;


namespace EduHub.Ch02.Interfaces;

public interface IAppLogger
{
    void LogInfo(string message);
    void LogError(string message);
}
