CREATE DATABASE QL_DTDD1;
GO
USE QL_DTDD1;
GO
CREATE TABLE Loai (
    MaLoai INT PRIMARY KEY,
    TenLoai NVARCHAR(50)
);
CREATE TABLE SanPham (
    MaSP INT PRIMARY KEY,
    TenSP NVARCHAR(100),
    DuongDan NVARCHAR(255),
    Gia DECIMAL(18,2),
    MoTa NVARCHAR(255),
    MaLoai INT,
    FOREIGN KEY (MaLoai) REFERENCES Loai(MaLoai)
);
CREATE TABLE KhachHang (
    MaKH INT PRIMARY KEY,
    HoTen NVARCHAR(100),
    DienThoai NVARCHAR(20),
    GioiTinh NVARCHAR(10),
    SoThich NVARCHAR(100),
    Email NVARCHAR(100),
    MatKhau NVARCHAR(50)
);
CREATE TABLE GioHang (
    MaGH INT PRIMARY KEY,
    MaKH INT,
    MaSP INT,
    SoLuong INT,
    Ngay DATE,
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);
INSERT INTO Loai VALUES 
(1, N'Điện thoại'),
(2, N'Máy tính bảng'),
(3, N'Phụ kiện'),
(4, N'Laptop');
INSERT INTO SanPham VALUES
(101, N'iPhone 15 Pro', N'/images/iphone15.jpg', 29990000, N'Smartphone cao cấp Apple', 1),
(102, N'Samsung Galaxy S23 Ultra', N'/images/s23ultra.jpg', 27990000, N'Smartphone cao cấp Samsung', 1),
(103, N'Xiaomi Redmi Note 12', N'/images/redmi12.jpg', 5990000, N'Điện thoại tầm trung', 1),
(104, N'Samsung Galaxy Tab S9', N'/images/tabS9.jpg', 21990000, N'Máy tính bảng Android', 2),
(105, N'iPad Pro 12.9', N'/images/ipadpro.jpg', 32990000, N'Máy tính bảng cao cấp Apple', 2),
(106, N'Ốp lưng iPhone 15', N'/images/oplung15.jpg', 199000, N'Phụ kiện bảo vệ iPhone 15', 3),
(107, N'Tai nghe AirPods Pro 2', N'/images/airpodspro2.jpg', 5990000, N'Tai nghe Bluetooth cao cấp', 3),
(108, N'MacBook Pro M2', N'/images/macbookm2.jpg', 45990000, N'Laptop Apple chip M2', 4),
(109, N'Asus TUF Gaming F15', N'/images/asusf15.jpg', 25990000, N'Laptop gaming tầm trung', 4);
INSERT INTO KhachHang VALUES
(1, N'Nguyễn Văn A', '0909123456', N'Nam', N'Công nghệ', 'a@gmail.com', '123456'),
(2, N'Lê Thị B', '0987654321', N'Nữ', N'Mua sắm', 'b@gmail.com', '654321'),
(3, N'Trần Văn C', '0912345678', N'Nam', N'Chơi game', 'c@gmail.com', 'abc123'),
(4, N'Phạm Thị D', '0933222111', N'Nữ', N'Đọc sách', 'd@gmail.com', 'pass123'),
(5, N'Hoàng Văn E', '0977888999', N'Nam', N'Âm nhạc', 'e@gmail.com', '111111');
INSERT INTO GioHang VALUES
(1001, 1, 101, 1, '2025-09-28'),  
(1002, 2, 106, 2, '2025-09-29'),  
(1003, 3, 109, 1, '2025-09-30'),  
(1004, 4, 105, 1, '2025-09-30'),  
(1005, 5, 107, 1, '2025-09-30'),  
(1006, 1, 103, 1, '2025-09-30'),  
(1007, 2, 104, 1, '2025-09-30');  
