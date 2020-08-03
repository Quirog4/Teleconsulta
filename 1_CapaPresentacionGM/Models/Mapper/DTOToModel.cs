using _2_CapaServiciosGM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static _2_CapaServiciosGM.DTO.FiltrosDTO;

namespace _1_CapaPresentacionGM.Models.Mapper
{
    public class DTOToModel
    {

        public static List<PacienteModel> listPaciente(IEnumerable<PacienteDTO> listDto)
        {

            IEnumerable<PacienteModel> listModel = listDto.Select(x => new PacienteModel
            {
                NroHistoria = x.NroHistoria.Trim(),
                Nombre = x.Nombre.Trim(),
                Edad = x.Edad.Trim(),
                Sexo = x.Sexo,
                Domicilio = x.Domicilio.Trim(),
                FNacimiento = x.FNacimiento.Trim(),
                EstCivil = x.EstCivil.Trim(),
                DNI = x.DNI.Trim().Trim(),
                tipoDocumento = x.tipoDocumento,
                mostrarNombre = EntityToDTO.formatnOMBRE(x.Nombre),
                celular = x.celular.Trim(),
                eMail = x.eMail
            });
            return listModel.ToList();
        }

        public static List<ArchivoModel> getArchivos(List<ArchivoDTO> list)
        {
            List<ArchivoModel> model = new List<ArchivoModel>();
            model = list.Select(x => new ArchivoModel
            {
                idArchivo = x.idArchivo,
                pdf = x.Archivo,
                codSolicitud = x.codSolicitud,
                Nombre = x.Nombre,
                Tipo = x.Tipo,
                Origen = x.origen,
                verWeb = x.verWeb
            }).ToList();
            return model;
        }

        public static List<LstFATModel> listaFATModel(List<ListaFATDTO> list)
        {
            List<LstFATModel> model = new List<LstFATModel>();
            model = list.Select(x => new LstFATModel
            {
                DocumentoPaciente = x.DocumentoPac,
                Estado = x.Estado,
                FecAtencion = x.FecRegistro,
                idAtencion = x.idFat,
                NombrePaciente = x.NombrePac,
                NroAtencion = x.NroAtencion,
                Seguro = x.Financiador,
                //----
                medico = x.nombreMedico,
                especialidad = x.Especialidad,
                oaa = x.OAA,
                fecoaa = x.FecOAA,
                usuoaa = x.UsuarioOAA,
                isrecetapdf = x.isPDFRecetaMedica,
                islabopdf = x.isPDFLaboratorio,
                isradiopdf = x.isPDFRadiologia,
                isguia = x.isGuiaDespacho,
                celularpac = x.celularPaciente,
                telfonopac = x.telefonoPaciente,
                emailpac = x.emailpaciente
            }).ToList();
            return model;
        }

        public static ArchivoModel ArchivoModel(ArchivoDTO archivoDTO)
        {
            ArchivoModel model = new ArchivoModel();
            model = new ArchivoModel
            {
                idArchivo = archivoDTO.idArchivo,
                pdf = archivoDTO.Archivo,
                codSolicitud = archivoDTO.codSolicitud,
                Nombre = archivoDTO.Nombre,
                Tipo = archivoDTO.Tipo

            };
            return model;
        }

        public static PacienteModel pacienteModel(PacienteDTO p)
        {
            PacienteModel model = new PacienteModel
            {
                DNI = p.DNI,
                Domicilio = p.Domicilio ?? "",
                Edad = p.Edad ?? "",
                eMail = p.eMail ?? "",
                EstCivil = p.EstCivil ?? "",
                FNacimiento = (p.FNacimiento != "") ? Convert.ToDateTime(p.FNacimiento).ToString("dd/MM/yyyy") : "",
                mostrarNombre = EntityToDTO.formatnOMBRE(p.Nombre),
                Nombre = p.Nombre,
                NroHistoria = p.NroHistoria ?? "",
                Sexo = p.Sexo ?? "",
                Telefono = p.Telefono ?? "",
                planSalud = (p.plan != null) ? planSaludModel(p.plan) : null,
                celular = p.celular,
                tipoDocumento = p.tipoDocumento,
                ApellidoMaterno = p.ApellidoMaterno ?? "",
                ApellidoPaterno = p.ApellidoPaterno ?? "",
                FUtimaAtencion = p.FecUltimaAtencion ?? ""
            };
            return model;
        }

