create database QL_NhaHang
go
use QL_NhaHang
go

-----------Bảng loại nhân viên----------------
create table LoaiNV
(
MaLoaiNV	varchar(10),
TenLoaiNV	nvarchar(50),
constraint	pk_LoaiNV_MaLoaiNV primary key(MaLoaiNV)
)

-----------Insert Loại Nhân Viên--------------
insert into LoaiNV
values
--Mã loại NV	  Tên loại
('LNV01',		N'Full time'),
('LNV02',		N'Part time')

select * from LoaiNV

-----------Bảng nhân viên----------------
create table NhanVien
(
MaNV			varchar(10),
HoTenNV			nvarchar(max)	not null,
ChucVu			nvarchar(30),
GioiTinh		nvarchar(10)	not null,
DiaChi			nvarchar(max)	not null,
SoDienThoai		varchar(10)		not null,
QueQuan			nvarchar(50)	not null,
SoCCCD			varchar(30)		not null,
NgaySinh		date			not null,
MaLoaiNV		varchar(10),
NgayVaoLam		date			not null,
LinkHinh		nvarchar(max) default N'None',
constraint pk_NV_MaNV		primary key(MaNV),
constraint Uni_NV_SDT		unique (SoDienThoai),
constraint Uni_NV_SoCCCD	unique (SoCCCD),
constraint Ck_NV_GioiTinh	check  (GioiTinh = N'Nam' or GioiTinh = N'Nữ'),
constraint Ck_NV_Tuoi		check  (year(getdate()) - year(NgaySinh) >=18),
constraint fk_NV_MaLoaiNV	foreign key(MaLoaiNV) references LoaiNV(MaLoaiNV)
)

------------Insert Nhân Viên--------------
set dateformat dmy
go
insert into NhanVien(MaNV,HoTenNV,ChucVu,GioiTinh,DiaChi,SoDienThoai,QueQuan,SoCCCD,NgaySinh,MaLoaiNV,NgayVaoLam)
values
--Mã NV		  Họ Tên			Chức vụ	   Giới tính						Địa chỉ									 Số điện thoại		Quê quán		    Số CCCD		  Ngày sinh	   Mã loại NV   Ngày vào làm	 
('NV01',  N'Trần Đức Huy',	   N'Quản lý',	 N'Nam',   N'9D Lê Thái, Q.11, P.Minh Vương, TP.Hồ Chí Minh',			 '0992582581',	N'TP.Hồ Chí Minh',	'092502950505',	 '12/01/1995',	'LNV01',	'22/12/2017'),
('NV02',  N'Tố Minh Ngọc',	   N'Quản lý',	 N'Nữ',    N'24F Lũy Bán Bích, Q.12, P.Minh Hòa, TP.Hồ Chí Minh',		 '0872582582',	N'Hà Nội',			'003202950511',	 '17/12/1996',	'LNV01',	'22/12/2018'),
('NV03',  N'Nguyễn Thái Học',  N'Lễ tân',	 N'Nữ',    N'12A Lý Thái Tổ, Q4, P.Bình Thạnh, TP.Hồ Chí Minh',			 '0112582583',	N'TP.Hồ Chí Minh',	'099872950501',	 '22/04/2000',	'LNV02',	'22/12/2015'),
('NV04',  N'Đỗ Tuấn An',	   N'Đầu bếp',	 N'Nam',   N'11 Quang Trung, Q.Gò Vấp, P.14, TP.Hồ Chí Minh',			 '0772582523',	N'Đà Nẵng',			'012502950507',	 '14/08/1990',	'LNV01',	'22/12/2019'),
('NV05',  N'Đặng Thái Duy',	   N'Phục vụ',	 N'Nam',   N'142/11X Bình Triệu, Q.10, P.Cộng Hòa, TP.Hồ Chí Minh',		 '0432582022',	N'Huế',				'023534950511',	 '17/09/1995',	'LNV02',	'22/12/2019'),
('NV06',  N'Hàn Minh Tuấn',	   N'Phục vụ',	 N'Nam',   N'12D Hai Bà Trưng, Q.4, P.14, TP.Hồ Chí Minh',				 '0222452122',	N'Huế',				'012530750511',	 '04/01/1995',	'LNV02',	'22/12/2020'),
('NV07',  N'Nguyễn Ngọc Nga',  N'Đầu bếp',	 N'Nữ',    N'25 Ngọc Điệp, Q.05, P.Thiên Hòa, TP.Hồ Chí Minh',			 '0212582009',	N'Huế',				'025434950509',	 '08/10/1992',	'LNV01',	'22/12/2015'),
('NV08',  N'Trần Thái Phú',	   N'Phục vụ',	 N'Nam',   N'20 Nguyễn Thái Sơn, Q.Gò Vấp, P.Thiên Hòa, TP.Hồ Chí Minh', '0452582011',	N'Đà Lạt',			'065534950587',	 '11/11/1999',	'LNV01',	'22/12/2021'),
('NV09',  N'Lệ Minh Ngọc',	   N'Lễ tân',	 N'Nam',   N'34 Bình Chánh Đông, Cai Lậy, P.14, TP.Hồ Chí Minh',		 '0654582021',	N'TP.Hồ Chi Minh',	'097534950222',	 '16/06/2001',	'LNV02',	'22/12/2022'),
('NV10',  N'Đặng Thái Bình',   N'Phục vụ',	 N'Nam',   N'12 Chế Lan Viên, Q.Tân Phú, P.Cộng Hòa, TP.Hồ Chí Minh',	 '0322582011',	N'Hà Nội',			'021134950565',	 '17/07/2002',	'LNV01',	'22/12/2021')

