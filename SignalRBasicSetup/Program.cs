
namespace SignalRBasicSetup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSignalR();
            builder.Services.AddSingleton<SignalR>();

            // Configure CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", configure =>
                {
                    configure.WithOrigins("http://localhost:5173") // Allowed origin
                        .AllowAnyHeader() // Allow any header
                        .AllowAnyMethod() // Allow any HTTP method
                        .AllowCredentials(); // Allow credentials (cookies, authorization headers)
                });
            });

            var app = builder.Build();            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            //app.UseAuthentication();
            app.UseAuthorization();
            
            app.MapHub<SignalR>("/signalRHub");

            app.MapControllers();

            app.Run();
        }
    }
}