        public static List<ServiciosFATModel> listaServisioFAT(List<ServiciosFATDTO> list)
        {
            List<ServiciosFATModel> model = new List<ServiciosFATModel>();
            if (list != null)
            {
                model = list.Select(l => new ServiciosFATModel
                {
                    codigo = l.codigo
                    ,
                    descripcion = l.Nombre
                    ,
                    observaciones = l.observaciones
                }).ToList();
            }
            return model;
        }

        public static AtencionTmModel FatModel(FATDTO fATDTO)
        {
            AtencionTmModel atencion = new AtencionTmModel
            {
                idAtencion = fATDTO.idFat
                ,
                Financiador = fATDTO.Financiador
                ,
                TipoAtencion = fATDTO.TipoAtencion
                ,
                Modalidad = fATDTO.MODALIDAD
                ,
                Anamnesis = fATDTO.Anamnesis
                ,
                Motivo = fATDTO.Motivo
                ,
                Medicacion = fATDTO.Receta
                ,
                Tratamiento = fATDTO.Tratamiento
                ,
                Estado = fATDTO.Estado
                ,
                NroAtencion = fATDTO.NroAtencion
                ,
                RNE = fATDTO.RNE
                ,
                FechaRegistro = fATDTO.FecRegistro
                ,
                HoraRegistro = fATDTO.HorRegistro
                ,
                isEditable = fATDTO.isEditable
                ,
                Medico = fATDTO.nombreMedico
                ,
                especialidad = fATDTO.especialidad
                ,
                CMP = fATDTO.CMP
                ,
                nroOaa = fATDTO.OAA
                ,
                medioContacto = fATDTO.medioContacto
                ,
                FechaCierre = fATDTO.FecCierre
                ,
                CodigoCentroTrabajo = fATDTO.CodigoCentroTrabajo
                ,
                DescripcionCentroTrabajo = fATDTO.DescripcionCentroTrabajo
                ,
                CodigoFinanciador=fATDTO.CodigoFinanciador,
                NumeroRegistro=fATDTO.NumeroRegistro,
                firma = fATDTO.firma
                ,iscontacto=fATDTO.isContactar
            };
            atencion.paciente = new PacienteModel
            {
                Nombre = fATDTO.NombrePac,
                ApellidoMaterno = fATDTO.ApeMaternoPac,
                ApellidoPaterno = fATDTO.ApePaternoPac,
                NroHistoria = fATDTO.HistoriaClinica,
                DNI = fATDTO.DocumentoPac,
                Edad = fATDTO.Edad.ToString(),
                Sexo = fATDTO.Sexo,
                FUtimaAtencion = fATDTO.FecUltimaAtencion
                ,
                eMail = fATDTO.email
                ,
                celular = fATDTO.celular
                ,
                Telefono = fATDTO.telefono

            };
            return atencion;
        }

        public static PlanSaludModel planSaludModel(PlanSaludDetallesDTO dto)
        {
            PlanSaludModel model = new PlanSaludModel
            {
                plan = dto.plan,
                contratoCodigo = dto.contratoCodigo,
                Parentesco = dto.Parenteco,
                producto = dto.producto,
                contratoIniVigencia = dto.contratoIniVigencia,
                TitularDocIden = dto.TitularDocIden ?? "",
                TitularNombre = dto.TitularNombre ?? "",
                estadocontrato = dto.estadocontrato,
                contratante = dto.contratante,
                fafiliacion = dto.fafiliacion,
                fcontrato = dto.fcontrato,
                codafilicacion = dto.codigoAfiliado
            };

            if (dto.beneficios != null)
            {
                model.beneficios = new List<BeneficioModel>();
                model.beneficios = listarBeneficios(dto.beneficios);
            }

            if (dto.preexistencias != null)
            {
                model.preexistencias = new List<PreexistenciasModel>();
                foreach (var b in dto.preexistencias)
                {
                    PreexistenciasModel be = new PreexistenciasModel
                    {
                        descripcion = b.descripcion,
                        codigo = b.codigo,
                        observaciones = b.observaciones
                    };
                    model.preexistencias.Add(be);
                }
            }
            if (dto.declaracionJ != null)
            {
                model.declaracionJur = new List<DeclaracionJuradaPSModel>();
                foreach (var b in dto.declaracionJ)
                {
                    DeclaracionJuradaPSModel be = new DeclaracionJuradaPSModel
                    {
                        dolencia = b.dolencia.Select(x => new DolenciaModel
                        {
                            detalle = x.detalle,
                            descripcion = x.descripcion,
                            situacionActual = x.situacionActual
                        }).ToList(),
                        respuesta = b.respuesta,
                        texto = b.texto
                    };
                    model.declaracionJur.Add(be);
                }
            }
            return model;

        }

