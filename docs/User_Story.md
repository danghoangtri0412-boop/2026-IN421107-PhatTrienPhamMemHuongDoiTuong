## Vai trò: Sinh viên

### US-01 · Sinh viên: huỷ đăng ký một sự kiện

1. Phiếu đang ở trạng thái Pending hoặc Confirmed, Sinh viên huỷ, phiếu chuyển sang trạng thái Cancelled.
2. Phiếu đã ở trạng thái Cancelled, Sinh viên huỷ lần nữa, hệ thống thông báo "Phiếu đã huỷ".

### US-02 · Sinh viên: xem các sự kiện mình đã đăng ký

1. Sinh viên có 2 phiếu đăng ký, Sinh viên xem danh sách, hệ thống hiển thị đầy đủ 2 sự kiện theo các trạng thái (Pending/Confirmed/Cancelled).
2. Sinh viên chưa đăng ký sự kiện nào, Sinh viên xem danh sách, hệ thống hiển thị danh sách rỗng.

## Vai trò: Ban CLB

### US-03 · Ban CLB: xác nhận phiếu đăng ký

1. Phiếu đang ở trạng thái Pending, Ban CLUB xác nhận, phiếu chuyển sang trạng thái Confirmed.
2. Phiếu đã ở trạng thái Cancelled, Ban CLUB xác nhận, hệ thống thông báo "Không thể xác nhận phiếu đang ở trạng thái Cancelled".

### US-04 · Ban CLB: xem danh sách thành viên của CLB

1. CLB có 3 thành viên, Ban CLUB xem danh sách, hệ thống hiển thị đầy đủ 3 thành viên.
2. CLB mới tạo chưa có ai, Ban CLUB xem danh sách, hệ thống hiện thị danh sách rỗng.

## Vai trò: Admin

### US-05 · Admin: tạo câu lạc bộ mới

1. Admin nhập tên CLB hợp lệ, Admin tạo CLUB, CLB được tạo với Id mới và chưa có thành viên.
2. Admin để trống tên CLB, Admin tạo CLUB, hệ thống thông báo "Tên CLB trống".
