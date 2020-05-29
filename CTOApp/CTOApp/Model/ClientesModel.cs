using System;
using System.Collections.Generic;
using System.Text;

namespace CTOApp.Model
{
    public class ClientesModel
    {
        public int socioId { get; set; }
        public int geograficoestructuraId { get; set; }
        public string geograficoestructuraNombre { get; set; }
        public int personalidadjuridicaId { get; set; }
        public string Cliente { get; set; }
        public string RepLegal { get; set; }
        public string socioFNacimiento { get; set; }
        public int socioEdad { get; set; }
        public string tipoestadocivilNombre { get; set; }
        public string socioSexo { get; set; }
        public string tipoidentificacionNombre { get; set; }
        public string socioIFE { get; set; }
        public string socioRFC { get; set; }
        public string socioSerieCFEA { get; set; }
        public string socioCURP { get; set; }
        public string personalidadjuridicaNombre { get; set; }
        public string actividadeconomicaNombre { get; set; }
        public string tiponacionalidadNombre { get; set; }
        public string socioFJuridica { get; set; }
        public string socioOcupacionGiro { get; set; }
        public string socioEmail { get; set; }
        public int socioAntiguedad { get; set; }
        public string LugarNacimiento { get; set; }
        public string PaisNacimiento { get; set; }
        public string Direccion { get; set; }
        public string sociodomicilioReferencia { get; set; }
        public string sociodomicilioTelefono { get; set; }
        public string socioConyugeNombre { get; set; }
        public int socioConyugeId { get; set; }
        public string socioFVigencia { get; set; }
        public int socioRelId { get; set; }
        public string socioRelacionadoTipo { get; set; }
        public string ClienteRelacionado { get; set; }
        public string PPE { get; set; }
        public string gradoRiesgo { get; set; }
        public int creditosActivos { get; set; }
        public string lpBloqueadas { get; set; }
        public string NoEscritura { get; set; }
        public string FolioEscritura { get; set; }
        public string NoNotario { get; set; }
        public string NotarioNombre { get; set; }
        public string NotarioEntidad { get; set; }
    }
}
