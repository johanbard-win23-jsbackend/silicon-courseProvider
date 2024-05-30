using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace silicon_courseProvider.Functions;

public class GraphQL
{
    private readonly ILogger<GraphQL> _logger;
    private readonly IGraphQLRequestExecutor _executor;

    public GraphQL(ILogger<GraphQL> logger, IGraphQLRequestExecutor executor)
    {
        _logger = logger;
        _executor = executor;
    }

    [Function("GraphQL")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "graphql")] HttpRequest req)
    {
       return await _executor.ExecuteAsync(req);
    }
}
