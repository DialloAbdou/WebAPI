using Microsoft.AspNetCore.Mvc;
using MiniApi;
using System.Reflection.Metadata.Ecma335;

List<Article> articles = new List<Article>()
{
    new Article(1, "Marteau"),
    new Article(2, "Scie"),

};
var builder = WebApplication.CreateBuilder();
var app = builder.Build();
app.MapGet("/get", () => "Bonjour Get");
app.MapPost("/post", () => "Bonjour Post");
app.MapPut("/put", () => "Bonjour put");
app.MapPatch("/patch", () => "Bonjour patch");
app.MapGet("/articles/{id:int}", (int id)=>
{
    var article = articles.Find(a=>a.Id == id);
    if (article is not null) return Results.Ok(article);
    return Results.BadRequest();
});
app.MapGet("/articles/{titre}", (string titre) => new Article(9999, "Marteau"));
//app.MapGet("/personnes/{nom}", ([FromRoute]string nom,
//                                [FromQuery] string? prenom,
//                                [FromHeader(Name= "Accept-Encoding")] string encoding)=> Results.Ok($"{nom},{prenom} {encoding}"));

//app.MapGet("/personne/indentite", (Personne p) => Results.Ok(p));
app.MapPost("/personne/identite", (Personne p) => Results.Ok(p));
app.Run();



