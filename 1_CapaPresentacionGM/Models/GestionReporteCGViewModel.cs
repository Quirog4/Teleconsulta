using _1_CapaPresentacionGM.Models.Mapper;
using _2_CapaServiciosGM.InterfaceGM;
using _2_CapaServiciosGM.ServiciosGM;
using NReco.PdfGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace _1_CapaPresentacionGM.Models
{

    public class ArchivoModel
    {
        public int idArchivo { get; set; }
        public byte[] pdf { get; set; }
        public string codSolicitud { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Origen { get; set; }
        public bool verWeb { get; set; }

        public ArchivoModel()
        {
            this.pdf = null;
            this.codSolicitud = "";
            this.Nombre = "";
            this.Tipo = "";
            this.Origen = "";
        }
    }

    public class GenerarReporteCGViewModel
    {
    
        public ArchivoModel archivo;
        protected string rutaImagen;
        protected string rutaArchivo;
        public GenerarReporteCGViewModel(){ }

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
          (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public List<ArchivoModel> getArchivoxSolicitud(string nrosolicitud, bool isAuditor)
        {
            List<ArchivoModel> archivos = new List<ArchivoModel>();
            IArchivosCGService service = new ArchivosCGService();
            var archivosDTO = service.archivos(0, nrosolicitud, isAuditor);
            archivos = DTOToModel.getArchivos(archivosDTO);
            return archivos;
        }

        public void getArchivo(int i, string codsolicitud)
        {
            this.archivo = new ArchivoModel();
            IArchivosCGService service = new ArchivosCGService();
            var arc = service.Archivo(i, codsolicitud);
            this.archivo = DTOToModel.ArchivoModel(arc);
        }

        public void getReporteiq(string codsolicitud)
        {
            this.archivo = new ArchivoModel();
            IArchivosCGService service = new ArchivosCGService();
            var archivo = service.reporteIQxBackoffice(codsolicitud);
            this.archivo = DTOToModel.ArchivoModel(archivo);
        }


        public void getCartaAuditor(int id, string codsolicitud)
        {
            this.archivo = new ArchivoModel();
            IArchivosCGService service = new ArchivosCGService();
            var archivo = service.cartaAuditor(id, codsolicitud);
            this.archivo = DTOToModel.ArchivoModel(archivo);
        }

        public byte[] generarCARTAGARANTIAPLANSALUDAUDITOR(string rutaPlantilla, object data)
        {

            try
            {
                if (!string.IsNullOrEmpty(rutaPlantilla) && File.Exists(rutaPlantilla))
                {
                    var htmlToPdf = new HtmlToPdfConverter();

                    string plantillaHtml = string.Empty;
                    //  htmlToPdf.PageHeaderHtml = "<div style = 'text-align: right;'> HEADER <span class = 'page'> </span> of <span class = 'topage'> </span> </div>";
                   

                    using (StreamReader reader = new StreamReader(rutaPlantilla))
                    {
                        plantillaHtml = reader.ReadToEnd();
                        reader.Close();
                    }

                    if (data != null)
                    {
                        foreach (var propertyInfo in data.GetType()
                               .GetProperties(
                                       BindingFlags.Public
                                       | BindingFlags.Instance))
                        {
                            string nombre = propertyInfo.Name;
                            string valor = propertyInfo.GetValue(data, null) == null ? string.Empty : propertyInfo.GetValue(data, null).ToString();
                            plantillaHtml = plantillaHtml.Replace("{{" + nombre + "}}", valor);

                        }
                    }

                    return htmlToPdf.GeneratePdf(plantillaHtml, null);

                    //  File.WriteAllBytes(rutaPdfGenerado, dataBytes);

                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        // generar imagenes
        public byte[] generarReporte(string rutaPlantilla, string rutaPlantillaHeader, object data,string footer)
        {

            try
            {
                if (!string.IsNullOrEmpty(rutaPlantilla) && File.Exists(rutaPlantilla))
                {
                    var htmlToPdf = new HtmlToPdfConverter();

                    string plantillaHtmlHeader = string.Empty;
                    string plantillaHtml = string.Empty;
                    
                    using (StreamReader reader = new StreamReader(rutaPlantilla))
                    {
                        plantillaHtml = reader.ReadToEnd();
                        reader.Close();
                    }

                    using (StreamReader reader = new StreamReader(rutaPlantillaHeader))
                    {
                        plantillaHtmlHeader = reader.ReadToEnd();
                        reader.Close();
                    }

                    if (data != null)
                    {
                        foreach (var propertyInfo in data.GetType()
                               .GetProperties(
                                       BindingFlags.Public
                                       | BindingFlags.Instance))
                        {
                            string nombre = propertyInfo.Name;
                            string valor = propertyInfo.GetValue(data, null) == null ? 
                                string.Empty : 
                                propertyInfo.GetValue(data, null).ToString().Replace("\n","<br/>")
                                .Replace("á","&aacute;").Replace("é", "&eacute;").Replace("í", "&iacute;").Replace("ó", "&oacute;").Replace("ú", "&uacute;")
                                .Replace("Á", "&aacute;").Replace("É", "&eacute;").Replace("Í", "&iacute;").Replace("Ó", "&oacute;").Replace("Ú", "&uacute;")
                                .Replace("Ñ", "&ntilde;").Replace("ñ", "&ntilde")
                                ;
                            plantillaHtml = plantillaHtml.Replace("{{" + nombre + "}}", valor);
                            plantillaHtmlHeader = plantillaHtmlHeader.Replace("{{" + nombre + "}}", valor);

                        }
                    }

                    htmlToPdf.PageHeaderHtml = plantillaHtmlHeader;
                    htmlToPdf.PageFooterHtml =(!string.IsNullOrEmpty(footer))?footer: "<div style=\"font-size: 11px; border-top:1px solid grey;font-family:Arial, Helvetica, sans-serif;letter-spacing:1pt;padding:15px 12px\">Clínica Ricardo Palma           RENIPRESS: 00009409</div>";
                    return htmlToPdf.GeneratePdf(plantillaHtml, null);
                }
            }
            catch (Exception e)
            {
                log.Error("ERROR MOSTRANDO REPORTE FAT__"+e.Source+"___"+e.ToString());
            }
            return null;
        }
    }
}