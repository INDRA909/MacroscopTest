using GrpcServer.gRPC;
using GrpcServer.Services;

Console.WriteLine("Enter the maximum number of requests simultaneously processed on the server");
int maxClientRequests = Convert.ToInt32(Console.ReadLine());

var builder = WebApplication.CreateBuilder();
builder.Services.AddGrpc(options =>
{
    options.Interceptors.Add(typeof(LimitClientRequests), maxClientRequests);
});


var app = builder.Build();
app.MapGrpcService<TextChecker>();
app.MapGet("/",
    () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
app.Run();
