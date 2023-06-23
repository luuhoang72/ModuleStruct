using Module.Invoices.API.Controllers;
using Module.Members.API.Controllers;
using Module.Orders.API.Controllers;
using ModuleStruct.Middlewares;

namespace ModuleStruct
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddHealthChecks();

            builder.Services
                .AddControllers()
                .AddControllers<InvoiceController>()
                .AddControllers<MemberController>()
                .AddControllers<OrderController>()
                ;

            builder.Services.AddBasesServices(builder.Configuration);
            builder.Services.AddOrdersServices(builder.Configuration);
            builder.Services.AddMembersServices(builder.Configuration);
            builder.Services.AddInvoicesServices(builder.Configuration);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.MapHealthChecks("/health");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<LastRequestTimeMiddleware>();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}