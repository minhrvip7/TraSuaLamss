USE master
GO

IF  EXISTS (
	SELECT name 
		FROM sys.databases 
		WHERE name = N'DBQuanLy'
)
DROP DATABASE DBQuanLy
GO

CREATE DATABASE DBQuanLy
GO

USE DBQuanLy
GO

CREATE TABLE TAIKHOAN
(
	Username VARCHAR(30) PRIMARY KEY NOT NULL,
	Password VARCHAR(30) NOT NULL,
	HoTen NVARCHAR(50) NOT NULL,
	PhanQuyen NVARCHAR(30) NOT NULL,
)
GO


CREATE TABLE LIENHE
(
	MaLH VARCHAR(5) PRIMARY KEY,
	TenLH NVARCHAR(50) NOT NULL,
	DiaChiLH NVARCHAR(100) NOT NULL,
	SDT VARCHAR(20) NOT NULL,
)
GO


CREATE TABLE PHANLOAI
(
	MaLoai VARCHAR(5) PRIMARY KEY,
	TenLoai NVARCHAR(50) NOT NULL,
)
GO


CREATE TABLE NHACUNGCAP
(
	MaNCC VARCHAR(5) PRIMARY KEY,
	TenNCC NVARCHAR(100) NOT NULL,
	DiaChi NVARCHAR(100) NOT NULL,
	SDT VARCHAR(20) NOT NULL,
)
GO


CREATE TABLE NGUYENLIEU
(
	MaNL VARCHAR(5) PRIMARY KEY,
	TenNL NVARCHAR(100) NOT NULL,
	MaNCC VARCHAR(5) NOT NULL,
	FOREIGN KEY (MaNCC) REFERENCES NHACUNGCAP (MaNCC)
)
GO



CREATE TABLE SANPHAM
(
	MaSP VARCHAR(5) PRIMARY KEY,
	TenSP NVARCHAR(30) NOT NULL,
	GiaBan MONEY NOT NULL,
	MoTa NVARCHAR(100) NOT NULL,
	Anh NVARCHAR(100) NOT NULL,
	MaNL VARCHAR(5) NOT NULL,
	MaLoai VARCHAR(5) NOT NULL,
	FOREIGN KEY (MaNL) REFERENCES NGUYENLIEU (MaNL),
	FOREIGN KEY (MaLoai) REFERENCES PHANLOAI (MaLoai),
)
GO



CREATE TABLE KHACHHANG
(
	MaKH INT PRIMARY KEY IDENTITY(1,1),
	TenKH NVARCHAR(30) NOT NULL,
	GioiTinh NVARCHAR(10) NOT NULL,
	NgaySinh DATETIME NOT NULL,
	Username VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	DiaChi NVARCHAR(200) NOT NULL,
	DienThoai VARCHAR(20) NOT NULL,
	FOREIGN KEY (USERNAME) REFERENCES TAIKHOAN (USERNAME),
)
GO



CREATE TABLE DONHANG
(
	MaDH VARCHAR(5) PRIMARY KEY NOT NULL,
	ThanhTien MONEY NOT NULL,
	PhuongThucThanhToan NVARCHAR(50) nOT NULL,
	ThanhToan NVARCHAR(30) NOT NULL,
	DiaChiGiaoHang NVARCHAR(50) NOT NULL,
	TinhTrangGiaoHang NVARCHAR(50) NOT NULL,
	NgayDat datetime NOT NULL,
	NgayGiao datetime NOT NULL,
	MaKH int NOT NULL,
	GhiChu NVARCHAR(100) NOT NULL,
	FOREIGN KEY (MaKH) REFERENCES KHACHHANG (MaKH),
)
GO



CREATE TABLE GIOHANG
(
	MaKH int NOT NULL,
	MaSP VARCHAR(5) NOT NULL,
	Soluong int NOT NULL,
	PRIMARY KEY (MaKH, MaSP),
	FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH),
	FOREIGN KEY (MaSP) REFERENCES SANPHAM(MaSP),
)
GO



