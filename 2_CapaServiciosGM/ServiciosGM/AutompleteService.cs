using _2_CapaServiciosGM.InterfaceGM;
using _3_CapaAccesoDatos;
using _3_CapaAccesoDatos.DAL;
using _3_CapaAccesoDatos.IDAL;
using System;
using System.Collections.Generic;

namespace _2_CapaServiciosGM.ServiciosGM
{
    public class AutompleteService : IAutocompleteService
    {
        public List<PRFAT_Autocompletar_Result> listaDiagnostico(string term)
        {
            try
            {
                IAutcompleteDAL _dal = new AutocompleteDAL();

                return _dal.listaDiagnostico(term);
            }
            catch (Exception) {
                return new List<PRFAT_Autocompletar_Result>();
            }
        }

        public List<PRFAT_Autocompletar_Result> listaLaboratorio(string term)
        {
            try
            {
                IAutcompleteDAL _dal = new AutocompleteDAL();

                return _dal.listaLaboratorio(term);
            }
            catch (Exception)
            {
                return new List<PRFAT_Autocompletar_Result>();
            }
        }

        public List<PRFAT_Autocompletar_Result> listaRadiologia(string term)
        {
            try
            {
                IAutcompleteDAL _dal = new AutocompleteDAL();

                return _dal.listaRadiologia(term);
            }
            catch (Exception)
            {
                return new List<PRFAT_Autocompletar_Result>();
            }
        }
    }
}
