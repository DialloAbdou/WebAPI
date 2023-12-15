using MiniApi;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();
app.MapGet("/get", () => "Bonjour Get");
app.MapPost("/post", () => "Bonjour Post");
app.MapPut("/put", () => "Bonjour put");
app.MapPatch("/patch", () => "Bonjour patch");
app.MapGet("/articles/{id:int}", (int id) => new Article(id, "Marteau"));
app.MapGet("/articles/{titre}", (string titre) => new Article(9999, "Marteau"));

app.Run();



