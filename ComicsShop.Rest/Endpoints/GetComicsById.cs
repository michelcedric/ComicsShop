using ComicsShop.Rest.Mappers;
using ComicsShop.Rest.Services;
using MinimalApi.Endpoint;

namespace ComicsShop.Rest.Endpoints;

public class GetComicsById : IEndpoint<IResult, string>
{
    private readonly IComicsService _service;
    private readonly IComicsMapper _mapper;

    public GetComicsById(IComicsService service, IComicsMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("/comics/{id}", (string id) => HandleAsync(id));
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

        return Results.Ok(_mapper.MapToComicsResponse(data));
    }
}