select * from NhanVien

select * from NhanVien where GioiTinh = N'Nữ'

select LinkHinh from NhanVien where MaNV = 'NV02'

select count(*) from NhanVien where SoCCCD = '097534950222'

------------Thủ tục/hàm nhân viên----------------
create proc XuatNV
as
select MaNV, HoTenNV, ChucVu, GioiTinh, DiaChi, SoDienThoai, QueQuan, SoCCCD, NgaySinh, TenLoaiNV, NgayVaoLam 
from NhanVien nv, LoaiNV lnv
where nv.MaLoaiNV = lnv.MaLoaiNV

exec XuatNV

create proc XuatNV_GT @GT nvarchar(10)
as
select MaNV, HoTenNV, ChucVu, GioiTinh, DiaChi, SoDienThoai, QueQuan, SoCCCD, NgaySinh, TenLoaiNV, NgayVaoLam 
from NhanVien nv, LoaiNV lnv
where nv.MaLoaiNV = lnv.MaLoaiNV and GioiTinh = @GT

exec XuatNV_GT N'Nữ'

create proc XuatNV_SoCCCD @SoCCCD varchar(30)
as
select MaNV, HoTenNV, ChucVu, GioiTinh, DiaChi, SoDienThoai, QueQuan, SoCCCD, NgaySinh, TenLoaiNV, NgayVaoLam 
from NhanVien nv, LoaiNV lnv
where nv.MaLoaiNV = lnv.MaLoaiNV 
and SoCCCD like '%'+@SoCCCD+'%'

exec XuatNV_SoCCCD '11'

create proc XuatNV_HoTen @hoten nvarchar(30)
as
select MaNV, HoTenNV, ChucVu, GioiTinh, DiaChi, SoDienThoai, QueQuan, SoCCCD, NgaySinh, TenLoaiNV, NgayVaoLam 
from NhanVien nv, LoaiNV lnv
where nv.MaLoaiNV = lnv.MaLoaiNV 
and HoTenNV like N'%'+@hoten+'%'

exec XuatNV_HoTen N'Nga'

create proc XuatNV_LoaiNV @LoaiNV varchar(10)
as
select MaNV, HoTenNV, ChucVu, GioiTinh, DiaChi, SoDienThoai, QueQuan, SoCCCD, NgaySinh, TenLoaiNV, NgayVaoLam 
from NhanVien nv, LoaiNV lnv
where nv.MaLoaiNV = lnv.MaLoaiNV 
and lnv.MaLoaiNV = @LoaiNV

exec XuatNV_LoaiNV 'LNV02'

create proc XuatNV_SDT @SDT varchar(20)
as
select MaNV, HoTenNV, ChucVu, GioiTinh, DiaChi, SoDienThoai, QueQuan, SoCCCD, NgaySinh, TenLoaiNV, NgayVaoLam 
from NhanVien nv, LoaiNV lnv
where nv.MaLoaiNV = lnv.MaLoaiNV 
and SoDienThoai like '%'+ @SDT+'%'

