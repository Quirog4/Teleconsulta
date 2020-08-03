using _1_CapaPresentacionGM.Models.Mapper;
using _2_CapaServiciosGM.InterfaceGM;
using _2_CapaServiciosGM.ServiciosGM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace _1_CapaPresentacionGM.Models
{
    public class MedicinasModel
    {
        public string FechaAt { get; set; }
        public string ProductoChavin { get; set; }
        public string DescripcionProducto { get; set; }
        public string PrincipioActivo { get; set; }
        public string Cantidad { get; set; }
        public string NroAdmision { get; set; }
        public string NroAtencion { get; set; }
        public string TipoProducto { get; set; }
        public string Forma { get; set; }
        public int Stock { get; set; }
        public string CodigoGrupoFormaFarmaceutica { get; set; }
        public string UnidadVentaProducto { get; set; }
        public string UMVAbreviado { get; set; }

        public string Dosis { get; set; }
        public string Via { get; set; }
        public string Cada { get; set; }
        public string Observacion { get; set; }
        public string Intervalo { get; set; }
        public string Codigo { get; set; }

        public string Viadesc { get; set; }
        public string dosisdesc { get; set; }
    }

    public class GuiasModel
    {
        public string usuario { get; set; }
        public string fecha { get; set; }
        public string Codigo { get; set; }
        public string estado { get; set; }
    }

    public class IntermedioTelefarmaciaModel
    {
        public int IdIntermedioTelefarmacia { get; set; }
        public bool FlagAtencion { get; set; }
        public int IdGuiaVenta { get; set; }
        public string CodigoUsuario { get; set; }
        public string NumeroAdmision { get; set; }
        public string RespuestaNoAtencionPaciente { get; set; }
        public string CorreoNoAtencionPaciente { get; set; }
        public string FechaHoraRegistro { get; set; }
        public string FechaRegistro { get; set; }
        public string HoraRegistro { get; set; }
        public string FechaHoraProceso { get; set; }
        public bool FlagIntegrado { get; set; }
        public string FechoraHoraReferencia { get; set; }
        public string Observacion { get; set; }
        public string FechaHoraEnvioCorreo { get; set; }
    }

    public class MedicinasServiciosViewModel
    {

        public List<MedicinasModel> medicinas;
        public string mensajeError;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
           (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void listardetalle(string nroAtencion, string hcu, string nroadmision)
        {
            IMedicinaService meservice = new MedicinaService();
            this.medicinas = new List<MedicinasModel>();

            List<MedicinasModel> medicinas = new List<MedicinasModel>();
            medicinas = listarMedicinasFlex(hcu).Where(x => x.NroAdmision == nroadmision).ToList();

            if (medicinas.Count() == 0)
            {
                medicinas = DTOToModel.listMedicinas(meservice.ListMedicina(nroAtencion));
                log.Info("Listando medicinas de paracas");
            }

            this.medicinas = medicinas;// Where(y => y.ProductoChavin[0] == 'A').ToList();
        }

        public List<MedicinasModel> listarMedicinasFlex(string hcu)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://10.7.2.223:8060/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/json"));

                //HttpResponseMessage Res = await client.GetAsync("HC_DIGITAL/api/farmacia/guias/historia-clinica/");

                // Realizar la petición GET
                HttpResponseMessage response = client.GetAsync("HC_DIGITAL/api/farmacia/guias/historia-clinica/" + hcu).Result;

                if (response.IsSuccessStatusCode)
                {
                    // Obtener el resultado como objeto dynamic 
                    string result = response.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1] { '"' });
                    return JsonConvert.DeserializeObject<List<MedicinasModel>>(result);
                }
                else
                {
                    return new List<MedicinasModel>();
                }
            }
        }
    }
}