        public static List<GuiasModel> listaGuias(List<GuiaDespachoDTO> list)
        {
            List<GuiasModel> result = new List<GuiasModel>();
            result = list.Select(l => new GuiasModel
            {
                Codigo = l.nroguia,
                fecha = l.fecha,
                usuario = l.usuario,
                estado = l.estado
            }).ToList();
            return result;
        }

        public static List<IntermedioTelefarmaciaModel> listaIntermedioTelefarmacia(IEnumerable<IntermedioTelefarmaciaDTO> list)
        {
            List<IntermedioTelefarmaciaModel> result = new List<IntermedioTelefarmaciaModel>();

            foreach (var l in list)
            {
                IntermedioTelefarmaciaModel oIntermedioTelefarmaciaModel = new IntermedioTelefarmaciaModel();

                oIntermedioTelefarmaciaModel.IdIntermedioTelefarmacia = l.IdIntermedioTelefarmacia;
                oIntermedioTelefarmaciaModel.FlagAtencion = l.FlagAtencion;
                oIntermedioTelefarmaciaModel.IdGuiaVenta = l.IdGuiaVenta;
                oIntermedioTelefarmaciaModel.CodigoUsuario = l.CodigoUsuario;
                oIntermedioTelefarmaciaModel.NumeroAdmision = l.NumeroAdmision;
                oIntermedioTelefarmaciaModel.RespuestaNoAtencionPaciente = l.RespuestaNoAtencionPaciente;
                oIntermedioTelefarmaciaModel.CorreoNoAtencionPaciente = l.CorreoNoAtencionPaciente;
                oIntermedioTelefarmaciaModel.FechaRegistro = l.FechaHoraRegistro.ToString("ddd d MMM yy");
                oIntermedioTelefarmaciaModel.HoraRegistro = l.FechaHoraRegistro.ToString("hh:MM:ss tt");
                oIntermedioTelefarmaciaModel.FechaHoraProceso = l.FechaHoraProceso == null ? string.Empty : Convert.ToDateTime(l.FechaHoraProceso).ToString("dd/MM/yyyy hh:MM:ss tt");
                oIntermedioTelefarmaciaModel.FlagIntegrado = l.FlagIntegrado;
                oIntermedioTelefarmaciaModel.FechoraHoraReferencia = l.FechoraHoraReferencia == null ? string.Empty : Convert.ToDateTime(l.FechoraHoraReferencia).ToString("dd/MM/yyyy hh:MM:ss tt");
                oIntermedioTelefarmaciaModel.Observacion = oIntermedioTelefarmaciaModel.FechoraHoraReferencia == string.Empty ? l.Observacion == null ? string.Empty : l.Observacion : l.Observacion + Environment.NewLine + "Fecha Llamada: " + oIntermedioTelefarmaciaModel.FechoraHoraReferencia;
                oIntermedioTelefarmaciaModel.FechaHoraEnvioCorreo = l.FechaHoraEnvioCorreo == null ? string.Empty : Convert.ToDateTime(l.FechaHoraEnvioCorreo).ToString("dd/MM/yyyy hh:MM:ss tt");

                result.Add(oIntermedioTelefarmaciaModel);
            }

            return result;
        }

        public static List<BeneficioModel> listarBeneficios(List<BeneficoPSDTO> beneficiops)
        {
            List<BeneficioModel> beneficios = new List<BeneficioModel>();
            foreach (var b in beneficiops)
            {
                BeneficioModel be = new BeneficioModel
                {
                    cobertura = b.cobertura,
                    codigo = b.codigo,
                    copagofijo = b.copagoFijo,
                    copagovariable = b.copagoVariable,
                    seleccionado = b.seleccionado
                };
                beneficios.Add(be);
            }
            return beneficios;
        }

        public static List<SuministroModel> suministroModel(List<SuministroDTO> suministro)
        {
            List<SuministroModel> sumi = new List<SuministroModel>();
            sumi = suministro.Select(s => new SuministroModel
            {
                cantidad = s.cantidad,
                codigo = s.codigo,
                descripcion = s.descripcion,
                observaciones = s.observacion
            }).ToList();
            return sumi;
        }

