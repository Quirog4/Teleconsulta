using _1_CapaPresentacionGM.Models.Mapper;
using _2_CapaServiciosGM.InterfaceGM;
using _2_CapaServiciosGM.ServiciosGM;
using _1_CapaPresentacionGM.Models.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapaSoporte.Cache;
using System.Configuration;

namespace _1_CapaPresentacionGM.Models
{
    public class ReportesFATViewModel: GenerarReporteCGViewModel
    {

        public ReportesFATViewModel()
        {
            this.rutaImagen = ConfigurationManager.AppSettings.Get("rutaImagen") + "LogoClinicaJCI.png";
        }
        public void getReporteFat(int id, string tipo)
        {
            this.archivo = new ArchivoModel();
            IFATService _fat = new FATService();
            this.rutaImagen = ConstantesCache.rutaImagen + "LogoClinicaJCI.png";
            string rutaPlantilla = ConstantesCache.rutaArchivos+ "FAT_PDF\\";
            string rutaPlantillaHeader = string.Empty;
            string tipoR = (tipo == "R") ? "RM" :
                (tipo == "X") ? "RAD" :
                (tipo == "L") ? "LAB" : "FAT";

            var fatdto = _fat.getFATReporte(id, tipoR);
            AtencionTmModel fat = DTOToModel.FatModel(fatdto);
            fat.dx = DTOToModel.listarDiagnostico(fatdto.diagnosticos);

            if (tipo == "R")
            {
                rutaPlantillaHeader = string.Concat(rutaPlantilla, "FatHeader_PDF.html");
                rutaPlantilla += "FatRecetavirtual_PDF.html";
                fat.medicinas = DTOToModel.listMedicinas(fatdto.medicinas);
                FAT_RecetaPDF rmodel = recetaReporte(fat);
                this.archivo.pdf = generarReporte(rutaPlantilla, rutaPlantillaHeader, rmodel,"");
            }
            else if (tipo == "X")
            {
                rutaPlantillaHeader = string.Concat(rutaPlantilla, "FatHeader_PDF.html");
                rutaPlantilla += "FatRadiologiaVirtual_PDF.html";
                fat.radiologia = DTOToModel.listaServisioFAT(fatdto.radiologia);
                FAT_RadiologiaPDF rmodel = radReporte(fat);
                this.archivo.pdf = generarReporte(rutaPlantilla, rutaPlantillaHeader, rmodel,"");
            }
            else if (tipo == "L")
            {
                rutaPlantillaHeader = string.Concat(rutaPlantilla, "FatHeader_PDF.html");
                rutaPlantilla += "FatLaboratorioVirtual_PDF.html";
                fat.laboratorio = DTOToModel.listaServisioFAT(fatdto.laboratorio);
                FAT_LaboratorioPDF rmodel = labReporte(fat);
                this.archivo.pdf = generarReporte(rutaPlantilla, rutaPlantillaHeader, rmodel,"");
            }
            else
            {
                rutaPlantillaHeader = string.Concat(rutaPlantilla, "FatHeader_PDF.html");
                rutaPlantilla += "FatAtencionVirtual_PDF.html";
                fat.laboratorio = DTOToModel.listaServisioFAT(fatdto.laboratorio);
                fat.radiologia = DTOToModel.listaServisioFAT(fatdto.radiologia);
                fat.medicinas = DTOToModel.listMedicinas(fatdto.medicinas);
                FAT_AtencionPDF rmodel = fatReporte(fat);
                this.archivo.pdf = generarReporte(rutaPlantilla, rutaPlantillaHeader, rmodel,"");
            }

        }

