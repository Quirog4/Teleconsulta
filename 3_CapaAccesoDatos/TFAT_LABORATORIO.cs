//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class TFAT_LABORATORIO
    {
        public int CFAT_ID_ATENCION { get; set; }
        public string SFAT_CODIGO { get; set; }
        public Nullable<bool> CFAT_ESTADO { get; set; }
        public string SFAT_USR_CREACION { get; set; }
        public Nullable<System.DateTime> DFAT_FEC_CREACION { get; set; }
        public string SFAT_OBSERVACIONES_LB { get; set; }
    
        public virtual TFAT_ATENCION TFAT_ATENCION { get; set; }
    }
}