        public static List<OIQuirurgicaModel> listaOrdenIQx(List<OrdenInternamientoQxDTO> s)
        {
            List<OIQuirurgicaModel> lista = new List<OIQuirurgicaModel>();
            lista = s.Select(x => new OIQuirurgicaModel
            {
                nroOIQuirurgica = x.NroOrden,
                idOrden = x.IdOrden,
                FecPrevistaCirugia = x.FecCirugia,
                Estado = x.Estado,
                Financiador = x.Financiador,
                QxProgramado = x.QxProgramado,
                paciente = new PacienteModel
                {
                    mostrarNombre = x.paciente.Nombre,
                    DNI = x.paciente.DNI
                },
                Sala = x.Sala,
                FecRegistro = x.FRegistro,
                Especialidad = x.Especialidad,
                colorEstado = x.colorEstado,
                EstadoPreqx = x.EstadoPqx,
                colorEstadoPreQx = x.colorEstadoPqx,
                FecCirugiaProgramada = x.FechaProgramada
                ,
                observacionesPreqx = x.obsPreQx
                ,
                tipoAnestesia = x.tipoAnestesia
            }).ToList();
            return lista;
        }

        public static List<OIQuirurgicaModel> listaCartaOrdenIQx(List<CartaGarantiaOIQDTO> select)
        {
            List<OIQuirurgicaModel> lista = new List<OIQuirurgicaModel>();
            lista = select.Select(x => new OIQuirurgicaModel
            {
                nroOIQuirurgica = x.NroCarta,
                idCarta = x.IdMovCarta,
                idOrden = x.idArchivo,
                FecCirugiaProgramada = x.FechaHorTentativa_Propuesta,
                Estado = x.EstadoCG,
                colorEstado = x.colorEstadoCG,
                Financiador = x.Financiador,
                QxProgramado = (x.QxProgramado == true) ? "Si" : "No",
                paciente = new PacienteModel
                {
                    mostrarNombre = x.NombrePac,
                    DNI = x.DocPac,
                    celular = x.CelularPac,
                    NroHistoria = x.HistoriaClinicaPas,
                    Edad = x.edadPaciente
                },
                FecRegistro = x.FechaRegistro,
                Especialidad = x.Especialidad,
                EstadoPreqx = x.EstadoPreQx,
                TipoCirugia = x.TipoCirugia,
                Departamento = x.Departamento,
                colorEstadoPreQx = x.colorEstadoPreQx,
                FecCitaPreQx = x.FechaCitaProgram,
                FecPrevistaCirugia = x.FechaHorTentativa_Propuesta,
                Solicitante = (x.Solicitante != "") ? x.Solicitante.Split('-')[1] : "",
                isEditablePreQx = x.isEditablePreQx,
                observacionesPreqx = x.observacionesPreQx,
                criterioEstadoPreqx = x.criterioEstadoPreQx,
                tipoSolicitante = (x.Solicitante != "") ? x.Solicitante.Split('-')[0] : "",
                Procedimientos = (x.cirugias != null) ? filtroModel(x.cirugias) : new List<FiltroModel>(),
                Alergia = x.alergia,
                Morbilidad = x.morbilidades,
                alertaProgramador = x.alertaProgramador,
                tipoAnestesia = x.TipoAnestesia
            }).ToList();
            return lista;
        }

