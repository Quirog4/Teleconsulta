using _1_CapaPresentacionGM.Models.Mapper;
using _1_CapaPresentacionGM.Models.Reportes;
using _2_CapaServiciosGM.InterfaceGM;
using _2_CapaServiciosGM.ServiciosGM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_CapaPresentacionGM.Models
{
    public class ObservacionesAuditorModel
    {
        public string oMedica { get; set; }
        public string oInterna { get; set; }
        public string estadoAuditado { get; set; }
        public FiltroModel motivoEstado { get; set; }
        public int codsolicitud { get; set; }
        public string tipoCarta { get; set; }
        public string departamento { get; set; }
        public string importeAuditor { get; set; }
        public string diagnosticoAuditor { get; set; }
        public List<string> procedimientoAuditor { get; set; }
    }

    public class AuditarCGViewModel
    {
        public CartaGarantiaModel carta;
        public List<FiltroModel> selEstado;
        public List<lstCartaGarantiaModel> cartas;
        public List<FiltroModel> lstTipoAtencion;
        public List<FiltroModel> selMotivo;

        public bool auditarCarta(ObservacionesAuditorModel auditoria, string usuario, string equipo,
             List<BeneficioModel> beneficios, string[] procedimientos,
            CGAuditoriaPLANSALUD cartaPDF, string ruta)
        {
            ICartaGarantiaService service = new CartaGarantiaService();
            GenerarReporteCGViewModel reportes = new GenerarReporteCGViewModel();
            ArchivoModel archivo = new ArchivoModel();
            archivo.codSolicitud = cartaPDF.nrosolicitud;
            archivo.idArchivo = auditoria.codsolicitud;
            string estado = cartaPDF.estadoCG.ToUpper();
            int ind = cartaPDF.estadoCG.Length - 1;
            var codEstado = Int32.Parse(auditoria.estadoAuditado);
            if (beneficios == null)
            {
                beneficios = new List<BeneficioModel>();
            }
            var beneficio = beneficios.Where(x => x.isForzado == true).FirstOrDefault();
            if (beneficio == null)
            {
                beneficio = beneficios.Where(x => x.seleccionado == true).FirstOrDefault();
            }
            if (codEstado == 213 || codEstado == 214)
            {

                if (estado[ind] == 'R')
                {
                    estado = "";
                    for (int i = 0; i < ind; i++)
                    {
                        estado += cartaPDF.estadoCG[i];
                    }
                    estado += "DO";
                }
                else
                {
                    estado = cartaPDF.estadoCG;
                }
                cartaPDF.estadoCG = estado.ToUpper();
                var impTotal = Convert.ToDouble(auditoria.importeAuditor);
                impTotal = impTotal + impTotal * 0.18;
                cartaPDF.importe = impTotal.ToString("0.##");
                cartaPDF.fechaRegistro = DateTime.Now.ToString();
                cartaPDF.preexistencias = cartaPDF.preexistencias ?? "Ninguna";

                if (beneficio != null)
                {
                        var cpv = Convert.ToDouble(beneficio.copagovariable.Trim());
                        cartaPDF.cargopaciente = (100.00 - cpv).ToString() + "%";
                        cartaPDF.deducible = beneficio.copagofijo.Trim();
                        cartaPDF.cobertura = beneficio.cobertura;
                    
                }
                else
                {
                    cartaPDF.cargopaciente = "--";
                }
                cartaPDF.importe = (cartaPDF.importe != "" || cartaPDF.importe == null) ?
                                   "S/. " + cartaPDF.importe : "S/. 0 ";
                var now = DateTime.Now;
                cartaPDF.diaRegistro = now.ToString("dddd dd");
                cartaPDF.mesRegistro = now.ToString("MMMM");
                cartaPDF.anioRegistro = now.Year.ToString();
                var dx = cartaPDF.diagnostico.Split('-');

                if (!string.IsNullOrEmpty(cartaPDF.diagnostico) && dx != null)
                {
                    if (dx.Length == 2)
                    {
                        cartaPDF.diagnostico = dx[1].TrimStart();
                    }
                }
                cartaPDF.obsmedicas = auditoria.oMedica;
                archivo.pdf = reportes.generarCARTAGARANTIAPLANSALUDAUDITOR(ruta, cartaPDF);
            }
            auditoria.procedimientoAuditor = new List<string>();
            if (procedimientos != null)
            {
                foreach (string p in procedimientos)
                {
                    if (string.IsNullOrEmpty(p))
                        continue;
                    auditoria.procedimientoAuditor.Add(p);
                }
            }
            bool aud = service.auditarCarta(auditoria.importeAuditor, auditoria.procedimientoAuditor, ModelDTO.beneficioDTO(beneficio),
               auditoria.oMedica, auditoria.estadoAuditado, auditoria.oInterna, auditoria.diagnosticoAuditor,
                  usuario, equipo, auditoria.motivoEstado.codigo, ModelDTO.archivoDTO(archivo), auditoria.departamento);
            return aud;
        }

        public void getCarta(int nroSolicitud, string departamento)
        {
            ICartaGarantiaService service = new CartaGarantiaService();
            this.carta = new CartaGarantiaModel();
            this.carta = DTOToModel.CartaGarantiaPSModel(service.getCarta(nroSolicitud, departamento));
        }

        public bool anularCarta(ObservacionesAuditorModel auditoria, string usuario, string equipo, string codsolicitud, int idsolicitud)
        {
            ICartaGarantiaService service = new CartaGarantiaService();
            ArchivoModel archivo = new ArchivoModel();
            archivo.codSolicitud = codsolicitud;
            archivo.idArchivo = idsolicitud;
            bool aud = service.auditarCarta(auditoria.importeAuditor, auditoria.procedimientoAuditor, null,
               auditoria.oMedica, auditoria.estadoAuditado, auditoria.oInterna, auditoria.diagnosticoAuditor,
                  usuario, equipo, auditoria.motivoEstado.codigo, ModelDTO.archivoDTO(archivo), auditoria.departamento);
            return aud;
        }

        public void listadoCartas(String busqueda, string fechaini, string fecfin, string tipoAt, string codestado)
        {
            ICartaGarantiaService service = new CartaGarantiaService();
            this.cartas = new List<lstCartaGarantiaModel>();
            this.cartas = DTOToModel.listarCartasGarantiaServicio(
                                service.bandejaCartasAuditor(busqueda, tipoAt, fechaini, fecfin, codestado)
                                );
        }

        public void eliminaProcedimiento(string codsolicitud, string codprocedimiento)
        {
            ICartaGarantiaService cartaserv = new CartaGarantiaService();
            cartaserv.eliminaProcedimiento(codsolicitud, codprocedimiento);
        }


        public List<BeneficioModel> listaBeneficiosPS(string term)
        {
            IConsultaPlanSaludService service = new ConsultaPlanSaludService();
            return DTOToModel.listarBeneficios(service.getbeneficioForzados(term));
        }
    }
}