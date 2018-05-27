USE DeltaX;

CREATE TABLE Producer
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL,
	Sex CHAR(1) NOT NULL,
	DOB DATE NOT NULL,
	Bio VARCHAR(2000),
	ImageFileName VARCHAR(100),
	CONSTRAINT CHK_SEX_PRODUCER CHECK (SEX = 'M' OR SEX = 'F')
);