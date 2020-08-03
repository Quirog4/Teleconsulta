using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_CapaPresentacionGM.Models
{
    public class Recaptchav3_Variables
    {
        public string SiteKey  { get; set; }

        public string SecretKey { get; set; }

        public Recaptchav3_Variables() {
            this.SiteKey="6LfUIOoUAAAAAOTs_VcetpzS75bGzgsM3PQp9t-E";
            this.SecretKey = "6LfUIOoUAAAAAHS_H52rqSqB6H6vplUd_cjiocgT";
        }
    }
}