exec XuatNV_SDT '20'

select * from NhanVien

------------Bảng khách hàng----------------
create table KhachHang
(
SoDienThoai		varchar(10),
HoTen			nvarchar(max)	not null,
GioiTinh		nvarchar(10),
DiaChi			nvarchar(max),
constraint		Ck_KH_GT check  (GioiTinh = N'Nam' or GioiTinh = N'Nữ'),
constraint pk_KH_SDT primary key(SoDienThoai)
)

------------Insert Khách Hàng--------------
insert into KhachHang
values
--Số điện thoại			Họ tên		  Giới tính						Địa chỉ
('0589345803',	  N'Đỗ Tuấn An',		N'Nam',		N'12A Chu Tấn,Q.12,P.Minh Kỳ,TP.Hồ Chí Minh'),
('0249345803',	  N'Đào Minh Công',		N'Nam',		null),
('0189345211',	  N'Huyền Minh Ngọc',	N'Nữ',		null),
('0389345844',	  N'Cao Tuấn Tài',		N'Nam',		null),
('0789345867',	  N'Đỗ Huệ Mẫn',		N'Nữ',		null),
('0489345833',	  N'Tố Anh Ngọc',		N'Nữ',		N'167 Tân Ký,Q.03,P.Châu Đức,TP.Hồ Chí Minh'),
('0201345801',	  N'Trần Thái Vũ',		N'Nam',		N'123/52 Tân Định,Q.08,P.Thiên Châu,TP.Hồ Chí Minh'),
('0689345899',	  N'Thiên Nhật Minh',	N'Nam',		null),
('0889345855',	  N'Nguyễn Thái Học',	N'Nam',		null),
('0984045803',	  N'Trần Ánh Linh',		N'Nữ',		N'16B Lũy Bán Bích,Q.12,P.Minh Hòa,TP.Hồ Chí Minh')

select * from KhachHang

update KhachHang set SoDienThoai = '', HoTen = N'', GioiTinh = N'', DiaChi = N'' where SoDienThoai = ''

select HoTen from KhachHang where SoDienThoai = ''

select count(*) from KhachHang where SoDienThoai = ''

select HoTen from KhachHang where SoDienThoai = ''

select GioiTinh from KhachHang where SoDienThoai = ''

select DiaChi from KhachHang where SoDienThoai = ''

------------Bảng tài khoản----------------
create table TaiKhoan
(
TenTK		varchar(100),
MatKhau		varchar(max) not null,
Quyen		nvarchar(50) not null,
MANV		varchar(10),
constraint	pk_TK_TenTK	 primary key(TenTK),
constraint	fk_TK_MANV	 foreign key(MANV) references NhanVien(MANV)
)
------------Bảng Tài Khoản--------------
insert into TaiKhoan
values
--Tài khoản		Mật khẩu		 Quyền		   Mã NV
('NV03',		 '123',			N'User',	  'NV03'),
('NV01',		 '123',			N'Manage',	  'NV01'),
('Admin',		 '123',			N'Admin',	   null),
('NV02',		 '123',			N'Manage',	  'NV02'),
('NV09',		 '123',			N'User',	  'NV09')

select * from TaiKhoan

update TaiKhoan set MatKhau = '' where TenTK = '' 

--------------Hàm/ Thủ tục Tài khoản-----------------

create proc KT_TenTaiKhoan @tentk varchar(10)
as
begin
	select count(*) from TaiKhoan where TenTK = @tentk
end

exec KT_TenTaiKhoan 'Admin'

create proc KT_MatKhau @tentk varchar(10), @MK varchar(max)
as
begin
	select count(*) from TaiKhoan where TenTK = @tentk and MatKhau = @MK
end

exec KT_MatKhau 'Admin', '123'

select Quyen from TaiKhoan where TenTK = 'Admin'

------------Bảng tầng----------------
create table Tang
(
MaTang		varchar(10),
TenTang		nvarchar(30) not null,
constraint	Uni_Tang_TenTang unique(TenTang),
constraint	pk_Tang_MaTang primary key(MaTang)
)

------------Insert Tầng--------------
insert into Tang
values
--Mã tầng		 Tên tầng
('T01',			N'Tầng 01'),
('T02',			N'Tầng 02'),
('T03',			N'Tầng 03')

select * from Tang

