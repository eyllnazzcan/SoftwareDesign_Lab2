create table CapitalDTO(
NameofCity varchar(300),
Country varchar(300),
Population int
);

insert into CapitalDTO(NameofCity, Country, Population) values ('Paris', 'France', '2000000');
insert into CapitalDTO(NameofCity, Country, Population) values ('Ankara', 'Turkey', '5500000');

select * from CapitalDTO;

create table Capital(
CapitalId serial,
Area int,
OfficialLanguage varchar(300),
NameofCity varchar(300),
Country varchar(300),
Population int
);

insert into Capital(Area, OfficialLanguage, NameofCity, Country, Population)
values           ('105', 'French', 'Paris', 'France', '2000000');
insert into Capital(Area, OfficialLanguage, NameofCity, Country, Population)
values           ('24521', 'Turkish', 'Ankara', 'Turkey', '5500000');

select * from Capital;