using System;
using System.Collections.Generic;
using System.Text;

using ingmmv01.infr.ecc;

namespace CineTV.Pelicula
{
	public class EngPelicula : EngECC<CPelicula>
	{
		public static ColECC<CPelicula> ColNueva()
		{
            return EngECC<CPelicula>.NuevaColeccionECC(); 
		}
		
		public static ColECC<CPelicula> ObtenerPelicula(int? pId)
		{			
			const string spSelect = "CINETV_Pelicula_S";
			object[] spParameters = new object[1];
					spParameters[0] = pId;
			
			return ObtenerColeccionECC(spSelect, spParameters);
		}
	}
}