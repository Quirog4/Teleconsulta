﻿using System.Web;
using System.Web.Mvc;

namespace _1_CapaPresentacionGM
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
