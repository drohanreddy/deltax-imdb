USE DeltaX;

CREATE TABLE MovieActors
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	ActorID INT NOT NULL,
	MovieID INT NOT NULL
);