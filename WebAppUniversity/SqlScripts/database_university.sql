create database University
use University

-- Tables creating
create table Faculty
(
    Id int identity(1,1) constraint PK_Faculty primary key,
    Name nvarchar(50),
    Dean nvarchar(50)
)

create table Class
(
    Id int identity(1,1) constraint PK_Class primary key,
    Name nvarchar(10),
    FacultyId int constraint FK_Class_Faculty references Faculty(Id)
	ON DELETE CASCADE
)

create table Student
(
    Id int identity(1,1) constraint PK_Student primary key,
    Surname nvarchar(25),
    Name nvarchar(25),
    Patronymic nvarchar(25),
    Age int,
    ClassId int constraint FK_Student_Class references Class(Id)
	ON DELETE CASCADE
)
