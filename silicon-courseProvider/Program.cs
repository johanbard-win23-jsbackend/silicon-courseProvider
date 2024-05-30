using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using silicon_courseProvider.Infrastructure.Data.Contexts;
using silicon_courseProvider.Infrastructure.GraphQL.Mutations;
using silicon_courseProvider.Infrastructure.GraphQL.ObjectTypes;
using silicon_courseProvider.Infrastructure.GraphQL.Queries;
using silicon_courseProvider.Infrastructure.Services;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddPooledDbContextFactory<DataContext>(o =>
        {
            o.UseCosmos(Environment.GetEnvironmentVariable("SIL_COSMOS_URI")!, Environment.GetEnvironmentVariable("SIL_COSMOS_NAME")!)
            .UseLazyLoadingProxies();
        });

        services.AddScoped<ICourseService, CourseService>();

        services.AddGraphQLFunction()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>()
            .AddType<CourseType>();

        var sp = services.BuildServiceProvider();
        using var scope = sp.CreateScope();
        var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DataContext>>();
        using var context = dbContextFactory.CreateDbContext();
        context.Database.EnsureCreated();

    })
    .Build();

host.Run();
