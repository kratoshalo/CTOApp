using System;
using System.Collections.Generic;
using System.Text;

namespace CTOApp.Model
{
    public class CreditosModel
    {
        public int socioId { get; set; }
        public string CONTRATO { get; set; }
        public string PAGARE { get; set; }
        public string FDESEMBOLSO { get; set; }
        public string FVENCIMIENTO { get; set; }
        public decimal MONTO { get; set; }
        public string CREDITOANTERIOR { get; set; }
        public string TASAINTERES { get; set; }
        public string TASAMORATORIA { get; set; }
        public decimal CAPITAL { get; set; }
        public decimal INTERES { get; set; }
        public decimal MORATORIOS { get; set; }
        public int DIASMORA { get; set; }
        public string ESTATUS { get; set; }
        public string RENEGOCIADO { get; set; }
        public string FCORTE { get; set; }
        public decimal SALDO { get; set; }
        public string ProductoNombre { get; set; }
        public string tipopldorigenNombre { get; set; }
        public string tipoplddestinoNombre { get; set; }
        public string image { get; set; }
    }
}
