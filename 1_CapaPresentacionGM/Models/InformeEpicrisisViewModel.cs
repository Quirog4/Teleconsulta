using _1_CapaPresentacionGM.Models.Mapper;
using _2_CapaServiciosGM.InterfaceGM;
using _2_CapaServiciosGM.ServiciosGM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_CapaPresentacionGM.Models
{

    public class EpicrisisModel
    {

        public string CMPDoctor { get; set; }
        public string Doctor { get; set; }
        public string Especialidad { get; set; }
        public string CondEgres { get; set; }
        public string Cama { get; set; }
        public string TiempoEstancia { get; set; }
        public string FIngreso { get; set; }
        public string HIngreso { get; set; }
        public string FecEgres { get; set; }
        public string HorEgres { get; set; }

        public string ResumenEnfeAct { get; set; }
        public string Evolucion { get; set; }
        public string Tratamiento { get; set; }
        public string ExamenesAuxil { get; set; }
        public string Procedimientos { get; set; }
        public string complicaciones { get; set; }

        public List<DiagnosticosModel> diagnosticos { get; set; }
    }

    public class DiagnosticosModel
    {
        public string Codigo { get; set; }
        public string Detalle { get; set; }
        public string Tipo { get; set; }
    }

    public class InformeEpicrisisViewModel
    {
        public EpicrisisModel informeEpi;
        public string mensajeError;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public void getEpicrisis(string hcu, string fecha)
        {
            IEpicrisisService service = new EpicrisisService();
            this.informeEpi = new EpicrisisModel();
            string f = Convert.ToDateTime(fecha).ToString("dd/MM/yyyy");
            log.Debug("Solicitando epicrisis:__fecha:" +f+"__hcu:" + hcu);
            if (service.getEpicrisis(hcu, f) == null)
            {
                log.Error("get Epicrisis null");
                mensajeError = "Hubo un problema, consute con el administrador";
            }
            else
            {
                this.informeEpi = DTOToModel.EpicrisisModel(service.getEpicrisis(hcu, f));
            }
        }

    }
}