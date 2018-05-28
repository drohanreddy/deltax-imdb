CREATE PROCEDURE usp_AddMovieDetails (
	@MovieName NVARCHAR(100)
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

		DECLARE @ID INT;

		INSERT INTO Movie
		(
		   [Name]
		  ,[YearOfRelease]
		  ,[Plot]
		  ,[PosterFileName]
		  ,[Producer]
		)
		VALUES (
			 @MovieName
			,@YearOfRelease
			,@Plot
			,@PosterFileName			
			,@ProducerID
			)

		SET @ID = (
				SELECT SCOPE_IDENTITY()
				)

		IF (
				@ActorsCSV IS NOT NULL
				AND LEN(@ActorsCSV) > 0
				)
		BEGIN
			INSERT INTO MovieActors (
				MovieID
				,ActorID
				)
			SELECT @ID
				,CAST(value AS INT)
			FROM string_split(@ActorsCSV, ',')
		END

		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END