CREATE TABLE CHITIETDONHANG
(
	MaHD VARCHAR(5),
	MaKH int ,
	MaSP VARCHAR(5),
	SoLuong INT NOT NULL,
	DonGia MONEY NOT NULL,
	PRIMARY KEY (MaHD,MaKH,MaSP),
	FOREIGN KEY (MaSP) REFERENCES SANPHAM (MaSP),
	FOREIGN KEY (MaKH) REFERENCES KHACHHANG (MaKH),

)
GO



CREATE TABLE NHANVIEN
(
	MaNV VARCHAR(5) PRIMARY KEY,
	TenNV NVARCHAR(30) NOT NULL,
	GioiTinh NVARCHAR(10) NOT NULL,
	NgaySinh datetime NOT NULL,
	Username VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	DiaChi NVARCHAR(200) NOT NULL,
	DienThoai NVARCHAR(20) NOT NULL,
	STK VARCHAR(50) NOT NULL,
	Luong MONEY NOT NULL,
	FOREIGN KEY (Username) REFERENCES TAIKHOAN (Username),
)
GO

--TAIKHOAN
--SELECT * FROM TAIKHOAN
--Admin
INSERT INTO TAIKHOAN(Username, Password, HoTen, PhanQuyen) VALUES('longvt','1',N'Vũ Thế Long', N'Admin')
GO
INSERT INTO TAIKHOAN(Username, Password, HoTen, PhanQuyen) VALUES('minhbd','1',N'Bùi Đình Minh', N'Admin')
GO
INSERT INTO TAIKHOAN(Username, Password, HoTen, PhanQuyen) VALUES('anhnh','1',N'Nuyễn Hoàng Anh', N'Admin')
GO
INSERT INTO TAIKHOAN(Username, Password, HoTen, PhanQuyen) VALUES('sangttt','1',N'Triệu Trung Tấn Sang', N'Admin')
GO
INSERT INTO TAIKHOAN(Username, Password, HoTen, PhanQuyen) VALUES('sondh','1',N'Đỗ Hồng Sơn', N'Admin')
GO
--Khach hang
INSERT INTO TAIKHOAN(Username, Password, HoTen, PhanQuyen) VALUES('kh1','1','Long', N'Khách hàng')
GO
INSERT INTO TAIKHOAN(Username, Password, HoTen, PhanQuyen) VALUES('kh2','1',N'Minh', N'Khách hàng')
GO
INSERT INTO TAIKHOAN(Username, Password, HoTen, PhanQuyen) VALUES('kh3','1',N'Anh', N'Khách hàng')
GO
INSERT INTO TAIKHOAN(Username, Password, HoTen, PhanQuyen) VALUES('kh4','1',N'Sang', N'Khách hàng')
GO
INSERT INTO TAIKHOAN(Username, Password, HoTen, PhanQuyen) VALUES('kh5','1',N'Sơn', N'Khách hàng')
GO
--Nhan vien
INSERT INTO TAIKHOAN(Username, Password, HoTen, PhanQuyen) VALUES('nv1','1',N'Vũ', N'Nhân viên')
GO
INSERT INTO TAIKHOAN(Username, Password, HoTen, PhanQuyen) VALUES('nv2','1',N'Bùi', N'Nhân viên')
GO
INSERT INTO TAIKHOAN(Username, Password, HoTen, PhanQuyen) VALUES('nv3','1',N'Nguyễn', N'Nhân viên')
GO
INSERT INTO TAIKHOAN(Username, Password, HoTen, PhanQuyen) VALUES('nv4','1',N'Triệu', N'Nhân viên')
GO
INSERT INTO TAIKHOAN(Username, Password, HoTen, PhanQuyen) VALUES('nv5','1',N'Đỗ', N'Nhân viên')
GO

--LIENHE
--SELECT * FROM LIENHE
INSERT INTO LIENHE(MaLH,TenLH, DiaChiLH, SDT) VALUES('LH001',N'Quan tra sua Lamss',N'Ha Noi', 1234)
GO

--PHANLOAI
--SELECT * FROM PHANLOAI
INSERT INTO PHANLOAI(MaLoai,TenLoai) VALUES('ML001',N'Trà sữa')
GO
INSERT INTO PHANLOAI(MaLoai,TenLoai) VALUES('ML002',N'Trà')
GO
INSERT INTO PHANLOAI(MaLoai,TenLoai) VALUES('ML003',N'Cà phê')
GO
INSERT INTO PHANLOAI(MaLoai,TenLoai) VALUES('ML004',N'Đồ ăn vặt')
GO

