using Microsoft.AspNetCore.Mvc;
/// <summary>
/// オプション演習０１ [FormQuery]属性を利用してクエリパラメータを受け取る
/// </summary>
[Route("Option01")]
public class Op01Controller : Controller
{
    /// <summary>
    /// リクエストパラメータを加算した結果を返す
    /// </summary>
    /// <param name="value1">加算対象</param>
    /// <param name="value2">加算対象</param>
    /// <returns>加算結果</returns>
    [HttpGet("Calc")]
    public IActionResult Calc([FromQuery] int value1 ,[FromQuery] int value2, [FromQuery] int opt)
    {
        // 演習-05 型変換エラーの場合、エラーメッセージを出力する
        /** 追加 **/
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