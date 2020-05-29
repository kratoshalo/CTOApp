using System;
using System.Collections.Generic;
using System.Text;

namespace CTOApp.Model
{
    public class CarteraModel
    {
        public int idOficina { get; set; }
        public string geograficoestructuraNombre { get; set; }
        public int socioId { get; set; }
        public string Grupo { get; set; }
        public string Cliente { get; set; }
        public string Telefono { get; set; }
        public string actividadeconomicaNombre { get; set; }
        public string Pagare { get; set; }
        public string Contrato { get; set; }
        public DateTime FDesembolso { get; set; }
        public DateTime FVencimiento { get; set; }
        public string Periodo { get; set; }
        public decimal TInteres { get; set; }
        public decimal TMoratoria { get; set; }
        public decimal Monto { get; set; }
        public decimal Capital { get; set; }
        public decimal Interes { get; set; }
        public decimal Moratorios { get; set; }
        public int DiasMora { get; set; }
        public string Estado { get; set; }
        public string Renegociado { get; set; }
        public string tipocreditoNombre { get; set; }
        public DateTime FCorte { get; set; }
    }
}
