﻿using BackOffice.WebApi.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace PedidoApi;

public static class PedidoEndpoints
{

    public static void MapPedidoModelEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Pedidos").WithTags("Pedidos");

        group.MapPost("/", async (PedidoRequestModel request, [FromServices] QueueService service) =>
        {
            request.Id = Guid.NewGuid();
            service.Publish(request);

            return TypedResults.Created($"/api/PedidoModel/{request.Id}", request);
        })
     .WithName("CreatePedidoModel");
    }
}