namespace PatternPioneer;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        #region Decorator Pattern
        builder.Services
            .AddMemoryCache()
            .AddSingleton<SlowRepository>()
            .AddScoped<IRepository>(p =>
            {
                var memoryCache = p.GetRequiredService<IMemoryCache>();
                var slowRepository = p.GetRequiredService<SlowRepository>();
                return new CachedRepository(slowRepository, memoryCache);
            });
        #endregion

        builder.Services.AddMessageBuilders();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<MessageBuilderEngine>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

public static class Helper
{
    public static void AddMessageBuilders(this IServiceCollection services)
    {
        var assembly = Assembly.GetAssembly(typeof(MessageBuilderBase));
        if (assembly == null)
            throw new InvalidOperationException("Unable to load the assembly containing MessageBuilderBase.");

        var messageBuilderTypes = assembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(MessageBuilderBase)) && !t.IsAbstract)
            .OrderByDescending(t => t.Name)
            .ToList();

        if (!messageBuilderTypes.Any())
            throw new InvalidOperationException("No implementations of MessageBuilderBase were found.");

        foreach (var type in messageBuilderTypes)
        {
            services.AddTransient(typeof(MessageBuilderBase), type);
        }
    }
}