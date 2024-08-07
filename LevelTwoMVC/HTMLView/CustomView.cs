using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace LevelTwoMVC.HTMLView;

public class CustomView : IView
{
    public string Path { get; set; }

    public CustomView(string path) => Path = path;

    /// <summary>
    /// Считывание полученного файла передставления
    /// </summary>
    /// <param name="context"></param>
    /// <returns>Полученное из файла представление пишется в выходной поток</returns>
    public async Task RenderAsync(ViewContext context)
    {
        string content = "";
        using (StreamReader reader = new(Path))
        {
            content = await reader.ReadToEndAsync();
        }
        await context.Writer.WriteAsync(content);
    }
}