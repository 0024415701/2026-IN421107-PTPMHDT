using System;
using System.Collections.Generic;
using System.Text;

using EduHub.Ch02.Interfaces;
using EduHub.Ch02.Strategies;

namespace EduHub.Ch02.Services;

public class ReportService
{
    private readonly IClubRepository _clubRepository;
    private readonly IAppLogger _logger;

    public ReportService(
        IClubRepository clubRepository,
        IAppLogger logger)
    {
        _clubRepository = clubRepository
                          ?? throw new ArgumentNullException(nameof(clubRepository));

        _logger = logger
                  ?? throw new ArgumentNullException(nameof(logger));
    }

    public List<string> GenerateClubReport()
    {
        var report = new List<string>();

        foreach (var club in _clubRepository.GetAllClubs())
        {
            int memberCount =
                _clubRepository.GetMemberCount(club.Id);

            string line =
                $"Club: {club.Name} | Members: {memberCount}";

            report.Add(line);
            _logger.LogInfo(line);
        }

        return report;
    }

    public void ExportReport(IReportStrategy strategy)
    {
        ArgumentNullException.ThrowIfNull(strategy);

        var report = GenerateClubReport();
        strategy.Generate(report);
    }
}
