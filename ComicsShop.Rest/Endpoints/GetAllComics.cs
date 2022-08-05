using ComicsShop.Rest.Mappers;
using ComicsShop.Rest.Services;
using MinimalApi.Endpoint;

namespace ComicsShop.Rest.Endpoints;

public class GetAllComics : IEndpoint<IEnumerable<ComicsResponse>>
{
    private readonly IComicsService _service;
    private readonly IComicsMapper _mapper;

    public GetAllComics(IComicsService service, IComicsMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("/comics", HandleAsync);
    }

    public async Task<IEnumerable<ComicsResponse>> HandleAsync()
    {
        var data = await _service.GetAll();

        return _mapper.MapToComicsListResponse(data);
    }
}