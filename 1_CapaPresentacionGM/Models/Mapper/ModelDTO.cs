using _2_CapaServiciosGM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_CapaPresentacionGM.Models.Mapper
{
    public class ModelDTO
    {
        public static CartaGarantiaDTO cartaDTO(CartaGarantiaModel carta, PlanSaludModel planSalud, PacienteModel paciente)
        {
            PlanSaludDetallesDTO plan = new PlanSaludDetallesDTO();
            if (planSalud != null)
            {
                plan = new PlanSaludDetallesDTO
                {
                    fafiliacion = planSalud.fafiliacion,
                    fcontrato = planSalud.fcontrato,
                    estadocontrato = planSalud.estadocontrato,
                    contratoCodigo = planSalud.contratoCodigo,
                    plan = planSalud.plan,
                    producto = planSalud.producto,
                    contratante = planSalud.contratante ?? "",
                    contratoIniVigencia = planSalud.contratoIniVigencia,
                    TitularNombre = planSalud.TitularNombre,
                    Parenteco = planSalud.Parentesco,
                    FNacimientoPaciente = paciente.FNacimiento,
                    codigoAfiliado = planSalud.codafilicacion,
                    beneficios = (planSalud.beneficios != null) ? planSalud.beneficios.Select(x => new BeneficoPSDTO
                    {
                        codigo = x.codigo,
                    }).ToList() : new List<BeneficoPSDTO>()
                };
            };
            PacienteDTO pac = new PacienteDTO();
            if (paciente != null)
            {

                pac = new PacienteDTO
                {
                    DNI = paciente.DNI,
                    Edad = paciente.Edad,
                    eMail = paciente.eMail,
                    Nombre = paciente.Nombre,
                    NroHistoria = paciente.NroHistoria,
                    Telefono = paciente.Telefono,
                    celular = paciente.celular,
                    plan = plan,
                    FNacimiento = paciente.FNacimiento
                    ,
                    tipoDocumento = paciente.tipoDocumento
                };
            }
            CartaGarantiaDTO cartadto = new CartaGarantiaDTO
            {

                NrSolicitud = carta.nrosolicitud,
                TipoSol = carta.tipoSolicitud,
                Importe = carta.importe,
                Especialidad = carta.especialidad.codigo,
                ObsMedTratante = carta.obsMedTratante,
                MedicoTratante = carta.medicoTratante.codigo,
                TenfAnio = carta.TenfAnio,
                TenfMes = carta.TenfMes,
                TenfDia = carta.TenfDia,
                DiagPrincipal = carta.diagnostico.codigo,
                TipoAten = carta.tipoAtencion,
                NDHosp = carta.nroDiasHosp,
                paciente = pac
            };

            return cartadto;
        }

        public static FATDTO faTDTO(AtencionTmModel fat)
        {
            FATDTO FatDto = new FATDTO {
                idFat = fat.idAtencion
                ,NroAtencion = fat.NroAtencion
                ,DocumentoPac = fat.paciente.DNI
                ,NombrePac = fat.paciente.Nombre
                ,ApePaternoPac = fat.paciente.ApellidoPaterno
                ,ApeMaternoPac = fat.paciente.ApellidoMaterno
                ,HistoriaClinica = fat.paciente.NroHistoria
                ,celular=fat.paciente.celular
                ,telefono=fat.paciente.Telefono
                ,email=fat.paciente.eMail
                ,Edad = (!string.IsNullOrEmpty(fat.paciente.Edad))?Convert.ToInt32(fat.paciente.Edad):0
                ,Sexo = (!string.IsNullOrEmpty(fat.paciente.Sexo)) ? fat.paciente.Sexo[0].ToString():""
                ,Financiador = fat.Financiador
                ,idTipoAtencion = fat.idTipoAtencion
                ,FecUltimaAtencion = fat.paciente.FUtimaAtencion
                ,Anamnesis = fat.Anamnesis
                ,Motivo = fat.Motivo
                ,idModalidad = fat.idModalidad
                ,Tratamiento = fat.Tratamiento
                ,Receta = fat.Medicacion
                ,RNE = fat.RNE
                };
            return FatDto;
        }

        public static List<DiagnosticoDTO> diagnosticosDTO(List<DiagnosticosModel> model)
        {
            List<DiagnosticoDTO> dto = new List<DiagnosticoDTO>();
            dto = model.Select(d=>new DiagnosticoDTO {
                CodigoDiagnostico=d.Codigo,
                Tipo=d.Tipo
            }).ToList();
            return dto;
        }

        public static List<ServiciosFATDTO> servicioDTO(List<ServiciosFATModel> model)
        {
            List<ServiciosFATDTO> dto = new List<ServiciosFATDTO>();
            dto = model.Select(d => new ServiciosFATDTO
            {
                codigo = d.codigo,
                observaciones = d.observaciones
            }).ToList();
            return dto;
        }

        public static List<MedicinaDTO> medicinasDTO(List<MedicinasModel> model)
        {
            List<MedicinaDTO> dto = new List<MedicinaDTO>();
            dto = model.Select(d => new MedicinaDTO
            {
                cada=d.Cada,
                Descripcion=d.DescripcionProducto,
                cantidad=d.Cantidad,
                dosis=d.Dosis,
                via=d.Via,
                observacion=d.Observacion,
                intervalo=d.Intervalo,
                CodMedicina = d.Codigo,
                DescMedicina = d.PrincipioActivo,
                TipoProducto = d.TipoProducto,
                Forma = d.Forma,
                UnidadVentaProducto = d.UnidadVentaProducto,
                UMVAbreviado = d.UMVAbreviado
            }).ToList();
            return dto;
        }

        public static ArchivoDTO archivoDTO(ArchivoModel archivo)
        {

            ArchivoDTO ar = new ArchivoDTO
            {

                codSolicitud = archivo.codSolicitud,
                Nombre = archivo.Nombre,
                Tipo = archivo.Tipo,
                idArchivo = archivo.idArchivo
            };
            if (archivo.pdf != null)
            {
                ar.Archivo = archivo.pdf;
            }

            return ar;
        }

        public static List<BeneficoPSDTO> beneficiosDTO(List<BeneficioModel> beneficios)
        {
            List<BeneficoPSDTO> dto = new List<BeneficoPSDTO>();
            if (beneficios != null)
            {
                dto = beneficios.Select(x => new BeneficoPSDTO
                {
                    cobertura = x.cobertura,
                    codigo = x.codigo,
                    copagoFijo = x.copagofijo,
                    copagoVariable = x.copagovariable
                    ,
                    seleccionado = x.seleccionado//)?true:false
                }).ToList();
            }
            return dto;
        }

        public static BeneficoPSDTO beneficioDTO(BeneficioModel x)
        {
            BeneficoPSDTO beneficio = new BeneficoPSDTO();
            if (x != null)
            {
                beneficio = new BeneficoPSDTO
                {
                    cobertura = x.cobertura,
                    codigo = x.codigo,
                    copagoFijo = x.copagofijo,
                    copagoVariable = x.copagovariable,
                    forzado=x.isForzado,
                    seleccionado = true
                };
            }
            return beneficio;
        }

        public static OrdenInternamientoQxDTO ordenIQx(OIQuirurgicaModel orden)
        {
            OrdenInternamientoQxDTO ord = new OrdenInternamientoQxDTO();
            ord.IdOrden = orden.idOrden;
            ord.NroOrden = orden.nroOIQuirurgica;
            if (orden.paciente != null) {
            ord.paciente = new PacienteDTO
            {
                DNI = orden.paciente.DNI,
                eMail = orden.paciente.eMail,
                celular = orden.paciente.celular,
                Nombre = orden.paciente.Nombre,
                NroHistoria = orden.paciente.NroHistoria,
                Edad = orden.paciente.Edad
            };
            }
            ord.Financiador = orden.Financiador;
            ord.Especialidad = orden.Especialidad;
            ord.TipoCirugia = orden.TipoCirugia;
            ord.TenfDia = orden.TiEnferDia;
            ord.TenfMes = orden.TiEnferMes;
            ord.TenfAnios = orden.TiEnferAnio;
            ord.DuracionHorQx = orden.DuracionCirugia;
            ord.Alergias = orden.Alergia;
            ord.Morbilidades = orden.Morbilidad;
            ord.Req1Consentimiento = orden.Requisito1;
            ord.Req2Examenes = orden.Requisito2;
            ord.Req3Imagenes = orden.Requisito3;
            ord.Req4RiesgoCar = orden.Requisito4;
            ord.Req5RiesgoNeu = orden.Requisito5;
            ord.Req6DSangre = orden.Requisito6;
            ord.Req7EvaPre = orden.Requisito7;
            ord.Req8Otros = orden.Requisito8;
            ord.Justificacion = orden.justificacion;
            ord.TEstimado = orden.TiempEstancia;
            ord.Profilaxis = orden.profilaxis;
            ord.FecCirugia = orden.FecPrevistaCirugia;
            ord.FecHospit = orden.FecPrevistaHospitalizacion;
            ord.HorCirugia = orden.HoraPrevistaCirugia;
            ord.HorHospit = orden.HoraPrevistaHospitalizacion;
            ord.isAlertar = orden.isAlertaProgramador;
            ord.tipoAnestesia = orden.tipoAnestesia;
            return ord;
        }

        public static List<ArchivoDTO> archivosDTO(List<ArchivoModel> anexos)
        {
            List<ArchivoDTO> archivos = new List<ArchivoDTO>();
            archivos = anexos.Select(a => new ArchivoDTO
            {
                Archivo = a.pdf,
                Nombre = a.Nombre,
                Tipo = a.Tipo,
                verWeb = true
            }).ToList();
            return archivos;
        }

        public static List<SuministroDTO> SuministroDTO(List<SuministroModel> suministro)
        {
            List<SuministroDTO> sumi = new List<SuministroDTO>();
            sumi = suministro.Select(s => new SuministroDTO
            {
                cantidad=s.cantidad,
                codigo=s.codigo,
                observacion=s.observaciones
            }).ToList();
            return sumi;
        }
    }
}