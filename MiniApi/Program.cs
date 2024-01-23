using Microsoft.AspNetCore.Mvc;
using MiniApi;
using System.Reflection.Metadata.Ecma335;
List<Article> articles = new List<Article>()
{
    new Article(1, "Marteau"),
    new Article(2, "Scie"),
    new Article(3, "Pointes"),


};
var builder = WebApplication.CreateBuilder();
var app = builder.Build();
app.MapGet("/get", () => "Bonjour Get");
app.MapPost("/post", () => "Bonjour Post");
app.MapPut("/put", () => "Bonjour put");
app.MapPatch("/patch", () => "Bonjour patch");
app.MapMethods("/methods", new[] { "GET", "POST", "PUT", "DELETE" }, () => "hello Methods");
app.MapGet("/article/1", () => new Article(1, "Portable"));

app.MapGet("/articles/{id:int}", (int id) =>
{
    var article = articles.Find(x => x.Id == id);
    if (article is not null) return Results.Ok(article);
    return Results.NotFound();
});
app.MapGet("/articles/{title}", (string title) => new Article(999, "Portable"));

app.MapGet("/personnes/{nom}",
          ([FromRoute] string nom,
          [FromQuery] string? prenom,
          [FromHeader(Name = "Accept-Encoding")] string encoding) =>
            Results.Ok($"{nom} {prenom} {encoding}"));

//app.MapGet("/personne/identite", (Personne p) => Results.Ok(p));

app.MapPost("/personne/identite", (Personne p) => Results.Ok(p));

app.Run();



