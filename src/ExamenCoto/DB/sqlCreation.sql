create database Examen;
use Examen;

create table gender(
    genderId int not null primary key,
    label varchar(45)
);

create table person(
    personId int not null primary key,
    firstName varchar(45),
    lastName varchar(45),
    genderId int not null,
    constraint genderId_persona_fk foreign key(genderId) references gender(genderId)
);