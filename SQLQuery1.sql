CREATE DATABASE ArchiveDB
go
use ArchiveDB

go

create table Type_Documents_Stagiaire(
Nom_Doc_Type varchar(60) primary key not null
)

go

create table Type_Documents_PV(
Nom_Type_PV varchar(60) primary key not null
)

go

create table Filiere(
ID_Filiere INT identity(1,1) primary key not null,
Nom_Filiere varchar(60)
)

go

create table Annee_Etude(
ID_Annee INT identity(1,1) primary key not null,
Session_Etude varchar(60)
)

go

create table Groupe(
ID_Groupe INT identity(1,1) primary key not null,
Nom_Groupe varchar(60),
ID_Filiere INT foreign key references Filiere(ID_Filiere) ON UPDATE CASCADE
)

go

create table Stagiaire(
CIN varchar(20) primary key not null,
CNE nvarchar(60) unique,
Nom varchar(60),
Prenom varchar(60),
Sexe nvarchar(60),
Date_Naissance nvarchar(60)
)

go

create table Stagiaire_Groupe_Session(
CIN varchar(20) foreign key references Stagiaire(CIN) on delete cascade on update cascade,
ID_Groupe INT foreign key references Groupe(ID_Groupe),
ID_Annee INT foreign key references Annee_Etude(ID_Annee),
Chemin_Stagiaire varchar(110),
primary key(CIN,ID_Groupe,ID_Annee)
)

go

create table Documents_Stagiaire(
ID_Doc_Stagiaire INT identity(1,1) primary key not null,
Nom_Doc_Type varchar(60) foreign key references Type_Documents_Stagiaire(Nom_Doc_Type) on update cascade,
Document_Stagiaire image,
Chemin_Stagiaire varchar(110),
CIN varchar(20) foreign key references Stagiaire(CIN) on delete cascade on update cascade
)

go

create table Documents_PV(
ID_PV INT identity(1,1) primary key not null,
Nom_Type_PV varchar(60) foreign key references Type_Documents_PV(Nom_Type_PV),
Document_PV image,
Chemin_PV varchar(110),
ID_Groupe int foreign key references Groupe(ID_Groupe),
ID_Annee INT foreign key references Annee_Etude(ID_Annee)
)

go

-------------------------------------------Table Stagiaire_Groupe_Annee --------------------------------------
Create trigger Chemin_Stagiaire on Stagiaire_Groupe_Session for insert,update as
begin
declare @stagiaire NVARCHAR(50),@Annee nvarchar(50),@Filiere nvarchar(50),@id int,@Groupe Nvarchar(50)
SELECT distinct @Stagiaire = Stagiaire.Nom+' '+ Stagiaire.Prenom,@Annee = Annee_Etude.Session_Etude,@Filiere = Filiere.Nom_Filiere,@Groupe = Groupe.Nom_Groupe
FROM            inserted INNER JOIN
                         Groupe ON inserted.ID_Groupe = Groupe.ID_Groupe INNER JOIN
                         Filiere ON Groupe.ID_Filiere = Filiere.ID_Filiere INNER JOIN
                         Annee_Etude ON inserted.ID_Annee = Annee_Etude.ID_Annee INNER JOIN
                         Stagiaire ON inserted.CIN = Stagiaire.CIN

update Stagiaire_Groupe_Session set Chemin_Stagiaire='Archive/Documents Stagiaire/'+@Annee +'/' + @Filiere+'/'+@Groupe + '/' + @stagiaire where CIN = (select CIN from inserted) AND ID_Groupe = (select ID_Groupe from inserted) AND ID_Annee = (select ID_Annee from inserted) 
end

go
-------------------------------------------------------Table Documents_Stagiaire ----------------------------------------------
Create trigger Chemin_Documents_Stagiaire on Documents_Stagiaire for insert,update as
begin
declare @Chemin VARCHAR(101),@Annee nvarchar(50),@Filiere nvarchar(50),@id int
SELECT distinct @Chemin = Stagiaire_Groupe_Session.Chemin_Stagiaire
FROM            Stagiaire INNER JOIN
                         Stagiaire_Groupe_Session ON Stagiaire.CIN = Stagiaire_Groupe_Session.CIN INNER JOIN
                         Inserted ON Stagiaire.CIN = inserted.CIN

update Documents_Stagiaire set Chemin_Stagiaire=@Chemin where ID_Doc_Stagiaire = (select ID_Doc_Stagiaire from inserted)
end
---------------------------------------------------Table Documents_PV ----------------------------------------------------
go

Create trigger Chemin_Documents_PV on Documents_PV for insert,update as
begin
declare @group NVARCHAR(50),@Annee nvarchar(50),@Filiere nvarchar(50),@id int
SELECT distinct @group = Groupe.Nom_Groupe,@Annee =Annee_Etude.Session_Etude,@Filiere = Filiere.Nom_Filiere
FROM            Groupe INNER JOIN
                         Filiere ON Groupe.ID_Filiere = Filiere.ID_Filiere INNER JOIN
                         inserted ON Groupe.ID_Groupe = inserted.ID_Groupe INNER JOIN
                         Annee_Etude ON inserted.ID_Annee = Annee_Etude.ID_Annee

update Documents_PV set Chemin_PV='Archive/PV/'+@Annee +'/' + @Filiere + '/' + @group where ID_PV = (select ID_PV from inserted)
end

go

