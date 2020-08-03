using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_CapaPresentacionGM.Models.Reportes
{
    public class CGAuditoriaPLANSALUD
    {
        public string estadoCG { get; set; }
        public string estadoContrato { get; set; }
        public string imagen { get; set; }
        public string motivoestado { get; set; }
        public string nrosolicitud { get; set; }
        public string diaRegistro { get; set; }
        public string mesRegistro { get; set; }
        public string anioRegistro { get; set; }
        public string nrocontrato { get; set; }
        public string contratante { get; set; }
        public string titular { get; set; }
        public string parentesco { get; set; }
        public string codigo { get; set; }
        public string fechaRegistro { get; set; }
        public string fechaSolicitud { get; set; }
        public string plan { get; set; }
        public string fIniciovig { get; set; }
        public string fAfiliacion { get; set; }
        public string importe { get; set; }
        public string deducible { get; set; }
        public string cargopaciente { get; set; }
        public string diagnostico { get; set; }
        public string copagoVariable { get; set; }
        public string cobertura { get; set; }
        public string obsmedicas { get; set; }
        public string nombreAuditor { get; set; }
        public string paciente { get; set; }

        public string preexistencias { get; set; }

        public CGAuditoriaPLANSALUD()
        {         this.estadoCG ="";
        this.motivoestado ="";
        this.nrosolicitud ="";
        this.nrocontrato ="";
        this.contratante ="";
        this.titular ="";
        this.parentesco ="";
        this.codigo ="";
        this.fechaSolicitud ="";
        this.plan ="";
        this.fIniciovig ="";
        this.importe ="0";
        this.deducible ="0";
        this.cargopaciente ="0%";
        this.diagnostico ="";
        this.cobertura ="";
        this.obsmedicas ="";
        this.nombreAuditor ="";
            this.imagen = "PLAN SALUD";
    }

        public CGAuditoriaPLANSALUD(CartaGarantiaModel model)
        {
            this.estadoCG = model.estado ;
            var plan = model.paciente.planSalud;
            this.motivoestado = model.auditor.motivoEstado.descripcion ;
            this.nrosolicitud = model.nrosolicitud ;
            this.nrocontrato = plan.contratoCodigo ;
            this.contratante = plan.contratante;
            this.titular = plan.TitularNombre ;
            this.parentesco = plan.Parentesco;
            this.codigo = "" ;
            this.fechaSolicitud = model.fechaRegistro;
            this.plan = plan.plan + " "+plan.producto ;
            this.fIniciovig = plan.contratoIniVigencia ;
            this.importe = model.importe ;
            this.deducible = model.deducible ;
            this.cargopaciente = "" ;
            this.diagnostico = model.diagnostico.descripcion ;
            this.cobertura = plan.beneficios[0].cobertura ;
            this.obsmedicas = model.auditor.oMedica ?? "Ninguna" ;
            this.nombreAuditor = model.usuarioRegistro ;
        }
    }
}