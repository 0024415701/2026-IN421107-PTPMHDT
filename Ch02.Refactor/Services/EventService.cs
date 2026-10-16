
using EduHub.Ch02.Domain;
using EduHub.Ch02.Interfaces;
using EduHub.Ch02.Observers;

namespace EduHub.Ch02.Services;

public class EventService
{
    private readonly IClubRepository _clubRepository;
    private readonly IAppLogger _logger;
    private readonly List<IEventObserver> _observers = new();

    public EventService(
        IClubRepository clubRepository,
        IAppLogger logger)
    {
        _clubRepository = clubRepository
            ?? throw new ArgumentNullException(nameof(clubRepository));

        _logger = logger
            ?? throw new ArgumentNullException(nameof(logger));
    }

    public void Subscribe(IEventObserver observer)
    {
        ArgumentNullException.ThrowIfNull(observer);

        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
    }

    public void Unsubscribe(IEventObserver observer)
    {
        _observers.Remove(observer);
    }

    public Event CreateEvent(Guid clubId, string title, DateTime date)
    {
        var club = _clubRepository.GetClubById(clubId)
            ?? throw new InvalidOperationException("Club not found");

        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Event title is required");
        }

        var newEvent = new Event
        {
            Id = Guid.NewGuid(),
            ClubId = clubId,
            Title = title,
            Date = date
        };

        _clubRepository.AddEvent(newEvent);
        _logger.LogInfo(
            $"Event created: {title} for club {club.Name}");

        // Thông báo cho tất cả observer đã đăng ký
        foreach (var observer in _observers.ToList())
        {
            observer.OnEventCreated(newEvent);
        }

        return newEvent;
    }

    public List<Event> GetEventsByClubId(Guid clubId)
    {
        if (_clubRepository.GetClubById(clubId) is null)
        {
            throw new InvalidOperationException("Club not found");
        }

        return _clubRepository.GetEventsByClubId(clubId);
    }
}
