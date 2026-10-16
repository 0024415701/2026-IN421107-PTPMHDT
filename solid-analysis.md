
# SOLID Analysis - ClubManager

## 1. Single Responsibility Principle (SRP)

- **Dòng 35–64, phương thức `CreateClub()`:** Vừa kiểm tra dữ liệu, tạo và lưu CLB, ghi log và gửi thông báo.
- **Dòng 67–84, phương thức `AddMemberToClub()`:** Vừa kiểm tra CLB, thêm thành viên, ghi log và gửi thông báo.
- **Dòng 88–99, phương thức `CreateEvent()`:** Vừa tạo sự kiện, ghi log và gửi email thông báo.
- **Dòng 103–113, phương thức `PrintClubReport()`:** Vừa thống kê thành viên, in báo cáo và ghi log.

**Nguyên tắc vi phạm:** SRP – Single Responsibility Principle.

**Hậu quả:** Class `ClubManager` có quá nhiều trách nhiệm. Khi thay đổi nghiệp vụ, cách ghi log hoặc thông báo, phải sửa cùng một class, khiến code khó bảo trì và kiểm thử.

**Hướng khắc phục:** Tách thành `ClubService`, `EventService`, `ReportService` và các thành phần chuyên trách.

## 2. Open/Closed Principle (OCP)

- **Dòng 50–64:** Dùng `if/else if` để kiểm tra Gmail, Yahoo và các email khác.
- **Dòng 81–83:** Gửi email và thông báo Slack trực tiếp trong phương thức thêm thành viên.
- **Dòng 103–108:** Báo cáo được in cố định bằng `Console.WriteLine()`.

**Nguyên tắc vi phạm:** OCP – Open/Closed Principle.

**Hậu quả:** Khi thêm kênh thông báo hoặc định dạng báo cáo mới, phải sửa code hiện tại, làm tăng nguy cơ phát sinh lỗi và giảm khả năng mở rộng.

**Hướng khắc phục:** Sử dụng Factory để tạo dịch vụ thông báo và Strategy để hỗ trợ nhiều định dạng báo cáo mà không cần sửa logic nghiệp vụ hiện có.

## 3. Dependency Inversion Principle (DIP)

- **Dòng 32:** Khai báo đường dẫn file log trực tiếp bằng kiểu `string`.
- **Dòng 48:** Ghi log tạo CLB bằng `File.AppendAllText()`.
- **Dòng 54, 58, 62:** Gửi thông báo bằng `Console.WriteLine()`.
- **Dòng 79:** Ghi log khi thêm thành viên bằng `File.AppendAllText()`.
- **Dòng 82–83:** Gửi thông báo trực tiếp bằng `Console.WriteLine()`.
- **Dòng 94:** Ghi log khi tạo sự kiện bằng `File.AppendAllText()`.
- **Dòng 97:** Gửi email thông báo trực tiếp bằng `Console.WriteLine()`.
- **Dòng 108, 111:** In báo cáo và ghi log trực tiếp.

**Nguyên tắc vi phạm:** DIP – Dependency Inversion Principle.

**Hậu quả:** Logic nghiệp vụ phụ thuộc vào file và console, khiến việc thay đổi cách ghi log, gửi thông báo hoặc xuất báo cáo khó khăn. Unit test cũng khó cô lập các phụ thuộc bên ngoài.

**Hướng khắc phục:** Khai báo các interface như `IAppLogger`, `INotificationService` và `IClubRepository`, sau đó truyền dependency qua constructor.

## 4. Interface Segregation Principle (ISP)

- **Vị trí:** Thiết kế tổng thể của `ClubManager`, đặc biệt các dòng 35–113, chưa tách riêng các thành phần quản lý CLB, ghi log, thông báo và báo cáo.

**Nguyên tắc:** ISP – Interface Segregation Principle.

**Nhận xét:** Code ban đầu chưa có interface lớn cụ thể để chứng minh vi phạm ISP trực tiếp. Đây là hạn chế thiết kế cần xem xét khi refactor.

**Hậu quả tiềm ẩn:** Nếu gom tất cả chức năng vào một interface lớn, các class sử dụng interface sẽ phải phụ thuộc vào những phương thức không cần thiết, làm tăng sự phụ thuộc và khó kiểm thử.

**Hướng khắc phục:** Tách các interface chuyên biệt như `IClubRepository`, `IAppLogger`, `INotificationService`, `IEventObserver` và `IReportStrategy`, để mỗi thành phần chỉ phụ thuộc vào những chức năng cần thiết.
