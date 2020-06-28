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
        private IItemLocalizerBusiness _itemLocalizerBusiness;

        public StarwarsDynamicRouteValueTransformer(IJediBusiness jediBusiness,
                                                    IItemLocalizerBusiness itemLocalizerBusiness)
        {
            _jediBusiness = jediBusiness;
            _itemLocalizerBusiness = itemLocalizerBusiness;
        }

        public override ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, 
                                                                       RouteValueDictionary values)
        {
            var language = values["language"] as string;
            if (string.IsNullOrEmpty(language))
            {
                language = "en";
            }

            var endpoint = values["endpoint"] as string;

            if (string.IsNullOrEmpty(endpoint))
            {
                return new ValueTask<RouteValueDictionary>(values);
            }

            var endpointSegment = endpoint.Split("/");

            var itemLocalizable = _itemLocalizerBusiness.GetByEndpoint(language, endpointSegment[0]);

            if (itemLocalizable == null)
            {
                return new ValueTask<RouteValueDictionary>(new RouteValueDictionary() {
                    { "controller", "Starwars" },
                    { "action", "GroupNotFound" }
                });
            }

            var jedi = _jediBusiness.GetByEndpoint(endpointSegment[1]);

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
                { "action", "GroupDetails" },
                { "language", language },
                { "itemKey", itemLocalizable.Key },
                { "jediId", jedi.Id }
            }; 

           
            return new ValueTask<RouteValueDictionary>(route);
        }
    }
}
