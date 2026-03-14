using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Starwars.Jedis.Business.Interfaces;

namespace WebApplication1.Code;

public class StarwarsDynamicRouteValueTransformer(IJediBusiness jediBusiness) : DynamicRouteValueTransformer
{
    public override ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext,
                                                                   RouteValueDictionary values)
    {
        var jediEndpoint = values["jediendpoint"] as string;

        if (string.IsNullOrEmpty(jediEndpoint))
            return new ValueTask<RouteValueDictionary>(new RouteValueDictionary());

        var jedi = jediBusiness.GetByEndpoint(jediEndpoint);

        if (jedi is null)
        {
            return new ValueTask<RouteValueDictionary>(new RouteValueDictionary
            {
                { "controller", "Starwars" },
                { "action", "JediNotFound" }
            });
        }

        return new ValueTask<RouteValueDictionary>(new RouteValueDictionary
        {
            { "controller", "Starwars" },
            { "action", "JediDetails" },
            { "id", jedi.Id },
        });
    }
}
