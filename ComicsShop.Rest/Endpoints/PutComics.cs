using ComicsShop.Rest.Entities;
using ComicsShop.Rest.Services;
using ComicsShop.Rest.Mappers;
using MinimalApi.Endpoint;

namespace ComicsShop.Rest.Endpoints;

public class PutComics : IEndpoint<IResult, string, Comics>
{
    private readonly IComicsService _service;
    private readonly IComicsMapper _mapper;

    public PutComics(IComicsService service, IComicsMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapPut("/comics/{id}", (string id, Comics comics) => HandleAsync(id, comics));
    }

    public async Task<IResult> HandleAsync(string id, Comics comics)
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

        var result = await _service.UpdateById(newGuid, comics);

        return Results.Ok(_mapper.MapToComicsResponse(result));
    }
}