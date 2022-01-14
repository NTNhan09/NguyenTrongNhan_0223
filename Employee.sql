create database HR
go
use HR

create table Employee_0223
(
IdEmployee int primary key, 
Name nvarchar(255), 
DateBirth nvarchar(255), 
Gender bit, 
PlaceBirth nvarchar(255), 
IdDepartment char(5)
)

go 
create table Department_0223(
IdDepartment char(5) primary key,
Name nvarchar(255)
)

go
insert into Employee_0223 values('53418',N'Trần Tín', '11/10/2000', 1,N'Hà Nội', 'IT')
go
insert into Employee_0223 values('53416', N'Nguyễn Cường', '21/07/1996', 0, N'Đak Lak', 'KT')
go
insert into Employee_0223 values('53417', N'Nguyễn Hào', '25/12/1996', 1, N'TP.Hồ Chí Minh', 'KSNB')

go
insert into Department_0223 values('IT', N'Công Nghệ Thông Tin')
insert into Department_0223 values('KT', N'Kế toán')
insert into Department_0223 values('KSNB', N'Kiểm soát nội bộ')


select*from Employee_0223
select*from Department_0223

