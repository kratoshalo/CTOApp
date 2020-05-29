using System;
using System.Collections.Generic;
using System.Text;

namespace CTOApp.Model
{
    public class NoticiasModel
    {
		public int idSNoticiaDetalle { get; set; }
		public int idSeccionNoticia { get; set; }

		public string tituloNoticia { get; set; }

		public string noticiaDetalle { get; set; }

		public string nombreArchivo { get; set; }

		public int Activo { get; set; }

		public DateTime Fecha { get; set; }
	}
}
