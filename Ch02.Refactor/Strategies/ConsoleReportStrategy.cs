using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Ch02.Strategies;

public class ConsoleReportStrategy : IReportStrategy
{
    public void Generate(List<string> reportLines)
    {
        foreach (var line in reportLines)
        {
            Console.WriteLine(line);
        }
    }
}
