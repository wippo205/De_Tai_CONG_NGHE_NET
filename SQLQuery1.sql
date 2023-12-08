-- Tạo cơ sở dữ liệu Net
CREATE DATABASE Net;
GO

-- Sử dụng cơ sở dữ liệu Net
USE Net;
GO

-- Tạo bảng SanPham
CREATE TABLE SanPham
(
    MaSanPham nvarchar(10) NOT NULL PRIMARY KEY,
    TenSanPham nvarchar(50) NOT NULL
);

-- Tạo bảng Khach
CREATE TABLE Khach
(
    MaKhach nvarchar(10) NOT NULL PRIMARY KEY,
    TenKhach nvarchar(50) NOT NULL,
    DiaChi nvarchar(50) NOT NULL,
    DienThoai integer NOT NULL
);

-- Tạo bảng Hang với khóa ngoại tham chiếu đến bảng SanPham
CREATE TABLE Hang
(
    MaHang nvarchar(10) NOT NULL PRIMARY KEY,
    TenHang varchar(50) NOT NULL,
    MaSanPham nvarchar(10) NOT NULL,
    Soluong int NOT NULL,
    DonGiaNhap float not null,
    DonGiaBan float not null,
    Img nvarchar(200) not null,
    ChuThich nvarchar(200) not null,
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);

-- Tạo bảng NhanVien
CREATE TABLE NhanVien
(
    MaNhanVien nvarchar(10) NOT NULL PRIMARY KEY,
    TenNhanVien varchar(50) NOT NULL,
    GioiTinh nvarchar(10) not null,
    DiaChi nvarchar(50) NOT NULL,
    DienThoai integer NOT NULL,
    NgaySinh datetime NOT NULL
);

-- Tạo bảng HDBan với khóa ngoại tham chiếu đến bảng NhanVien và bảng Khach
CREATE TABLE HDBan
(
    MaHDBan varchar(50) NOT NULL PRIMARY KEY,
    MaNhanVien nvarchar(10) NOT NULL,
    NgayBan datetime NOT NULL,
    MaKhach nvarchar(10) NOT NULL,
    TongTien float NOT NULL,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaKhach) REFERENCES Khach(MaKhach)
);

-- Alter the data type of the MaHDBan column in the HDBan table


-- Tạo bảng ChiTietHDBan với khóa ngoại tham chiếu đến bảng HDBan và bảng Hang
CREATE TABLE ChiTietHDBan
(
    MaHDBan varchar(10) NOT NULL,
    MaHang nvarchar(10) NOT NULL,
    Soluong int NOT NULL,
    DonGia float not null,
    GiamGia float not null,
    ThanhTien float not null,
    PRIMARY KEY (MaHDBan, MaHang),
    FOREIGN KEY (MaHDBan) REFERENCES HDBan(MaHDBan),
    FOREIGN KEY (MaHang) REFERENCES Hang(MaHang)
);

CREATE TABLE DangNhap
(
    ID int PRIMARY KEY,
    UserName nvarchar(50) NOT NULL,
    Password nvarchar(50) NOT NULL
);





