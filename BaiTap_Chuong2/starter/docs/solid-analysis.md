# Phân tích các vi phạm SOLID trong `ClubManager.cs`

Các số dòng dưới đây tham chiếu đến `Ch02.Refactor/ClubManager.cs`.

| Dòng | Nguyên tắc | Vi phạm | Hậu quả |
|---|---|---|---|
| 28–32, 35–48 | SRP — Single Responsibility Principle | `ClubManager` vừa giữ dữ liệu CLB/thành viên, vừa kiểm tra dữ liệu, xử lý nghiệp vụ, ghi log và điều phối thông báo. Riêng `CreateClub` (35–48) xác thực tên, tạo/lưu CLB và ghi log. | Các lý do thay đổi bị dồn vào một lớp. Thay đổi quy tắc tên, cách lưu trữ hay logging đều có thể ảnh hưởng lớp này; kiểm thử từng trách nhiệm cũng khó hơn. |
| 38–41 | SRP — Single Responsibility Principle | Quy tắc hợp lệ của tên CLB được đặt trong `ClubManager.CreateClub` thay vì cùng mô hình/nghiệp vụ `Club`. | Quy tắc có nguy cơ bị lặp hoặc không được áp dụng khi tạo CLB qua đường khác; thay đổi giới hạn tên buộc sửa lớp điều phối. |
| 47–48, 78–79, 94, 110–111 | DIP — Dependency Inversion Principle | Lớp nghiệp vụ gọi trực tiếp `File.AppendAllText` và phụ thuộc vào đường dẫn/tệp vật lý, thay vì dùng abstraction logging được inject. | Khó thay logger (ví dụ console hoặc logger kiểm thử), cần thao tác tệp trong test, và lỗi/đặc thù lưu trữ bị gắn chặt với nghiệp vụ. |
| 50–63 | OCP — Open/Closed Principle | `CreateClub` chọn cách thông báo bằng điều kiện theo miền email (`gmail.com`, `yahoo.com`, còn lại). | Thêm hoặc đổi kênh/nhà cung cấp thông báo đòi hỏi sửa logic hiện có; số nhánh tăng và dễ gây hồi quy. |
| 66–84 | SRP — Single Responsibility Principle | `AddMemberToClub` vừa kiểm tra CLB và giới hạn số thành viên, vừa tạo/lưu thành viên, ghi log và gửi nhiều thông báo (82–83). | Thay đổi chính sách thành viên, lưu trữ hoặc thông báo cùng tác động một phương thức; khó kiểm thử nghiệp vụ độc lập với các side effect. |
| 86–99 | SRP và OCP — Single Responsibility / Open-Closed Principles | `CreateEvent` tạo sự kiện, ghi log và tự gửi email cho từng thành viên; danh sách người nhận và cách gửi bị gắn cứng trong vòng lặp (96–97). | Quy tắc thông báo làm phình logic tạo sự kiện; thêm observer/kênh mới hoặc đổi cách gửi buộc sửa phương thức, đồng thời khó kiểm thử riêng việc tạo sự kiện. |
| 101–112 | SRP và OCP — Single Responsibility / Open-Closed Principles | `PrintClubReport` tính dữ liệu báo cáo, xuất trực tiếp ra console và ghi log. Cách xuất bị cố định, không có abstraction/strategy. | Thêm định dạng như CSV hoặc đổi nơi xuất đòi hỏi sửa phương thức; không thể tái sử dụng dữ liệu báo cáo độc lập với cách trình bày và logging. |
| 54, 58, 62, 82–83, 97, 108 | DIP — Dependency Inversion Principle | Luồng nghiệp vụ phụ thuộc trực tiếp vào `Console.WriteLine` để gửi thông báo/in báo cáo, thay vì phụ thuộc vào abstraction thông báo hoặc báo cáo. | Khó chuyển sang dịch vụ thật hoặc đầu ra khác, và test phải chịu side effect console thay vì thay thế dependency bằng giả lập. |