--NHACUNGCAP
--SELECT * FROM NHACUNGCAP
INSERT INTO NHACUNGCAP(MaNCC,TenNCC, DiaChi, SDT) VALUES('NCC01',N'DingTea', N'Hải Phòng', 123)
GO
INSERT INTO NHACUNGCAP(MaNCC,TenNCC, DiaChi, SDT) VALUES('NCC02',N'Tea Group', N'Hà Nội', 123)
GO
INSERT INTO NHACUNGCAP(MaNCC,TenNCC, DiaChi, SDT) VALUES('NCC03',N'Trung Nguyên Cà Phê', N'Dalak', 123)
GO
INSERT INTO NHACUNGCAP(MaNCC,TenNCC, DiaChi, SDT) VALUES('NCC04',N'Hoa Ban Food', N'Sơn La', 123)
GO
INSERT INTO NHACUNGCAP(MaNCC,TenNCC, DiaChi, SDT) VALUES('NCC05',N'Hướng dương Food', N'Hải Phòng', 123)
GO

--NGUYENLIEU
--SELECT * FROM NGUYENLIEU
INSERT INTO NGUYENLIEU(MaNL,TenNL, MaNCC) VALUES('NL001',N'Gói Trà sữa','NCC01')
GO
INSERT INTO NGUYENLIEU(MaNL,TenNL, MaNCC) VALUES('NL002',N'Gói Trà sữa chân châu','NCC01')
GO
INSERT INTO NGUYENLIEU(MaNL,TenNL, MaNCC) VALUES('NL003',N'Gói Trà sữa chân châu đường đen','NCC01')
GO
INSERT INTO NGUYENLIEU(MaNL,TenNL, MaNCC) VALUES('NL004',N'Trà đào túi lọc','NCC02')
GO
INSERT INTO NGUYENLIEU(MaNL,TenNL, MaNCC) VALUES('NL005',N'Trà Chanh túi lọc','NCC02')
GO
INSERT INTO NGUYENLIEU(MaNL,TenNL, MaNCC) VALUES('NL006',N'Trà Tắc túi lọc','NCC02')
GO
INSERT INTO NGUYENLIEU(MaNL,TenNL, MaNCC) VALUES('NL007',N'Hộp cà phê đen','NCC03')
GO
INSERT INTO NGUYENLIEU(MaNL,TenNL, MaNCC) VALUES('NL008',N'Hộp cà phê sữa','NCC03')
GO
INSERT INTO NGUYENLIEU(MaNL,TenNL, MaNCC) VALUES('NL009',N'Hộp cà phê Chery','NCC03')
GO
INSERT INTO NGUYENLIEU(MaNL,TenNL, MaNCC) VALUES('NL010',N'Gói Khô gà','NCC04')
GO
INSERT INTO NGUYENLIEU(MaNL,TenNL, MaNCC) VALUES('NL011',N'Gói Khô mực','NCC04')
GO
INSERT INTO NGUYENLIEU(MaNL,TenNL, MaNCC) VALUES('NL012',N'Gói Khô bò','NCC04')
GO
INSERT INTO NGUYENLIEU(MaNL,TenNL, MaNCC) VALUES('NL013',N'Túi hướng dương','NCC05')
GO
INSERT INTO NGUYENLIEU(MaNL,TenNL, MaNCC) VALUES('NL014',N'Túi hướng dương vỏ ngọt','NCC05')
GO
INSERT INTO NGUYENLIEU(MaNL,TenNL, MaNCC) VALUES('NL015',N'Túi hướng dương vỏ mặn','NCC05')
GO


