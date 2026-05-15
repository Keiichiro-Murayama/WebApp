using Microsoft.AspNetCore.Mvc;
/// <summary>
/// 演習-06 ルートパラメータを取得するコントローラを実装する
/// </summary>
[Route("Option02")]
public class Op02Controller : Controller
{
    /// <summary>
    /// ルートパラメータを加算した結果を返す
    /// </summary>
    /// <param name="value1">加算対象</param>
    /// <param name="value2">加算対象</param>
    /// <returns>加算結果</returns>
    [HttpGet("Calc/{value1}/{value2}/{opt}")]
    public IActionResult Calc(int value1, int value2, int opt)
    {
        if (! ModelState.IsValid) // 型変換エラー?
        {
            // value1とvalue2で型変換エラー
            if ((ModelState["value1"]?.Errors.Count ?? 0) > 0
            &&  (ModelState["value2"]?.Errors.Count ?? 0) > 0
            &&  (ModelState["opt"]?.Errors.Count ?? 0) >0)
            {
                return Content("value1とvalue2は整数ではありません。");
            }
            // value1で型変換エラー
            if ((ModelState["value1"]?.Errors.Count ?? 0) > 0)
            {
                return Content("value1は整数ではありません。");
            }
            // value2で型変換エラー
            if ((ModelState["value2"]?.Errors.Count ?? 0) > 0)
            {
                return Content("value2は整数ではありません。");
                // return View();
            }
            if ((ModelState["opt"]?.Errors.Count ?? 0) >0)
            {
                return Content("optは整数ではありません。");
            }
        }

        int result;
        switch (opt)
        {
            case 1:
                result = value1 + value2;
                return Content($"{value1} + {value2} = {result}");
            case 2:
                result = value1 - value2;
                return Content($"{value1} - {value2} = {result}");
            
            case 3:
                result = value1 * value2;
                return Content($"{value1} * {value2} = {result}");
            
            case 4:
                result = value1 / value2;
                return Content($"{value1} / {value2} = {result}");                
                        
            case 5:
                result = value1 % value2;
                return Content($"{value1} % {value2} = {result}");
            default:
                return Content("不明な計算種別です。");
        }
    }
}