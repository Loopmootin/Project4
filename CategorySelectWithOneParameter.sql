CREATE PROCEDURE [dbo].[MoviesDatabase] 
	@genre_id int
AS
BEGIN
	SET NOCOUNT ON;

    SELECT [dbo].movies.movie_id, [dbo].movies.movie_name, [dbo].movies.movie_release, [dbo].genre.genre_type 
	FROM [dbo].movies, [dbo].genre 
		WHERE genre.id = movies.genre_id AND genre.id = @genre_id;

END