--SANPHAM
--SELECT * FROM SANPHAM
INSERT INTO SANPHAM(MaSP,TenSP, GiaBan, MoTa, Anh, MaNL, MaLoai,Anh) VALUES ('SP001',N'Trà sữa',40000,N'Sản phẩm bán chạy', N'None', 'NL001','ML001','TraSua.jpg')
GO
INSERT INTO SANPHAM(MaSP,TenSP, GiaBan, MoTa, Anh, MaNL, MaLoai,Anh) VALUES ('SP002',N'Trà sữa chân châu',50000,N'Sản phẩm bán chạy', N'None', 'NL002','ML001','TraSuaChanChau.jpg')
GO
INSERT INTO SANPHAM(MaSP,TenSP, GiaBan, MoTa, Anh, MaNL, MaLoai,Anh) VALUES ('SP003',N'Trà sữa chân châu đường đen',60000,N'Sản phẩm bán chạy', N'None', 'NL003','ML001','TraSuaChanChauDuongDen.jpg')
GO
INSERT INTO SANPHAM(MaSP,TenSP, GiaBan, MoTa, Anh, MaNL, MaLoai,Anh) VALUES ('SP004',N'Trà đào',40000,N'Sản phẩm bán chạy', N'None', 'NL004','ML002','TraDao.jpg')
GO
INSERT INTO SANPHAM(MaSP,TenSP, GiaBan, MoTa, Anh, MaNL, MaLoai,Anh) VALUES ('SP005',N'Trà chanh',50000,N'Sản phẩm bán chạy', N'None', 'NL005','ML002','TraChanh.jpg')
GO
INSERT INTO SANPHAM(MaSP,TenSP, GiaBan, MoTa, Anh, MaNL, MaLoai,Anh) VALUES ('SP006',N'Trà tắc',60000,N'Sản phẩm ăn chạy', N'None', 'NL006','ML002','h0.png')
GO
INSERT INTO SANPHAM(MaSP,TenSP, GiaBan, MoTa, Anh, MaNL, MaLoai,Anh) VALUES ('SP007',N'Cà phê đen',40000,N'Sản phẩmbán chạy', N'None', 'NL007','ML003','CaPheDen.jpg')
GO
INSERT INTO SANPHAM(MaSP,TenSP, GiaBan, MoTa, Anh, MaNL, MaLoai,Anh) VALUES ('SP008',N'Cà phê sữa',50000,N'Sản phẩm bán chạy', N'None', 'NL008','ML003','CaPheSua.jpg')
GO
INSERT INTO SANPHAM(MaSP,TenSP, GiaBan, MoTa, Anh, MaNL, MaLoai,Anh) VALUES ('SP009',N'Cà phê Chery',60000,N'Sản phẩm bán chạy', N'None', 'NL009','ML003','CaPheCherry.jpg')
GO
INSERT INTO SANPHAM(MaSP,TenSP, GiaBan, MoTa, Anh, MaNL, MaLoai,Anh) VALUES ('SP010',N'Khô gà',40000,N'Sản phẩm ăn kèm bán chạy', N'None', 'NL010','ML004','KhoGa.jpg')
GO
INSERT INTO SANPHAM(MaSP,TenSP, GiaBan, MoTa, Anh, MaNL, MaLoai,Anh) VALUES ('SP011',N'Khô mực',50000,N'Sản phẩm ăn kèm bán chạy', N'None', 'NL011','ML004','KhoMuc.jpg')
GO
INSERT INTO SANPHAM(MaSP,TenSP, GiaBan, MoTa, Anh, MaNL, MaLoai,Anh) VALUES ('SP012',N'Khô bò',60000,N'Sản phẩm ăn kèm bán chạy', N'None', 'NL012','ML004','KhoBo.jpg')
GO
INSERT INTO SANPHAM(MaSP,TenSP, GiaBan, MoTa, Anh, MaNL, MaLoai,Anh) VALUES ('SP013',N'Hướng dương',40000,N'Sản phẩm ăn kèm bán chạy', N'None', 'NL013','ML004','HuongDuong.jpg')
GO
INSERT INTO SANPHAM(MaSP,TenSP, GiaBan, MoTa, Anh, MaNL, MaLoai,Anh) VALUES ('SP014',N'Hướng dương vỏ ngọt',50000,N'Sản phẩm ăn kèm bán chạy', N'None', 'NL014','ML004','HuongDuongVoNgot.jpg')
GO
INSERT INTO SANPHAM(MaSP,TenSP, GiaBan, MoTa, Anh, MaNL, MaLoai,Anh) VALUES ('SP015',N'Hướng dương vỏ mặn',60000,N'Sản phẩm ăn kèm bán chạy', N'None', 'NL015','ML004','HuongDuongVoMan.jpg')
GO

