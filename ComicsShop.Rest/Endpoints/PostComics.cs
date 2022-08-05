using ComicsShop.Rest.Entities;
using ComicsShop.Rest.Mappers;
using ComicsShop.Rest.Services;
using MinimalApi.Endpoint;

namespace ComicsShop.Rest.Endpoints;

public class PostComics : IEndpoint<IResult, Comics>
{
    private readonly IComicsService _service;
    private readonly IComicsMapper _mapper;

    public PostComics(IComicsService service, IComicsMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapPost("/comics", HandleAsync);
    }

    public async Task<IResult> HandleAsync(Comics comics)
    {
        try
        {
            var data = await _service.Create(comics);
            return Results.Created($"/comics/{data.Id}", _mapper.MapToComicsResponse(data));
        }
        catch
        {
            return Results.BadRequest("Could not create new entity");
        }
    }
}