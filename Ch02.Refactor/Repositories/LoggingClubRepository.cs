using System;
using System.Collections.Generic;
using System.Text;

using EduHub.Ch02.Domain;
using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Repositories;

public class LoggingClubRepository : IClubRepository
{
    private readonly IClubRepository _inner;
    private readonly IAppLogger _logger;

    public LoggingClubRepository(
        IClubRepository inner,
        IAppLogger logger)
    {
        _inner = inner
                 ?? throw new ArgumentNullException(nameof(inner));

        _logger = logger
                  ?? throw new ArgumentNullException(nameof(logger));
    }

    public void AddClub(Club club)
    {
        _inner.AddClub(club);
        _logger.LogInfo($"Repository: added club {club.Name}");
    }

    public Club? GetClubById(Guid clubId)
    {
        _logger.LogInfo($"Repository: get club {clubId}");
        return _inner.GetClubById(clubId);
    }

    public List<Club> GetAllClubs()
    {
        _logger.LogInfo("Repository: get all clubs");
        return _inner.GetAllClubs();
    }

    public void AddMember(Member member)
    {
        _inner.AddMember(member);
        _logger.LogInfo($"Repository: added member {member.Name}");
    }

    public List<Member> GetMembersByClubId(Guid clubId)
    {
        _logger.LogInfo($"Repository: get members of club {clubId}");
        return _inner.GetMembersByClubId(clubId);
    }

    public int GetMemberCount(Guid clubId)
    {
        return _inner.GetMemberCount(clubId);
    }

    public void AddEvent(Event ev)
    {
        _inner.AddEvent(ev);
        _logger.LogInfo($"Repository: added event {ev.Title}");
    }

    public List<Event> GetEventsByClubId(Guid clubId)
    {
        _logger.LogInfo($"Repository: get events of club {clubId}");
        return _inner.GetEventsByClubId(clubId);
    }
}
