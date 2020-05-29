using CTOApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTOApp.ViewModel
{
    public class VMCartera
    {
        public List<CarteraModel> listaGOficina = new List<CarteraModel>();

        public List<pickerOficina> listaOficina()
        {
            List<pickerOficina> lista = new List<pickerOficina>();

            var query = listaGOficina.Select(x => new { x.idOficina, x.geograficoestructuraNombre }).Distinct().ToList();

            lista.Add(new pickerOficina() { key = 0, value = "TODAS" });

            foreach (var item in query)
            {
                pickerOficina oficina = new pickerOficina();
                oficina.key = item.idOficina;
                oficina.value = item.geograficoestructuraNombre;
                lista.Add(oficina);
            }

            return lista;
        }


    }

    public class pickerOficina
    {
        public int key { get; set; }
        public string value { get; set; }
    }

}
