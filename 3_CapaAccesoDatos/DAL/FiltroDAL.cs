using _3_CapaAccesoDatos.BD;
using _3_CapaAccesoDatos.IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CapaAccesoDatos.DAL
{
    public class FiltroDAL : BaseContextCRPCG, IFiltroDAL
    {
        public List<SelectAutocomplete_Result> diagnosticos(string term)
        {
            try
            {
                List<SelectAutocomplete_Result> diagnosticos = new List<SelectAutocomplete_Result>();
                diagnosticos = _context.PRGUR_FiltrosAutocompletar(ConstanteDB.FiltroCIE,term).ToList();
                return diagnosticos;
            }
            catch (Exception e)
            {
                log.Error("PRGUR_FiltroServicios" + e.Message + "\n" + e.ToString());
                new LOG("Error", "", "PRGUR_FiltroServicios", e.Message, e.ToString());
            }
            return new List<SelectAutocomplete_Result>();
        }

        public List<Filtros_Result> especialidades()
        {
            List<Filtros_Result> especialidades = new List<Filtros_Result>();
            try
            {
                especialidades = _context.PRGUR_Filtros(ConstanteDB.FiltroServicio).ToList();
            }
            catch (Exception e)
            {
                new LOG("Error", "", "PRGUR_FiltroServicios", e.Message, e.ToString());
            }
            return especialidades;
        }


        public List<Filtros_Result> especialidadesMedicas()
        {
            List<Filtros_Result> especialidades = new List<Filtros_Result>();
            try
            {
                especialidades = _context.PRGUR_Filtros(ConstanteDB.FiltroEspecialidades).ToList();
            }
            catch (Exception e)
            {
                new LOG("Error", "", "PRGUR_FiltroEspecialidMedica", e.Message, e.ToString());
            }
            return especialidades;
            }

        public List<Filtros_Result> estadoPreQx()
        {
            try
            {
                List<Filtros_Result> estado = new List<Filtros_Result>();
                estado = _context.PRGUR_Filtros(ConstanteDB.FiltroEstadoPreQx).ToList();
                return estado;
            }
            catch (Exception e)
            {
                log.Error("PRGUR_FiltroEstado" + e.Message + "\n" + e.ToString());
                new LOG("Error", "", "PRGUR_FiltroEstado", e.Message, e.ToString());
            }
            return new List<Filtros_Result>();
        }

        public List<Filtros_Result> estadoCartaAuditor()
        {
            try
            {
                List<Filtros_Result> estado = new List<Filtros_Result>();
                estado = _context.PRGUR_Filtros(ConstanteDB.FiltroEstadoCartaAuditor).ToList();
                return estado;
            }
            catch (Exception e)
            {
                log.Error("PRGUR_FiltroEstado" + e.Message + "\n" + e.ToString());
                new LOG("Error", "", "PRGUR_FiltroEstado", e.Message, e.ToString());
            }
            return new List<Filtros_Result>();
        }

        public List<Filtros_Result> financiador()
        {
            try
            {
                List<Filtros_Result> estado = new List<Filtros_Result>();
                estado = _context.PRGUR_Filtros(ConstanteDB.FiltroFinanciador).ToList();
                return estado;
            }
            catch (Exception e)
            {
                log.Error("PRGUR_FiltroEstado" + e.Message + "\n" + e.ToString());
                new LOG("Error", "", "PRGUR_FiltroEstado", e.Message, e.ToString());
            }
            return new List<Filtros_Result>();
        }

        public List<SelectAutocomplete_Result> insumosvarios(string term)
        {
            try
            {
                List<SelectAutocomplete_Result> insumosvarios = new List<SelectAutocomplete_Result>();
                insumosvarios = _context.PRGUR_FiltrosAutocompletar(ConstanteDB.FiltroInsumoVarios, term).ToList();
                return insumosvarios;
            }
            catch (Exception e)
            {
                log.Error("PRGUR_FiltroServicios" + e.Message + "\n" + e.ToString());
                new LOG("Error", "", "PRGUR_FiltroServicios", e.Message, e.ToString());
            }
            return new List<SelectAutocomplete_Result>();
        }

        public List<SelectAutocomplete_Result> medico(string term)
        {
            try
            {
                List<SelectAutocomplete_Result> medicos = new List<SelectAutocomplete_Result>();
                medicos = _context.PRGUR_FiltrosAutocompletar(ConstanteDB.FiltroMedico,term).ToList();
                return medicos;
            }
            catch (Exception e)
            {
                log.Error("PRGUR_FiltroServicios" + e.Message + "\n" + e.ToString());
                new LOG("Error", "", "PRGUR_FiltroServicios", e.Message, e.ToString());
            }
            return null;
        }

        public List<SelectAutocomplete_Result> motivoEstadoAuditar(string codestado)
        {
            try
            {
                List<SelectAutocomplete_Result> motivos = new List<SelectAutocomplete_Result>();
                motivos = _context.PRGUR_FiltrosAutocompletar(ConstanteDB.FiltroMotivoAuditor,codestado).ToList();
                return motivos;
            }
            catch (Exception e)
            {
                log.Error("PRGUR_FiltroServicios" + e.Message + "\n" + e.ToString());
                new LOG("Error", "", "PRGUR_FiltroServicios", e.Message, e.ToString());
            }
            return null;
        }

        public List<SelectAutocomplete_Result> procedimientos(string term)
        {
            try
            {
                List<SelectAutocomplete_Result> procedimientos = new List<SelectAutocomplete_Result>();
                procedimientos = _context.PRGUR_FiltrosAutocompletar(ConstanteDB.FiltroProcedimiento,term).ToList();
                return procedimientos;
            }
            catch (Exception e)
            {
                log.Error("PRGUR_FiltroServicios" + e.Message + "\n" + e.ToString());
                new LOG("Error", "", "PRGUR_FiltroServicios", e.Message, e.ToString());
            }
            return null;
        }

        public List<SelectAutocomplete_Result> laboratorio(string term)
        {
            try
            {
                List<SelectAutocomplete_Result> list = new List<SelectAutocomplete_Result>();
                list = _context.PRGUR_FiltrosAutocompletar(ConstanteDB.FiltroLaboratorio, term).ToList();
                return list;
            }
            catch (Exception e)
            {
                log.Error("PRGUR_FiltroServicios" + e.Message + "\n" + e.ToString());
                new LOG("Error", "", "PRGUR_FiltroServicios", e.Message, e.ToString());
            }
            return null;
        }

        public List<SelectAutocomplete_Result> radiologia(string term)
        {
            try
            {
                List<SelectAutocomplete_Result> list = new List<SelectAutocomplete_Result>();
                list = _context.PRGUR_FiltrosAutocompletar(ConstanteDB.FiltroRadiologia, term).ToList();
                return list;
            }
            catch (Exception e)
            {
                log.Error("PRGUR_FiltroServicios" + e.Message + "\n" + e.ToString());
                new LOG("Error", "", "PRGUR_FiltroServicios", e.Message, e.ToString());
            }
            return null;
        }
        public List<Filtros_Result> TipoCirugia()
        {
            try
            {
                List<Filtros_Result> estado = new List<Filtros_Result>();
                estado = _context.PRGUR_Filtros(ConstanteDB.FiltroTipoCirugia).ToList();
                return estado;
            }
            catch (Exception e)
            {
                log.Error("PRGUR_FiltroEstado" + e.Message + "\n" + e.ToString());
                new LOG("Error", "", "PRGUR_FiltroEstado", e.Message, e.ToString());
            }
            return new List<Filtros_Result>();
        }

        public List<Filtros_Result> tipoDocumentoPS()
        {
            try
            {
                List<Filtros_Result> tipodocumentos = new List<Filtros_Result>();
                tipodocumentos = _context.PRGUR_Filtros(ConstanteDB.FiltroTipoDocumentoPS).ToList();
                return tipodocumentos;
            }
            catch (Exception e)
            {
                log.Error("PRGUR_FiltroTipoDocPS" + e.Message + "\n" + e.ToString());
                new LOG("Error", "", "PRGUR_FiltroTipoDocPS", e.Message, e.ToString());
            }
            return new List<Filtros_Result>();
        }

        public List<SelectAutocomplete_Result> criterioEstado(string codigo)
        {
                List<SelectAutocomplete_Result> lista = new List<SelectAutocomplete_Result>();
               
            try
            {
                lista = _context.PRGUR_FiltrosAutocompletar(ConstanteDB.FiltroCriterioEstadoPreQx, codigo).ToList();
            }
            catch (Exception e)
            {
                new LOG("Error", "", "PRGUR_FiltrosAutocompletar", e.Message, e.ToString());
            }
            return lista;
        }

        public List<Filtros_Result> sala()
        {

            List<Filtros_Result> salas = new List<Filtros_Result>();
            try
            {
                salas = _context.PRGUR_Filtros(ConstanteDB.FiltroSala).ToList();
            }
            catch (Exception e)
            {
                new LOG("Error", "", "PRGUR_FiltroServicios", e.Message, e.ToString());
            }
            return salas;
        }

        public string anexoProgramadorSala()
        {
            string anexo = "";
            try
            {
                var filtros = _context.PRGUR_Filtros(ConstanteDB.DTAnexoProgSala).ToList().FirstOrDefault();
                anexo = filtros.DESCRIPCION;
            }
            catch (Exception e)
            {
                new LOG("Error", "", "PRGUR_FiltroAnexo", e.Message, e.ToString());
            }
            return anexo;
        }

        public List<Filtros_Result> financiadorFAT()
        {
            try
            {
                List<Filtros_Result> estado = new List<Filtros_Result>();
                estado = _context.PRGUR_Filtros(ConstanteDB.FiltroFinanciadorFAT).ToList();
                return estado;
            }
            catch (Exception e)
            {
                log.Error("PRGUR_Filtrofat" + e.Message + "\n" + e.ToString());
                new LOG("Error", "", "PRGUR_Filtrofat", e.Message, e.ToString());
            }
            return new List<Filtros_Result>();
        }

        public List<Filtros_Result> ViaMedicacion()
        {
            List<Filtros_Result> lista = new List<Filtros_Result>();
            try
            {
                lista = _context.PRGUR_Filtros(ConstanteDB.FiltroVia).ToList();
            }
            catch (Exception e)
            {
                new LOG("Error", "", "PRGUR_Filtros", e.Message, e.ToString());
            }
            return lista;
        }

        public List<SelectAutocomplete_Result> ViaMedicacionPorCodigoGrupoFarmaceutico(string codigoGrupo)
        {
            List<SelectAutocomplete_Result> lista = new List<SelectAutocomplete_Result>();
            try
            {
                lista = _context.PRGUR_FiltrosAutocompletar(ConstanteDB.FiltroVia, codigoGrupo).ToList();
            }
            catch (Exception e)
            {
                new LOG("Error", "", "PRGUR_Filtros", e.Message, e.ToString());
            }
            return lista;
        }

        public List<SelectAutocomplete_Result> UnidadPrescripcionPorCodigoGrupoFarmaceutico(string codigoGrupo)
        {
            List<SelectAutocomplete_Result> lista = new List<SelectAutocomplete_Result>();
            try
            {
                lista = _context.PRGUR_FiltrosAutocompletar(ConstanteDB.FiltroUnidadPrescripcion, codigoGrupo).ToList();
            }
            catch (Exception e)
            {
                new LOG("Error", "", "PRGUR_Filtros", e.Message, e.ToString());
            }
            return lista;
        }

        public List<Filtros_Result> TiempoMedicacion()
        {
            List<Filtros_Result> lista = new List<Filtros_Result>();
            try
            {
                lista = _context.PRGUR_Filtros(ConstanteDB.FiltroTiempo).ToList();
            }
            catch (Exception e)
            {
                new LOG("Error", "", "PRGUR_Filtros", e.Message, e.ToString());
            }
            return lista;
        }
    }
}