        public static OIQuirurgicaModel getOIQx(OrdenInternamientoQxDTO o)
        {
            OIQuirurgicaModel orden = new OIQuirurgicaModel
            {
                idOrden = o.IdOrden,
                nroOIQuirurgica = o.NroOrden,
                colorEstado = o.colorEstado,
                Estado = o.Estado,
                paciente = new PacienteModel
                {
                    DNI = o.paciente.DNI,
                    NroHistoria = o.paciente.NroHistoria,
                    Edad = o.paciente.Edad,
                    celular = o.paciente.celular,
                    mostrarNombre = o.paciente.Nombre,
                    eMail = o.paciente.eMail,
                },
                Financiador = o.Financiador,
                Especialidad = o.Especialidad,
                TipoCirugia = o.TipoCirugia,
                TiEnferDia = o.TenfDia,
                TiEnferMes = o.TenfMes,
                TiEnferAnio = o.TenfAnios,
                TiempEstancia = o.TEstimado,
                Alergia = o.Alergias,
                Morbilidad = o.Morbilidades,
                Requisito1 = o.Req1Consentimiento,
                Requisito2 = o.Req2Examenes,
                Requisito3 = o.Req3Imagenes,
                Requisito4 = o.Req4RiesgoCar,
                Requisito5 = o.Req5RiesgoNeu,
                Requisito6 = o.Req6DSangre,
                Requisito7 = o.Req7EvaPre,
                Requisito8 = o.Req8Otros,
                FecPrevistaCirugia = o.FecCirugia.ToString(),
                HoraPrevistaCirugia = o.HorCirugia,
                FecPrevistaHospitalizacion = o.FecHospit.ToString(),
                HoraPrevistaHospitalizacion = o.HorHospit,
                justificacion = o.Justificacion,
                DuracionCirugia = o.DuracionHorQx,
                profilaxis = o.Profilaxis,
                isEditable = (o.IsEditable == 1) ? true : false,
                FecRegistro = o.FRegistro,
                isAlertaProgramador = o.isAlertar,
                tipoAnestesia = o.tipoAnestesia
            };
            return orden;
        }

        public static OIQuirurgicaModel getCartaOIQx(CartaGarantiaOIQDTO o)
        {
            OIQuirurgicaModel orden = new OIQuirurgicaModel
            {
                idCarta = o.IdMovCarta,
                idOrden = o.IdOrden,
                nroOIQuirurgica = o.NroCarta,
                FecRegistro = o.FechaRegistro,
                colorEstado = o.colorEstadoCG,
                Estado = o.EstadoCG,
                paciente = new PacienteModel
                {
                    DNI = o.DocPac,
                    NroHistoria = o.HistoriaClinicaPas,
                    Edad = o.edadPaciente,
                    celular = o.CelularPac,
                    mostrarNombre = o.NombrePac,
                    eMail = o.correoPaciente,
                },
                Financiador = o.Financiador,
                Especialidad = o.Especialidad,
                observacionesPreqx = o.observacionesPreQx,
                EstadoPreqx = o.EstadoPreQx,
                colorEstadoPreQx = o.colorEstadoPreQx,
                criterioEstadoPreqx = o.criterioEstadoPreQx,
                Sala = o.sala,
                FecCirugiaProgramada = o.FechaCitaProgram,
                HoraPrevistaCirugia = o.horaCitaProgram,
                idArchivo = o.idArchivo,
                observacionFidelizacion = o.obserFidelizado,
                obsProgramador = o.obsProgramador,
                preqxRealizado = o.preqxRealizado,
                pacienteAdmitido = o.pacienteAdmitido,
                requierePreqx = o.reqpreqx,
                Solicitante = o.Solicitante,
                Departamento = o.Departamento,
                QxConfirmado = o.QxProgramado
                ,
                Alergia = o.alergia
                ,
                Morbilidad = o.morbilidades
            };
            return orden;
        }

        public static List<ListaPreQx> listarPreQx(List<PreQuirurquicosDTO> list)
        {
            List<ListaPreQx> preqx = new List<ListaPreQx>();
            preqx = list.Select(l => new ListaPreQx
            {
                descripcion = l.Descripcion,
                fecha = l.Fecha,
                observaciones = l.Observaciones,
            }).ToList(); ;
            return preqx;
        }

        public static List<lstCartaGarantiaModel> listarCartasGarantiaServicio(List<CartaGarantiaDTO> list)
        {
            List<lstCartaGarantiaModel> model = new List<lstCartaGarantiaModel>();
            model = list.Select(x => new lstCartaGarantiaModel
            {
                id = x.idCartaGarantia,
                nrosolicitud = x.NrSolicitud,
                fechaRegistro = x.Fregistro,
                tipoAtencion = (x.TipoAten ?? "").ToUpper(),
                titular = x.lstTitular,
                nroContrato = x.lstnrocontrato,
                nompaciente = x.paciente.Nombre,
                estado = x.Estado,
                colorEstado = x.colorEstado,
                procedimiento = x.Procedimiento,
                departamento = x.departamento

            }).ToList();
            return model;
        }