------------Bảng bàn----------------
create table Ban
(
MaBan			varchar(10),
TrangThaiBan	nvarchar(30) default N'Trống',
MaTang			varchar(10),
constraint pk_Ban_MaBan	 primary key(MaBan),
constraint fk_Ban_MaTang foreign key(MaTang) references Tang(MaTang)
)

------------Insert Bàn----------------
insert into Ban (MaBan, MaTang)
values
--Mã bàn	Mã tầng
('B101',	'T01'),
('B102',	'T01'),
('B103',	'T01'),
('B104',	'T01'),
('B105',	'T01'),
('B106',	'T01'),
('B107',	'T01'),
('B108',	'T01'),
('B109',	'T01'),
('B110',	'T01'),
('B201',	'T02'),
('B202',	'T02'),
('B203',	'T02'),
('B204',	'T02'),
('B205',	'T02'),
('B206',	'T02'),
('B207',	'T02'),
('B208',	'T02'),
('B209',	'T02'),
('B210',	'T02'),
('B301',	'T03'),
('B302',	'T03'),
('B303',	'T03'),
('B304',	'T03'),
('B305',	'T03'),
('B306',	'T03'),
('B307',	'T03'),
('B308',	'T03'),
('B309',	'T03'),
('B310',	'T03')

select * from Ban

update Ban set TrangThaiBan = N'' where MaBan = ''

select count(*) from Ban where MaBan = 'P101'

--------------Hàm/ Thủ tục Bàn-----------------
create proc XuatBan_Tang @MaTang varchar(10)
as
begin
	select MaBan, TrangThaiBan, TenTang 
	from Ban ba, Tang tg
	where ba.MaTang = tg.MaTang
	and ba.MaTang = @MaTang
end

exec XuatBan_Tang 'T03'

create proc XuatBan_TrangThai @TrangThai nvarchar(10)
as
begin
	select MaBan, TrangThaiBan, TenTang 
	from Ban ba, Tang tg
	where ba.MaTang = tg.MaTang
	and TrangThaiBan = @TrangThai
end

exec XuatBan_TrangThai N'Không trống'

create proc XuatBan_Tang_TrangThai @MaTang varchar(10), @TrangThai nvarchar(10)
as
begin
	select MaBan, TrangThaiBan, TenTang 
	from Ban ba, Tang tg
	where ba.MaTang = tg.MaTang
	and TrangThaiBan = @TrangThai and  ba.MaTang = @MaTang
end

exec XuatBan_Tang_TrangThai 'T02',N'Trống'

------------Bảng loại phòng----------------
create table LoaiPhong
(
MaLoaiPH	varchar(10),
TenLoai		nvarchar(50),
GiaThue		int,
constraint	pk_LoaiPhong_MaLoai primary key(MaLoaiPH)
)

------------Insert Loại Phòng----------------
insert into LoaiPhong
values
--Mã loại	 Tên loại			Giá thuê
('LP01',	N'Phòng Vip',		200000),
('LP02',	N'Phòng Thường',	100000)

select * from LoaiPhong

------------Bảng phòng----------------
create table Phong
(
MaPH		varchar(10),
MaLoaiPH	varchar(10),
TrangThaiPH	nvarchar(30) default N'Trống',
MaTang		varchar(10),
constraint	pk_Phong_MaPH primary key(MaPH),
constraint	fk_Phong_MaLoaiBan foreign key(MaLoaiPH) references LoaiPhong(MaLoaiPH),
constraint	fk_Phong_MaTang foreign key(MaTang) references Tang(MaTang)
)

------------Bảng phòng----------------
insert into Phong (MaPH, MaLoaiPH, MaTang)
values
--Mã phòng	 Mã loại Phòng	  Mã tầng
('P101',		'LP01',		   'T01'),
('P102',		'LP01',		   'T01'),
('P103',		'LP02',		   'T01'),
('P104',		'LP02',		   'T01'),
('P201',		'LP01',		   'T02'),
('P202',		'LP01',		   'T02'),
('P203',		'LP02',	       'T02'),
('P204',		'LP02',		   'T02'),
('P301',		'LP01',		   'T03'),
('P302',		'LP01',		   'T03'),
('P303',		'LP02',		   'T03'),
('P304',		'LP02',		   'T03')

select * from Phong

update Phong set TrangThaiPH = N'' where MaPH = ''

