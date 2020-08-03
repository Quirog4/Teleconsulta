using _1_CapaPresentacionGM.Models.Mapper;
using _2_CapaServiciosGM.InterfaceGM;
using _2_CapaServiciosGM.ServiciosGM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_CapaPresentacionGM.Models
{
    public class DetalleSerAuxModel {
        public string NroServicio { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }//Labo
        public string Resultados { get; set; }
        public string Examinador { get; set; }
        public string ResultIn { get; set; }//Labo
        public string FueraRango { get; set; }//Labo
        public string Unidad { get; set; }//Labo
        public string Referencia { get; set; }//Labo
        public string Razon { get; set; }
        public string FechaProc { get; set; }
    }

    public class DetallesSerAuxViewModel
    {
        public List<DetalleSerAuxModel> detalleSA;
        public string mensajeError;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void listardetalle(string nroAtencion)
        {
            IServicioAuxiliarService saservice = new ServicioAuxiliarService();
            this.detalleSA = new List<DetalleSerAuxModel>();
            log.Info("Listando servicios de paracas");
            if (saservice.servDetalles(nroAtencion) == null)
            {
                log.Error("Lista de paciente null");
                mensajeError = "Hubo un problema, consute con el administrador";
            }
            else
            {
                this.detalleSA = DTOToModel.listaDetallesSA(saservice.servDetalles(nroAtencion));
            }
        }
    }
}