--KHACHHANG
--SELECT * FROM KHACHHANG
--SELECT * FROM TAIKHOAN WHERE PhanQuyen = N'Khách hàng'
INSERT INTO KHACHHANG(TenKH, GioiTinh, NgaySinh, USERNAME, Email, DiaChi, DienThoai) VALUES (N'Long', N'Nam', '1/1/2022', 'kh1', 'long@gmail.com', N'Hà Nội', 0971)
GO
INSERT INTO KHACHHANG(TenKH, GioiTinh, NgaySinh, USERNAME, Email, DiaChi, DienThoai) VALUES (N'Minh', N'Nam', '1/1/2022', 'kh2', 'minh@gmail.com', N'Hải Dương', 0971)
GO
INSERT INTO KHACHHANG(TenKH, GioiTinh, NgaySinh, USERNAME, Email, DiaChi, DienThoai) VALUES (N'Anh', N'Nam','1/1/2022', 'kh3', 'anh@gmail.com', N'Hà Nam', 0971)
GO
INSERT INTO KHACHHANG(TenKH, GioiTinh, NgaySinh, USERNAME, Email, DiaChi, DienThoai) VALUES (N'Sang', N'Nam', '1/1/2022', 'kh4', 'sang@gmail.com', N'Hải Phòng', 0971)
GO
INSERT INTO KHACHHANG(TenKH, GioiTinh, NgaySinh, USERNAME, Email, DiaChi, DienThoai) VALUES (N'Sơn', N'Nam', '1/1/2022', 'kh5', 'son@gmail.com', N'Quảng Ninh', 0971)
GO


--DONHANG
--SELECT * FROM DONHANG
INSERT INTO DONHANG(MaDH,PhuongThucThanhToan, ThanhTien, ThanhToan, DiaChiGiaoHang, TinhTrangGiaoHang, NgayDat, NgayGiao, MaKH, GhiChu) VALUES
('DH001',N'Thanh toán khi nhận hàng', 160000, N'Chưa thanh toán', N'Nguyên Xá', N'Đang giao', '1/1/2022', '2/1/2022', 1, N'Giao nhanh')
GO
INSERT INTO DONHANG(MaDH,PhuongThucThanhToan, ThanhTien, ThanhToan, DiaChiGiaoHang, TinhTrangGiaoHang, NgayDat, NgayGiao, MaKH, GhiChu) VALUES
('DH002',N'Thanh toán qua thẻ ngân hàng', 200000, N'Đã thanh toán', N'Văn trì' , N'Đã giao', '1/1/2022', '2/1/2022', 2, N'Giao nhanh')
GO
INSERT INTO DONHANG(MaDH,PhuongThucThanhToan, ThanhTien, ThanhToan, DiaChiGiaoHang, TinhTrangGiaoHang, NgayDat, NgayGiao, MaKH, GhiChu) VALUES
('DH003',N'Thanh toán khi nhận hàng', 240000, N'Chưa thanh toán', N'Ngọa Long' , N'Giao thất bại', '1/1/2022', '2/1/2022', 3, N'Khách hàng không nhận')
GO
INSERT INTO DONHANG(MaDH,PhuongThucThanhToan, ThanhTien, ThanhToan, DiaChiGiaoHang, TinhTrangGiaoHang, NgayDat, NgayGiao, MaKH, GhiChu) VALUES
('DH004',N'Thanh toán khi nhận hàng', 160000, N'Chưa thanh toán', N'Tây Tựu' , N'Giao thất bại', '1/1/2022', '2/1/2022', 4, N'Trả hàng')
GO
INSERT INTO DONHANG(MaDH,PhuongThucThanhToan, ThanhTien, ThanhToan, DiaChiGiaoHang, TinhTrangGiaoHang, NgayDat, NgayGiao, MaKH, GhiChu) VALUES
('DH005',N'Thanh toán khi nhận hàng', 160000, N'Chưa thanh toán', N'Tu Hoàng' , N'Đã giao', '1/1/2022', '2/1/2022', 5, N'Giao thành công')
GO

