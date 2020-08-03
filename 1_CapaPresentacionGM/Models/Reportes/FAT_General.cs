using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace _1_CapaPresentacionGM.Models.Reportes
{
    public class FAT_General : Header
    {
        public string cNombreMedico { get; set; }
        public string cEspecialidadMedico { get; set; }
        public string cCMP { get; set; }
        public string cRNE { get; set; }
        public string cOAA { get; set; }
        public string dFecTele { get; set; }
        public string cNroFat { get; set; }
        public string cNombrePaciente { get; set; }
        public string nEdaad { get; set; }
        public string cSeguro { get; set; }
        public string cSexo { get; set; }
        public string cDNI { get; set; }
        public string cHC { get; set; }
        public string fechaCierre { get; set; }
        public string codigoFinanciador { get; set; }
        public string codigoCentroTrabajo { get; set; }
        public string descripcionCentroTrabajo { get; set; }
        public string numeroRegistro { get; set; }
        public string lstDiagnostico { get; set; }
        public string cfirma { get; set; }


        public void datosMedico(string nomed, string especialidad, string cmp, string rne, string ft, string nf, string fi, byte[] firma)
        {
            this.cCMP = cmp;
            this.cRNE = rne;
            this.cNombreMedico = nomed;
            this.dFecTele = ft;
            this.cNroFat = nf;
            this.cSeguro = fi;
            this.cEspecialidadMedico = especialidad;
            string firm;
            try
            {
                firm = "<div class=\"firma\" style=\"text-align:center; padding-top:25px; font-weight:bold\">" +
              "<img src=\"data:image;charset=utf-8;base64," + Convert.ToBase64String(firma) + "\" width=\"200\" style=\"margin-bottom:10px\"/><br/>" +
               "</div> ";
            }
            catch (Exception e)
            {
                firm = "";
            }
            this.cfirma = firm;
        }

        public void datosPaciente(string np, string e, string s, string dn, string hc, string oaa, string fechaCierre, string codigoFinanciador, string codigoCentroTrabajo, string descripcionCentroTrabajo, string numeroRegistro)
        {
            this.cNombrePaciente = np;
            this.nEdaad = e;
            this.cSexo = s;
            this.cDNI = dn;
            this.cHC = hc;
            this.cOAA = oaa;
            this.fechaCierre = fechaCierre;
            this.codigoFinanciador = codigoFinanciador;
            this.codigoCentroTrabajo = codigoCentroTrabajo;
            this.descripcionCentroTrabajo = descripcionCentroTrabajo;
            this.numeroRegistro = numeroRegistro;
        }

        public string listaSimple(List<ServiciosFATModel> data)
        {
            string lista = "";
            foreach (ServiciosFATModel s in data)
            {

                lista += s.codigo + " | ";
                lista += s.descripcion;
                lista += (string.IsNullOrEmpty(s.observaciones)) ? "" : "  (" + s.observaciones + ")";
                lista += "<br/>";
            }
            return lista;
        }
        public string listarReceta(List<MedicinasModel> medicinas)
        {
            string lista = (medicinas.Count != 0) ? "<table><thead>" +
                "<tr style=\"page-break-inside: avoid\">" +
                    "<th width=\"250\">DESCRIPCION</th>" +
                    "<th width=\"60\">CANTIDAD A DISPENSAR</th>" +
                    "<th width=\"90\">POSOLOGÍA</th>" +
                    "<th width=\"50\">DURACION</th>" +
                    "<th width=\"75\">VIA</th>" +
                    "<th width=\"90\">OBSERVACION</th>" +
                "</tr></thead><tbody>" : "";
            foreach (MedicinasModel m in medicinas)
            {
                lista += "<tr style=\"page-break-inside: avoid\">"
                    + "<td>" + "<div style=\"font-weight:bold; text-decoration:underline; width:100%;margin-bottom:3px\">" + m.PrincipioActivo + " </div>" + //"<br>" +
                               m.DescripcionProducto + "</td>"
                    + "<td style=\"text-align:center\">" + m.Cantidad + "</td>"
                    + "<td style=\"text-align:center\">";
                lista += (string.IsNullOrEmpty(m.dosisdesc)) ? m.Dosis : m.dosisdesc;
                lista += "</td>"
                    + "<td style=\"text-align:center\">" + m.Intervalo + "</td>"
                    + "<td style=\"text-align:center\">";
                lista += (string.IsNullOrEmpty(m.Viadesc)) ? m.Via : m.Viadesc;
                lista += "</td>"
                + "<td>" + m.Observacion + "</td>";
                lista += "</tr>";
            }
            lista += "</tbody></table>";
            return lista;

        }
        public void listarDX(List<DiagnosticosModel> dx)
        {
            string lista = (dx.Count == 0) ? "" : "<table><thead><tr><th width=\"110\">CIE-10</th><th>Diagn&oacute;stico </th><th width=\"110\">Tipo</th></tr></thead><tbody>";
            foreach (DiagnosticosModel d in dx)
            {
                lista += "<tr>"
                    + "<td>" + d.Codigo + "</td>"
                    + "<td>" + d.Detalle + "</td>"
                    + "<td>";
                lista += (d.Tipo == "P") ? "PRESUNTIVO" :
                    (d.Tipo == "D") ? "DEFINITIVO" :
                    (d.Tipo == "R") ? "REPETIVO" : d.Tipo;
                lista += "</td></tr>";
            }
            lista += "</tbody></table>";
            this.lstDiagnostico = lista;
        }


    }
}