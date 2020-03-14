create database OICAR
go
use OICAR
go
create table StavkaJelovnika(
	IDStavkaJelovnika int primary key identity(1,1),
	Naziv nvarchar(100),
	Cijena smallmoney
)
go

create table Jelovnik(
	IDJelovnik int primary key identity(1,1),
	Dnevni bit,
	Specijalni bit
)
go
create table Jelovnik_Stavke(
	IDJelovnik_Stavke int primary key identity(1,1),
	JelovnikID int foreign key references Jelovnik(IDJelovnik),
	StavkaJelovnika int foreign key references StavkaJelovnika(IDStavkaJelovnika)
)
go
create table Geopoint
(
    IDGeopoint bigint NOT NULL primary key identity(1,1), 
    Latitude float NOT NULL, 
    Longitude float NOT NULL, 
    ts rowversion NOT NULL, 
    GeographyPoint  AS (geography::STGeomFromText(((('POINT('+CONVERT(varchar(20),Longitude))+' ')+CONVERT(varchar(20),Latitude))+')',(4326))) 
)
go
create table Adresa(
	IDAdresa int primary key identity(1,1),
	Drzava nvarchar(100),
	Grad nvarchar(100),
	Ulica nvarchar(100),
	KucniBroj nvarchar(100),
	PostanskiBroj int null
)
go
create table Restoran(
	IDRestoran int primary key identity(1,1),
	telefon nvarchar(50),
	JelovnikID int foreign key references Jelovnik(IDJelovnik),
	AdresaID int foreign key references Adresa(IDAdresa),
	GeopointID bigint foreign key references Geopoint(IDGeopoint)
)