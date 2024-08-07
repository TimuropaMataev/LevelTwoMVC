using LevelTwoMVC.HTMLView;
using Microsoft.AspNetCore.Mvc;

namespace LevelTwoMVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddMvc();

        // установка движка представления
        builder.Services.Configure<MvcViewOptions>(options =>
        {
            options.ViewEngines.Clear();
            options.ViewEngines.Insert(0, new CustomViewEngine());
        });

        var app = builder.Build();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}