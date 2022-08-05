using ComicsShop.Rest.Entities;
using ComicsShop.Rest.Services;
using ComicsShop.Rest.Mappers;
using MinimalApi.Endpoint;

namespace ComicsShop.Rest.Endpoints;

public class DeleteComicsById : IEndpoint<IResult, string>
{
    private readonly IComicsService _service;

    public DeleteComicsById(IComicsService service)
    {
        _service = service;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapDelete("/comics/{id}", (string id) => HandleAsync(id));
    }

    public async Task<IResult> HandleAsync(string id)
    {
        if (!Guid.TryParse(id, out var newGuid))
        {
            return Results.BadRequest("Id is not GUID");
        }

        var data = await _service.GetById(newGuid);

        if (data is null)
        {
            return Results.NotFound("Comics not found");
        }

        await _service.Delete(newGuid);

        return Results.NoContent();
    }
}