--------------Hàm/ Thủ tục Phòng-----------------

create proc XuatPH_LoaiPH @MaLoai varchar(10)
as
begin
	select MaPH, TenLoai, TrangThaiPH, TenTang 
	from Phong ph, LoaiPhong lph, Tang tg 
	where ph.MaLoaiPH = lph.MaLoaiPH and tg.MaTang = ph.MaTang
	and ph.MaLoaiPH = @MaLoai
end

exec XuatPH_LoaiPH 'LP01'

create proc XuatPH_Tang @MaTang varchar(10)
as
begin
	select MaPH, TenLoai, TrangThaiPH, TenTang
	from Phong ph, Tang tg, LoaiPhong lph 
	where ph.MaLoaiPH = lph.MaLoaiPH and tg.MaTang = ph.MaTang
	and ph.MaTang = @MaTang
end

exec XuatPH_Tang 'T01'

create proc XuatPH_TrangThai @TrangThai nvarchar(50)
as
begin
	select MaPH, TenLoai, TrangThaiPH, TenTang
	from Phong ph, Tang tg, LoaiPhong lph 
	where ph.MaLoaiPH = lph.MaLoaiPH and tg.MaTang = ph.MaTang
	and TrangThaiPH = @TrangThai
end

exec XuatPH_TrangThai N'Trống'

create proc XuatPH_Tang_TrangThai @MaTang varchar(10), @TrangThai nvarchar(50)
as
begin
	select MaPH, TenLoai, TrangThaiPH, TenTang
	from Phong ph, Tang tg, LoaiPhong lph 
	where ph.MaLoaiPH = lph.MaLoaiPH and tg.MaTang = ph.MaTang
	and TrangThaiPH = @TrangThai and ph.MaTang = @MaTang
end 

exec XuatPH_Tang_TrangThai 'T02', N'Trống'

create proc XuatPH_Tang_LoaiPH @MaLoai varchar(10), @MaTang varchar(10)
as
begin
	select MaPH, TenLoai, TrangThaiPH, TenTang
	from Phong ph, Tang tg, LoaiPhong lph 
	where ph.MaLoaiPH = lph.MaLoaiPH and tg.MaTang = ph.MaTang
	and ph.MaLoaiPH = @MaLoai and ph.MaTang = @MaTang
end

exec XuatPH_Tang_LoaiPH 'LP02', 'T03'

create proc XuatPH_LoaiPH_TrangThai @MaLoai varchar(10), @TrangThai nvarchar(50)
as
begin
	select MaPH, TenLoai, TrangThaiPH, TenTang
	from Phong ph, Tang tg, LoaiPhong lph 
	where ph.MaLoaiPH = lph.MaLoaiPH and tg.MaTang = ph.MaTang
	and TrangThaiPH = @TrangThai and ph.MaLoaiPH = @MaLoai
end

exec XuatPH_LoaiPH_TrangThai 'LP01', N'Trống'

create proc XuatPH_LoaiPH_TrangThai_Tang @MaLoai varchar(10), @MaTang varchar(10), @TrangThai nvarchar(50)
as
begin
	select MaPH, TenLoai, TrangThaiPH, TenTang
	from Phong ph, Tang tg, LoaiPhong lph 
	where ph.MaLoaiPH = lph.MaLoaiPH and tg.MaTang = ph.MaTang
	and TrangThaiPH = @TrangThai and ph.MaLoaiPH = @MaLoai
	and  ph.MaTang = @MaTang
end

exec XuatPH_LoaiPH_TrangThai_Tang 'LP01','T03', N'Trống'

------------Bảng loại sản phẩm----------------
create table LoaiSP
(
MaLoaiSP	varchar(10),
TenLoai		nvarchar(100),
constraint	Uni_LoaiSP_TenLoai unique(TenLoai),
constraint	pk_LoaiSP_MaLoaiSP primary key(MaLoaiSP)
)

------------Insert Loại Sản Phẩm--------------
insert into LoaiSP
values
--Mã loại SP		Tên loại
('LSP01',			N'Món xào'),
('LSP02',			N'Món chiên'),
('LSP03',			N'Món hấp'),
('LSP04',			N'Món nướng'),
('LSP05',			N'Món lẩu'),
('LSP06',			N'Món tráng miện'),
('LSP07',			N'Bia/ rượu'),
('LSP08',			N'Nước trái cây'),
('LSP09',			N'Nước trà'),
('LSP10',			N'Nước ngọt'),
('LSP11',			N'Nước lọc')

