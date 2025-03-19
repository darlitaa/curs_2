using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDirectoryBrowser();

var app = builder.Build();
var filePath = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Celebrities"));

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = filePath,

    //RequestPath = "/Photo",

    RequestPath = "/Celebrities/download",

    //OnPrepareResponse = ctx =>
    //{
    //    ctx.Context.Response.Headers.Append("Content-Disposition", "attachment");
    //}
});

app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = filePath,
    RequestPath = "/Celebrities/download" 
});

using (IRepository repository = Repository.Create(@"D:\curs_2\study_4_sem\ÒÏâÈ\lab\lab03\ASPA\ASPA003\Celebrities"))
{
    app.MapGet("/Celebrities", () => repository.GetAllCelebrities());
    app.MapGet("/Celebrities/{id:int}", (int id) => repository.GetCelebrityById(id));
    app.MapGet("/Celebrities/BySurname/{surname}", (string surname) => repository.GetCelebritiesBySurname(surname));
    app.MapGet("/Celebrities/PhotoPathById/{id:int}", (int id) => repository.GetPhotoPathById(id));
}

app.Run();