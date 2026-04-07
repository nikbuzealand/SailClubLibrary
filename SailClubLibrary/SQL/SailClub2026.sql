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