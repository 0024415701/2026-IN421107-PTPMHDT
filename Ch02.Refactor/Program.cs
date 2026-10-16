
using EduHub.Ch02.Interfaces;
using EduHub.Ch02.Notifications;
using EduHub.Ch02.Observers;
using EduHub.Ch02.Repositories;
using EduHub.Ch02.Services;
using EduHub.Ch02.Strategies;

// 1. Khoi tao Logger
var logger = new ConsoleAppLogger();

// 2. Khoi tao Repository va Decorator Pattern
IClubRepository repository = new LoggingClubRepository(
    new InMemoryClubRepository(),
    logger);

// 3. Factory Pattern: tao dich vu thong bao
var notificationService = NotificationFactory.Create(
    NotificationChannel.Email);

// 4. Dependency Injection: khoi tao cac Service
var clubService = new ClubService(
    repository,
    logger,
    notificationService);

var eventService = new EventService(
    repository,
    logger);

var reportService = new ReportService(
    repository,
    logger);

// 5. Observer Pattern: dang ky cac observer
eventService.Subscribe(new LogNotifier(logger));
eventService.Subscribe(new EduHub.Ch02.Observers.EmailNotifier());

// 6. Tao cau lac bo
Console.WriteLine("=== TAO CAU LAC BO ===");

var club = clubService.CreateClub(
    "Tech Club",
    "Cau lac bo cong nghe",
    "president@gmail.com");

// 7. Them thanh vien
Console.WriteLine("\n=== THEM THANH VIEN ===");

clubService.AddMemberToClub(
    club.Id,
    "Nguyen Van A",
    "a@student.dthu.edu.vn");

// 8. Tao su kien
Console.WriteLine("\n=== TAO SU KIEN ===");

eventService.CreateEvent(
    club.Id,
    "Workshop SOLID",
    new DateTime(2026, 11, 20));

// 9. Tao bao cao
Console.WriteLine("\n=== BAO CAO CAU LAC BO ===");

var report = reportService.GenerateClubReport();

foreach (var line in report)
{
    Console.WriteLine(line);
}

// 10. Strategy Pattern: xuat bao cao Console
Console.WriteLine("\n=== XUAT BAO CAO CONSOLE ===");

reportService.ExportReport(new ConsoleReportStrategy());

// 11. Strategy Pattern: xuat bao cao CSV
Console.WriteLine("\n=== XUAT BAO CAO CSV ===");

reportService.ExportReport(new CsvReportStrategy());

// 12. Ket thuc
Console.WriteLine("\n=== KET THUC CHUONG TRINH ===");
