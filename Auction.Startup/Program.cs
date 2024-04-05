using Auction.Application;
using Auction.Infrastructure;
using AuctionApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApi();
builder.Services.AddApplication();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));


var app = builder.Build();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.Run();