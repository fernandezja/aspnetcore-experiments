using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Starwars.Jedis.Business.Interfaces;

namespace WebApplication1.Code;

public class StarwarsDynamicRouteValueTransformer(
    IJediBusiness jediBusiness,
    IItemLocalizerBusiness itemLocalizerBusiness) : DynamicRouteValueTransformer
{
    public override ValueTask<RouteValueDictionary> TransformAsync(
        HttpContext httpContext,
        RouteValueDictionary values)
    {
        var language = values["language"] as string;
        if (string.IsNullOrWhiteSpace(language))
        {
            language = "en";
        }

        var endpoint = values["endpoint"] as string;
        if (string.IsNullOrWhiteSpace(endpoint))
        {
            return new ValueTask<RouteValueDictionary>(values);
        }

        var endpointSegments = endpoint.Split(
            '/',
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        if (endpointSegments.Length < 2)
        {
            return new ValueTask<RouteValueDictionary>(CreateJediNotFoundRoute());
        }

        var itemLocalizable = itemLocalizerBusiness.GetByEndpoint(language, endpointSegments[0]);
        if (itemLocalizable is null)
        {
            return new ValueTask<RouteValueDictionary>(CreateGroupNotFoundRoute());
        }

        var jedi = jediBusiness.GetByEndpoint(endpointSegments[1]);
        if (jedi is null)
        {
            return new ValueTask<RouteValueDictionary>(CreateJediNotFoundRoute());
        }

        var route = new RouteValueDictionary
        {
            { "controller", "Starwars" },
            { "action", "GroupDetails" },
            { "language", language },
            { "itemKey", itemLocalizable.Key },
            { "jediId", jedi.Id }
        };

        return new ValueTask<RouteValueDictionary>(route);
    }

    private static RouteValueDictionary CreateGroupNotFoundRoute() => new()
    {
        { "controller", "Starwars" },
        { "action", "GroupNotFound" }
    };

    private static RouteValueDictionary CreateJediNotFoundRoute() => new()
    {
        { "controller", "Starwars" },
        { "action", "JediNotFound" }
    };
}
