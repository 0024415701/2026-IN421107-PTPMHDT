using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Ch02.Strategies;

public interface IReportStrategy
{
    void Generate(List<string> reportLines);
}
