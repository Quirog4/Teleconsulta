using _3_CapaAccesoDatos.BD;
using _3_CapaAccesoDatos.IDAL;
using CapaSoporte.LogAplicacion;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace _3_CapaAccesoDatos.DAL
{

    public class PacienteDAL : BaseContextHCD, IPacienteDAL
    {

        public IEnumerable<ListadoPacientes_Result> getPacientes(string hcd, string nombres)
        {  IEnumerable<ListadoPacientes_Result> listado = new List<ListadoPacientes_Result>();
           
            try
            {
                   if (hcd != "")
                {
                    listado = _context.PRHCD_SELPACIENTE(hcd, ConstanteDB.BusquedaHCU).ToList();
                }
                else
                {
                    listado = _context.PRHCD_SELPACIENTE(nombres, ConstanteDB.BusquedaNombre).ToList();
                }

                return listado;
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error",
                   parametros: "hcd:"+hcd+"_nombres:"+nombres,
                   ruta_sp: "Capa AccesoDatos : PRHCD_SELPACIENTE",
                   detalle: e.Message,
                   mensaje: e.ToString());
            }
            Control.bug = true;
            Control.mensaje = "Ocurrio un error al intentar mostrar los pacientes, porfavor intentelo más tarde o comuniquede con el administrador del sistema";
            return listado;
        }
        public PacienteFAT_Result getPacienteFAT(string nrodoc)
        {
            try
            {
                PacienteFAT_Result paciente = new PacienteFAT_Result();
                paciente = _context.PRFAT_BUSCAR_HC_DOC(iS_HC_DOCUMENTO: nrodoc, iS_tipoBusqueda: ConstanteDB.BusquedaDoc).FirstOrDefault();
                return paciente;
            }
            catch (Exception e)
            {
                new LOG(tipo: "Error", parametros: "idfat:" + nrodoc,
                                  ruta_sp: "Capa AccesoDatos : PRFAT_BUSCAR_HC_DOC",
                                  detalle: e.Message,
                                  mensaje: e.ToString());

            }
            return new PacienteFAT_Result();
        }
    }
}
