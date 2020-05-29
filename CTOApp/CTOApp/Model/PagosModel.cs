using System;
using System.Collections.Generic;
using System.Text;

namespace CTOApp.Model
{
    public class PagosModel
    {
        public string creditopagareNumero { get; set; }
        public string fichaFecha { get; set; }
        public string fichaFAutoriza { get; set; }
        public string fichaIEfectivo { get; set; }
        public string fichaICheque { get; set; }
        public string fichaITransfer { get; set; }
        public string fichaITotal { get; set; }
        public string Moneda { get; set; }
    }
}