INSERT INTO DONHANG(MaDH,PhuongThucThanhToan, ThanhTien, ThanhToan, DiaChiGiaoHang, TinhTrangGiaoHang, NgayDat, NgayGiao, MaKH, GhiChu) VALUES
('DH006',N'Thanh toán khi nhận hàng', 160000, N'Chưa thanh toán', N'Nguyên Xá', N'Đang giao', '2/1/2022', '2/1/2022', 1, N'Giao nhanh'),
('DH007',N'Thanh toán qua thẻ ngân hàng', 200000, N'Đã thanh toán', N'Văn trì' , N'Đã giao', '2/1/2022', '2/1/2022', 2, N'Giao nhanh'),
('DH008',N'Thanh toán khi nhận hàng', 240000, N'Chưa thanh toán', N'Ngọa Long' , N'Giao thất bại', '3/2/2022', '2/1/2022', 3, N'Khách hàng không nhận'),
('DH009',N'Thanh toán khi nhận hàng', 160000, N'Chưa thanh toán', N'Tây Tựu' , N'Giao thất bại', '3/2/2022', '2/1/2022', 4, N'Trả hàng'),
('DH010',N'Thanh toán khi nhận hàng', 160000, N'Chưa thanh toán', N'Tu Hoàng' , N'Đã giao', '4/3/2022', '2/1/2022', 5, N'Giao thành công'),
('DH011',N'Thanh toán khi nhận hàng', 160000, N'Chưa thanh toán', N'Nguyên Xá', N'Đang giao', '4/3/2022', '2/1/2022', 1, N'Giao nhanh'),
('DH012',N'Thanh toán qua thẻ ngân hàng', 200000, N'Đã thanh toán', N'Văn trì' , N'Đã giao', '5/4/2022', '2/1/2022', 2, N'Giao nhanh'),
('DH013',N'Thanh toán khi nhận hàng', 240000, N'Chưa thanh toán', N'Ngọa Long' , N'Giao thất bại', '5/4/2022', '2/1/2022', 3, N'Khách hàng không nhận'),
('DH014',N'Thanh toán khi nhận hàng', 160000, N'Chưa thanh toán', N'Tây Tựu' , N'Giao thất bại', '6/5/2022', '2/1/2022', 4, N'Trả hàng'),
('DH015',N'Thanh toán khi nhận hàng', 160000, N'Chưa thanh toán', N'Tu Hoàng' , N'Đã giao', '6/5/2022', '2/1/2022', 5, N'Giao thành công'),
('DH016',N'Thanh toán khi nhận hàng', 160000, N'Chưa thanh toán', N'Nguyên Xá', N'Đang giao', '7/6/2022', '2/1/2022', 1, N'Giao nhanh'),
('DH017',N'Thanh toán qua thẻ ngân hàng', 200000, N'Đã thanh toán', N'Văn trì' , N'Đã giao', '7/6/2022', '2/1/2022', 2, N'Giao nhanh'),
('DH018',N'Thanh toán khi nhận hàng', 240000, N'Chưa thanh toán', N'Ngọa Long' , N'Giao thất bại', '8/7/2022', '2/1/2022', 3, N'Khách hàng không nhận'),
('DH019',N'Thanh toán khi nhận hàng', 160000, N'Chưa thanh toán', N'Tây Tựu' , N'Giao thất bại', '8/7/2022', '2/1/2022', 4, N'Trả hàng'),
('DH020',N'Thanh toán khi nhận hàng', 160000, N'Chưa thanh toán', N'Tu Hoàng' , N'Đã giao', '9/8/2022', '2/1/2022', 5, N'Giao thành công'),
('DH021',N'Thanh toán khi nhận hàng', 160000, N'Chưa thanh toán', N'Nguyên Xá', N'Đang giao', '9/8/2022', '2/1/2022', 1, N'Giao nhanh'),
('DH022',N'Thanh toán qua thẻ ngân hàng', 200000, N'Đã thanh toán', N'Văn trì' , N'Đã giao', '10/9/2022', '2/1/2022', 2, N'Giao nhanh'),
('DH023',N'Thanh toán khi nhận hàng', 240000, N'Chưa thanh toán', N'Ngọa Long' , N'Giao thất bại', '10/9/2022', '2/1/2022', 3, N'Khách hàng không nhận'),
('DH024',N'Thanh toán khi nhận hàng', 160000, N'Chưa thanh toán', N'Tây Tựu' , N'Giao thất bại', '11/10/2022', '2/1/2022', 4, N'Trả hàng'),
('DH025',N'Thanh toán khi nhận hàng', 160000, N'Chưa thanh toán', N'Tu Hoàng' , N'Đã giao', '11/10/2022', '2/1/2022', 5, N'Giao thành công'),
('DH026',N'Thanh toán khi nhận hàng', 160000, N'Chưa thanh toán', N'Nguyên Xá', N'Đang giao', '12/11/2022', '2/1/2022', 1, N'Giao nhanh'),
('DH027',N'Thanh toán qua thẻ ngân hàng', 200000, N'Đã thanh toán', N'Văn trì' , N'Đã giao', '12/11/2022', '2/1/2022', 2, N'Giao nhanh'),
('DH028',N'Thanh toán khi nhận hàng', 240000, N'Chưa thanh toán', N'Ngọa Long' , N'Giao thất bại', '12/12/2022', '2/1/2022', 3, N'Khách hàng không nhận'),
('DH029',N'Thanh toán khi nhận hàng', 160000, N'Chưa thanh toán', N'Tây Tựu' , N'Giao thất bại', '12/12/2022', '2/1/2022', 4, N'Trả hàng')
GO






