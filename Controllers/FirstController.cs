using System.IO;
using System.Linq;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        public string Index()
        {
            // lop controller co thể lấy được tất cả thông tin của request
            // this.HttpContext
            // this.Request
            // this.Response
            // this.RouteData

            // //Page Models
            // this.User
            // this.ModelState
            // this.ViewBag
            // this.ViewData
            // this.Url
            // this.TempData

            //LogLevel
            _logger.Log(LogLevel.Warning, "Thong bao aaa");
            _logger.LogError("Log Error");
            _logger.LogInformation("Index Action Logger");
            return "Trang First Index";
        }

        public IActionResult Readme()
        {
            var content = @"
            Xin chao cac ban,
            tang o tang


            O TANG
            ";
            return Content(content, "text/plain");
        }

        public IActionResult Cocacola()
        {
            string filePath = Path.Combine(Startup.ContentRootPath, "Files", "Cocacola.jpeg");
            var bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, "image/jpeg");
        }

        public IActionResult HelloFirst(string username)
        {
            if (string.IsNullOrEmpty(username)) username = "Khách";
            // View() -> Razor Engine, doc .cshtml (template)
            //-----------------------------------------------
            // View(template) - template là đường dẫn tuyệt đối .cshtml
            // View(template, model)
            // return View("MyView/Hello1.cshtml", username);
            // return View("Hello2", username);
            // return View((object)username);
            return View("Hello3", username);
        }

        [TempData]
        public string StatusMessage {get; set;}
        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if (product == null) 
            {
                StatusMessage = "Not found product";
                return Redirect(Url.Action("Index", "Home"));
            }
            //------Model------
            // return View(product);
            //------ViewData-----
            // ViewData["product"] = product;
            // ViewData["Title"] = product.Name;
            // return View("ViewProduct2");
            //------ViewBag-------
            ViewBag.product = product;
            return View("ViewProduct3");

        }

    // Kiểu trả về                 | Phương thức
    // ------------------------------------------------
    // ContentResult               | Content()
    // EmptyResult                 | new EmptyResult()
    // FileResult                  | File()
    // ForbidResult                | Forbid()
    // JsonResult                  | Json()
    // LocalRedirectResult         | LocalRedirect()
    // RedirectResult              | Redirect()
    // RedirectToActionResult      | RedirectToAction()
    // RedirectToPageResult        | RedirectToRoute()
    // RedirectToRouteResult       | RedirectToPage()
    // PartialViewResult           | PartialView()
    // ViewComponentResult         | ViewComponent()
    // StatusCodeResult            | StatusCode()
    // ViewResult                  | View()
    }
}