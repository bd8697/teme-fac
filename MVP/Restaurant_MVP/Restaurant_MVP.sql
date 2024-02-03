	CREATE DATABASE Restaurant_MVP

GO

USE Restaurant_MVP

GO

GO
CREATE TABLE [dbo].[Categorii] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Title]       VARCHAR (40)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT C_UNIQUE_ID UNIQUE(Id)
);

GO

INSERT INTO [dbo].[Categorii] ([Title]) VALUES (N'mic dejun')
INSERT INTO [dbo].[Categorii] ([Title]) VALUES (N'aperitive')
INSERT INTO [dbo].[Categorii] ([Title]) VALUES (N'supe/ciorbe')
INSERT INTO [dbo].[Categorii] ([Title]) VALUES (N'deserturi')
INSERT INTO [dbo].[Categorii] ([Title]) VALUES (N'bauturi')

GO

GO
CREATE TABLE [dbo].[Preparate] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Denumire]       VARCHAR (40)  NOT NULL,
	[Pret]       INT  NOT NULL,
	[Cantitate]       INT  NOT NULL,
	[Cantitate_Totala]       INT  NOT NULL,
	[Categorie]       VARCHAR (40)  NOT NULL,
	[Alergen]		VARCHAR (40)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT F_UNIQUE_ID UNIQUE(Id)
);

GO

INSERT INTO [dbo].[Preparate] ([Denumire], [Pret], [Cantitate], [Cantitate_totala], [Categorie], [Alergen]) VALUES (N'Salata de varza', 7, 70, 700, N'aperitive', 'gluten')
INSERT INTO [dbo].[Preparate] ([Denumire], [Pret], [Cantitate], [Cantitate_totala], [Categorie], [Alergen]) VALUES (N'Fanta', 5, 50, 10000, N'bauturi', 'gluten')
INSERT INTO [dbo].[Preparate] ([Denumire], [Pret], [Cantitate], [Cantitate_totala], [Categorie], [Alergen]) VALUES (N'Pepsi', 6, 50, 5000, N'bauturi', 'gluten')
INSERT INTO [dbo].[Preparate] ([Denumire], [Pret], [Cantitate], [Cantitate_totala], [Categorie], [Alergen]) VALUES (N'Snitel de pui', 10, 200, 7000, N'aperitive', 'telina')
INSERT INTO [dbo].[Preparate] ([Denumire], [Pret], [Cantitate], [Cantitate_totala], [Categorie], [Alergen]) VALUES (N'Savarina', 15, 100, 1000, N'deserturi', 'lactoza')
INSERT INTO [dbo].[Preparate] ([Denumire], [Pret], [Cantitate], [Cantitate_totala], [Categorie], [Alergen]) VALUES (N'Omleta', 13, 70, 500, N'mic dejun', 'oua')

GO

CREATE TABLE [dbo].[Meniuri_Preparate] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Denumire]       VARCHAR (300)  NOT NULL,
	[Pret]       VarCHar(300)  NOT NULL,
	[Cantitate]       VARCHAR (300)  NOT NULL,
	[Cantitate_Totala]       VARCHAR(300)  NOT NULL,
	[Categorie]       VARCHAR (40)  NOT NULL,
	[Alergen]		VARCHAR (40)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT L_UNIQUE_ID UNIQUE(Id)
);

GO

INSERT INTO [dbo].[Meniuri_Preparate] ([Denumire], [Pret], [Cantitate], [Cantitate_totala], [Categorie], [Alergen]) VALUES (N'Salata de varza, snitel, cartofi', N'60 (10 + 20 + 30)', N'900 (300 + 300 + 300)', N'900 (300 + 300 + 300)', N'aperitive', 'gluten')
INSERT INTO [dbo].[Meniuri_Preparate] ([Denumire], [Pret], [Cantitate], [Cantitate_totala], [Categorie], [Alergen]) VALUES (N'budinca valilie, shake cocos, clatite finetti', N'70 (20 + 20 + 30)', N'300 (100 + 100 + 100)', N'900 (300 + 300 + 300)', N'deserturi', 'lactoza')
INSERT INTO [dbo].[Meniuri_Preparate] ([Denumire], [Pret], [Cantitate], [Cantitate_totala], [Categorie], [Alergen]) VALUES (N'fish, chips', N'30 (15 + 15)', N'500 (250 + 250)', N'900 (300 + 300 + 300)', N'aperitive', 'gluten')
INSERT INTO [dbo].[Meniuri_Preparate] ([Denumire], [Pret], [Cantitate], [Cantitate_totala], [Categorie], [Alergen]) VALUES (N'mere + pere', N'60 (30 + 40)', N'600 (300 + 400)', N'900 (300 + 300 + 300)', N'mic dejun', 'polen')
INSERT INTO [dbo].[Meniuri_Preparate] ([Denumire], [Pret], [Cantitate], [Cantitate_totala], [Categorie], [Alergen]) VALUES (N'savarina, omleta, avocado', N'50 (10 + 20 + 20)', N'900 (300 + 300 + 300)', N'900 (300 + 300 + 300)', N'aperitive', 'gluten')

