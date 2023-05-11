using CustomersApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(resp => resp.LowercaseUrls = true);
builder.Services.AddCors();
builder.Services.AddDbContext<CustomerDbContext>(resp =>
    {
        resp.UseMySQL(builder.Configuration.GetConnectionString("defaultConnection"));
    }
);

var app = builder.Build();

app.UseCors(op =>
{
    op.AllowAnyOrigin();
    op.AllowAnyMethod();
    op.AllowAnyHeader();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();