select * from LoaiSP

------------Bảng sản phẩm----------------
create table SanPham
(
MaSP		varchar(10),
TenSP		nvarchar(200),
MaLoaiSP	varchar(10),
Gia			int,
DonViTinh	nvarchar(30),
LinkHinh	nvarchar(max) default N'None',
constraint	Uni_SP_TenSP   unique(TenSP),
constraint	pk_SP_MaSP	   primary key(MaSP),
constraint	fk_SP_MaLoaiSP foreign key(MaLoaiSP) references LoaiSP(MaLoaiSP)
)

------------Bảng sản phẩm--------------
insert into SanPham(MaSP,TenSP,MaLoaiSP,Gia,DonViTinh)
values
--Mã SP			       Tên SP						Mã loại SP		 Giá	  Đơn vị tính
----------------------------- Xào -------------------------------------------
('SP01',	N'Mì Xào Hải Sản',						'LSP01',		120000,		N'Đĩa'),
('SP02',	N'Mực Xào Chua Ngọt',					'LSP01',		175000,		N'Đĩa'),
('SP03',	N'Tôm Sú Rang Me',						'LSP01',		180000,		N'Đĩa'),
('SP04',	N'Hải Sản Xào Chua Ngọt',				'LSP01',		160000,		N'Đĩa'),
('SP05',	N'Ếch Xào Sa Tế',						'LSP01',		140000,		N'Đĩa'),
--------------------------- Chiên -------------------------------------------
('SP06',	N'Tôm Chiên Xù',						'LSP02',		185000,		N'Đĩa'),
('SP07',	N'Bánh Xếp Nhân Thịt Heo Chiên Giòn',	'LSP02',		135000,		N'Đĩa'),
('SP08',	N'Bánh KOROKKR Nhân Thịt Bò',			'LSP02',		120000,		N'Đĩa'),
('SP09',	N'Cơm Chiên Kim Chi Hải Sản',			'LSP02',		125000,		N'Đĩa'),
('SP10',	N'Cơm Chiên Hải Sản',					'LSP02',		135000,		N'Đĩa'),
--------------------------- Hấp ---------------------------------------------
('SP11',	N'Mực Hấp Rim Mắm Tỏi',					'LSP03',		180000,		N'Đĩa'),
('SP12',	N'Ngao 2 Cồi Hấp Sả',					'LSP03',		160000,		N'Đĩa'),
('SP13',	N'Tôm Càng Xanh Hấp Nước Dừa',			'LSP03',		126000,		N'Đĩa'),
('SP14',	N'Mực Trừng Hấp Gừng',					'LSP03',		245000,		N'Đĩa'),
('SP15',	N'Trứng Đúc Thịt Bò Băm Hấp ',			'LSP03',		120000,		N'Đĩa'),
--------------------------- Nướng --------------------------------------------
('SP16',	N'Tôm Nướng Bơ Tỏi',					'LSP04',		170000,		N'Đĩa'),
('SP17',	N'Mực Nướng Muối Ớt',					'LSP04',		320000,		N'Đĩa'),
('SP18',	N'Cá Lóc Nướng Mỡ Hành',				'LSP04',		280000,		N'Đĩa'),
('SP19',	N'Bạch Tuộc Nướng Sa Tế ',				'LSP04',		360000,		N'Đĩa'),
('SP20',	N'Sò Điệp Nướng Mỡ Hành',				'LSP04',		260000,		N'Đĩa'),
------------------------ Lẩu -------------------------------------------------
('SP21',	N'Lẩu Cua Đồng',						'LSP05',		280000,		N'Lẩu'),
('SP22',	N'Lẩu Gà Ớt Hiểm',						'LSP05',		265000,		N'Lẩu'),
('SP23',	N'Lẩu Hải Sản',							'LSP05',		195000,		N'Lẩu'),
('SP24',	N'Lẩu Hải Sản Thập Cẩm',				'LSP05',		280000,		N'Lẩu'),
('SP25',	N'Lẩu Hải Sản Nấm',						'LSP05',		186000,		N'Lẩu'),
----------------------- Tráng miện -------------------------------------------
('SP26',	N'Bánh Mật Ong',						'LSP06',		46000,		N'Đĩa'),
('SP27',	N'Bánh Phô Mai',						'LSP06',		33000,		N'Đĩa'),
('SP28',	N'Bánh Kem Socola',						'LSP06',		33000,		N'Đĩa'),
('SP29',	N'Bánh Kem Trứng',						'LSP06',		42000,		N'Đĩa'),
('SP30',	N'Bánh Xếp',							'LSP06',		67000,		N'Đĩa'),
------------------- Đồ Uống --------------------------------------------------
('SP31',	N'Bia Tiger',							'LSP07',		29000,		N'Lon'),
('SP32',	N'Rượu Chivas',							'LSP07',		1120000,	N'Chai'),
('SP33',	N'Nước Cam',							'LSP08',		30000,		N'Ly'),
('SP34',	N'Bia Heineken',						'LSP07',		30000,		N'Chai'),
('SP35',	N'Nước Dưa Hấu',						'LSP08',		30000,		N'Ly'),
('SP36',	N'Trà Sen',								'LSP09',		25000,		N'Ly'),
('SP37',	N'Trà Đào',								'LSP09',		25000,		N'Ly'),
('SP38',	N'Sinh Tố Xoài ',						'LSP08',		35000,		N'Ly'),
('SP39',	N'Sinh Tố Đu Đủ',						'LSP08',		35000,		N'Ly'),
('SP40',	N'Trà Bạc Hà',							'LSP09',		30000,		N'Ly'),
('SP41',	N'Trà Lipton',							'LSP09',		25000,		N'Chai'),
('SP42',	N'Nước Khoáng',							'LSP11',		20000,		N'Chai')


