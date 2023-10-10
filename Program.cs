using PatternPioneer.Factories;
using PatternPioneer.Services;
using PatternPioneer.Strategies.MessageBuilders;

namespace PatternPioneer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<MessageBuilderBase, OrderConfirmationMessageBuilder>();
            builder.Services.AddTransient<MessageBuilderBase, ProfileUpdateAlertMessageBuilder>();
            builder.Services.AddTransient<MessageBuilderBase, UserRegistrationMessageBuilder>();
            builder.Services.AddTransient<MessageBuilderBase, DefaultMessageBuilder>();

            builder.Services.AddTransient<MessageBuilderEngine>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}