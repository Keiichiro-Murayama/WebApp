using Microsoft.AspNetCore.Mvc;
/// <summary>
/// 演習-03 ルーティング属性を利用するコントローラを実装する
/// </summary>
[Route("Exercise03")]
public class Ex03Controller : Controller
{
    [HttpGet("Morning")]
    public IActionResult Goodmorning(){
        return Content("おはようございます。");
    }

    [HttpGet("Evening")]
    public IActionResult Goodevening(){
        return Content("こんばんは。");
    }
}