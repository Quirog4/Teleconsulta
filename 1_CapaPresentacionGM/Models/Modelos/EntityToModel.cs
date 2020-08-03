using _3_CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _1_CapaPresentacionGM.Models.Modelos
{
    public class EntityToModel
    {
        public static List<UIAutocompleteModel> listaAutocomplete(List<PRFAT_Autocompletar_Result> lst)
        {
            List<UIAutocompleteModel> list = lst.Select(l =>
         new UIAutocompleteModel
         {
             codigo = l.CODIGO,
             descripcion = l.DESCRIPCION,
             id = l.id
         }).ToList();
            return list;
        }

        public static TeleconsultaModel teleconsultaModel(TFAT_ATENCION telec)
        {
            TeleconsultaModel t = new TeleconsultaModel();
            t.IdAtencion = telec.CFAT_ID_ATENCION;
            t.HoraCita = telec.SFAT_HORA_CITA;
            t.Estado = (telec.CFAT_ESTADO == 1) ?
                    "PENDIENTE" : (telec.CFAT_ESTADO == 2) ?
                    "ADMITIDO" : (telec.CFAT_ESTADO == 3) ?
                    "CERRADO" : (telec.CFAT_ESTADO == 4) ?
                    "ANULADO" : "";
            t.Anamnesis = telec.SFAT_ANAMNESIS;
            t.Motivo = telec.SFAT_MOTIVO;
            t.Receta = telec.SFAT_TRATAMIENTO;
            t.OAA = telec.SFAT_OAA;
            t.usuarioOAA = telec.SFAT_USUARIO_OAA;
            t.tipoAtencion = (telec.CFAT_ID_ATENCION == 1) ?
                    "TELECONSULTA" : "";
            t.medioContacto = telec.SFAT_MEDIOCONTACTO;
            t.FechaCita = Convert.ToDateTime( telec.DFAT_FECHA_CITA).ToShortDateString();
            t.fechaOAA = Convert.ToDateTime(telec.DFAT_FECHA_OAA).ToShortDateString();
            return t;
        }
     
    }
}