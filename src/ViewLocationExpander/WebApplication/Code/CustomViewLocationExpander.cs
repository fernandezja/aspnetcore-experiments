using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Code
{
    public class CustomViewLocationExpander : IViewLocationExpander
    {
        public static IEnumerable<string> Locations
        {
            get
            {
                return new string[] {"/Views/{1}/{0}.cshtml",
                                    "/Views/Shared/{0}.cshtml",
                                    "/Views/Components/{1}/{0}.cshtml",

                                    "/ViewExternalFolder2/{0}.cshtml",
                                    "/ViewExternalFolder2/{1}/{0}.cshtml",
                                    "/ViewExternalFolder2/Shared/{0}.cshtml",
                                    "/ViewExternalFolder2/Components/{0}.cshtml",

                                     "/ViewExternalFolder3/{0}.cshtml"
                                    };
            }
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            return Locations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Values["customviewlocation"] = nameof(CustomViewLocationExpander);
        }
    }
}
