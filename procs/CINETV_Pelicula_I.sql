CREATE PROCEDURE [dbo].[CINETV_Pelicula_I] 
@Id AS INT,
	@Fecha AS DATETIME,
	@Hora AS DATETIME,
	@Título AS CHAR(50),
	@Cadena AS CHAR(50),
	@Genero AS CHAR(50),
	@Calificacion AS INT,
	@Sinopsis AS TEXT
AS
BEGIN
	INSERT INTO PeliculaTB 
			(Id,
			Fecha,
			Hora,
			Título,
			Cadena,
			Genero,
			Calificacion,
			Sinopsis)
			VALUES(@Id,
			@Fecha,
			@Hora,
			@Título,
			@Cadena,
			@Genero,
			@Calificacion,
			@Sinopsis) 
END;