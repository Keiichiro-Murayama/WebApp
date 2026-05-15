using Microsoft.AspNetCore.Mvc;
using WebApp_Exercise.Views;

[Route("Option03")]

public class Op03Controller : Controller
{

    [HttpPost("Calc")]
    public IActionResult inputData(Opt03Form calc)
    {
        int? value1 = calc.Value1;
        int? value2 = calc.Value2;
        int? opt = calc.Opt;

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
        int? result;
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