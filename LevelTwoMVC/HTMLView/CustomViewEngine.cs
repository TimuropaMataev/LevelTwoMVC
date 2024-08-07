using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace LevelTwoMVC.HTMLView;

public class CustomViewEngine : IViewEngine
{
    /// <summary>
    /// Указывает что представление не найдено и ищет по имени
    /// в перегруженной вересии метода View
    /// </summary>
    /// <param name="file"></param>
    /// <param name="view"></param>
    /// <param name="isPage"></param>
    /// <returns>Возвращяет массив путей по которому шёл поиск</returns>
    public ViewEngineResult GetView(string? file, string view, bool isPage)
    {
        return ViewEngineResult.NotFound(view, new string[] { });
    }

    /// <summary>
    /// Ищет по контексту выполнения через строку запроса
    /// </summary>
    /// <param name="context"></param>
    /// <param name="view"></param>
    /// <param name="isPage"></param>
    /// <returns>Возвращяет ответ в зависимости от наличия представления</returns>
    public ViewEngineResult FindView(ActionContext context, string view, bool isPage)
    {
        string path = $"Views/{view}.html";

        if (string.IsNullOrEmpty(view))
            path = $"Views/{context.RouteData.Values["action"]}.html";

        if (File.Exists(path))
            return ViewEngineResult.Found(view, new CustomView(path));
        else
            return ViewEngineResult.NotFound(path, new string[] { path });
    }
}