using System;
using System.Collections.Generic;
using System.Text;


using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Interfaces;

public interface IClubRepository
{
    // Club
    void AddClub(Club club);
    Club? GetClubById(Guid clubId);
    List<Club> GetAllClubs();

    // Member
    void AddMember(Member member);
    List<Member> GetMembersByClubId(Guid clubId);
    int GetMemberCount(Guid clubId);

    // Event
    void AddEvent(Event ev);
    List<Event> GetEventsByClubId(Guid clubId);
}