select * from SanPham

------------Thủ tục/ Hàm sản phẩm----------------
create proc XuatSP
as
select MaSP, TenSP, TenLoai, Gia, DonViTinh
from SanPham sp, LoaiSP lsp 
where sp.MaLoaiSP = lsp.MaLoaiSP

exec XuatSP

create proc XuatSP_TenSP @TenSP nvarchar(200)
as
select MaSP, TenSP, TenLoai, Gia, DonViTinh
from SanPham sp, LoaiSP lsp 
where sp.MaLoaiSP = lsp.MaLoaiSP
and TenSP like N'%'+@TenSP+'%'

exec XuatSP_TenSP N'Cơm'

create proc XuatSP_LoaiSP @LoaiSP varchar(10)
as
select MaSP, TenSP, TenLoai, Gia, DonViTinh
from SanPham sp, LoaiSP lsp 
where sp.MaLoaiSP = lsp.MaLoaiSP
and lsp.MaLoaiSP = @LoaiSP

exec XuatSP_LoaiSP 'LSP03'

create proc XuatSP_GiaTang
as
select MaSP, TenSP, TenLoai, Gia, DonViTinh
from SanPham sp, LoaiSP lsp 
where sp.MaLoaiSP = lsp.MaLoaiSP
order by Gia asc, TenSP asc

exec XuatSP_GiaTang

create proc XuatSP_GiaGiam
as
select MaSP, TenSP, TenLoai, Gia, DonViTinh
from SanPham sp, LoaiSP lsp 
where sp.MaLoaiSP = lsp.MaLoaiSP
order by Gia desc, TenSP asc

exec XuatSP_GiaGiam

select LinkHinh from SanPham where MaSP = 'SP02'


------------Bảng chọn Bàn----------------
create table ChonBan
(
MaBanChon	 varchar(10),
SoNguoi_Ban	 int default 1,
SDTKhach_Ban varchar(10),
constraint pk_ChonBan_MaBanChon primary key(MaBanChon),
constraint fk_ChonBan_MaBanChon  foreign key(MaBanChon) references Ban(MaBan),
constraint fk_ChonBan_SDTKhach  foreign key(SDTKhach_Ban) references KhachHang(SoDienThoai)
)

select * from ChonBan


------------Bảng chọn Phòng----------------
create table ChonPH
(
MaPHChon	varchar(10),
SoNguoi_PH	int default 1,
SDTKhach_PH	varchar(10),
constraint pk_ChonPH_MaPHChon primary key(MaPHChon),
constraint fk_ChonPH_MaPHChon foreign key(MaPHChon) references Phong(MaPH),
constraint fk_ChonPH_SDTKhach foreign key(SDTKhach_PH) references KhachHang(SoDienThoai)
)