GO

CREATE TABLE [dbo].[Alergeni] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Denumire]       VARCHAR (40)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT X_UNIQUE_ID UNIQUE(Id)
);

GO

INSERT INTO [dbo].[Alergeni] ([Denumire]) VALUES (N'gluten')
INSERT INTO [dbo].[Alergeni] ([Denumire]) VALUES (N'oua')
INSERT INTO [dbo].[Alergeni] ([Denumire]) VALUES (N'lactoza')
INSERT INTO [dbo].[Alergeni] ([Denumire]) VALUES (N'polen')
INSERT INTO [dbo].[Alergeni] ([Denumire]) VALUES (N'telina')

GO

-- Create a sequence
CREATE SEQUENCE seq
    START WITH 3786
    INCREMENT BY 97 ;
GO


GO
CREATE TABLE [dbo].[Comenzi] (
    [Id]        INT IDENTITY (1,1) NOT NULL,
    [Cod]      INT NOT NULL DEFAULT (NEXT VALUE FOR seq),
	[Client]	VARCHAR(100)  NOT NULL,
	[Continut]      VARCHAR(1000)  NOT NULL,
	[Pret]		INT NOT NULL,
	[Stare]       VARCHAR(50)  NOT NULL,
	[Data]       VARCHAR(50)  NOT NULL,
	[Ora_Livrare]       VARCHAR(50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT H_UNIQUE_ID UNIQUE(Id)
);

GO

INSERT INTO [dbo].[Comenzi] ([Client], [Continut], [Pret], [Stare], [Data], [Ora_Livrare]) VALUES (N'Virorica Dancila', N'2*supa crema de ciuperci, 1*platoutaranesc, 2*capucino', 234, 'livrata', N'6/19/2016', N'05:50 AM')
INSERT INTO [dbo].[Comenzi] ([Client], [Continut], [Pret], [Stare], [Data], [Ora_Livrare]) VALUES (N'Deaconu Adrian', N'10 * pepsi', 123, 'anulata', N'7/12/2017', N'09:09 AM')
INSERT INTO [dbo].[Comenzi] ([Client], [Continut], [Pret], [Stare], [Data], [Ora_Livrare]) VALUES (N'Sasu Lucian', N'3 * pizza party', 11, 'se pregateste', N'12/12/2012', N'12:12 PM')
INSERT INTO [dbo].[Comenzi] ([Client], [Continut], [Pret], [Stare], [Data], [Ora_Livrare]) VALUES (N'Domnu Florea', N'1 * gin, 1 * bere, 1 * vin, 1 * apa minerala', 999, 'inregistrata', N'01/01/2001', N'01:51 AM')
INSERT INTO [dbo].[Comenzi] ([Client], [Continut], [Pret], [Stare], [Data], [Ora_Livrare]) VALUES (N'B.S.', N'two number 9s, a number 9 large, a number 6 with extra dip, a number 7, two number 45s, one with cheese, and a large soda.', 6547, 'inregistrata', N'04/04/2004', N'04:44 AM')

GO

CREATE TABLE [dbo].[Conturi] (
    [Id]        INT IDENTITY (1,1) NOT NULL,
    [Nume]      VARCHAR(50)  NOT NULL,
	[Prenume]      VARCHAR(50)  NOT NULL,
	[e_mail]      VARCHAR(50)  NOT NULL,
	[Numar_telefon]      VARCHAR(15)  NOT NULL,
	[Adresa]      VARCHAR(300)  NOT NULL,
	[Parola]      VARCHAR(50)  NOT NULL,
	[Tip_cont]    BIT  NOT NULL, -- 0 = client, 1 = angajat
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT J_UNIQUE_ID UNIQUE(Id)
);

GO

INSERT INTO [dbo].[Conturi] ([Nume], [Prenume], [e_mail], [Numar_telefon], [Adresa], [Parola], [Tip_Cont]) VALUES (N'Virorica', N'Dancila', N'v.dan@hotmail.com', N'0724321202', N'Strada Lunga 14, Brasov, 500058', 'viorica4ever', 0)
INSERT INTO [dbo].[Conturi] ([Nume], [Prenume], [e_mail], [Numar_telefon], [Adresa], [Parola], [Tip_Cont]) VALUES (N'Deaconu', N'Adrian', N'a.deac@hotmail.com', N'0722345202', N'STR. BELOESCU S. nr. 1 bl. M1-4 sc. A Ap. 3, BÂRLAD, 731139', '.', 0)
INSERT INTO [dbo].[Conturi] ([Nume], [Prenume], [e_mail], [Numar_telefon], [Adresa], [Parola], [Tip_Cont]) VALUES (N'Sasu', N'Lucian', N'lmsasu@hotmail.com', N'0721212121', N'Bulevardul Pache Protopopescu 111, Bucuresti 2', 'lmsasu', 0)
INSERT INTO [dbo].[Conturi] ([Nume], [Prenume], [e_mail], [Numar_telefon], [Adresa], [Parola], [Tip_Cont]) VALUES (N'Domnu', N'Florea', N'florea@hotmail.com', N'0724321111', N'STR. PRINCIPALĂ nr. 38, BUZIAŞ', 'fl', 1)
INSERT INTO [dbo].[Conturi] ([Nume], [Prenume], [e_mail], [Numar_telefon], [Adresa], [Parola], [Tip_Cont]) VALUES (N'Ilinca', N'Maniu', N'i.man@gmail.com', N'07062391388', N'STR. MAIORESCU TITU nr. 6 bl. ARCADIA et 3, IAŞI, 700460', 'i.man', 1)

GO

CREATE PROCEDURE [dbo].[addRecordinCategorii]
	@pTitle varchar(40)

AS
	INSERT INTO Categorii (Title) VALUES (@pTitle);

GO

CREATE PROCEDURE [dbo].[addRecordinPreparate]
	@pDenumire varchar(40),
	@pPret int,
	@pCantitate int,
	@pCantitate_Totala int,
	@pCategorie VARCHAR(100),
	@pAlergen VARCHAR(100)
AS
	INSERT INTO Preparate (Denumire, Pret, Cantitate, Cantitate_Totala, Categorie, Alergen) VALUES (@pDenumire, @pPret, @pCantitate, @pCantitate_Totala, @pCategorie, @pAlergen);

GO

CREATE PROCEDURE [dbo].[addRecordinMeniuri_Preparate]
	@pDenumire varchar(300),
	@pPret varchar(300),
	@pCantitate varchar(300),
	@pCantitate_Totala varchar(300),
	@pCategorie VARCHAR(100),
	@pAlergen VARCHAR(100)
AS
	INSERT INTO Meniuri_Preparate (Denumire, Pret, Cantitate, Cantitate_Totala, Categorie, Alergen) VALUES (@pDenumire, @pPret, @pCantitate, @pCantitate_Totala, @pCategorie, @pAlergen);

GO


CREATE PROCEDURE [dbo].[addRecordinConturi]
	@pNume varchar(40),
	@pPrenume varchar(40),
	@pE_mail varchar(40),
	@pTelefon varchar(40),
	@pAdresa varchar(40),
	@pParola varchar(40),
	@pTip_cont BIT
AS
	INSERT INTO Conturi (Nume, Prenume, e_mail, Numar_telefon, Adresa, Parola, Tip_cont) VALUES (@pNume, @pPrenume, @pE_mail, @pTelefon, @pAdresa, @pParola, @pTip_cont);

GO

CREATE PROCEDURE [dbo].[addRecordinComenzi]
	@pClient VARCHAR(100),
	@pContinut VARCHAR(1000),
	@pPret INT,
	@pStare VARCHAR(50),
	@pData VARCHAR(50),
	@pOra_Livrare VARCHAR(50)
AS
	INSERT INTO Comenzi (Client, Continut, Pret, Stare, Data, Ora_livrare) VALUES (@pClient, @pContinut, @pPret, @pStare, @pData, @pOra_livrare);

GO


CREATE PROCEDURE dbo.[retRecords]
	@TitlePhrase varchar(40)
AS
	declare @param VARCHAR(40)
	set @param = '%' + @TitlePhrase + '%' 

	SELECT * FROM Movie WHERE Title LIKE @param;

GO

CREATE PROCEDURE dbo.[retRecordsinPreparate]
	@TitlePhrase varchar(40)
AS
	declare @param VARCHAR(40)
	set @param = '%' + @TitlePhrase + '%' 

	SELECT * FROM Preparate WHERE Denumire LIKE @param;

GO

CREATE PROCEDURE dbo.[retRecordsinMeniuri_Preparate]
	@TitlePhrase varchar(300)
AS
	declare @param VARCHAR(300)
	set @param = '%' + @TitlePhrase + '%' 

	SELECT * FROM Meniuri_Preparate WHERE Denumire LIKE @param;

GO

CREATE PROCEDURE dbo.[retRecordsinCategorii]
	@TitlePhrase varchar(40)
AS
	declare @param VARCHAR(40)
	set @param = '%' + @TitlePhrase + '%' 

	SELECT * FROM Categorii WHERE Title LIKE @param;

GO

CREATE PROCEDURE dbo.[retRecordsinConturi]
	@TitlePhrase varchar(40)
AS
	declare @param VARCHAR(40)
	set @param = '%' + @TitlePhrase + '%' 

	SELECT * FROM Conturi WHERE e_mail LIKE @param;

GO

CREATE PROCEDURE dbo.[retRecordsinComenzi]
	@TitlePhrase varchar(40)
AS
	declare @param VARCHAR(40)
	set @param = '%' + @TitlePhrase + '%' 

	SELECT * FROM Comenzi WHERE Client LIKE @param;

GO

CREATE PROCEDURE [dbo].[deleteRecordinPreparate]
	@pID int
AS
	DELETE Preparate
	WHERE id = @pID;

GO

CREATE PROCEDURE [dbo].[deleteRecordinCategorii]
	@pID int
AS
	DELETE Categorii
	WHERE id = @pID;

GO

CREATE PROCEDURE [dbo].[deleteRecordinMeniuri_Preparate]
	@pID int
AS
	DELETE Meniuri_Preparate
	WHERE id = @pID;

GO


CREATE PROCEDURE [dbo].[deleteRecordinConturi]
	@pID int
AS
	DELETE Conturi
	WHERE id = @pID;

GO

CREATE PROCEDURE [dbo].[deleteRecordinComenzi]
	@pID int
AS
	DELETE Comenzi
	WHERE id = @pID;

GO

CREATE PROCEDURE [dbo].[updateRecordinPreparate]
	@pID int,
	@pDenumire varchar(40),
	@pPret int,
	@pCantitate int,
	@pCantitate_Totala int,
	@pCategorie VARCHAR(100),
	@pAlergen VARCHAR(100)
AS
	UPDATE Preparate
	SET Denumire = @pDenumire, Pret = @pPret, Cantitate = @pCantitate, Cantitate_Totala = @pCantitate_Totala, Categorie = @pCategorie, Alergen = @pAlergen
	WHERE id = @pID;

GO

CREATE PROCEDURE [dbo].[updateRecordinMeniuri_Preparate]
	@pID int,
	@pDenumire varchar(300),
	@pPret varchar(300),
	@pCantitate varchar(300),
	@pCantitate_Totala varchar(300),
	@pCategorie VARCHAR(100),
	@pAlergen VARCHAR(100)
AS
	UPDATE Meniuri_Preparate
	SET Denumire = @pDenumire, Pret = @pPret, Cantitate = @pCantitate, Cantitate_Totala = @pCantitate_Totala, Categorie = @pCategorie, Alergen = @pAlergen
	WHERE id = @pID;

GO


CREATE PROCEDURE [dbo].[updateRecordinConturi]
	@pID INT,
	@pNume varchar(40),
	@pPrenume varchar(40),
	@pE_mail varchar(40),
	@pTelefon varchar(40),
	@pAdresa varchar(40),
	@pParola varchar(40),
	@pTip_cont BIT
AS
	UPDATE Conturi
	SET Nume = @pNume, Prenume = @pPrenume, e_mail = @pE_mail, Numar_telefon = @pTelefon, Adresa = @pAdresa, Parola = @pParola, Tip_cont = @pTip_cont
	WHERE id = @pID;

GO

CREATE PROCEDURE [dbo].[updateRecordinComenzi]
	@pID INT,
	@pCod INT,
	@pClient varchar(40),
	@pContinut varchar(1000),
	@pPret INT,
	@pStare varchar(40),
	@pData varchar(40),
	@pOra_Livrare varchar(40)

AS
	UPDATE Comenzi
	SET Cod = @pCod, Client = @pClient, Continut = @pContinut, Pret = @pPret, Stare = @pStare, Data = @pData, Ora_Livrare = @pOra_Livrare
	WHERE id = @pID;

GO