        public FAT_AtencionPDF fatReporte(AtencionTmModel fat)
        {
            FAT_AtencionPDF rmodel = new FAT_AtencionPDF(fat.Medicacion, fat.Tratamiento, fat.Motivo, fat.Anamnesis);
            rmodel.datosMedico(fat.Medico, fat.especialidad, fat.CMP, fat.RNE, fat.FechaRegistro, fat.NroAtencion, fat.Financiador, fat.firma);
            PacienteModel p = fat.paciente;
            string pnombres = p.Nombre+" "+p.ApellidoPaterno + " "+p.ApellidoMaterno;
            rmodel.datosPaciente(p.Nombre, p.Edad, p.Sexo, p.DNI, p.NroHistoria, fat.nroOaa, fat.FechaCierre, fat.CodigoFinanciador, fat.CodigoCentroTrabajo, fat.DescripcionCentroTrabajo, fat.NumeroRegistro);
            rmodel.listarDX(fat.dx);
            rmodel.listarLab(fat.laboratorio);
            rmodel.listarRx(fat.radiologia);
            rmodel.cReceta = rmodel.listarReceta(fat.medicinas);
            rmodel.rutaImagen = this.rutaImagen;
            return rmodel;
        }

        public FAT_LaboratorioPDF labReporte(AtencionTmModel fat)
        {
            FAT_LaboratorioPDF rmodel = new FAT_LaboratorioPDF();
            rmodel.datosMedico(fat.Medico, fat.especialidad, fat.CMP, fat.RNE, fat.FechaRegistro, fat.NroAtencion, fat.Financiador, fat.firma);
            PacienteModel p = fat.paciente;
            rmodel.datosPaciente(p.Nombre, p.Edad, p.Sexo, p.DNI, p.NroHistoria, fat.nroOaa, fat.FechaCierre, fat.CodigoFinanciador, fat.CodigoCentroTrabajo, fat.DescripcionCentroTrabajo, fat.NumeroRegistro);
            rmodel.listarDX(fat.dx);
            rmodel.cExamen= rmodel.listaSimple(fat.laboratorio);
            rmodel.rutaImagen = this.rutaImagen;
            return rmodel;
        }

        public FAT_RadiologiaPDF radReporte(AtencionTmModel fat)
        {
            FAT_RadiologiaPDF rmodel = new FAT_RadiologiaPDF();
            rmodel.datosMedico(fat.Medico, fat.especialidad, fat.CMP, fat.RNE, fat.FechaRegistro, fat.NroAtencion, fat.Financiador, fat.firma);
            PacienteModel p = fat.paciente;
            rmodel.datosPaciente(p.Nombre, p.Edad, p.Sexo, p.DNI, p.NroHistoria, fat.nroOaa, fat.FechaCierre, fat.CodigoFinanciador, fat.CodigoCentroTrabajo, fat.DescripcionCentroTrabajo, fat.NumeroRegistro);
            rmodel.listarDX(fat.dx);
            rmodel.cExamen = rmodel.listaSimple(fat.radiologia);
            rmodel.rutaImagen = this.rutaImagen;
            return rmodel;
        }

        public FAT_RecetaPDF recetaReporte(AtencionTmModel fat)
        {
            FAT_RecetaPDF rmodel = new FAT_RecetaPDF(fat.Medicacion, fat.Tratamiento);
            rmodel.datosMedico(fat.Medico, fat.especialidad, fat.CMP, fat.RNE, fat.FechaRegistro, fat.NroAtencion, fat.Financiador, fat.firma);
            PacienteModel p = fat.paciente;
            string pnombres = p.Nombre + " " + p.ApellidoPaterno + " " + p.ApellidoMaterno;
            rmodel.datosPaciente(p.Nombre, p.Edad, p.Sexo, p.DNI, p.NroHistoria, fat.nroOaa, fat.FechaCierre, fat.CodigoFinanciador, fat.CodigoCentroTrabajo, fat.DescripcionCentroTrabajo, fat.NumeroRegistro);
            rmodel.rutaImagen = this.rutaImagen;
            rmodel.listarDX(fat.dx);
            rmodel.cDatosReceta = rmodel.listarReceta(fat.medicinas);
            return rmodel;
        }

    }
}