--CHITIETDONHANG
--SELECT * FROM CHITIETDONHANG
--SELECT * FROM DONHANG
--SELECT * FROM SANPHAM

INSERT INTO CHITIETDONHANG (MaHD, MaKH, MaSP, SoLuong, DonGia) VALUES ('DH001', 1,'SP001',4 , 40000)
GO
INSERT INTO CHITIETDONHANG(MaHD, MaKH, MaSP, SoLuong, DonGia) VALUES ('DH002', 2,'SP002',4 , 50000)
GO
INSERT INTO CHITIETDONHANG(MaHD, MaKH, MaSP, SoLuong, DonGia) VALUES ('DH003', 3,'SP003',4 , 60000)
GO
INSERT INTO CHITIETDONHANG(MaHD, MaKH, MaSP, SoLuong, DonGia) VALUES ('DH004', 5,'SP001',4 , 40000)
GO
INSERT INTO CHITIETDONHANG(MaHD, MaKH, MaSP, SoLuong, DonGia) VALUES ('DH005', 4,'SP001',4 , 40000)
GO

--NHACNVIEN
--SELECT * FROM NHANVIEN
--SELECT * FROM TAIKHOAN WHERE PhanQuyen = N'Nhân viên'
INSERT INTO NHANVIEN(MaNV,TenNV, GioiTinh, NgaySinh, Username, Email, DiaChi, DienThoai, STK, Luong) VALUES ('NV001',N'Vũ', N'Nam','1/1/2020','nv1' ,'vu@gmail.com', N'Hà Nội', 0123, '123', 500000)
GO
INSERT INTO NHANVIEN(MaNV,TenNV, GioiTinh, NgaySinh, Username, Email, DiaChi, DienThoai, STK, Luong) VALUES ('NV002',N'Bùi', N'Nam','1/1/2020','nv2' ,'bui@gmail.com', N'Hà Nội', 0123, '123', 500000)
GO
INSERT INTO NHANVIEN(MaNV,TenNV, GioiTinh, NgaySinh, Username, Email, DiaChi, DienThoai, STK, Luong) VALUES ('NV003',N'Nguyễn', N'Nam','1/1/2020','nv3' ,'nguyen@gmail.com', N'Hà Nội', 0123, '123', 500000)
GO
INSERT INTO NHANVIEN(MaNV,TenNV, GioiTinh, NgaySinh, Username, Email, DiaChi, DienThoai, STK, Luong) VALUES ('NV004',N'Triệu', N'Nam','1/1/2020','nv4' ,'trieu@gmail.com', N'Hà Nội', 0123, '123', 500000)
GO
INSERT INTO NHANVIEN(MaNV,TenNV, GioiTinh, NgaySinh, Username, Email, DiaChi, DienThoai, STK, Luong) VALUES ('NV005',N'Đỗ', N'Nam','1/1/2020','nv5' ,'do@gmail.com', N'Hà Nội', 0123, '123', 500000)
GO

