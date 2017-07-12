CREATE PROCEDURE [dbo].[CINETV_Pelicula_U] 
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
	UPDATE PeliculaTB 
			SET
			Fecha = @Fecha,
				Hora = @Hora,
				Título = @Título,
				Cadena = @Cadena,
				Genero = @Genero,
				Calificacion = @Calificacion,
				Sinopsis = @Sinopsis
			WHERE Id = @Id
			  
END;