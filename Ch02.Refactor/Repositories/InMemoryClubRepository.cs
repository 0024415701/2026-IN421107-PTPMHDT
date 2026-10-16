using System;
using System.Collections.Generic;
using System.Text;


using EduHub.Ch02.Domain;
using EduHub.Ch02.Interfaces;

namespace EduHub.Ch02.Repositories;

public class InMemoryClubRepository : IClubRepository
{
    private readonly List<Club> _clubs = new();
    private readonly List<Member> _members = new();
    private readonly List<Event> _events = new();

    public void AddClub(Club club)
    {
        _clubs.Add(club);
    }

    public Club? GetClubById(Guid clubId)
    {
        return _clubs.FirstOrDefault(c => c.Id == clubId);
    }

    public List<Club> GetAllClubs()
    {
        return _clubs.ToList();
    }

    public void AddMember(Member member)
    {
        _members.Add(member);
    }

    public List<Member> GetMembersByClubId(Guid clubId)
    {
        return _members
            .Where(m => m.ClubId == clubId)
            .ToList();
    }

    public int GetMemberCount(Guid clubId)
    {
        return _members.Count(m => m.ClubId == clubId);
    }

    public void AddEvent(Event ev)
    {
        _events.Add(ev);
    }

    public List<Event> GetEventsByClubId(Guid clubId)
    {
        return _events
            .Where(e => e.ClubId == clubId)
            .ToList();
    }
}
