using ComicsShop.Rest.Mappers;
using ComicsShop.Rest.Services;
using MinimalApi.Endpoint;

namespace ComicsShop.Rest.Endpoints;

public class GetAllComics : IEndpoint<IEnumerable<ComicsResponse>, IComicsService>
{
    private readonly IComicsMapper _mapper;

    public GetAllComics(IComicsMapper mapper)
    {
        _mapper = mapper;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("/comics", (IComicsService service) =>
        {
            return HandleAsync(service);
        });
    }

    public async Task<IEnumerable<ComicsResponse>> HandleAsync(IComicsService service)
    {
        var data = await service.GetAll();

        return _mapper.MapToComicsListResponse(data);
    }
}