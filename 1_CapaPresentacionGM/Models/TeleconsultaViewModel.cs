using _1_CapaPresentacionGM.Models.Modelos;
using _2_CapaServiciosGM.InterfaceGM;
using _2_CapaServiciosGM.ServiciosGM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_CapaPresentacionGM.Models
{
    public class TeleconsultaViewModel
    {
        public List<TeleconsultaModel> teleconsultas;
        public TeleconsultaModel teleconsulta;

        public void listarTeleconsulta(string fecInicio, string fecfin, string cmp) {
            IFATService  _service= new FATService();
           var lista=_service.listaFAT(fecInicio,fecfin,cmp);
            this.teleconsultas = new List<TeleconsultaModel>();
            this.teleconsultas = lista.Select(l=>new TeleconsultaModel {
                Estado=l.Estado,
                IdAtencion=l.IdAtencion,
                NroDocumento=l.NroDocumento,
                Paciente=new PacienteModel {Nombres=l.Paciente },
                Seguro=l.Seguro,
                HoraCita=l.HorCita,
                FechaCita=Convert.ToDateTime(l.FecCita).ToShortDateString()
            }).ToList();
        }

        public void getTeleconsulta(int id)
        {
            IFATService _service = new FATService();
            var telec = _service.getTeleconsulta(id);
            this.teleconsulta = new TeleconsultaModel();
            this.teleconsulta = EntityToModel.teleconsultaModel(telec);
        }
    }
}