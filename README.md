# Quy Trình Mượn Trả Sách - Phần Mềm Quản Lý Cửa Hàng Sách

## 1. Quy Trình Mượn Sách

### 1.1. Khởi tạo phiếu mượn
- Hệ thống tự động tạo mã mượn
- Nhập thông tin khách hàng
- Ghi nhận thông tin nhân viên thực hiện
- Xác định ngày mượn và ngày trả dự kiến

### 1.2. Thêm sách vào phiếu mượn
- Chọn sách cần mượn từ kho
- Ghi nhận giá thuê cho từng cuốn
- Có thể thêm nhiều sách trong một phiếu

### 1.3. Hoàn tất phiếu mượn
- Tính tổng tiền thuê
- Thu tiền đặt cọc
- In phiếu mượn cho khách

## 2. Quy Trình Trả Sách

### 2.1. Khởi tạo phiếu trả
- Hệ thống tự động tạo mã trả
- Nhập mã phiếu mượn để lấy thông tin
- Ghi nhận ngày trả thực tế

### 2.2. Kiểm tra và xử lý vi phạm
Kiểm tra từng cuốn sách và ghi nhận các vi phạm:
- Mất sách: Phạt 100% giá sách
- Hỏng sách: Phạt 70% giá sách
- Quá hạn: Phạt 2.000đ/ngày
- Có thể áp dụng nhiều loại vi phạm cùng lúc

### 2.3. Tính toán chi phí
Tổng tiền = Tiền thuê sách + Tổng tiền phạt vi phạm
Tiền khách trả = Tổng tiền - Tiền đặt cọc

### 2.4. Hoàn tất thủ tục
- Cập nhật trạng thái sách trong kho
- Thu tiền phạt (nếu có)
- Hoàn trả tiền đặt cọc (nếu không có vi phạm)
- In phiếu trả cho khách

## 3. Chức Năng Hệ Thống

### 3.1. Quản lý thông tin
- Lưu trữ chi tiết phiếu mượn/trả
- Theo dõi lịch sử vi phạm
- Cập nhật tình trạng sách
- Ghi nhận doanh thu từ cho thuê và phạt

### 3.2. Báo cáo và thống kê
- Xuất danh sách sách đang cho thuê
- Thống kê vi phạm
- Báo cáo doanh thu theo thời gian
- Thống kê sách được thuê nhiều nhất

## 4. Ưu Điểm

1. Quản lý chặt chẽ việc mượn trả
2. Theo dõi được tình trạng sách
3. Tính toán chính xác các khoản phí
4. Lưu trữ đầy đủ thông tin
5. Dễ dàng tra cứu và thống kê

## 5. Lưu Ý Khi Sử Dụng

1. Kiểm tra kỹ thông tin khách hàng trước khi cho mượn
2. Đảm bảo nhập đúng mã phiếu mượn khi làm thủ tục trả
3. Kiểm tra cẩn thận tình trạng sách khi nhận trả
4. Tính toán chính xác các khoản phí và tiền phạt
5. Lưu giữ phiếu mượn/trả cẩn thận

## 6. Yêu Cầu Hệ Thống

- Hệ điều hành: Windows 10 trở lên
- .NET Framework: Phiên bản mới nhất
- SQL Server: 2019 trở lên
- Máy in: Để in phiếu mượn/trả
