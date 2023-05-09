using CustomersApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(resp => resp.LowercaseUrls = true);
builder.Services.AddDbContext<CustomerDbContext>(resp =>
    {
        resp.UseMySQL("Server=sql10.freemysqlhosting.net;Database=sql10617111;Uid=sql10617111;Pwd=BmlJ7leIvm");
    }
);

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
