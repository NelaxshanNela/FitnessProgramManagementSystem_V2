create database FitnessProgramManagement;

create table FitnessPrograms (
FitnessProgramId int primary key,
Title nvarchar(20),
Duration nvarchar (20),
Price decimal
);

insert into FitnessPrograms(FitnessProgramId, Title, Duration, Price) values
(1, 'YOGA', '2 months', 10.00);

select * from FitnessPrograms;
