﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _3_CapaAccesoDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class HCDigitalCRPEntities : DbContext
    {
        public HCDigitalCRPEntities()
            : base("name=HCDigitalCRPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TGUR_LOGDEBUG> TGUR_LOGDEBUG { get; set; }
    
        public virtual ObjectResult<ListMedicinasXAte_Result> PRHCD_MEDICINAxAte(string nroAtencion)
        {
            var nroAtencionParameter = nroAtencion != null ?
                new ObjectParameter("NroAtencion", nroAtencion) :
                new ObjectParameter("NroAtencion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListMedicinasXAte_Result>("PRHCD_MEDICINAxAte", nroAtencionParameter);
        }
    
        public virtual ObjectResult<SelMedicos_Result> PRHCD_SELMEDICO()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelMedicos_Result>("PRHCD_SELMEDICO");
        }
    
        public virtual ObjectResult<ListDetServAux_Result> PRHCD_DETSERVAUX(string nroAtencion)
        {
            var nroAtencionParameter = nroAtencion != null ?
                new ObjectParameter("nroAtencion", nroAtencion) :
                new ObjectParameter("nroAtencion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListDetServAux_Result>("PRHCD_DETSERVAUX", nroAtencionParameter);
        }
    
        public virtual ObjectResult<ListadoPacientes_Result> PRHCD_SELPACIENTE(string nombre, Nullable<int> fLG_BUSACAR)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var fLG_BUSACARParameter = fLG_BUSACAR.HasValue ?
                new ObjectParameter("FLG_BUSACAR", fLG_BUSACAR) :
                new ObjectParameter("FLG_BUSACAR", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListadoPacientes_Result>("PRHCD_SELPACIENTE", nombreParameter, fLG_BUSACARParameter);
        }
    
        public virtual ObjectResult<DetalleAtenciones_Result> PRHCD_ATENCIONES(string i_sHC, string i_sIP, string i_sUser, string i_sPaciente)
        {
            var i_sHCParameter = i_sHC != null ?
                new ObjectParameter("I_sHC", i_sHC) :
                new ObjectParameter("I_sHC", typeof(string));
    
            var i_sIPParameter = i_sIP != null ?
                new ObjectParameter("I_sIP", i_sIP) :
                new ObjectParameter("I_sIP", typeof(string));
    
            var i_sUserParameter = i_sUser != null ?
                new ObjectParameter("I_sUser", i_sUser) :
                new ObjectParameter("I_sUser", typeof(string));
    
            var i_sPacienteParameter = i_sPaciente != null ?
                new ObjectParameter("I_sPaciente", i_sPaciente) :
                new ObjectParameter("I_sPaciente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DetalleAtenciones_Result>("PRHCD_ATENCIONES", i_sHCParameter, i_sIPParameter, i_sUserParameter, i_sPacienteParameter);
        }
    
        public virtual ObjectResult<PacienteFAT_Result> PRFAT_BUSCAR_HC_DOC(string iS_HC_DOCUMENTO, string iS_tipoBusqueda)
        {
            var iS_HC_DOCUMENTOParameter = iS_HC_DOCUMENTO != null ?
                new ObjectParameter("IS_HC_DOCUMENTO", iS_HC_DOCUMENTO) :
                new ObjectParameter("IS_HC_DOCUMENTO", typeof(string));
    
            var iS_tipoBusquedaParameter = iS_tipoBusqueda != null ?
                new ObjectParameter("IS_tipoBusqueda", iS_tipoBusqueda) :
                new ObjectParameter("IS_tipoBusqueda", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PacienteFAT_Result>("PRFAT_BUSCAR_HC_DOC", iS_HC_DOCUMENTOParameter, iS_tipoBusquedaParameter);
        }
    }
}
