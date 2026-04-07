use SailClub2026
go

--Drop tables
drop table bookings
drop table members
drop table boats

--Create tables
create table boats
(
	boatID int not null identity(1,1) primary key,
	boatTypeEnumID int not null,
	boatModel varchar(50) not null,
	boatSailNumber varchar(50) not null,
	boatEngineInfo varchar(200) not null,
	boatDraft decimal not null,
	boatWidth decimal not null,
	boatLength decimal not null,
	boatYearOfConstruction varchar(4) not null,
);

create table members
(
	memberID int not null identity(1,1) primary key,
	memberFirstName varchar(50) not null,
	memberSurName varchar(50) not null,
	memberPhoneNumber varchar(50) not null,
	memberAddress varchar(50) not null,
	memberCity varchar(50) not null,
	memberMail varchar(50) not null,
	memberTypeEnumID int not null,
	memberRoleEnumID int not null,
);

create table bookings
(
	bookingID int not null identity(1,1) primary key,
	bookingStartDate datetime not null,
	bookingEndDate dateTime not null,
	bookingDestination varchar(50) not null,
	
	bookingTheMemberID int foreign key references members(memberID) not null,
	bookingTheBoatID int foreign key references boats(boatID) not null,
);

--Fill tables
insert into boats values(0,'Model','16-3335','Is very good :3',32,23,33,'1982');
insert into boats values(6,'Model','17-8767','Fast :3',34,25,17,'2000');

insert into members values('Peter','Jensen','23456789','Gaden 1','Hillerød','PH@gamil.com',2,1);
insert into members values('Charlotte','Hansen','65345890','Street 1','Roskilde','ch@gamil.com',1,0);

insert into bookings values(getdate(),getdate(),'Boathouse',1,1);

--View tables
select * from boats
select * from members
select * from bookings;