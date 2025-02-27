var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();

app.MapGet("/aspnetcore", () => "������, ASP.NET Core!");

app.MapGet("/", async context =>
{
    context.Response.Redirect("/Index.html");
});

app.MapGet("/ASPA002", async context =>
{
    context.Response.ContentType = "image/jpg";
    await context.Response.SendFileAsync("wwwroot/jpg/Neumann.jpg");
});

app.Run();