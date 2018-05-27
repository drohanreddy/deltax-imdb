USE DeltaX;
GO 
CREATE PROCEDURE usp_GetAllMovieData
AS
BEGIN
	SELECT M.Id AS MovieID
		,M.Name AS MovieName
		,YEAR(M.YearOfRelease) AS YearOfRelease
		,M.PosterFileName AS MoviePoster
		,P.Id AS ProducerID
		,P.Name AS ProducerName
	FROM DeltaX.dbo.Movie M
	INNER JOIN DeltaX.dbo.PRODUCER P ON P.Id = M.Producer
END