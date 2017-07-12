CREATE PROCEDURE [dbo].[CINETV_Pelicula_S] 
@Id AS INT
AS
BEGIN
	SELECT Id AS Id,
			Fecha AS Fecha,
			Hora AS Hora,
			Título AS Título,
			Cadena AS Cadena,
			Genero AS Genero,
			Calificacion AS Calificacion,
			Sinopsis AS Sinopsis 
	FROM PeliculaTB 

	WHERE (Id = @Id OR @Id IS NULL)
	  
END;