        public static List<AtencionModel> listaAtencionModel(IEnumerable<AtencionDTO> list)
        {
            IEnumerable<AtencionModel> lsmodel = list.Select(x => new AtencionModel
            {
                NroAtencion = x.NroAtencion,
                CodAdmision = x.CodAdmision,
                FechaAT = x.GrupoFechaAT,
                fechaalta = x.fechaalta,
                TipoAt = x.TipoAt,
                //  rowspan = list.Where(y => y.FechaAt == x.FechaAt).Count(),
                Medico = converMinus(x.Medico),
                colorTA = (x.TipoAt[0] == 'E') ? "danger" :
                          (x.TipoAt[0] == 'A') ? "primary" :
                          (x.TipoAt[0] == 'H') ? "success" : "info",
                Especialidad = (x.Especialidad != null) ? x.Especialidad.ToLower() : "",
                Diagnosticos = converMinus(diag(x.CodDiag1, x.DescripDiag1, x.CodDiag2, x.DescripDiag2, x.DiagAlta, "")),
                medicinas = x.medicinas,
                serv = x.serviciosaux,
                infoepicrisi = x.epicrisis
            });
            return lsmodel.ToList();
        }

        public static CartaGarantiaModel CartaGarantiaModel(CartaGarantiaDTO cartaGarantiaDTO)
        {
            PacienteModel pac = pacienteModel(cartaGarantiaDTO.paciente);
            CartaGarantiaModel model = new CartaGarantiaModel();
            model.nrosolicitud = cartaGarantiaDTO.NrSolicitud;
            model.estado = cartaGarantiaDTO.Estado;
            model.colorEstado = cartaGarantiaDTO.colorEstado;
            model.agente = cartaGarantiaDTO.Agente ?? "";
            model.nrogarantia = cartaGarantiaDTO.NroCartaGarantia ?? "";
            model.procedimiento = cartaGarantiaDTO.Procedimiento ?? "";
            model.fechavcto = cartaGarantiaDTO.Fvencimiento ?? "";
            model.financiador = cartaGarantiaDTO.Financiador ?? "";
            model.obsfin = cartaGarantiaDTO.obsFinanciador ?? "";
            model.tipoCarta = cartaGarantiaDTO.TipoCarta ?? "";
            model.obsrechazado = cartaGarantiaDTO.ObsRech ?? "";
            model.motivodemora = cartaGarantiaDTO.MotivoDem ?? "";
            model.importe = cartaGarantiaDTO.Importe;
            model.deducible = cartaGarantiaDTO.Deducible ?? "";
            model.coaseguro = cartaGarantiaDTO.Coaseguro ?? "";
            model.fechaRegistro = cartaGarantiaDTO.Fregistro;
            model.NoCubierto = cartaGarantiaDTO.NoCubierto;
            model.ObsNoCubierto = cartaGarantiaDTO.ObsNoCubierto;
            model.codtipoAtencion = cartaGarantiaDTO.TipoAten;
            model.TenfAnio = cartaGarantiaDTO.TenfAnio;
            model.TenfMes = cartaGarantiaDTO.TenfMes;
            model.TenfDia = cartaGarantiaDTO.TenfDia;
            model.diagnostico = new FiltroModel { descripcion = cartaGarantiaDTO.DiagPrincipal };
            model.especialidad = new FiltroModel { descripcion = cartaGarantiaDTO.Especialidad };
            model.medicoTratante = new FiltroModel { descripcion = cartaGarantiaDTO.MedicoTratante };
            model.nroDiasHosp = cartaGarantiaDTO.NDHosp;
            model.tipoAtencion = cartaGarantiaDTO.TipoAten;
            model.obsMedTratante = cartaGarantiaDTO.ObsMedTratante;
            model.paciente = pac;

            return model;
        }

