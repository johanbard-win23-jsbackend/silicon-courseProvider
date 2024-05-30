using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Drawing;

namespace silicon_courseProvider.Functions;

public class Playground
{
    private readonly ILogger<Playground> _logger;

    public Playground(ILogger<Playground> logger)
    {
        _logger = logger;
    }

    [Function("Playground")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "playground")] HttpRequestData req)
    {
        var res = req.CreateResponse();
        res.Headers.Add("Content-Type", "text/html; charset=utf-8");
        await res.WriteStringAsync(PlaygroundPage());
        return res;
    }

    private string PlaygroundPage()
    {
        return @"
        <!DOCTYPE html>
        <html lang=""en"">
        <head>
            <meta charset=""UTF-8"">
            <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
            <title>GraphQL Playground</title>
            <link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/npm/graphql-playground-react/build/static/css/index.css"" />
            <link rel=""shortcut icon"" href=""https://cdn.jsdelivr.net/npm/graphql-playground-react/build/favicon.png"" />
            <script src=""https://cdn.jsdelivr.net/npm/graphql-playground-react/build/static/js/middleware.js""></script>
        </head>
        <body>
            <div id=""root""></div>
            <script>
                window.addEventListener('load', function (event) {
                    const root = document.getElementById('root');
                    GraphQLPlayground.init(root, {
                        endpoint: '/api/graphql'
                    })
                })
            </script>
        </body>
        </html>";
    }
}
