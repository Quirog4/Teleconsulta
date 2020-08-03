using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _1_CapaPresentacionGM.Models.Reportes
{
    public class FAT_AtencionPDF : FAT_General
    {
        public string cAnamnesis { get; set; }
        public string cMotivo { get; set; }
        public string cTratamiento { get; set; }
        public string cReceta { get; set; }
        public string lstRadiologia { get; set; }
        public string lstLaboratorio { get; set; }

        public FAT_AtencionPDF() { }
        public FAT_AtencionPDF(string re, string trat, string mot, string anam)
        {
            this.titulo = "Formato de Atención de Telemonitoreo";
            this.cReceta = re;
            this.cAnamnesis = anam;
            this.cTratamiento = trat;
            this.cMotivo = mot;
        }

       

        public void listarLab(List<ServiciosFATModel> lst)
        {
            string lista = (lst.Count != 0) ? "<table><thead><tr><th width=\"110\">C&oacute;digo</th><th width=\"260\">Descripci&oacute;n </th><th>Observaci&oacute;n </th></tr></thead><tbody>" : "--";
            foreach (ServiciosFATModel d in lst)
            {
                lista += "<tr>"
                    + "<td>" + d.codigo + "</td>"
                    + "<td>" + d.descripcion + "</td>"
                    + "<td>" + d.observaciones + "</td></tr>";
            }
            lista += "</tbody></table>";
            this.lstLaboratorio = lista;
        }

        public void listarRx(List<ServiciosFATModel> lst)
        {
            string lista = (lst.Count!=0)? "<table><thead><tr><th width=\"110\">C&oacute;digo</th><th width=\"260\">Descripci&oacute;n </th><th>Observaci&oacute;n </th></tr></thead><tbody>" : "--";
            foreach (ServiciosFATModel d in lst)
            {
                lista += "<tr>"
                    + "<td>" + d.codigo + "</td>"
                    + "<td>" + d.descripcion + "</td>"
                    + "<td>" + d.observaciones + "</td></tr>";
            }
            lista += "</tbody></table>";
            this.lstRadiologia = lista;
        }

    }
}