        public static CartaGarantiaModel CartaGarantiaPSModel(CartaGarantiaDTO cartaGarantiaDTO)
        {
            CartaGarantiaModel model = new CartaGarantiaModel
            {
                idCartaGarantia = cartaGarantiaDTO.idCartaGarantia,
                paciente = pacienteModel(cartaGarantiaDTO.paciente),
                nrosolicitud = cartaGarantiaDTO.NrSolicitud,
                estado = cartaGarantiaDTO.Estado,
                colorEstado = cartaGarantiaDTO.colorEstado,
                agente = cartaGarantiaDTO.Agente,
                nrogarantia = cartaGarantiaDTO.NroCartaGarantia,
                procedimiento = cartaGarantiaDTO.Procedimiento.Trim(),
                // tipoSolicitud = cartaGarantiaDTO.TipoSol,
                fechavcto = cartaGarantiaDTO.Fvencimiento,
                financiador = cartaGarantiaDTO.Financiador,
                obsfin = cartaGarantiaDTO.obsFinanciador,
                obseGenerales = cartaGarantiaDTO.ObsGenerales,
                tipoCarta = cartaGarantiaDTO.TipoCarta,
                obsrechazado = cartaGarantiaDTO.ObsRech,
                motivodemora = cartaGarantiaDTO.MotivoDem,
                importe = cartaGarantiaDTO.Importe,
                deducible = cartaGarantiaDTO.Deducible,
                coaseguro = cartaGarantiaDTO.Coaseguro,
                fechaRegistro = cartaGarantiaDTO.Fregistro,
                NoCubierto = cartaGarantiaDTO.NoCubierto,
                ObsNoCubierto = cartaGarantiaDTO.ObsNoCubierto,
                importePresup = cartaGarantiaDTO.ImportePresup
            };
            model.codtipoAtencion = cartaGarantiaDTO.TipoAten;
            model.TenfAnio = cartaGarantiaDTO.TenfAnio;
            model.TenfMes = cartaGarantiaDTO.TenfMes;
            model.TenfDia = cartaGarantiaDTO.TenfDia;
            model.diagnostico = new FiltroModel { descripcion = cartaGarantiaDTO.DiagPrincipal };
            model.especialidad = new FiltroModel { descripcion = cartaGarantiaDTO.Especialidad };
            model.medicoTratante = new FiltroModel { descripcion = cartaGarantiaDTO.MedicoTratante };
            model.nroDiasHosp = cartaGarantiaDTO.NDHosp;
            model.tipoAtencion = cartaGarantiaDTO.TipoAten;
            model.obsMedTratante = cartaGarantiaDTO.ObsMedTratante;
            if (cartaGarantiaDTO.procedimientos != null)
            {
                model.procedimientos = cartaGarantiaDTO.procedimientos.Select(x => new FiltroModel
                {
                    codigo = x.codigo,
                    descripcion = x.descripcion
                }).ToList();
            }
            ObservacionesAuditorModel obs = new ObservacionesAuditorModel();
            obs.motivoEstado = new FiltroModel
            {
                descripcion = cartaGarantiaDTO.MotivoEstado
            };
            obs.oInterna = cartaGarantiaDTO.OInternas;
            obs.oMedica = cartaGarantiaDTO.OMedicas;
            model.auditor = obs;
            return model;
        }

        public static EpicrisisModel EpicrisisModel(InformeEpicrisisDTO dto)
        {
            EpicrisisModel model = new EpicrisisModel
            {
                Cama = dto.Cama,
                CMPDoctor = dto.CMPDoctor,
                complicaciones = dto.complicaciones,
                CondEgres = dto.CondEgres,
                Doctor = dto.Doctor,
                Especialidad = dto.Especialidad,
                Evolucion = dto.Evolucion,
                ExamenesAuxil = dto.ExamenesAuxil,
                FecEgres = dto.FecEgres,
                FIngreso = dto.FIngreso,
                HIngreso = dto.HIngreso,
                HorEgres = dto.HorEgres,
                Procedimientos = dto.Procedimientos,
                ResumenEnfeAct = dto.ResumenEnfeAct,
                TiempoEstancia = dto.TiempoEstancia,
                Tratamiento = dto.Tratamiento,
                diagnosticos = (dto.diagnosticos != null) ? listarDiagnostico(dto.diagnosticos) :
                                new List<DiagnosticosModel>()
            };

            return model;
        }

        public static List<FiltroModel> filtroModel(List<FiltrosDTO> list)
        {
            List<FiltroModel> model = new List<FiltroModel>();
            model = list.Select(x => new FiltroModel
            {
                codigo = x.codigo,
                descripcion = x.descripcion
            }).ToList();
            return model;
        }

        public static List<lstCartaGarantiaModel> listarCartasGarantia(List<CartaGarantiaDTO> list)
        {
            List<lstCartaGarantiaModel> model = new List<lstCartaGarantiaModel>();
            model = list.Select(x => new lstCartaGarantiaModel
            {
                id = x.idCartaGarantia,
                nrosolicitud = x.NrSolicitud,
                fechaRegistro = x.Fregistro,
                procedimiento = x.Procedimiento.Trim(),
                tipoSolicitud = x.TipoSol,
                nompaciente = x.paciente.Nombre,
                estado = x.Estado,
                colorEstado = x.colorEstado
            }).ToList();
            return model;
        }

