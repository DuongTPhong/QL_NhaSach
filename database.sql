create database Sach

use Sach



	CREATE TABLE Dangnhap(
	MaNV	nvarchar(10) not null,	
	Tennguoidung varchar(40),
	Matkhau	varchar(50),
	constraint pk_kh primary key(Tennguoidung)
)
	CREATE TABLE Nhanvien(
	MaNV	nvarchar(10) not null,	
	Hoten	nvarchar(40),
	Gioitinh nvarchar(10),
	Diachi nvarchar(50),
	ngaysinh	date,
	SDT	varchar(12),
	Email varchar(40),
	constraint pk_nv primary key(MANV)
)
	CREATE TABLE Hoadon(
	MaHD	nvarchar(20) not null,
	MaNV	nvarchar(10) not null,
	MaKH	nvarchar(10) not null,
	MaSach	nvarchar(30),
	Soluong int,
	Dongia	decimal(10,3),
	NgayBan date,
	Tongtien decimal(10,3),
	constraint pk_hd primary key(MaKH,MaHD)
)
	CREATE TABLE Sach(
	MaSach	nvarchar(30) not null,
	TenSach nvarchar(70),
	MaLoaiSach varchar(10),
	TenNXB nvarchar(30),
	NamXB date,
	Tacgia nvarchar(30),
	MaNCC varchar(10),
	GiaNhap decimal(10,3),
	GiaBan decimal(10,3),
	Soluong int,
	constraint pk_sach primary key(MaSach)
)	
	CREATE TABLE Nhacungcap(
	MaNCC varchar(10) not null,
	TenNCC	nvarchar(50),
	Diachi nvarchar(50),
	SDT varchar(12),
	MaSach	nvarchar(30) not null,
	Dongia	decimal(10,3),
	Soluong int,
	Ngaynhap date,
	constraint pk_nhacc primary key(MaNCC)
)
	create table LoaiSach(
	MaLoaiSach varchar(10) not null,
	TenLoaiSach nvarchar(50),
	constraint pk_lsach primary key(MaLoaiSach)
	)

ALTER TABLE Hoadon ADD CONSTRAINT fk01_HD FOREIGN KEY(MANV) REFERENCES Nhanvien(MANV)
ALTER TABLE Dangnhap ADD CONSTRAINT fk01_LG FOREIGN KEY(MANV) REFERENCES Nhanvien(MANV)
ALTER TABLE Hoadon ADD CONSTRAINT fk02_Sach FOREIGN KEY(MaSach) REFERENCES Sach(MaSach)
ALTER TABLE Sach ADD CONSTRAINT fk01_NCC FOREIGN KEY(MaNCC) REFERENCES Nhacungcap(MaNCC)
ALTER TABLE Sach ADD CONSTRAINT fk02_TLS FOREIGN KEY(MaLoaiSach) REFERENCES Loaisach(MaLoaiSach)


insert into Nhacungcap values
('NCC01',N'Trí Tuệ - Công Ty Cổ Phần Sách',N'187 Giảng Võ, Q. Đống Đa, Hà Nội','0379557155','S01',30,100,'2022-06-08'),
('NCC02',N'Công Ty Cổ Phần Sách Mcbooks',N' P. Phúc Diễm, Q. Bắc Từ Liêm, Hà Nội','0384112369','S02',40,50,'2022-06-05')

insert into LoaiSach values
	('VH01',N'Văn học nước ngoài'),
	('TT01',N'Tiểu Thuyết'),
	('TR01',N'Truyện tranh'),
	('KN01',N'Kỹ năng')

insert into Sach values
('S01',N'One Piece','TR01',N'Kim Đồng','2018-10-06','Oda Eiichiro','NCC01',30,35,2),

('S02',N'Hoàng tử bé','VH01',N'Kim Đồng','2015-09-07',' Antoine de Saint Exupéry','NCC01',40,60,2),

('S03',N'LIFE 3.0 – Loài Người Trong Kỷ Nguyên Trí Tuệ Nhân Tạo','KN01',N'NXB Thế Giới','2019-07-01','Max Tegmark','NCC02',130,160,5),

('S04',N'Tư duy nhanh chậm','KN01',N'NXB Thế Giới','2019-09-15',' Antoine de Saint Exupéry','NCC02',200,250,5),

('S05',N'Dầu Mỏ,Tiền Bạc Và Quyền Lực','KN01',N'NXB Thế Giới','2018-04-10','Daniel Yergin','NCC02',500,650,10),

('S06',N'Hai Số Phận','TT01',N'NXB Văn học','2018-04-10','Jeffrey Archer','NCC01',140,180,4)

insert into Nhanvien values
('NV01',N'Thắng',N'Nam',N'Cầu Giấy,Hà Nội','2002-10-08','0339557817','thanhthang@gmail.com'),
('NV02',N'Phong',N'Nam',N'Phú Diễn,Hà Nội','2002-06-15','0336237817','phongduong@gmail.com'),
('NV03',N'Ngọc Anh',N'Nam',N'Phú Diễn,Hà Nội','2002-02-20','0336262217','ngocanh@gmail.com'),
('NV04',N'Dương',N'Nam',N'Phú Diễn,Hà Nội','2002-04-26','0336233317','minhduong@gmail.com')

insert into Hoadon values
('HD01','NV02','KH01','S01','1','35','2022-10-10',35),
('HD02','NV02','KH01','S02','1','60','2022-10-12',60),
('HD03','NV03','KH02','S01','1','35','2022-11-05',35),
('HD03-1','NV03','KH02','S02','1','60','2022-11-05',60),
('HD04','NV03','KH03','S03','1','160','2022-10-09',160),
('HD05','NV04','KH04','S04','1','250','2022-12-01',250),
('HD06','NV04','KH05','S06','2','180','2022-12-29',360),
('HD07','NV01','KH10','S05','2','650','2022-06-13',1300),
('HD08','NV01','KH10','S04','1','250','2022-06-15',250)

insert into Dangnhap values

('NV01','thang','thang'),
('NV02','duong','duong'),
('NV03','phong','phong'),
('NV04','ngocanh','ngocanh')