------------------------------------------------------------------------
create proc Affectation as begin 
SELECT top 10 Stagiaire.CIN, Stagiaire.Nom, Stagiaire.Prenom, Groupe.Nom_Groupe as Groupe, Annee_Etude.Session_Etude  as Session
FROM Annee_Etude INNER JOIN Stagiaire_Groupe_Session ON Annee_Etude.ID_Annee = Stagiaire_Groupe_Session.ID_Annee INNER JOIN
 Stagiaire ON Stagiaire_Groupe_Session.CIN = Stagiaire.CIN INNER JOIN
 Groupe ON Stagiaire_Groupe_Session.ID_Groupe = Groupe.ID_Groupe
end
go
Create proc AffectationSearch (@CIN varchar(20)) as begin 
SELECT top 10 Stagiaire.CIN, Stagiaire.Nom, Stagiaire.Prenom, Groupe.Nom_Groupe as Groupe, Annee_Etude.Session_Etude  as Session
FROM Annee_Etude INNER JOIN Stagiaire_Groupe_Session ON Annee_Etude.ID_Annee = Stagiaire_Groupe_Session.ID_Annee INNER JOIN
 Stagiaire ON Stagiaire_Groupe_Session.CIN = Stagiaire.CIN INNER JOIN
 Groupe ON Stagiaire_Groupe_Session.ID_Groupe = Groupe.ID_Groupe WHERE Stagiaire.CIN like @CIN +'%'
end
go
create proc GroupeDGV as begin 
Select top 10 Groupe.ID_Groupe as ID,Groupe.Nom_Groupe as 'Nom de Groupe',Filiere.Nom_Filiere as 'Filière' from Groupe inner join Filiere on Groupe.ID_Filiere=Filiere.ID_Filiere order by Groupe.ID_Groupe desc
end
go
create proc GroupeDGVSearch(@Groupe varchar(60)) as begin 
Select top 10 Groupe.ID_Groupe as ID,Groupe.Nom_Groupe as 'Nom de Groupe',Filiere.Nom_Filiere as 'Filière' from Groupe inner join Filiere on Groupe.ID_Filiere=Filiere.ID_Filiere
WHERE Groupe.Nom_Groupe like @Groupe + '%'
end
go

create proc DocStag as begin 
SELECT TOP 10 Documents_Stagiaire.ID_Doc_Stagiaire as 'ID', Documents_Stagiaire.Nom_Doc_Type as 'Nom de document', Stagiaire.Nom +' '+ Stagiaire.Prenom as 'Stagiaire'
FROM Documents_Stagiaire INNER JOIN Stagiaire ON Documents_Stagiaire.CIN = Stagiaire.CIN ORDER BY Documents_Stagiaire.ID_Doc_Stagiaire DESC
end

go

create proc DocStagSearch(@CIN varchar(20),@CNE varchar(40)) as begin 
SELECT Documents_Stagiaire.ID_Doc_Stagiaire as 'ID', Documents_Stagiaire.Nom_Doc_Type as 'Nom de document', Stagiaire.Nom +' '+ Stagiaire.Prenom as 'Stagiaire'
FROM Documents_Stagiaire INNER JOIN Stagiaire ON Documents_Stagiaire.CIN = Stagiaire.CIN where Stagiaire.CIN like @CIN or Stagiaire.CNE like @CNE
end

go

create proc DocPV as begin 
SELECT TOP 10 Documents_PV.ID_PV as 'ID', Documents_PV.Nom_Type_PV as 'Type de PV', Groupe.Nom_Groupe as 'Groupe', Annee_Etude.Session_Etude as 'Session'
FROM Annee_Etude INNER JOIN Documents_PV ON Annee_Etude.ID_Annee = Documents_PV.ID_Annee INNER JOIN Groupe ON Documents_PV.ID_Groupe = Groupe.ID_Groupe ORDER BY Documents_PV.ID_PV  DESC
end

go

create proc DocPVSearch(@Annee varchar(40),@Groupe varchar(40)) as begin 
SELECT Documents_PV.ID_PV as 'ID', Documents_PV.Nom_Type_PV as 'Type de PV', Groupe.Nom_Groupe as 'Groupe', Annee_Etude.Session_Etude as 'Session'
FROM Annee_Etude INNER JOIN Documents_PV ON Annee_Etude.ID_Annee = Documents_PV.ID_Annee INNER JOIN Groupe ON Documents_PV.ID_Groupe = Groupe.ID_Groupe
WHERE Annee_Etude.ID_Annee = @Annee and Groupe.ID_Groupe = @Groupe
end

--------------------------------------------------------------Procedure of chart ---------------------------------------------------------------------

create proc ChartFiller as 
begin
SELECT       Filiere.Nom_Filiere as 'Filiere',COUNT(Documents_Stagiaire.ID_Doc_Stagiaire) as 'Documents'
FROM            Documents_Stagiaire INNER JOIN
                         Stagiaire_Groupe_Session ON Documents_Stagiaire.CIN = Stagiaire_Groupe_Session.CIN INNER JOIN
                         Groupe ON Stagiaire_Groupe_Session.ID_Groupe = Groupe.ID_Groupe INNER JOIN
                         Filiere ON Groupe.ID_Filiere = Filiere.ID_Filiere INNER JOIN
                         Stagiaire ON Documents_Stagiaire.CIN = Stagiaire.CIN AND Stagiaire_Groupe_Session.CIN = Stagiaire.CIN group by Filiere.Nom_Filiere
end