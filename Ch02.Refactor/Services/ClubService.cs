using System;
using System.Collections.Generic;
using System.Text;

using EduHub.Ch02.Domain;
using EduHub.Ch02.Interfaces;
using EduHub.Ch02.Notifications;

namespace EduHub.Ch02.Services;

public class ClubService
{
    private readonly IClubRepository _clubRepository;
    private readonly IAppLogger _logger;
    private readonly INotificationService _notificationService;

    public ClubService(
        IClubRepository clubRepository,
        IAppLogger logger,
        INotificationService notificationService)
    {
        _clubRepository = clubRepository
            ?? throw new ArgumentNullException(nameof(clubRepository));

        _logger = logger
            ?? throw new ArgumentNullException(nameof(logger));

        _notificationService = notificationService
            ?? throw new ArgumentNullException(nameof(notificationService));
    }

    public Club CreateClub(
        string name,
        string description,
        string presidentEmail)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Club name is required");

        if (name.Length > 100)
            throw new ArgumentException("Club name too long");

        var club = new Club
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description
        };

        _clubRepository.AddClub(club);
        _logger.LogInfo($"Club created: {name}");

        _notificationService.Send(
            presidentEmail,
            $"Your club '{name}' has been created.");

        return club;
    }

    public void AddMemberToClub(
        Guid clubId,
        string memberName,
        string email)
    {
        var club = _clubRepository.GetClubById(clubId)
            ?? throw new InvalidOperationException("Club not found");

        if (_clubRepository.GetMemberCount(clubId) >= 50)
            throw new InvalidOperationException(
                "Club is full (max 50 members)");

        var member = new Member
        {
            Id = Guid.NewGuid(),
            Name = memberName,
            Email = email,
            ClubId = clubId
        };

        _clubRepository.AddMember(member);
        _logger.LogInfo($"Member {memberName} joined {club.Name}");
    }

    public List<Club> GetAllClubs()
    {
        return _clubRepository.GetAllClubs();
    }
}
