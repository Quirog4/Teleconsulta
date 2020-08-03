using _1_CapaPresentacionGM.Models.Mapper;
using _2_CapaServiciosGM.ServiciosGM;
using System.Collections.Generic;
using System.Linq;

namespace _1_CapaPresentacionGM.Models
{
    public class AtencionModel
    {
        public string FechaAT { get; set; }
        public string NroAtencion { get; set; }
        public string CodAdmision { get; set; }
        public string colorTA { get; set; }
        public string fechaalta { get; set; }
        public string TipoAt { get; set; }
        public string Diagnosticos { get; set; }
        public string Medico { get; set; }
        public string Especialidad { get; set; }
        public bool serv { get; set; }
        public bool medicinas { get; set; }
        public bool infoepicrisi { get; set; }
    }


    public class AtencionViewModel
    {

        public List<AtencionModel> atenciones;
        public string mensajeError;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void listarAtenciones(string hcu, string user, string paciente, string ip)
        {

            AtencionService atservice = new AtencionService();
            MedicinasServiciosViewModel medservice = new MedicinasServiciosViewModel();
            this.atenciones = new List<AtencionModel>();
            log.Info("Solicitud de atencines usuario:" + user + "__paciente:" + paciente + "__ip:" + ip + "__hcu:" + hcu);
            if (atservice.detAtenciones(hcu, user, paciente, ip) != null) 
            {
                this.atenciones = DTOToModel.listaAtencionModel(atservice.detAtenciones(hcu, user, paciente, ip));
                List<MedicinasModel> m = medservice.listarMedicinasFlex(hcu);
                if (m.Count() != 0)
                {
                    foreach (AtencionModel a in this.atenciones)
                    {
                        a.medicinas = (m.Where(x => x.NroAdmision == a.CodAdmision).Count() == 0) ? a.medicinas : true;
                    }
                }
                
            }else
            {
                mensajeError = "Hubo un problema, consute con el administrador";
            }
           
        }
    }
}