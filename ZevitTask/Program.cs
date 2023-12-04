
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using ZevitTask.Application.comm;
using ZevitTask.Infrastructure.Out.Persistence.Repository;
using ZevitTask.Infrastructure.Out.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ContactService>();


builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"))
);

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
