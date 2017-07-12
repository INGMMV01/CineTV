using System;
using System.Collections.Generic;
using System.Text;

using HtmlAgilityPack;

using ingmmv01.infr.ecc;
	
namespace CineTV.Pelicula
{
	
	public class CPelicula: CECC
	{
		#region Declaraciones
				
		int _intId;	
		DateTime _datFecha;	
		String _datHora;	
		string _strTítulo;	
		string _strCadena;	
		string _strGenero;	
		int? _intCalificacion;	
		string _strSinopsis;	
		
		#endregion
		
		#region Constructor
		
		public CPelicula()
		{			
		}

        public CPelicula(HtmlNode nodo): base()
        {
            asignaFechaHora(nodo);            
            this.Título = nodo.SelectSingleNode("h3/a").InnerText;
            this.Cadena = nodo.SelectSingleNode("p[@class = 'channel-name']").InnerText;
            string genero = nodo.SelectSingleNode("p[@class = 'type']").InnerText;
            this.Genero = genero.Substring(5);
            asignaCalificacion(nodo);
            this.Sinopsis = "http://sincroguia.tv" + nodo.SelectSingleNode("a/@href").GetAttributeValue("href", ""); ;
        }

        #endregion

        #region Procedimientos Almacenados
        /*
		protected override string QueryRefresh
		{
			get { return "CINETV_Pelicula_S"; }
		}
		*/
        protected override string spInsert
		{
			get { return "CINETV_Pelicula_I"; }
		}

        protected override string spUpdate
		{
			get { return "CINETV_Pelicula_U"; }
		}

        protected override string spDelete
      	{
			get { return "CINETV_Pelicula_D"; }
		}
		
		#endregion
		
		#region Propiedades ECC
		
		public override string ClaveObjeto
		{
			get { return _intId.ToString(); }
		}
		
		
		public int Id
		{
			get { return _intId; }
			set
			{
				base.SetPropiedadECC();
				_intId = value;
			}
		}
	
		public DateTime Fecha
		{
			get { return _datFecha; }
			set
			{
				base.SetPropiedadECC();
				_datFecha = value;
			}
		}
	
		public String Hora
		{
			get { return _datHora; }
			set
			{
				base.SetPropiedadECC();
				_datHora = value;
			}
		}
	
		public string Título
		{
			get { return _strTítulo; }
			set
			{
				base.SetPropiedadECC();
				_strTítulo = value;
			}
		}
	
		public string Cadena
		{
			get { return _strCadena; }
			set
			{
				base.SetPropiedadECC();
				_strCadena = value;
			}
		}
	
		public string Genero
		{
			get { return _strGenero; }
			set
			{
				base.SetPropiedadECC();
				_strGenero = value;
			}
		}
	
		public int? Calificacion
		{
			get { return _intCalificacion; }
			set
			{
				base.SetPropiedadECC();
				_intCalificacion = value;
			}
		}
	
		public string Sinopsis
		{
			get { return _strSinopsis; }
			set
			{
				base.SetPropiedadECC();
				_strSinopsis = value;
			}
		}

        #endregion

        #region Métodos

        private void asignaFechaHora(HtmlNode nodo)
        {            
            string fechaHora = nodo.SelectSingleNode("p[@class = 'chapter-date']").InnerText;
            string[] arrayFH = fechaHora.Split('-');
            string fecha = arrayFH[0];

            int dia = 1;
            int mes = 1;
            try
            {
                dia = Convert.ToInt16(fecha.Split(' ')[0]);

                switch (fecha.Split(' ')[2])
                { 
                    case "Enero":
                        mes = 1;
                        break;
                    case "Febrero":
                        mes = 2;
                        break;
                    case "Marzo":
                        mes = 3;
                        break;
                    case "Abril":
                        mes = 4;
                        break;
                    case "Mayo":
                        mes = 5;
                        break;
                    case "Junio":
                        mes = 6;
                        break;
                    case "Julio":
                        mes = 7;
                        break;
                    case "Agosto":
                        mes = 8;
                        break;
                    case "Septiembre":
                        mes = 9;
                        break;
                    case "Octubre":
                        mes = 10;
                        break;
                    case "Noviembre":
                        mes = 11;
                        break;
                    case "Diciembre":
                        mes = 12;
                        break;
                }

                this.Fecha = new DateTime(DateTime.Now.Year, mes, dia);
            }
            catch
            {
                this.Fecha = DateTime.Now;
            }

            this.Hora = arrayFH[1];                          
        }

        private void asignaCalificacion(HtmlNode nodo)
        {
            int suma = 0;

            string sentenciaXPathBase = "p/span[@class = 'rating stars*']";
            string sentenciaXPath;

            HtmlNodeCollection col = null;
            
            for (int i=1;i<=5;i++)
            {
                sentenciaXPath = sentenciaXPathBase.Replace("*",i.ToString());
                col = nodo.SelectNodes(sentenciaXPath);
                if (null != col)
                    suma += col.Count * i;
            }

            this.Calificacion = suma;            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Fecha: " + this.Fecha.ToString() + "\r\n");
            sb.Append("Hora: " + this.Hora.ToString() + "\r\n");
            sb.Append("Titulo: " + this.Título.ToString() + "\r\n");
            sb.Append("Cadena: " + this.Cadena.ToString() + "\r\n");
            sb.Append("Genero: " + this.Genero.ToString() + "\r\n");
            sb.Append("Calificación : " + this.Calificacion.ToString() + "\r\n");
            //sb.Append("Sinopsis: " + this.Sinopsis.ToString() + "\r\n");

            return sb.ToString();
        }

        #endregion

    }
}
