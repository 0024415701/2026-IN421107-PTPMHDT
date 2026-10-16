using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Ch02.Strategies;

public class CsvReportStrategy : IReportStrategy
{
    public void Generate(List<string> reportLines)
    {
        const string fileName = "club-report.csv";

        var lines = new List<string>
        {
            "ClubReport",
            "ClubName,MemberCount"
        };

        foreach (var line in reportLines)
        {
            var parts = line.Split('|');

            if (parts.Length == 2)
            {
                var clubName = parts[0]
                    .Replace("Club:", "")
                    .Trim();

                var memberCount = parts[1]
                    .Replace("Members:", "")
                    .Trim();

                lines.Add($"\"{clubName}\",{memberCount}");
            }
        }

        File.WriteAllLines(fileName, lines);
        Console.WriteLine($"CSV report saved to: {Path.GetFullPath(fileName)}");
    }
}
