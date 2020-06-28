using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Starwars.Jedis.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Code
{
    public class StarwarsDynamicRouteValueTransformer : DynamicRouteValueTransformer
    {
        private IJediBusiness _jediBusiness;

        public StarwarsDynamicRouteValueTransformer(IJediBusiness jediBusiness)
        {
            _jediBusiness = jediBusiness;
        }

        public override ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, 
                                                                       RouteValueDictionary values)
        {
            var jediEndpoint = values["jediendpoint"] as string;

            if (string.IsNullOrEmpty(jediEndpoint))
            {
                return new ValueTask<RouteValueDictionary>(new RouteValueDictionary()); 
            }

            var jedi = _jediBusiness.GetByEndpoint(jediEndpoint);

            if (jedi == null)
            {
                return new ValueTask<RouteValueDictionary>(new RouteValueDictionary() {
                    { "controller", "Starwars" },
                    { "action", "JediNotFound" }
                });
            }

            var route = new RouteValueDictionary()
            {
                { "controller", "Starwars" },
                { "action", "JediDetails" },
                { "id", jedi.Id },
            }; 

           
            return new ValueTask<RouteValueDictionary>(route);
        }
    }
}