select * from ChonPH

------------Bảng hóa đơn----------------
create table HoaDon
(
MaHD			varchar(10),
SDTKH			varchar(10),
TenTK_HD		varchar(100),
MaBan_Phong		varchar(10),
SoNguoi			int,
ThoiGian		date,
ThanhToan		int default 0,
constraint pk_HD_MaHD	primary key(MaHD),
constraint fk_HD_SDTKH	foreign key(SDTKH) references KhachHang(SoDienThoai),
constraint fk_HD_TenTK_HD	foreign key(TenTK_HD) references TaiKhoan(TenTK),
)

select * from HoaDon

insert into HoaDon(MaHD)
values
('HD01')

select count(*) from HoaDon where MaHD = 'HD01'

delete from ChiTietHD where MaCTHD =''

set dateformat dmy update HoaDon set SDTKH = '0589345803', TenTK_HD ='nv03', MaBan_Phong='P101',SoNguoi=2,ThoiGian='22/12/2022' WHERE MaHD = 'HD02'

select * from HoaDon

select count(*) from HoaDon where ThoiGian is not null and MaHD = 'HD02'

------------Thủ tục/ Hàm Hóa đơn---------------

------------Bảng chi tiết hóa đơn-------------
create table ChiTietHD
(
MaCTHD		varchar(10),
MaSP_CTHD		varchar(10),
SoLuong			int default 0,
TongTien_CTHD	int default 0,
constraint pk_CTHD_MaHD_MaSP primary key(MaCTHD, MaSP_CTHD),
constraint fk_CTHD_MaSP_MaCTHD foreign key(MaCTHD) references HoaDon(MaHD),
constraint fk_CTHD_MaSP foreign key(MaSP_CTHD) references SanPham(MaSP)
)

create proc XuatCTHD @MaHD VARCHAR(10)
as
select TenSP, SoLuong, TongTien_CTHD 
from ChiTietHD cthd, SanPham sp
where cthd.MaSP_CTHD = sp.MaSP
and cthd.MaCTHD = @MaHD

exec XuatCTHD 'HD01'

select * from ChiTietHD

insert into ChiTietHD(MaCTHD,MaSP_CTHD)
values
('HD01','SP01')

insert into ChiTietHD(MaCTHD,MaSP_CTHD)
values
('HD01','SP03')

------------Trigger---------------
create trigger CapNhatTongTien_CTHD on ChiTietHD
for insert, update
as
update ChiTietHD
set TongTien_CTHD = SoLuong * Gia
from ChiTietHD cthd, SanPham sp
where cthd.MaSP_CTHD = sp.MaSP
and MaCTHD = (select MaCTHD from inserted)


------------Thủ tục ThanhToan---------------
create proc CapNhatThanhToan @MaHD varchar(10)
as
update HoaDon
set ThanhToan = 
(select sum(TongTien_CTHD) 
from HoaDon hd, ChiTietHD cthd 
where hd.MaHD = cthd.MaCTHD 
and hd.MaHD = @MaHD)
from HoaDon where MaHD = @MaHD

exec CapNhatThanhToan 'HD03'

select * from HoaDon

----------------------Truy vấn---------------------

select * from LoaiNV

select * from NhanVien

select * from KhachHang

select * from TaiKhoan

select * from SanPham

select * from Ban

select * from LoaiPhong

select * from Phong

select * from HoaDon

select * from ChiTietHD

select * from Tang

select count(*) from TaiKhoan where MANV is null and TenTK = 'NV01'

select MANV from TaiKhoan where TenTK ='NV01'

select HoTenNV from NhanVien where MaNV = 'NV01'

select GioiTinh from NhanVien where MaNV = 'NV01'

select SoDienThoai from NhanVien where MaNV = 'NV01'

select QueQuan from NhanVien where MaNV = 'NV01'

select ChucVu from NhanVien where MaNV = 'NV01'

select Quyen from TaiKhoan where TenTK = 'Admin'

select * from KhachHang where SoDienThoai like '%'+'11'+'%'

select * from KhachHang where HoTen like '%'+N'Ngọc'+'%'

select * from KhachHang where GioiTinh = N'Nữ'

select * from ChiTietHD where MaCTHD = ''


