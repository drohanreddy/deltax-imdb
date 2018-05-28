CREATE PROCEDURE usp_UpdateMovieDetails (
	 @MovieID INT
	,@MovieName NVARCHAR(100)
	,@YearOfRelease DATETIME
	,@Plot VARCHAR(5000)
	,@PosterFileName VARCHAR(100)
	,@ActorsCSV VARCHAR(200)
	,@ProducerID INT
	)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION

		UPDATE DeltaX.dbo.Movie
		SET Name = @MovieName
			,PosterFileName = @PosterFileName
			,Plot = @Plot
			,YearOfRelease = @YearOfRelease
			,Producer = @ProducerID
		WHERE Id = @MovieID

		DELETE
		FROM DeltaX.dbo.MovieActors
		WHERE MovieID = @MovieID

		IF (
				@ActorsCSV IS NOT NULL
				AND LEN(@ActorsCSV) > 0
				)
		BEGIN
			INSERT INTO MovieActors (MovieID,ActorID)
			SELECT @MovieID
				,CAST(value AS INT)
			FROM string_split(@ActorsCSV, ',')
		END

		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END