        public static List<DetalleSerAuxModel> listaDetallesSA(List<DetalleServicioDTO> listDto)
        {
            IEnumerable<DetalleSerAuxModel> listModel = new List<DetalleSerAuxModel>();
            if (listDto != null)
            {
                listModel = listDto.Select(x => new DetalleSerAuxModel
                {
                    NroServicio = x.NroServicio,
                    Descripcion = x.Descripcion,
                    Tipo = x.TipoServ,
                    Examinador = x.Examinador,
                    FechaProc = x.FechaProc.ToString("dd-MM-yyyy"),
                    FueraRango = x.FueraRango,
                    Razon = x.Razon,
                    Referencia = x.Referencia,
                    Resultados = x.Resultados,
                    ResultIn = x.ResultIn,
                    Unidad = x.Unidad
                });
            }
            return listModel.ToList();
        }

        public static List<DiagnosticosModel> listarDiagnostico(IEnumerable<DiagnosticoDTO> list)
        {
            List<DiagnosticosModel> lista = new List<DiagnosticosModel>();
            if (list != null)
            {
                lista = list.Select(z => new DiagnosticosModel
                {
                    Codigo = z.CodigoDiagnostico,
                    Detalle = z.Detalle,
                    Tipo = z.Tipo
                }).ToList();
            }


            return lista;
        }

        public static List<MedicinasModel> listMedicinas(IEnumerable<MedicinaDTO> listDto)
        {
            IEnumerable<MedicinasModel> listModel = new List<MedicinasModel>();
            if (listDto != null)
            {

                listModel = listDto.Select(x => new MedicinasModel
                {
                    Cantidad = x.cantidad,
                    DescripcionProducto = x.Descripcion,
                    ProductoChavin = x.CodMedicina,
                    NroAtencion = x.NroAtencion,
                    PrincipioActivo = x.DescMedicina,
                    FechaAt = x.FechaAt.ToString("dd/MM/yyyy"),
                    Dosis = x.dosis,
                    Cada = x.cada,
                    Via = x.via,
                    Observacion = x.observacion,
                    Intervalo = x.intervalo,
                    TipoProducto = x.TipoProducto,
                    Forma = x.Forma
                    ,
                    Codigo = x.CodMedicina
                });
            }
            return listModel.ToList();
        }

        public static List<MedicinasModel> listMedicinasParaReceta(IEnumerable<MedicinaDTO> listDto)
        {
            IEnumerable<MedicinasModel> listModel = new List<MedicinasModel>();
            if (listDto != null)
            {
                listModel = listDto.Select(x => new MedicinasModel
                {
                    Codigo = x.CodMedicina,
                    DescripcionProducto = x.Descripcion,
                    PrincipioActivo = x.DescMedicina,
                    TipoProducto = x.TipoProducto,
                    Forma = x.Forma,
                    Stock = x.Stock,
                    CodigoGrupoFormaFarmaceutica = x.CodigoGrupoFormaFarmaceutica,
                    UnidadVentaProducto = x.UnidadVentaProducto,
                    UMVAbreviado = x.UMVAbreviado
                });
            }
            return listModel.ToList();
        }

        /*
          * Agregado por ETITO::BCLOUD
          */
        public static VideoConferenciaModel ObtenerVideoConferenciaModelDesdeDTO(VideoConferenciaDTO dto)
        {
            VideoConferenciaModel listModel = new VideoConferenciaModel();
            if (dto != null)
            {
                listModel = new VideoConferenciaModel()
                {
                    IndentificadorUnico = dto.IdentificadorUnico,
                    VideoConferenciaURL = dto.VideoConferenciaUrl
                };
            }
            return listModel;
        }
        /*
         * 
         */

        protected static string diag(string cod1, string dia1, string cod2, string dia2, string cod3, string dia3)
        {
            string diagnostico = "";
            diagnostico += (cod1 != "") ? "<b> " + cod1 + ": </b>" + dia1 : "";
            diagnostico += (cod2 != "") ? ", <b> " + cod2 + ": </b> " + dia2 : "";
            //diagnostico += (cod3 != "") ?  " ("+cod3 + ") " +dia3 : "";
            return diagnostico;

        }

        protected static string converMinus(string valor)
        {
            return (valor != null) ? valor.ToLower() : "";
        }
    }
}
